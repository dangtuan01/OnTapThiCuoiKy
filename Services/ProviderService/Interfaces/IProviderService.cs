using OnTapThiCuoiKy.Dtos.Filters;
using OnTapThiCuoiKy.Dtos.ProviderDto;
using OnTapThiCuoiKy.Dtos.ShopDto;

namespace OnTapThiCuoiKy.Services.ProviderService.Interfaces
{
    public interface IProviderService
    {
        public void Create(CreateProviderDto input);

        public void Update(UpdateProviderDto input);
        public void Delete(int id);
        public ProviderDto GetById(int id);
        public PageResultDto<ProviderDto> GetAll(FilterDto input);
    }
}
