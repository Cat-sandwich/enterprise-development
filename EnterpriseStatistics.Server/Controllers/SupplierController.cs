﻿using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EnterpriseStatistics.Domain.Models;
using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Application.DTO;

namespace EnterpriseStatistics.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController(IRepository<Supplier, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Вернуть всех поставщиков
    /// </summary>
    /// <returns>Список объектов <see cref="Supplier"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Поставщики не найдены</response>
    [HttpGet]
    public ActionResult<IEnumerable<Supplier>> Get()
    {
        var supplier = repository.GetAll();
        if (supplier == null) return NotFound();
        return Ok(); ;
    }

    /// <summary>
    /// Вернуть поставщика по id
    /// </summary>
    /// <param name="id">id возвращаемого объекта</param>
    /// <returns>Список объектов <see cref="Supplier"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Поставщик не найден</response>
    [HttpGet("{id}")]
    public ActionResult<Supplier> Get(int id)
    {
        var supplier = repository.GetById(id);

        if (supplier == null) return NotFound();

        return Ok(supplier);
    }

    /// <summary>
    /// Добавить нового поставщика
    /// </summary>
    /// <param name="item">Добавляемый объект</param>
    /// <returns>Созданный объект <see cref="Supplier"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    [HttpPost]
    public IActionResult Post([FromBody] SupplierDto item)
    {
        var supplier = mapper.Map<Supplier>(item);
        repository.Add(supplier);
        return Ok(supplier);
    }

    /// <summary>
    /// Изменить поставщика по id
    /// </summary>
    /// <param name="id">id изменяемого объекта</param>
    /// <param name="newItem">Изменяемый объект</param>
    /// <returns>Измененный объект <see cref="Supplier"/></returns>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Поставщик не найдеа</response>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SupplierDto newItem)
    {
        var supplier = mapper.Map<Supplier>(newItem);
        supplier.Id = id;
        if (!repository.Update(supplier, id)) return NotFound();
        return Ok(supplier);
    }

    /// <summary>
    /// Удалить поставщика по id
    /// </summary>
    /// <param name="id">id удаляемого объекта</param>
    /// <response code="200">Запрос выполнен успешно</response>
    /// <response code="404">Поставщик не найден</response>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}