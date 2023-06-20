using System.ComponentModel.DataAnnotations;

namespace OnTapThiCuoiKy.Dtos.ShopDto
{
    public class CreateShopDto
    {
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
    }
}
