using System.ComponentModel.DataAnnotations;

namespace Capi_Library_Api.ViewModels.Books
{
    public class CreateBookViewModel
    {
        [Required(ErrorMessage = "Titulo obrigatório")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Sinopse obrigatória")]
        public string Sinopsis { get; set; }

        [Required(ErrorMessage = "Páginas obrigatórias")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "Classificação indicativa obrigatória")]
        public string GeneralAud { get; set; }

        [Required(ErrorMessage = "Autor obrigatório")]
        public List<string> authors { get; set; } = new List<string>();

        [Required(ErrorMessage = "Categoria obrigatória")]
        public List<string> categories { get; set; } = new List<string>();
    }
}
