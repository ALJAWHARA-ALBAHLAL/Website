using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    [Table("Cuatomers", Schema ="Shop")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(200)")]
        public string FullName { get; set; }

    }
}