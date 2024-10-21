using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Domain.Repositories;

public class SupplierRepository: IRepository<Supplier, int>
{
    private static readonly List<Supplier> _suppliers = [];

    public List<Supplier> GetAll()
    {
        return _suppliers;
    }
    public Supplier GetById(int id)
    {
        return _suppliers.Find(s => s.Id == id);
    }

    
    public void Add(Supplier newItem)
    {
        newItem.Id = _suppliers.Count;
        _suppliers.Add(newItem);
    }

   
    public bool Update(Supplier newValue, int id)
    {
        var item_id = _suppliers.FindIndex(s => s.Id == id);
        if (item_id == -1)
            return false;

        _suppliers[item_id].Id = newValue.Id;
        _suppliers[item_id].FullName = newValue.FullName;
        _suppliers[item_id].Address = newValue.Address;
        _suppliers[item_id].Phone = newValue.Phone;
        return true;
    }

    
    public bool Delete(int id)
    {
        var supplier = GetById(id);

        if (supplier == null)
            return false;

        for (var i = id + 1; i < _suppliers.Count; i++)
            _suppliers[i].Id = i - 1;

        _suppliers.Remove(supplier);
        return true;
    }



}
