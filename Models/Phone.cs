namespace Capi_Library_Api.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }

        public User User { get; set; }
    }
}
