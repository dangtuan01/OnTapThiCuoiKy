using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnTapThiCuoiKy.Entities
{
    [Table("ShopProvider")]
    public class ShopProvider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdShop { get; set; }
        public Shop Shop { get; set; }
        public int IdProvider { get; set; }
        public Provider Provider { get; set; }
        public float FriendlyPoint { get; set; }

    }
}
