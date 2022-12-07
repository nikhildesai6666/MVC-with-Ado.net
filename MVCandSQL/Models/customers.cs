using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDWithAdoNet.Models
{
    [Table("Customers")]
    public class customers
    {
        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [MaxLength(20)]

        public string? name { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [DataType(DataType.EmailAddress)]

        public string? email { get; set; }

        [Required(ErrorMessage ="Contact is required")]

        public string? contact { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]

        public string? password { get; set; }
    }
}
