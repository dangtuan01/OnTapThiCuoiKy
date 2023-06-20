using System.ComponentModel.DataAnnotations;

namespace OnTapThiCuoiKy.Dtos.ShopDto
{
    public class ShopDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
       
        public string OpenTime { get; set; }
      
        public string CloseTime { get; set; }
    }
}
