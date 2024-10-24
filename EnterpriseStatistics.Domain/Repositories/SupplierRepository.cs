using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Domain.Repositories;

public class SupplierRepository: IRepository<Supplier, int>
{
    private static readonly List<Supplier> _suppliers = [];
    private int _supplierId = 0;

    /// <summary>
    /// Вернуть всех поставщиков
    /// </summary>
    /// <returns>Список объектов <see cref="Supplier"/></returns>
    public List<Supplier> GetAll() => _suppliers;


    /// <summary>
    /// Вернуть поставщика по id
    /// </summary>
    /// <param name="id">id возвращаемого объекта</param>
    /// <returns>Объект <see cref="Supplier"/> или null, если не найден</returns>
    public Supplier? GetById(int id) => _suppliers.FirstOrDefault(d => d.Id == id);
    

    /// <summary>
    /// Добавить поставщика
    /// </summary>
    /// <param name="newItem">добавляемый объект</param>
    public void Add(Supplier newItem)
    {
        newItem.Id = _supplierId++;
        _suppliers.Add(newItem);
    }

    /// <summary>
    /// Обновить поставщика по id
    /// </summary>
    /// <param name="newItem">объект с новыми значениями</param>
    /// <param name="id">id изменяемого объекта</param>
    /// <returns>false, если не удалось найти элемент по id, true - иначе</returns>
    public bool Update(Supplier newItem, int id)
    {
        var supplier = GetById(id);

        if (supplier == null) return false;

        supplier.Id = newItem.Id;
        supplier.FullName = newItem.FullName;
        supplier.Address = newItem.Address;
        supplier.Phone = newItem.Phone;

        return true;
    }

    /// <summary>
    /// Удалить поставщика по id
    /// </summary>
    /// <param name="id">id удаляемого объекта</param>
    /// <returns>false, если не удалось найти элемент по id, true - иначе</returns>
    public bool Delete(int id)
    {
        var supplier = GetById(id);

        if (supplier == null)
            return false;
        
        return _suppliers.Remove(supplier);
    }
}
