namespace EnterpriseStatistics.Application.DTO;

/// <summary>
/// Поставщик
/// </summary>
public class SupplierDto
{
    /// <summary>
    /// ФИО
    /// </summary>
    public required string FullName { get; set; }
    /// <summary>
    /// Адрес
    /// </summary>
    public required string Address { get; set; }
    /// <summary>
    /// Телефон
    /// </summary>
    public required string Phone { get; set; }
}
