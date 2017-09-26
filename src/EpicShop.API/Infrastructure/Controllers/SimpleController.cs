using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpicShop.API.Infrastructure.Controllers
{
    public class SimpleController<TService,TModel, TInputViewModel> : BaseController where TService : BaseService<TModel,TInputViewModel> where TModel : BaseModel where TInputViewModel : BaseViewModel
    {
        private readonly TService _service;

        public SimpleController(TService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var viewModel = _service.FindById(id);
            return Ok(viewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TInputViewModel value)
        {
            var viewModel = _service.Add(value);
            return Accepted(viewModel.Id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TInputViewModel value)
        {
            _service.Update(value, id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}