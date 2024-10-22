using EnterpriseStatistics.Application.DTO;
using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseStatistics.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QueryController(IRepository<Supply, int> repository) : ControllerBase
{
    private readonly List<Supply> _supplyList = EnterpriseStatisticsFileReader.ReadSupply(Path.Combine("Data", "data.csv"));
    /// <summary>
    /// Все сведения о конкретном предприятии.
    /// </summary>
    /// <param name="mainStateRegistrationNumber">ОГРН конкретного предприятия</param>
    /// <returns></returns>
    [HttpGet("1")]
    public ActionResult<IEnumerable<Enterprise>> InfoSpecificEnterprise(ulong mainStateRegistrationNumber)
    {
        var specificEnterprise = _supplyList
        .Select(e => e.Enterprise)
        .Where(e => e.MainStateRegistrationNumber == mainStateRegistrationNumber).ToList();

        return Ok(specificEnterprise);
    }

    /// <summary>
    /// Все поставщики, поставившие сырье за заданный период, упорядочить по названию.
    /// </summary>
    /// <param name="startDate">Дата начала периода</param>
    /// <param name="endDate">Дата окончания периода</param>
    /// <returns></returns>
    [HttpGet("2")]
    public ActionResult<IEnumerable<Supplier>> InfoSupplierDate(DateTime startDate, DateTime endDate)
    {

        var supplierDate = _supplyList
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
    /// <returns></returns>
    [HttpGet("3")]
    public ActionResult<IEnumerable<EnterpriseCountsDto>> CountEnterprise()
    {
        var supplierEnterpriseCounts = _supplyList
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
    /// <returns></returns>
    [HttpGet("4")]
    public ActionResult<IEnumerable<SupplierCountIndustryOwnershipDto>> SupplierCountIndustryOwnership()
    {
        var result = _supplyList
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
    /// <returns></returns>
    [HttpGet("5")]
    public ActionResult<IEnumerable<EnterprisesSupplyCountDto>> Top5EnterprisesSupplyCount()
    {
        var topEnterprises = _supplyList
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
    /// <returns></returns>
    [HttpGet("6")]
    public ActionResult<IEnumerable<SuppliersWithMaxSupplyDto>> MaxSupplierPeriod(DateTime startDate, DateTime endDate)
    {
        var supplierQuantities = _supplyList
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
