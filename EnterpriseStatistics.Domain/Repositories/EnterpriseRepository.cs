using EnterpriseStatistics.Domain.Interfaces;
using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Domain.Repositories;

public class EnterpriseRepository: IRepository<Enterprise, ulong>
{
    private static readonly List<Enterprise> _enterprises = [];

    public List<Enterprise> GetAll()
    {
        return _enterprises;
    }
    public Enterprise GetById(ulong id)
    {
        return _enterprises.Find(e => e.MainStateRegistrationNumber == id);
    }

    
    public void Add(Enterprise newItem)
    {
        newItem.MainStateRegistrationNumber = (ulong)_enterprises.Count;
        _enterprises.Add(newItem);
    }

   
    public bool Update(Enterprise newValue, ulong id)
    {
        var item_id = _enterprises.FindIndex(e => e.MainStateRegistrationNumber == id);
        if (item_id == -1)
            return false;

        _enterprises[item_id].MainStateRegistrationNumber = newValue.MainStateRegistrationNumber;
        _enterprises[item_id].Name = newValue.Name;
        _enterprises[item_id].IndustryType = newValue.IndustryType;
        _enterprises[item_id].Address = newValue.Address;
        _enterprises[item_id].Phone = newValue.Phone;
        _enterprises[item_id].OwnershipForm = newValue.OwnershipForm;
        _enterprises[item_id].EmployeeCount = newValue.EmployeeCount;
        _enterprises[item_id].TotalArea = newValue.TotalArea;
        return true;
    }

    
    public bool Delete(ulong id)
    {
        var enterprise = GetById(id);

        if (enterprise == null)
            return false;

        _enterprises.Remove(enterprise);
        return true;
    }



}
