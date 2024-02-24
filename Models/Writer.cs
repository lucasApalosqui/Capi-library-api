namespace Capi_Library_Api.Models
{
    public class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Book> Books { get; set; }
    }
}
