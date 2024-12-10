﻿using Microsoft.AspNetCore.Mvc;
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
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Enterprise>>> Get() => Ok(await repository.GetAll());

    /// <summary>
    /// Вернуть предприятие по ОГРН
    /// </summary>
    /// <param name="mainStateRegistrationNumber">ОГРН возвращаемого объекта</param>
    /// <returns>Список объектов <see cref="Enterprise"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Предприятие не найдено</response>
    [HttpGet("{mainStateRegistrationNumber}")]
    public async Task<ActionResult<Enterprise>> Get(ulong mainStateRegistrationNumber)
    {
        var enterprise = await repository.GetById(mainStateRegistrationNumber);

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
    public async Task<ActionResult<Enterprise>> Post([FromBody] EnterpriseDto item)
    {
        if(item.MainStateRegistrationNumber < 1000000000000 || item.MainStateRegistrationNumber > 10000000000000)
            return BadRequest("ОГРН должен содержать 13 цифр");
        if (string.IsNullOrWhiteSpace(item.Name))
            return BadRequest("Название обязательно для заполнения");
        if (string.IsNullOrWhiteSpace(item.Address))
            return BadRequest("Адрес обязателен к заполнению");
        if (string.IsNullOrWhiteSpace(item.Phone))
            return BadRequest("Телефон обязателен к заполнению");
        if (item.EmployeeCount <= 0)
            return BadRequest("Количество сотрудников должно быть больше 0");
        if (item.TotalArea <= 0)
            return BadRequest("Общая площадь должна быть больше 0");

        var enterprise = mapper.Map<Enterprise>(item);
        await repository.Add(enterprise);
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
    public async Task<ActionResult<Enterprise>> Put(ulong mainStateRegistrationNumber, [FromBody] EnterpriseDto item)
    {
        if (item.MainStateRegistrationNumber < 1000000000000 || item.MainStateRegistrationNumber > 10000000000000)
            return BadRequest("ОГРН должен содержать 13 цифр");
        if (string.IsNullOrWhiteSpace(item.Name))
            return BadRequest("Название обязательно для заполнения");
        if (string.IsNullOrWhiteSpace(item.Address))
            return BadRequest("Адрес обязателен к заполнению");
        if (string.IsNullOrWhiteSpace(item.Phone))
            return BadRequest("Телефон обязателен к заполнению");
        if (item.EmployeeCount <= 0)
            return BadRequest("Количество сотрудников должно быть больше 0");
        if (item.TotalArea <= 0)
            return BadRequest("Общая площадь должна быть больше 0");

        var enterprise = mapper.Map<Enterprise>(item);
        if (!await repository.Update(enterprise, mainStateRegistrationNumber))
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
    public async Task<IActionResult> Delete(ulong mainStateRegistrationNumber)
    {
        if (!await repository.Delete(mainStateRegistrationNumber)) return NotFound();
        return Ok();
    }
}
