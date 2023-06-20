using OnTapThiCuoiKy.Contexts;
using OnTapThiCuoiKy.Dtos.Filters;
using OnTapThiCuoiKy.Dtos.ProviderDto;
using OnTapThiCuoiKy.Services.ProviderService.Interfaces;

namespace OnTapThiCuoiKy.Services.ProviderService.Implements
{
    public class ProviderService : IProviderService
    {
        private readonly AppDbContext _context;

        public ProviderService(AppDbContext context)
        {
            _context = context;
        }

        public void Create(CreateProviderDto input)
        {
            var check = _context.Providers.FirstOrDefault(c => c.Name == input.Name);
            if (check != null)
            {
                throw new Exception("Ten da ton tai");
            }
            _context.Providers.Add(new Entities.Provider
            {
                Name = input.Name,
                Address = input.Address,
                PhoneNumber = input.PhoneNumber
            });
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var check = _context.Providers.FirstOrDefault(c => c.Id == id);
            if (check == null)
            {
                throw new Exception("Khong ton tai");
            }
            _context.Providers.Remove(check);
            _context.SaveChanges();
        }

        public ProviderDto GetById(int id)
        {
            var check = _context.Providers.FirstOrDefault(c => c.Id == id);
            if (check == null)
            {
                throw new Exception("Khong ton tai");
            }
            return new ProviderDto
            {
                Name = check.Name,
                Address = check.Address,
                PhoneNumber = check.PhoneNumber
                
            };
        }

        public PageResultDto<ProviderDto> GetAll(FilterDto input)
        {
            var query = _context.Providers.AsQueryable();
            query = query.Where(c => input.Keyword == null || c.Name.ToLower().Trim().Contains(input.Keyword));
            var totalItem = query.Count();
            var result = query.Skip((input.PageIndex - 1) * input.PageSize).Take(input.PageSize);
            var actual_result = result.Select(c => new ProviderDto
            {
                Name = c.Name,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber
            });
            return new PageResultDto<ProviderDto>
            {
                Item = actual_result,
                TotalItem = totalItem
            };
        }

        public void Update(UpdateProviderDto input)
        {
            var check = _context.Providers.FirstOrDefault(c => c.Id == input.Id);
            if (check == null)
            {
                throw new Exception("Khong ton tai");
            }
            check.Name = input.Name;
            check.Address = input.Address;
            check.PhoneNumber = input.PhoneNumber;
            _context.SaveChanges();
        }
    }
}
