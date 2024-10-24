namespace EnterpriseStatistics.Application.DTO;

/// <summary>
/// Поставщик и количество предприятий, с которыми он работает
/// </summary>
public class EnterpriseCountsDto
{
    /// <summary>
    /// Id поставщика
    /// </summary>
    public required int SupplierId { get; set; }
    /// <summary>
    /// ФИО поставщика
    /// </summary>
    public required string FullName { get; set; }
    /// <summary>
    /// Количество предприятий, с которыми работает каждый поставщик
    /// </summary>
    public int EnterpriseCount { get; set; }
}
