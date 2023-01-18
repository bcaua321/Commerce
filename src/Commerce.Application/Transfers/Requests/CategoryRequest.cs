using System.ComponentModel.DataAnnotations;

namespace Commerce.Application.Transfers.Requests
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [MinLength(2, ErrorMessage = "The field {0} is required")]
        string Name { get; set; }
    }
}
