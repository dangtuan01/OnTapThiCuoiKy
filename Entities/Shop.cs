using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnTapThiCuoiKy.Entities
{
    public class Shop
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
        public string OpenTime { get; set; }
        [Required]
        public string CloseTime { get; set; }
        public List<Provider> Provider { get; set; }
        public List<ShopProvider> ShopProvider { get; set; }
    }
}
