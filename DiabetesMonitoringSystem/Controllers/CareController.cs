using System;
using System.Data;
using DiabetesMonitoringSystem.Models;

namespace DiabetesMonitoringSystem.Controllers
{
    public class CareController
    {
        private readonly CareRepository care = new CareRepository();

        public DataTable Patients(User user)
        {
            RequireDoctor(user);
            return care.Patients(user.Id);
        }

        public void Record(User user, string text, DateTime when)
        {
            if (user.Role != "Patient") throw new UnauthorizedAccessException("Only a patient can record readings.");
            decimal value;
            if (!decimal.TryParse(text, out value) || value <= 0 || value > 999999999.999m ||
                decimal.Round(value, 3) != value)
                throw new ArgumentException("Enter a positive reading in mg/dL with up to 3 decimal places.");

            CheckSaved(care.Record(user.Id, value, when));
        }

        public DataTable History(User user, int patientId, DateTime? from, DateTime? to)
        {
            bool doctor = CheckPatientAccess(user, patientId);
            if (from.HasValue != to.HasValue ||
                (from.HasValue && (from.Value.Date > to.Value.Date || to.Value.Date == DateTime.MaxValue.Date)))
                throw new ArgumentException("Choose a valid start and end date.");

            return care.History(user.Id, patientId, doctor, from?.Date, to?.Date.AddDays(1));
        }

        public DataTable Appointments(User user, int patientId)
        {
            bool doctor = CheckPatientAccess(user, patientId);
            return care.Appointments(user.Id, patientId, doctor);
        }

        public void Schedule(User user, int patientId, DateTime when)
        {
            RequireDoctor(user);
            CheckSaved(care.Schedule(user.Id, patientId, when));
        }

        public void Reschedule(User user, int patientId, int appointmentId, DateTime when)
        {
            RequireDoctor(user);
            CheckSaved(care.Reschedule(user.Id, patientId, appointmentId, when));
        }

        public void Cancel(User user, int patientId, int appointmentId)
        {
            RequireDoctor(user);
            CheckSaved(care.Cancel(user.Id, patientId, appointmentId));
        }

        private bool CheckPatientAccess(User user, int patientId)
        {
            if (user.Role == "Patient" && user.Id == patientId) return false;
            RequireDoctor(user);
            return true;
        }

        private void RequireDoctor(User user)
        {
            if (user.Role != "Doctor") throw new UnauthorizedAccessException("Only an assigned doctor can do this.");
        }

        private void CheckSaved(int rows)
        {
            if (rows <= 0) throw new InvalidOperationException("The change was not saved. Check the account, assignment or appointment status.");
        }
    }
}
