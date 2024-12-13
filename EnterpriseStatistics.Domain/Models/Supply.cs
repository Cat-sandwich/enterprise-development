using System.ComponentModel.DataAnnotations;

namespace EnterpriseStatistics.Domain.Models;
/// <summary>
/// Поставка
/// </summary>
public class Supply
{
    /// <summary>
    /// Идентификатор поставки
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Поставщик
    /// </summary>
    public required Supplier Supplier { get; set; }
    /// <summary>
    /// Предприятие
    /// </summary>
    public required Enterprise Enterprise { get; set; }
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
