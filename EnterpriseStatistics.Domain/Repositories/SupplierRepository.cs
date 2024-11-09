using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseStatistics.Domain.Repositories;

public class SupplierRepository(EnterpriseStatisticsDbContext context) : IRepository<Supplier, int>
{
    /// <summary>
    /// Вернуть всех поставщиков
    /// </summary>
    /// <returns>Список объектов <see cref="Supplier"/></returns>
    public async Task<List<Supplier>> GetAll() => await context.Suppliers.ToListAsync();

    /// <summary>
    /// Вернуть поставщика по id
    /// </summary>
    /// <param name="id">id возвращаемого объекта</param>
    /// <returns>Объект <see cref="Supplier"/> или null, если не найден</returns>
    public async Task<Supplier?> GetById(int id) => await context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);    

    /// <summary>
    /// Добавить поставщика
    /// </summary>
    /// <param name="newItem">добавляемый объект</param>
    public async Task Add(Supplier newItem)
    {
        await context.Suppliers.AddAsync(newItem);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Обновить поставщика по id
    /// </summary>
    /// <param name="newItem">объект с новыми значениями</param>
    /// <param name="id">id изменяемого объекта</param>
    /// <returns>false, если не удалось найти элемент по id, true - иначе</returns>
    public async Task<bool> Update(Supplier newItem, int id)
    {
        var supplier = await GetById(id);

        if (supplier == null) return false;

        supplier.FullName = newItem.FullName;
        supplier.Address = newItem.Address;
        supplier.Phone = newItem.Phone;

        context.Suppliers.Update(supplier);
        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Удалить поставщика по id
    /// </summary>
    /// <param name="id">id удаляемого объекта</param>
    /// <returns>false, если не удалось найти элемент по id, true - иначе</returns>
    public async Task<bool> Delete(int id)
    {
        var supplier = await GetById(id);

        if (supplier == null)
            return false;

        context.Suppliers.Remove(supplier);
        await context.SaveChangesAsync();

        return true;
    }
}
