using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Application.DTO;

public class SupplierCountIndustryOwnershipDto
{
    public required IndustryTypes IndustryType { get; set; }
    public required OwnershipForms OwnershipForm { get; set; }
    public required int Count { get; set; }
}
