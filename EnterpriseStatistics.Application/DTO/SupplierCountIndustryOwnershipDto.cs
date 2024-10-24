using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Application.DTO;

/// <summary>
/// Информация о количестве поставщиков для каждого типа отрасли и формы собственности
/// </summary>
public class SupplierCountIndustryOwnershipDto
{
    /// <summary>
    /// Тип отрасли
    /// </summary>
    public required IndustryTypes IndustryType { get; set; }
    /// <summary>
    /// Форма собственности
    /// </summary>
    public required OwnershipForms OwnershipForm { get; set; }
    /// <summary>
    /// Количестве поставщиков для каждого типа отрасли и формы собственности
    /// </summary>
    public required int Count { get; set; }
}
