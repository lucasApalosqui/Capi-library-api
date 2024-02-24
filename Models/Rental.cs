namespace Capi_Library_Api.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public Book BookRent { get; set; }
        public User UserRent { get; set; }
        public DateTime GetDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
