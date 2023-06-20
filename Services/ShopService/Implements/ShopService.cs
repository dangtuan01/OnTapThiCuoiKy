using OnTapThiCuoiKy.Contexts;
using OnTapThiCuoiKy.Dtos.Filters;
using OnTapThiCuoiKy.Dtos.ShopDto;
using OnTapThiCuoiKy.Services.ShopService.Interfaces;

namespace OnTapThiCuoiKy.Services.ShopService.Implements
{
    public class ShopService : IShopService
    {
        private readonly AppDbContext _context;

        public ShopService(AppDbContext context)
        {
            _context = context;
        }

        public void Create(CreateShopDto input)
        {
            var check = _context.Shops.FirstOrDefault(c => c.Name == input.Name);
            if(check != null)
            {
                throw new Exception("Ten da ton tai");
            }
            _context.Shops.Add(new Entities.Shop
            {
                Name = input.Name,
                Address = input.Address,
                OpenTime = input.OpenTime,
                CloseTime = input.CloseTime,
            });
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var check = _context.Shops.FirstOrDefault(c => c.Id == id);
            if(check == null)
            {
                throw new Exception("Khong ton tai");
            }
            _context.Shops.Remove(check);
            _context.SaveChanges();
        }

        public ShopDto GetById(int id)
        {
            var check = _context.Shops.FirstOrDefault(c => c.Id == id);
            if (check == null)
            {
                throw new Exception("Khong ton tai");
            }
            return new ShopDto
            {
                Name = check.Name,
                Address = check.Address,
                OpenTime = check.OpenTime,
                CloseTime = check.CloseTime,
            };
        }

        public PageResultDto<ShopDto> GetPage(FilterDto input)
        {
            var query = _context.Shops.AsQueryable();
            query = query.Where(c => input.Keyword == null || c.Name.ToLower().Trim().Contains(input.Keyword));
            var totalItem = query.Count();
            var result = query.Skip((input.PageIndex - 1) * input.PageSize).Take(input.PageSize);
            var actual_result = result.Select(c => new ShopDto
            {
                Name = c.Name,
                Address = c.Address,
                OpenTime = c.OpenTime,
                CloseTime = c.CloseTime,
            });
            return new PageResultDto<ShopDto>
            {
                Item = actual_result,
                TotalItem = totalItem
            };  
        }

        public void Update(UpdateShopDto input)
        {
            var check = _context.Shops.FirstOrDefault(c => c.Id == input.Id);
            if (check == null)
            {
                throw new Exception("Khong ton tai");
            }
            check.Name = input.Name;
            check.Address = input.Address;
            check.OpenTime = input.OpenTime;
            check.CloseTime = input.CloseTime;
            _context.SaveChanges();
        }
    }
}
