using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Application.DTO;

/// <summary>
/// Предприятие и количество поставок для него
/// </summary>
public class EnterprisesSupplyCountDto
{
    /// <summary>
    /// Предприятие
    /// </summary>
    public required Enterprise Enterprise { get; set; }
    /// <summary>
    /// Количество поставок
    /// </summary>
    public required int SupplyCount { get; set; }
}
