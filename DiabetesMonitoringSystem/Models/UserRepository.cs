using System.Data;

namespace DiabetesMonitoringSystem.Models
{
    internal class UserRepository
    {
        private readonly Database database = new Database();

        public DataTable FindActive(string username)
        {
            return database.Read(@"SELECT UserId, FullName, `Role`, PasswordHash, PasswordSalt,
                PasswordIterations FROM Users WHERE Username = @username AND IsActive = 1",
                "@username", username);
        }

        public int Create(string name, string username, string role, byte[] hash, byte[] salt, int rounds, int adminId)
        {
            return database.Write(@"INSERT INTO Users
                (FullName, Username, `Role`, PasswordHash, PasswordSalt, PasswordIterations)
                SELECT @name, @username, @role, @hash, @salt, @rounds FROM DUAL
                WHERE (@admin = 0 AND @role = 'Patient') OR EXISTS
                (SELECT 1 FROM Users WHERE UserId = @admin AND `Role` = 'Admin' AND IsActive = 1)",
                "@name", name, "@username", username, "@role", role,
                "@hash", hash, "@salt", salt, "@rounds", rounds, "@admin", adminId);
        }

        public DataTable List(int adminId, string role = "", bool activeOnly = false)
        {
            return database.Read(@"SELECT UserId, FullName, Username, `Role`, IsActive
                FROM Users WHERE `Role` IN ('Patient','Doctor')
                AND (@role = '' OR `Role` = @role) AND (@active = 0 OR IsActive = 1)
                AND EXISTS (SELECT 1 FROM Users WHERE UserId = @admin AND `Role` = 'Admin' AND IsActive = 1)
                ORDER BY FullName, UserId", "@admin", adminId, "@role", role, "@active", activeOnly);
        }

        public int Update(int adminId, int id, string name, string username)
        {
            return database.Write(@"UPDATE Users SET FullName = @name, Username = @username
                WHERE UserId = @id AND `Role` IN ('Patient','Doctor')
                AND EXISTS (SELECT 1 FROM Users WHERE UserId = @admin AND `Role` = 'Admin' AND IsActive = 1)",
                "@name", name, "@username", username, "@id", id, "@admin", adminId);
        }

        public int Deactivate(int adminId, int id)
        {
            return database.Write(@"UPDATE Users SET IsActive = 0
                WHERE UserId = @id AND `Role` IN ('Patient','Doctor') AND IsActive = 1
                AND EXISTS (SELECT 1 FROM Users WHERE UserId = @admin AND `Role` = 'Admin' AND IsActive = 1)",
                "@id", id, "@admin", adminId);
        }

        public DataTable Assignments(int adminId)
        {
            return database.Read(@"SELECT p.FullName AS Patient, d.FullName AS Doctor, d.IsActive AS DoctorActive
                FROM PatientAssignments a JOIN Users p ON a.PatientId = p.UserId
                JOIN Users d ON a.DoctorId = d.UserId
                WHERE EXISTS (SELECT 1 FROM Users WHERE UserId = @admin AND `Role` = 'Admin' AND IsActive = 1)
                ORDER BY p.FullName", "@admin", adminId);
        }

        public int Assign(int adminId, int patientId, int doctorId)
        {
            return database.Write(@"INSERT INTO PatientAssignments (PatientId, DoctorId)
                SELECT @patient, @doctor FROM DUAL
                WHERE EXISTS (SELECT 1 FROM Users WHERE UserId = @admin AND `Role` = 'Admin' AND IsActive = 1)
                  AND EXISTS (SELECT 1 FROM Users WHERE UserId = @doctor AND `Role` = 'Doctor' AND IsActive = 1)
                  AND EXISTS (SELECT 1 FROM Users WHERE UserId = @patient AND `Role` = 'Patient')
                ON DUPLICATE KEY UPDATE DoctorId = @doctor",
                "@admin", adminId, "@patient", patientId, "@doctor", doctorId);
        }
    }
}
