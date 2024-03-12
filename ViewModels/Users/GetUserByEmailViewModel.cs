namespace Capi_Library_Api.ViewModels.Users
{
    public class GetUserByEmailViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Role { get; set; }
        public string? street { get; set; }
        public string? Disctrict { get; set; }
        public string? State { get; set; }
        public int? Number { get; set; }
        public string? Complement { get; set; }
        public IList<string> phone { get; set; }

        public int? RentalId { get; set; }
        public string? book { get; set; }
        public DateTime? GetDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
