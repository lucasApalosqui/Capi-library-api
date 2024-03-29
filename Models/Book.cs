﻿namespace Capi_Library_Api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Sinopsis { get; set; }
        public int Pages { get; set; }
        public string GeneralAud {  get; set; }

        public Rental? Rental { get; set; }
        public IList<Writer> Writers { get; set; }
        public IList<Category> Categories { get; set; }
    }
}
