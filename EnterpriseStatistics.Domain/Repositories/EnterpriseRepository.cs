using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseStatistics.Domain.Repositories;

public class EnterpriseRepository(EnterpriseStatisticsDbContext context): IRepository<Enterprise, ulong>
{
    /// <summary>
    /// Вернуть список предприятий
    /// </summary>
    /// <returns>Список объектов <see cref="Enterprise"/></returns>
    public async Task<List<Enterprise>> GetAll() => await context.Enterprises.ToListAsync();

    /// <summary>
    /// Вернуть предприятие по id
    /// </summary>
    /// <param name="id">id возвращаемого объекта</param>
    /// <returns>Объект <see cref="Enterprise"/> или null, если не найден</returns>
    public async Task<Enterprise?> GetById(ulong id) => await context.Enterprises.FirstOrDefaultAsync(e => e.MainStateRegistrationNumber == id);

    /// <summary>
    /// Добавить предприятие
    /// </summary>
    /// <param name="newItem">добавляемый объект</param>
    public async Task Add(Enterprise newItem)
    {
        if (await GetById(newItem.MainStateRegistrationNumber) == null)
        {
            await context.Enterprises.AddAsync(newItem);
            await context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Обновить предприятие по id
    /// </summary>
    /// <param name="newItem">объект с новыми значениями</param>
    /// <param name="id">id изменяемого объекта</param>
    /// <returns>false, если не удалось найти элемент по id, true - иначе</returns>
    public async Task<bool> Update(Enterprise newItem, ulong id)
    {
        var enterprise = await GetById(id);

        if (enterprise == null) return false;

        enterprise.Name = newItem.Name;
        enterprise.Address = newItem.Address;
        enterprise.Phone = newItem.Phone;
        enterprise.EmployeeCount = newItem.EmployeeCount;
        enterprise.TotalArea = newItem.TotalArea;
        enterprise.IndustryType = newItem.IndustryType;
        enterprise.OwnershipForm = newItem.OwnershipForm;

        context.Enterprises.Update(enterprise);
        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Удалить предприятие по id
    /// </summary>
    /// <param name="id">id удаляемого объекта</param>
    /// <returns>false, если не удалось найти элемент по id, true - иначе</returns>
    public async Task<bool> Delete(ulong id)
    {
        var enterprise = await GetById(id);

        if (enterprise == null)
            return false;

        context.Enterprises.Remove(enterprise);
        await context.SaveChangesAsync();

        return true;
    }
}
