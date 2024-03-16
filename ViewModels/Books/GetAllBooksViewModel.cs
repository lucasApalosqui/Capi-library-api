namespace Capi_Library_Api.ViewModels.Books
{
    public class GetAllBooksViewModel
    {
        public string Title { get; set; }
        public string Sinopsis { get; set; }
        public int Pages { get; set; }
        public string GeneralAud { get; set; }
        public List<string> Authors { get; set; } = new List<string>();
        public List<string> Categories { get; set; } = new List<string>();

    }
}
