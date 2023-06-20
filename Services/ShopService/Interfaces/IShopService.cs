using OnTapThiCuoiKy.Dtos.Filters;
using OnTapThiCuoiKy.Dtos.ShopDto;

namespace OnTapThiCuoiKy.Services.ShopService.Interfaces
{
    public interface IShopService
    {
        public void Create(CreateShopDto input);

        public void Update(UpdateShopDto input);   
        public void Delete(int id);
        public ShopDto GetById(int id);
        public PageResultDto<ShopDto> GetPage(FilterDto input);

    }
}
