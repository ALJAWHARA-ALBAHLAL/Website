using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;

namespace Website.Models
{
    [Table("Orders", Schema = "Shop")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string status { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public Customer Customer { get; set; }

    }
}
