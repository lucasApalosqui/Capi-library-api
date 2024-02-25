namespace Capi_Library_Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Cpf { get; set; }

        public Role Role { get; set; }
        public Address Address { get; set; }

        public Rental? Rental { get; set; }

        public IList<Phone> Phones { get; set; }
    }
}
