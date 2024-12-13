using System.ComponentModel.DataAnnotations;

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
    [Range(1, 1000, ErrorMessage = "Количество единиц сырья должено быть в диапазоне {1}-{2}")]
    public required int Quanity { get; set; }
    /// <summary>
    /// Дата поставки
    /// </summary>
    public required DateTime Date { get; set; }
}
