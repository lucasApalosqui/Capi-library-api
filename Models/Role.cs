namespace Capi_Library_Api.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<User> Users { get; set; }
    }
}
