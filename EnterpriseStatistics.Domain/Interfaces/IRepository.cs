namespace EnterpriseStatistics.Domain.Interfaces;

public interface IRepository<TEntity, in Tkey>
{
    /// <summary>
    /// Возвращает все элементы коллекции
    /// </summary>
    /// <returns></returns>
    public Task<List<TEntity>> GetAll();

    /// <summary>
    /// Возвращает элемент по id
    /// </summary>
    /// <param name="id">id возвращаемого элемента</param>
    /// <returns></returns>
    public Task<TEntity?> GetById(Tkey id);

    /// <summary>
    /// Добавляет элемент в коллекцию
    /// </summary>
    /// <param name="newItem">Элемент для добавления</param>
    /// <returns></returns>
    public Task Add(TEntity newItem);

    /// <summary>
    /// Изменяет элемент коллекции по id
    /// </summary>
    /// <param name="newValue">Изменяемое значение</param>
    /// <param name="id">id изменяемого элемента</param>
    /// <returns></returns>
    public Task<bool> Update(TEntity newValue, Tkey id);

    /// <summary>
    /// Удаляет элемент из коллекции по id
    /// </summary>
    /// <param name="id">id удаляемого элемента</param>
    /// <returns></returns>
    public Task<bool> Delete(Tkey id);
}
