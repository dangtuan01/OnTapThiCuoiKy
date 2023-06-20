using System.ComponentModel.DataAnnotations;

namespace OnTapThiCuoiKy.Dtos.ProviderDto
{
    public class CreateProviderDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
    }
}
