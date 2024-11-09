using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseStatistics.Domain.Repositories;

public class SupplyRepository(EnterpriseStatisticsDbContext context) : IRepository<Supply, int>
{
    /// <summary>
    /// Вернуть все поставки
    /// </summary>
    /// <returns>Список объектов <see cref="Supply"/></returns>
    public async Task<List<Supply>> GetAll() => await context.Supplies.Include(s => s.Supplier).Include(s => s.Enterprise).ToListAsync();

    /// <summary>
    /// Вернуть поставку по id
    /// </summary>
    /// <param name="id">id возвращаемого объекта</param>
    /// <returns>Объект <see cref="Supply"/> или null, если не найден</returns>
    public async Task<Supply?> GetById(int id) => await context.Supplies.Include(s => s.Supplier).Include(s => s.Enterprise).FirstOrDefaultAsync(s => s.Id == id);

    /// <summary>
    /// Добавить поставку
    /// </summary>
    /// <param name="newItem">добавляемый объект</param>
    public async Task Add(Supply newItem)
    {
        await context.Supplies.AddAsync(newItem);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Обновить поставку по id
    /// </summary>
    /// <param name="newItem">объект с новыми значениями</param>
    /// <param name="id">id изменяемого объекта</param>
    /// <returns>false, если не удалось найти элемент по id, true - иначе</returns>
    public async Task<bool> Update(Supply newItem, int id)
    {
        var supply = await GetById(id);

        if (supply == null) return false;

        supply.Supplier = newItem.Supplier;
        supply.Enterprise = newItem.Enterprise;
        supply.Quanity = newItem.Quanity;
        supply.Date = newItem.Date;

        context.Supplies.Update(supply);
        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Удалить поставку по id
    /// </summary>
    /// <param name="id">id удаляемого объекта</param>
    /// <returns>false, если не удалось найти элемент по id, true - иначе</returns>
    public async Task<bool> Delete(int id)
    {
        var supply = await GetById(id);

        if (supply == null)
            return false;

        context.Supplies.Remove(supply);
        await context.SaveChangesAsync();

        return true;
    }
}
