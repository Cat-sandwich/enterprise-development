using EnterpriseStatistics.Application.DTO;
using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseStatistics.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QueryController(IRepository<Supply, int> supplyRepository, IRepository<Enterprise, ulong> enterpriseRepository) : ControllerBase
{
    /// <summary>
    /// Все сведения о конкретном предприятии.
    /// </summary>
    /// <param name="mainStateRegistrationNumber">ОГРН конкретного предприятия</param>
    /// <returns>Объект <see cref="Enterprise"/></returns>
    [HttpGet("info_specific_enterprise")]
    public ActionResult<IEnumerable<Enterprise>> InfoSpecificEnterprise(ulong mainStateRegistrationNumber)
    {
        var specificEnterprise = enterpriseRepository.GetAll()
        .Where(e => e.MainStateRegistrationNumber == mainStateRegistrationNumber);

        return Ok(specificEnterprise);
    }

    /// <summary>
    /// Все поставщики, поставившие сырье за заданный период, упорядочить по названию.
    /// </summary>
    /// <param name="startDate">Дата начала периода</param>
    /// <param name="endDate">Дата окончания периода</param>
    /// <returns>Список <see cref="Supplier"/></returns>
    [HttpGet("info_supplier_by_date")]
    public ActionResult<IEnumerable<Supplier>> InfoSupplierDate(DateTime startDate, DateTime endDate)
    {
        var supplierDate = supplyRepository.GetAll()
            .Where(supply => supply.Date >= startDate && supply.Date <= endDate)
            .Select(supply => supply.Supplier)
            .Distinct()
            .OrderBy(supplier => supplier.FullName)
            .ToList();
        return Ok(supplierDate);
    }

    /// <summary>
    /// Количество предприятий, с которыми работает каждый поставщик.
    /// </summary>
    /// <returns>Список <see cref="EnterpriseCountsDto"/></returns>
    [HttpGet("count_enterprise")]
    public ActionResult<IEnumerable<EnterpriseCountsDto>> CountEnterprise()
    {
        var supplierEnterpriseCounts = supplyRepository.GetAll()
       .GroupBy(supply => supply.Supplier).Distinct()
       .Select(supplier => new
       {
           SupplierId = supplier.Key.Id,
           supplier.Key.FullName,
           EnterpriseCount = supplier.Select(s => s.Enterprise.MainStateRegistrationNumber).Distinct().Count()
       }).ToList();

       return Ok(supplierEnterpriseCounts);
    }

    /// <summary>
    /// Информация о количестве поставщиков для каждого типа отрасли и форме собственности.
    /// </summary>
    /// <returns>Список <see cref="SupplierCountIndustryOwnershipDto"/></returns>
    [HttpGet("supplier_by_industy_and_ownership")]
    public ActionResult<IEnumerable<SupplierCountIndustryOwnershipDto>> SupplierCountIndustryOwnership()
    {
        var result = supplyRepository.GetAll()
        .GroupBy(supply => new { supply.Enterprise.IndustryType, supply.Enterprise.OwnershipForm })
        .Select(group => new
        {
            group.Key.IndustryType,
            group.Key.OwnershipForm,
            SupplierCount = group.Select(s => s.Supplier.Id).Distinct().Count()
        })
        .ToList();

        return Ok(result);
    }

    /// <summary>
    /// Топ 5 предприятий по количеству поставок.
    /// </summary>
    /// <returns>Список <see cref="EnterprisesSupplyCountDto"/></returns>
    [HttpGet("top_5_enterprise")]
    public ActionResult<IEnumerable<EnterprisesSupplyCountDto>> Top5EnterprisesSupplyCount()
    {
        var topEnterprises = supplyRepository.GetAll()
        .GroupBy(supply => supply.Enterprise)
        .Select(group => new
        {
            Enterprise = group.Key,
            SupplyCount = group.Count()
        }).OrderByDescending(x => x.SupplyCount).Take(5).ToList();


        return Ok(topEnterprises);
    }

    /// <summary>
    /// Инфорация о поставщиках, поставивших максимальное количество товара за указанный период.
    /// </summary>
    /// <param name="startDate">Дата начала периода</param>
    /// <param name="endDate">Дата окончания периода</param>
    /// <returns>Список <see cref="SuppliersWithMaxSupplyDto"/></returns>
    [HttpGet("supplier_and_max_quantity_by_period")]
    public ActionResult<IEnumerable<SuppliersWithMaxSupplyDto>> MaxSupplierPeriod(DateTime startDate, DateTime endDate)
    {
        var supplierQuantities = supplyRepository.GetAll()
            .Where(s => s.Date >= startDate && s.Date <= endDate)
            .GroupBy(s => s.Supplier)
            .Select(group => new
            {
                Supplier = group.Key,
                TotalQuantity = group.Sum(s => s.Quanity)
            })
            .ToList();

        var maxQuantity = supplierQuantities.Max(x => x.TotalQuantity);

        var suppliersWithMaxSupply = supplierQuantities
            .Where(x => x.TotalQuantity == maxQuantity)
            .ToList();

        return Ok(suppliersWithMaxSupply);
    }
}
