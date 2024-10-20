namespace EnterpriseStatistics.Application.DTO;

/// <summary>
/// Поставщик
/// </summary>
internal class SupplierDto
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
