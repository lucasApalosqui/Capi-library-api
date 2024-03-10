using System.ComponentModel.DataAnnotations;

namespace Capi_Library_Api.ViewModels.Accounts
{
    public class RegisterAccountViewModel
    {
        [Required(ErrorMessage = "Nome obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Cpf obrigatório")]
        public string Cpf {  get; set; }

    }
}
