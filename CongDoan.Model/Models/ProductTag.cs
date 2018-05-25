using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongDoan.Model.Models
{
    [Table("ProductTags")]
    public class ProductTag
    {
        [Key]
        [Column(TypeName = "varchar", Order = 1)]
        [MaxLength(50)]
        public string TagID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductID { get; set; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}