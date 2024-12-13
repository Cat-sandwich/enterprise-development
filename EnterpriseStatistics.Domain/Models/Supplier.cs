using System.ComponentModel.DataAnnotations;

namespace EnterpriseStatistics.Domain.Models;
/// <summary>
/// Поставщик
/// </summary>
public class Supplier
{
    /// <summary>
    /// Идентификатор поставщика
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// ФИО
    /// </summary>
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина ФИО от {2} до {1}")]
    public required string FullName { get; set; }
    /// <summary>
    /// Адрес
    /// </summary>
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина адреса от {2} до {1}")]
    public required string Address { get; set; }
    /// <summary>
    /// Телефон
    /// </summary>
    [Phone]
    public required string Phone { get; set; }

}
