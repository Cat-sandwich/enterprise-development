using System.ComponentModel.DataAnnotations;

namespace EnterpriseStatistics.Application.DTO;

/// <summary>
/// Поставщик
/// </summary>
public class SupplierDto
{
    /// <summary>
    /// ФИО
    /// </summary>
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина ФИО должна быть от {2} до {1}")]
    public required string FullName { get; set; }
    /// <summary>
    /// Адрес
    /// </summary>
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина адреса должна быть от {2} до {1}")]
    public required string Address { get; set; }
    /// <summary>
    /// Телефон
    /// </summary>
    [Phone(ErrorMessage = "Номер телефона должен быть в формате \"+xxxx-xxx-xxxx\"")]
    public required string Phone { get; set; }
}
