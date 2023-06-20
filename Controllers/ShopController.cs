using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnTapThiCuoiKy.Dtos.Filters;
using OnTapThiCuoiKy.Dtos.ShopDto;
using OnTapThiCuoiKy.Services.ShopService.Interfaces;

namespace OnTapThiCuoiKy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        [HttpGet("get-all")]
        public IActionResult GetAll(FilterDto input)
        {
            return Ok(_shopService.GetPage(input));
        }
        [HttpPost("create")]
        public IActionResult Create(CreateShopDto input)
        {
            try
            {
                _shopService.Create(input);
                return Ok("Them thanh cong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update")]
        public IActionResult Update(UpdateShopDto input)
        {
            try
            {
                _shopService.Update(input);
                return Ok("Them thanh cong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-by-id")]
        public IActionResult getById(int id)
        {
            try
            {
                var result = _shopService.GetById(id);
                return Ok("Xoa thanh cong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-by-id")]
        public IActionResult Delete(int id)
        {
            try
            {
                _shopService.Delete(id);
                return Ok("Xóa thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
