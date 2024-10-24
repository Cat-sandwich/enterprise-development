using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Application.DTO;

/// <summary>
/// Поставщик и сумма его поставок
/// </summary>
public class SuppliersWithMaxSupplyDto
{
    /// <summary>
    /// Поставщик
    /// </summary>
    public required Supplier Supplier { get; set; }
    /// <summary>
    /// Количество товара
    /// </summary>
    public required int TotalQuantity { get; set; }
}
