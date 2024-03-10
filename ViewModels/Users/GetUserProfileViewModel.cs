namespace Capi_Library_Api.ViewModels.Users
{
    public class GetUserProfileViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Role { get; set; }
        public string street { get; set; }
        public string Disctrict { get; set; }
        public string State { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public IList<string> phone { get; set; }
    }
}
