﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnTapThiCuoiKy.Dtos.Filters;
using OnTapThiCuoiKy.Dtos.ProviderDto;
using OnTapThiCuoiKy.Services.ProviderService.Interfaces;

namespace OnTapThiCuoiKy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;
        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }
        [HttpGet("get-all-paging")]
        public IActionResult GetAll([FromQuery] FilterDto input)
        {
            return Ok(_providerService.GetAll(input));
        }
        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _providerService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create")]
        public IActionResult Create(CreateProviderDto input)
        {
            try
            {
                _providerService.Create(input);
                return Ok("Thêm thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update")]
        public IActionResult Update(UpdateProviderDto input)
        {
            try
            {
                _providerService.Update(input);
                return Ok("Update thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _providerService.Delete(id);
                return Ok("Xóa thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
