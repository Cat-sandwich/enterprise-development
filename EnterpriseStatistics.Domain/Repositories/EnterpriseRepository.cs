using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Domain.Repositories;

public class EnterpriseRepository: IRepository<Enterprise, ulong>
{
    private static readonly List<Enterprise> _enterprises = [];

    /// <summary>
    /// Вернуть список предприятий
    /// </summary>
    /// <returns>Список объектов <see cref="Enterprise"/></returns>
    public List<Enterprise> GetAll() => _enterprises;

    /// <summary>
    /// Вернуть предприятие по id
    /// </summary>
    /// <param name="id">id возвращаемого объекта</param>
    /// <returns>Объект <see cref="Enterprise"/> или null, если не найден</returns>
    public Enterprise? GetById(ulong id) => _enterprises.FirstOrDefault(d => d.MainStateRegistrationNumber == id);

    /// <summary>
    /// Добавить предприятие
    /// </summary>
    /// <param name="newItem">добавляемый объект</param>
    public void Add(Enterprise newItem)
    {
        _enterprises.Add(newItem);
    }

    /// <summary>
    /// Обновить предприятие по id
    /// </summary>
    /// <param name="newItem">объект с новыми значениями</param>
    /// <param name="id">id изменяемого объекта</param>
    /// <returns>false, если не удалось найти элемент по id, true - иначе</returns>
    public bool Update(Enterprise newItem, ulong id)
    {
        var item_id = _enterprises.FindIndex(e => e.MainStateRegistrationNumber == id);
        if (item_id == -1)
            return false;

        _enterprises[item_id] = newItem;
        return true;
    }

    /// <summary>
    /// Удалить предприятие по id
    /// </summary>
    /// <param name="id">id удаляемого объекта</param>
    /// <returns>false, если не удалось найти элемент по id, true - иначе</returns>
    public bool Delete(ulong id)
    {
        var enterprise = GetById(id);

        if (enterprise == null)
            return false;
        return _enterprises.Remove(enterprise);
    }
}
