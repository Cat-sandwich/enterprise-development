namespace EnterpriseStatistics.Application.DTO;

/// <summary>
/// Поставка
/// </summary>
public class SupplyDto
{
    /// <summary>
    /// id поставщика
    /// </summary>
    public required int IdSupplier { get; set; }
    /// <summary>
    /// ОГРН предприятия
    /// </summary>
    public required ulong MainStateRegistrationNumber { get; set; }
    /// <summary>
    /// Количество единиц сырья
    /// </summary>
    public required int Quanity { get; set; }
    /// <summary>
    /// Дата поставки
    /// </summary>
    public required DateTime Date { get; set; }
}
