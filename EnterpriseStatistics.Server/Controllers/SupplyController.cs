using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EnterpriseStatistics.Domain.Models;
using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Application.DTO;

namespace EnterpriseStatistics.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplyController(IRepository<Supply, int> supplyRepository,
        IRepository<Supplier, int> supplierRepository, IRepository<Enterprise, ulong> enterpriseRepository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Вернуть все поставки
    /// </summary>
    /// <returns>Список объектов <see cref="Supply"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Поставки не найдены</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Supply>>> Get() => Ok(await supplyRepository.GetAll());

    /// <summary>
    /// Вернуть поставку по id
    /// </summary>
    /// <param name="id">id возвращаемого объекта</param>
    /// <returns>Список объектов <see cref="Supply"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Поставка не найдена</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Supply>> Get(int id)
    {
        var supply = await supplyRepository.GetById(id);

        if (supply == null) return NotFound();
        return Ok(supply);
    }

    /// <summary>
    /// Добавить новую поставку
    /// </summary>
    /// <param name="item">Добавляемый объект</param>
    /// <returns>Созданный объект <see cref="Supply"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="400">Объекты не найдены</response>
    [HttpPost]
    public async Task<ActionResult<Supply>> Post([FromBody] SupplyDto item)
    {
        var supplier = await supplierRepository.GetById(item.IdSupplier);

        if (supplier == null)
            return NotFound("Поставщик не найден");

        var enterprise = await enterpriseRepository.GetById(item.MainStateRegistrationNumber);

        if (enterprise == null)
            return NotFound("Предприятие не найдено");

        var supply = mapper.Map<Supply>(item);

        supply.Supplier = supplier;
        supply.Enterprise = enterprise;

        await supplyRepository.Add(supply);
        return Ok(supply);
    }

    /// <summary>
    /// Изменить поставку по id
    /// </summary>
    /// <param name="id">id изменяемого объекта</param>
    /// <param name="item">Изменяемый объект</param>
    /// <returns>Измененный объект <see cref="Supply"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Поставка не найдена</response>
    [HttpPut("{id}")]
    public async Task<ActionResult<Supply>> Put(int id, [FromBody] SupplyDto item)
    {
        var supplier = await supplierRepository.GetById(item.IdSupplier);

        if (supplier == null)
            return NotFound("Поставщик не найден");

        var enterprise = await enterpriseRepository.GetById(item.MainStateRegistrationNumber);

        if (enterprise == null)
            return NotFound("Предприятие не найдено");

        var supply = mapper.Map<Supply>(item);

        supply.Supplier = supplier;
        supply.Enterprise = enterprise;

        if (!await supplyRepository.Update(supply, id))
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
    public async Task<IActionResult> Delete(int id)
    {
        if (!await supplyRepository.Delete(id)) return NotFound();
        return Ok();
    }
}
