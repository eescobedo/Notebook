using System.ComponentModel.DataAnnotations;

namespace CrudNotebook.Models
{
    public class ModelContact
    {
        public int IdContact { get; set; }

        [Required(ErrorMessage = "The field Name is required!")]
        public string? Name { get; set; }
        
        [Required (ErrorMessage = "The field Phone is required!")]
        public string? Phone { get; set; }
        
        [Required (ErrorMessage="The field Email is required!")]
        public string? Email { get; set; }
        
    }
}
