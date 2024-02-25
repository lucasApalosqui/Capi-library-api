namespace Capi_Library_Api.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public Book RentalBook { get; set; }
        public User Rentaluser { get; set; }
        public DateTime GetDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
