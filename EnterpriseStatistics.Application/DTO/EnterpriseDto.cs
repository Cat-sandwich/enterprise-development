namespace EnterpriseStatistics.Application.DTO;

/// <summary>
/// Предприятие
/// </summary>
public class EnterpriseDto
{

    /// <summary>
    /// Идентификатор предприятия - ОГРН
    /// </summary>
    public required ulong MainStateRegistrationNumber { get; set; }
    /// <summary>
    /// Название
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Адрес
    /// </summary>
    public required string Address { get; set; }
    /// <summary>
    /// Телефон
    /// </summary>
    public required string Phone { get; set; }
    /// <summary>
    /// Количество работников
    /// </summary>
    public required int EmployeeCount { get; set; }
    /// <summary>
    /// Общая площадь
    /// </summary>
    public required int TotalArea { get; set; }
    /// <summary>
    /// Тип отрасли
    /// </summary>
    public required string IndustryType { get; set; }
    /// <summary>
    /// Форма собственности
    /// </summary>
    public required string OwnershipForm { get; set; }
}
