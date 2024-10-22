using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EnterpriseStatistics.Domain.Models;
using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Application.DTO;

namespace EnterpriseStatistics.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplyController(IRepository<Supply, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Вернуть все поставки
    /// </summary>
    /// <returns>Список объектов <see cref="Supply"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Поставки не найдены</response>
    [HttpGet]
    public ActionResult<IEnumerable<Supply>> Get()
    {
        var supply = repository.GetAll();
        if (supply == null) return NotFound();
        return Ok();
    }

    /// <summary>
    /// Вернуть поставку по id
    /// </summary>
    /// <param name="id">id возвращаемого объекта</param>
    /// <returns>Список объектов <see cref="Supply"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Поставка не найдена</response>
    [HttpGet("{id}")]
    public ActionResult<Supply> Get(int id)
    {
        var supply = repository.GetById(id);

        if (supply == null) return NotFound();
        return Ok(supply);
    }

    /// <summary>
    /// Добавить новую поставку
    /// </summary>
    /// <param name="item">Добавляемый объект</param>
    /// <returns>Созданный объект <see cref="Supply"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    [HttpPost]
    public IActionResult Post([FromBody] SupplyDto item)
    {
        Application.Mapper servise = new(mapper);
        var supply = servise.GetSupply(item);
        repository.Add(supply);
        return Ok(supply);
    }

    /// <summary>
    /// Изменить поставку по id
    /// </summary>
    /// <param name="id">id изменяемого объекта</param>
    /// <param name="newItem">Изменяемый объект</param>
    /// <returns>Измененный объект <see cref="Supply"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Поставка не найдена</response>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SupplyDto newItem)
    {
        var supply = mapper.Map<Supply>(newItem);
        supply.Id = id;
        if (!repository.Update(supply, id))
            return NotFound();
        return Ok(supply);
    }

    /// <summary>
    /// Удалить поставку по id
    /// </summary>
    /// <param name="id">id удаляемого объекта</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Поставка не найдена</response>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}
