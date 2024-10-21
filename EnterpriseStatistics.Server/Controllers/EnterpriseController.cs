using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EnterpriseStatistics.Domain.Models;
using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Application.DTO;

namespace EnterpriseStatistics.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseController(IRepository<Enterprise, ulong> repository, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Вернуть все предприятия
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Enterprise>> Get()
        {
            Application.Mapper servise = new(mapper);
            repository.GetAll().ForEach(e => servise.GetEnterpriseDto(e));
            return Ok(repository);
        }

        /// <summary>
        /// Вернуть предприятие по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Enterprise> Get(ulong id)
        {
            var enterprise = repository.GetById(id);

            if (enterprise == null)
                return NotFound();

            return Ok(enterprise);
        }

        /// <summary>
        /// Добавить новое предприятие
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] EnterpriseDto item)
        {
            Application.Mapper servise = new(mapper);
            var enterprise = servise.GetEnterprise(item);
            repository.Add(enterprise);
            return Ok();
        }

        /// <summary>
        /// Изменить предприятие по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(ulong id, [FromBody] EnterpriseDto item)
        {
            Application.Mapper servise = new(mapper);
            var enterprise = servise.GetEnterprise(item);
            enterprise.MainStateRegistrationNumber = id;
            if (!repository.Update(enterprise, id))
                return NotFound();
            return Ok();
        }

        /// <summary>
        /// Удалить предприятие по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            if (!repository.Delete(id))
                return NotFound();
            return Ok();
        }
    }
}
