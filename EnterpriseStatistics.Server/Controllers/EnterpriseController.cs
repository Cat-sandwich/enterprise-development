using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EnterpriseStatistics.Domain.Models;
using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Application.DTO;
using System.Numerics;

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
    [HttpGet]
    public ActionResult<IEnumerable<Enterprise>> Get() => Ok(repository.GetAll());

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
    public ActionResult<Enterprise> Post([FromBody] EnterpriseDto item)
    {
        var enterprise = mapper.Map<Enterprise>(item);
        if (Enum.TryParse<IndustryTypes>(item.IndustryType, out var industryType))
        {
            enterprise.IndustryType = industryType;
        }
        else
        {
            NotFound("IndustryType not found");
        }
        if (Enum.TryParse<OwnershipForms>(item.OwnershipForm, out var ownershipForm))
        {
            enterprise.OwnershipForm = ownershipForm;
        }
        else
        {
            NotFound("OwnershipForm not found");
        }
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
    public ActionResult<Enterprise> Put(ulong mainStateRegistrationNumber, [FromBody] EnterpriseDto item)
    {
        var enterprise = mapper.Map<Enterprise>(item);
        if (Enum.TryParse<IndustryTypes>(item.IndustryType, out var industryType))
        {
            enterprise.IndustryType = industryType;
        }
        else
        {
            NotFound("IndustryType not found");
        }
        if (Enum.TryParse<OwnershipForms>(item.OwnershipForm, out var ownershipForm))
        {
            enterprise.OwnershipForm = ownershipForm;
        }
        else
        {
            NotFound("OwnershipForm not found");
        }
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
