namespace RentX.Domain
{
    public class User
    {
        public User(
            Guid id,
            string name,
            string password,
            string email,
            string driverLicense,
            bool admin,
            string avatar)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            DriverLicense = driverLicense;
            Admin = admin;
            Avatar = avatar;
        }

        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Password { get; protected set; }

        public string Email { get; protected set; }

        public string DriverLicense { get; protected set; }

        public bool Admin { get; protected set; }

        public string Avatar { get; protected set; }

    }
}
