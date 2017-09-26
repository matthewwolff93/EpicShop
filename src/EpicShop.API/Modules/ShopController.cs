using EpicShop.API.Infrastructure.Controllers;
using EpicShop.Core.Modules.Shop.Models;
using EpicShop.Core.Modules.Shop.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpicShop.API.Modules
{

    [Route("api/[controller]")]
    public class ShopController : BaseController
    {
        private readonly ShopService _shopService;

        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_shopService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var viewModel = _shopService.FindById(id);
            return Ok(viewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ShopInputViewModel value)
        {
            var viewModel = _shopService.Add(value);
            return Accepted(viewModel.Id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ShopInputViewModel value)
        {
            _shopService.Update(value, id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _shopService.Delete(id);
        }
    }
}
