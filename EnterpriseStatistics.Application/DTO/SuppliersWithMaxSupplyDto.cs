using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Application.DTO;

public class SuppliersWithMaxSupplyDto
{
    public required Supplier Supplier { get; set; }
    public required int TotalQuantity { get; set; }
}
