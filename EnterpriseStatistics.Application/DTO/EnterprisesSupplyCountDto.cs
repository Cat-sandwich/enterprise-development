using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Application.DTO;

public class EnterprisesSupplyCountDto
{
    public required Enterprise Enterprise { get; set; }
    public required int SupplyCount { get; set; }
}
