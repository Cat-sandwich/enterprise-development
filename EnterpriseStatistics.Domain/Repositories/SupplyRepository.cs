using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Domain.Repositories;

public class SupplyRepository: IRepository<Supply, int>
{
    private static readonly List<Supply> _supplies = [];

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
        newItem.Id = _supplies.Count;
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
        var item_id = _supplies.FindIndex(s => s.Id == id);
        if (item_id == -1)
            return false;

        _supplies[item_id] = newItem;
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

        _supplies.Remove(supplier);
        return true;
    }
}
