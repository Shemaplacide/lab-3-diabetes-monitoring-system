namespace DiabetesMonitoringSystem.Models
{
    public class User
    {
        public int Id { get; }
        public string FullName { get; }
        public string Role { get; }

        internal User(int id, string fullName, string role)
        {
            Id = id;
            FullName = fullName;
            Role = role;
        }
    }
}
