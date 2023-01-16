using System.ComponentModel.DataAnnotations;

namespace Commerce.Application.Transfers.Requests
{
    public class UserRegisterRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(5, ErrorMessage = "O campo {0} deve ter ao menos 5 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(6, ErrorMessage = "O campo {0} deve ter ao menos 5 caracteres")]
        public string Password { get; set; }
    }
}
