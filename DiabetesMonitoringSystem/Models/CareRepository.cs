using System;
using System.Data;

namespace DiabetesMonitoringSystem.Models
{
    internal class CareRepository
    {
        private readonly Database database = new Database();
        private const string PatientAccess = @"@user = @patient AND EXISTS
            (SELECT 1 FROM Users WHERE UserId = @user AND `Role` = 'Patient' AND IsActive = 1)";
        private const string DoctorAccess = @"EXISTS
            (SELECT 1 FROM PatientAssignments a JOIN Users d ON d.UserId = a.DoctorId
             WHERE a.PatientId = @patient AND a.DoctorId = @user AND d.`Role` = 'Doctor' AND d.IsActive = 1)";

        public DataTable Patients(int doctorId)
        {
            return database.Read(@"SELECT p.UserId, p.FullName, p.Username
                FROM PatientAssignments a JOIN Users p ON p.UserId = a.PatientId
                JOIN Users d ON d.UserId = a.DoctorId
                WHERE a.DoctorId = @user AND d.`Role` = 'Doctor' AND d.IsActive = 1
                ORDER BY p.FullName, p.UserId", "@user", doctorId);
        }

        public int Record(int patientId, decimal value, DateTime measuredAt)
        {
            return database.Write(@"INSERT INTO GlucoseReadings (PatientId, GlucoseValue, MeasuredAt)
                SELECT @patient, @value, @time FROM DUAL WHERE " + PatientAccess,
                "@user", patientId, "@patient", patientId, "@value", value, "@time", measuredAt);
        }

        public DataTable History(int userId, int patientId, bool doctor, DateTime? from, DateTime? until)
        {
            string access = doctor ? DoctorAccess : PatientAccess;
            EnsureAccess(access, userId, patientId);
            string sql = @"SELECT MeasuredAt AS `Measured at`, GlucoseValue AS `Reading`, 'mg/dL' AS Unit
                FROM GlucoseReadings WHERE PatientId = @patient AND (" + access + ")";
            if (from.HasValue && until.HasValue)
            {
                sql += " AND MeasuredAt >= @from AND MeasuredAt < @until ORDER BY MeasuredAt DESC, ReadingId DESC";
                return database.Read(sql, "@user", userId, "@patient", patientId, "@from", from.Value, "@until", until.Value);
            }

            return database.Read(sql + " ORDER BY MeasuredAt DESC, ReadingId DESC", "@user", userId, "@patient", patientId);
        }

        public DataTable Appointments(int userId, int patientId, bool doctor)
        {
            string access = doctor ? DoctorAccess : PatientAccess;
            EnsureAccess(access, userId, patientId);
            return database.Read(@"SELECT AppointmentId, AppointmentAt AS `Date and time`, Status FROM Appointments
                WHERE PatientId = @patient AND (" + access +
                ") ORDER BY AppointmentAt, AppointmentId", "@user", userId, "@patient", patientId);
        }

        private void EnsureAccess(string condition, int userId, int patientId)
        {
            DataTable result = database.Read("SELECT 1 FROM DUAL WHERE " + condition,
                "@user", userId, "@patient", patientId);
            if (result.Rows.Count == 0)
                throw new UnauthorizedAccessException("You do not have access to these records.");
        }

        public int Schedule(int doctorId, int patientId, DateTime appointmentAt)
        {
            return database.Write(@"INSERT INTO Appointments (PatientId, AppointmentAt)
                SELECT @patient, @time FROM DUAL WHERE " + DoctorAccess + @"
                AND EXISTS (SELECT 1 FROM Users WHERE UserId = @patient AND `Role` = 'Patient' AND IsActive = 1)",
                "@user", doctorId, "@patient", patientId, "@time", appointmentAt);
        }

        public int Reschedule(int doctorId, int patientId, int appointmentId, DateTime appointmentAt)
        {
            return database.Write(@"UPDATE Appointments SET AppointmentAt = @time
                WHERE AppointmentId = @id AND PatientId = @patient AND Status = 'Scheduled' AND " + DoctorAccess,
                "@user", doctorId, "@patient", patientId, "@id", appointmentId, "@time", appointmentAt);
        }

        public int Cancel(int doctorId, int patientId, int appointmentId)
        {
            return database.Write(@"UPDATE Appointments SET Status = 'Cancelled'
                WHERE AppointmentId = @id AND PatientId = @patient AND Status = 'Scheduled' AND " + DoctorAccess,
                "@user", doctorId, "@patient", patientId, "@id", appointmentId);
        }
    }
}
