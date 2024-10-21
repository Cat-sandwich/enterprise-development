using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EnterpriseStatistics.Domain.Models;
using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Application.DTO;
using EnterpriseStatistics.Application;

namespace EnterpriseStatistics.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyController(IRepository<Supply, int> repository, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Вернуть все поставки
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Supply>> Get()
        {
            return Ok(repository.GetAll());
        }

        /// <summary>
        /// Вернуть поставку по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Supply> Get(int id)
        {
            var supply = repository.GetById(id);

            if (supply == null)
                return NotFound();

            return Ok(supply);
        }

        /// <summary>
        /// Добавить новую поставку
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] SupplyDto item)
        {
            Application.Mapper servise = new(mapper);
            var supply = servise.GetSupply(item);
            repository.Add(supply);
            return Ok();
        }

        /// <summary>
        /// Изменить поставку по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newItem"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SupplyDto newItem)
        {
            var supply = mapper.Map<Supply>(newItem);
            supply.Id = id;
            if (!repository.Update(supply, id))
                return NotFound();
            return Ok();
        }

        /// <summary>
        /// Удалить поставку по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!repository.Delete(id))
                return NotFound();
            return Ok();
        }
    }
}
