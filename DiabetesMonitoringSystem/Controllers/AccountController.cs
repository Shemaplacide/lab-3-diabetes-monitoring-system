using System;
using System.Data;
using MySqlConnector;
using System.Security.Cryptography;
using DiabetesMonitoringSystem.Models;

namespace DiabetesMonitoringSystem.Controllers
{
    public class AccountController
    {
        private readonly UserRepository users = new UserRepository();
        private const int Iterations = 600000;

        public User Login(string username, string password)
        {
            DataTable result = users.FindActive(username.Trim());
            if (result.Rows.Count == 0) return null;

            DataRow row = result.Rows[0];
            byte[] saved = (byte[])row["PasswordHash"];
            byte[] entered = HashPassword(password, (byte[])row["PasswordSalt"], (int)row["PasswordIterations"]);
            int difference = 0;
            for (int index = 0; index < saved.Length; index++)
                difference |= saved[index] ^ entered[index];

            if (difference != 0) return null;
            return new User((int)row["UserId"], (string)row["FullName"], (string)row["Role"]);
        }

        public void Register(string name, string username, string password)
        {
            Create(0, name, username, "Patient", password);
        }

        public void CreateAccount(User admin, string name, string username, string role, string password)
        {
            RequireAdmin(admin);
            if (role != "Doctor" && role != "Patient") throw new ArgumentException("Select Patient or Doctor.");
            Create(admin.Id, name, username, role, password);
        }

        public DataTable Accounts(User admin, string role = "", bool activeOnly = false)
        {
            RequireAdmin(admin);
            return users.List(admin.Id, role, activeOnly);
        }

        public void Update(User admin, int id, string name, string username)
        {
            RequireAdmin(admin);
            ValidateIdentity(name, username);
            try
            {
                CheckSaved(users.Update(admin.Id, id, name.Trim(), username.Trim()));
            }
            catch (MySqlException error) when (error.Number == 1062)
            {
                throw new ArgumentException("That username is already taken.");
            }
        }

        public void Deactivate(User admin, int id)
        {
            RequireAdmin(admin);
            CheckSaved(users.Deactivate(admin.Id, id));
        }

        public DataTable Assignments(User admin)
        {
            RequireAdmin(admin);
            return users.Assignments(admin.Id);
        }

        public void Assign(User admin, int patientId, int doctorId)
        {
            RequireAdmin(admin);
            CheckSaved(users.Assign(admin.Id, patientId, doctorId));
        }

        private void Create(int adminId, string name, string username, string role, string password)
        {
            ValidateIdentity(name, username);
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8 || password.Length > 128)
                throw new ArgumentException("Use a password of 8 to 128 characters.");

            byte[] salt = new byte[16];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
                random.GetBytes(salt);

            try
            {
                CheckSaved(users.Create(name.Trim(), username.Trim(), role,
                    HashPassword(password, salt, Iterations), salt, Iterations, adminId));
            }
            catch (MySqlException error) when (error.Number == 1062)
            {
                throw new ArgumentException("That username is already taken.");
            }
        }

        private static byte[] HashPassword(string password, byte[] salt, int rounds)
        {
            using (Rfc2898DeriveBytes hash = new Rfc2898DeriveBytes(password, salt, rounds, HashAlgorithmName.SHA256))
                return hash.GetBytes(32);
        }

        private static void ValidateIdentity(string name, string username)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Trim().Length > 100)
                throw new ArgumentException("Enter a full name of up to 100 characters.");
            if (string.IsNullOrWhiteSpace(username) || username.Trim().Length > 50)
                throw new ArgumentException("Enter a username of up to 50 characters.");
        }

        private static void RequireAdmin(User user)
        {
            if (user == null || user.Role != "Admin")
                throw new UnauthorizedAccessException("Only an administrator can do this.");
        }

        private static void CheckSaved(int rows)
        {
            if (rows <= 0) throw new InvalidOperationException("The change could not be saved. Refresh and try again.");
        }
    }
}
