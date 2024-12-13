using EnterpriseStatistics.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EnterpriseStatistics.Application.DTO;

/// <summary>
/// Предприятие
/// </summary>
public class EnterpriseDto
{

    /// <summary>
    /// Идентификатор предприятия - ОГРН
    /// </summary>
    [Range(1000000000000, 10000000000000, ErrorMessage = "ОГРН должен содержать 13 цифр")]
    public required ulong MainStateRegistrationNumber { get; set; }
    /// <summary>
    /// Название
    /// </summary>
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина названия должна быть от {2} до {1}")]
    public required string Name { get; set; }
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
    /// <summary>
    /// Количество работников
    /// </summary>
    [Range(1, 100, ErrorMessage = "Количество работников должено быть в диапазоне {1}-{2}")]
    public required int EmployeeCount { get; set; }
    /// <summary>
    /// Общая площадь
    /// </summary>
    [Range(10, 1000, ErrorMessage = "Общая площадь должена быть в диапазоне {1}-{2}")]
    public required int TotalArea { get; set; }
    /// <summary>
    /// Тип отрасли
    /// </summary>
    [EnumDataType(typeof(IndustryTypes))]
    public required string IndustryType { get; set; }
    /// <summary>
    /// Форма собственности
    /// </summary>
    [EnumDataType(typeof(OwnershipForms))]
    public required string OwnershipForm { get; set; }
}
