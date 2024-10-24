using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Domain.Repositories;

public class SupplyRepository: IRepository<Supply, int>
{
    private static readonly List<Supply> _supplies = [];
    private int _supplyId = 0;

    /// <summary>
    /// Вернуть все поставки
    /// </summary>
    /// <returns>Список объектов <see cref="Supply"/></returns>
    public List<Supply> GetAll() => _supplies;

    /// <summary>
    /// Вернуть поставку по id
    /// </summary>
    /// <param name="id">id возвращаемого объекта</param>
    /// <returns>Объект <see cref="Supply"/> или null, если не найден</returns>
    public Supply? GetById(int id) => _supplies.FirstOrDefault(d => d.Id == id);

    /// <summary>
    /// Добавить поставку
    /// </summary>
    /// <param name="newItem">добавляемый объект</param>
    public void Add(Supply newItem)
    {
        newItem.Id = _supplyId++;
        _supplies.Add(newItem);
    }

    /// <summary>
    /// Обновить поставку по id
    /// </summary>
    /// <param name="newItem">объект с новыми значениями</param>
    /// <param name="id">id изменяемого объекта</param>
    /// <returns>false, если не удалось найти элемент по id, true - иначе</returns>
    public bool Update(Supply newItem, int id)
    {
        var supply = GetById(id);

        if (supply == null) return false;

        supply.Id = newItem.Id;
        supply.Supplier = newItem.Supplier;
        supply.Enterprise = newItem.Enterprise;
        supply.Quanity = newItem.Quanity;
        supply.Date = newItem.Date;

        return true;
    }

    /// <summary>
    /// Удалить поставку по id
    /// </summary>
    /// <param name="id">id удаляемого объекта</param>
    /// <returns>false, если не удалось найти элемент по id, true - иначе</returns>
    public bool Delete(int id)
    {
        var supplier = GetById(id);

        if (supplier == null)
            return false;
                
        return _supplies.Remove(supplier);
    }
}
