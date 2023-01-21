using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Commerce.Application.Transfers.Requests
{
    public class CategoryRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MinLength(2, ErrorMessage = "The field {0} is required")]
        public string Name { get; set; }
    }
}
