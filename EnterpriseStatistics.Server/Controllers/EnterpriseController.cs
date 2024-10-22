using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EnterpriseStatistics.Domain.Models;
using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Application.DTO;

namespace EnterpriseStatistics.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnterpriseController(IRepository<Enterprise, ulong> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Вернуть все предприятия
    /// </summary>
    /// <returns>Список объектов <see cref="EnterpriseDto"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Предприятия не найдены</response>
    [HttpGet]
    public ActionResult<IEnumerable<Enterprise>> Get()
    {
        Application.Mapper servise = new(mapper);
        var enterpriseDto = repository.GetAll()
            .Select(e => servise.GetEnterpriseDto(e)).ToList();

        if(enterpriseDto == null) return NotFound();
        return Ok(enterpriseDto);
    }

    /// <summary>
    /// Вернуть предприятие по ОГРН
    /// </summary>
    /// <param name="mainStateRegistrationNumber">ОГРН возвращаемого объекта</param>
    /// <returns>Список объектов <see cref="Enterprise"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Предприятие не найдено</response>
    [HttpGet("{mainStateRegistrationNumber}")]
    public ActionResult<Enterprise> Get(ulong mainStateRegistrationNumber)
    {
        var enterprise = repository.GetById(mainStateRegistrationNumber);

        if (enterprise == null)
            return NotFound();

        return Ok(enterprise);
    }

    /// <summary>
    /// Добавить новое предприятие
    /// </summary>
    /// <param name="item">Добавляемый объект</param>
    /// <returns>Созданный объект <see cref="Enterprise"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    [HttpPost]
    public IActionResult Post([FromBody] EnterpriseDto item)
    {
        Application.Mapper servise = new(mapper);
        var enterprise = servise.GetEnterprise(item);
        repository.Add(enterprise);
        return Ok(enterprise);
    }

    /// <summary>
    /// Изменить предприятие по ОГРН
    /// </summary>
    /// <param name="mainStateRegistrationNumber">ОГРН изменяемого объекта</param>
    /// <param name="item">Изменяемый объект</param>
    /// <returns>Измененный объект <see cref="Enterprise"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Предприятие не найдено</response>
    [HttpPut("{mainStateRegistrationNumber}")]
    public IActionResult Put(ulong mainStateRegistrationNumber, [FromBody] EnterpriseDto item)
    {
        Application.Mapper servise = new(mapper);
        var enterprise = servise.GetEnterprise(item);
        enterprise.MainStateRegistrationNumber = mainStateRegistrationNumber;
        if (!repository.Update(enterprise, mainStateRegistrationNumber))
            return NotFound();
        return Ok(enterprise);
    }

    /// <summary>
    /// Удалить предприятие по ОГРН
    /// </summary>
    /// <param name="mainStateRegistrationNumber">ОГРН удаляемого объекта</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Предприятие не найдено</response>
    [HttpDelete("{mainStateRegistrationNumber}")]
    public IActionResult Delete(ulong mainStateRegistrationNumber)
    {
        if (!repository.Delete(mainStateRegistrationNumber)) return NotFound();
        return Ok();
    }
}
