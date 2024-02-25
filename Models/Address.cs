namespace Capi_Library_Api.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Disctrict { get; set; }
        public string State { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }


    }
}
