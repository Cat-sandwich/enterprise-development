using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Domain.Repositories;

public class SupplyRepository: IRepository<Supply, int>
{
    private static readonly List<Supply> _supplies = new List<Supply>(); // изменить на чтение

    public List<Supply> GetAll()
    {
        return _supplies;
    }
    public Supply GetById(int id)
    {
        return _supplies.Find(s => s.Id == id);
    }

    
    public void Add(Supply newItem)
    {
        newItem.Id = _supplies.Count;
        _supplies.Add(newItem);
    }

   
    public bool Update(Supply newValue, int id)
    {
        var item_id = _supplies.FindIndex(s => s.Id == id);
        if (item_id == -1)
            return false;

        _supplies[item_id].Id = newValue.Id;
        _supplies[item_id].Supplier = newValue.Supplier;
        _supplies[item_id].Enterprise = newValue.Enterprise;
        _supplies[item_id].Quanity = newValue.Quanity;
        _supplies[item_id].Date = newValue.Date;
        return true;
    }

    
    public bool Delete(int id)
    {
        var supplier = GetById(id);

        if (supplier == null)
            return false;

        for (var i = id + 1; i < _supplies.Count; i++)
            _supplies[i].Id = i - 1;

        _supplies.Remove(supplier);
        return true;
    }



}
