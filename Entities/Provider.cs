using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnTapThiCuoiKy.Entities
{
    [Table("Provider")]
    public class Provider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        public List<Shop> Shop { get; set; }
        public List<ShopProvider> ShopProvider { get; set; }

    }
}
