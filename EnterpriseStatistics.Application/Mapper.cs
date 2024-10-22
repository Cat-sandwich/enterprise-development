using AutoMapper;
using EnterpriseStatistics.Application.DTO;
using EnterpriseStatistics.Domain.Models;
using EnterpriseStatistics.Domain.Repositories;

namespace EnterpriseStatistics.Application;

public class Mapper(IMapper mapper)
{
    /// <summary>
    /// Преобразование из <see cref="SupplyDto"/> в объект класса <see cref="Supply"/>
    /// </summary>
    /// <param name="item">Объект для преобразования</param>
    /// <returns>Объект класса <see cref="Supply"/></returns>
    public Supply GetSupply(SupplyDto item)
    {
        var supply = mapper.Map<Supply>(item);

        EnterpriseRepository enterpriseRepository = new();
        var enterprise = enterpriseRepository.GetById(item.MainStateRegistrationNumber);
        if (enterprise == null)
        {
            supply.Enterprise = null;
        }
        else
        {
            supply.Enterprise = enterprise;
        };

        SupplierRepository supplierRepository = new();
        var supplier = supplierRepository.GetById(item.IdSupplier);
        if (supplier == null)
        {
            supply.Supplier = null;
        }
        else
        {
            supply.Supplier = supplier;
        };

        return supply;
    }

    /// <summary>
    /// Преобразование из <see cref="EnterpriseDto"/> в объект класса <see cref="Enterprise"/>
    /// </summary>
    /// <param name="item">Объект для преобразования</param>
    /// <returns>Объект класса <see cref="Enterprise"/></returns>
    public Enterprise GetEnterprise(EnterpriseDto item)
    {
        var enterprise = mapper.Map<Enterprise>(item);
        try
        {
            enterprise.IndustryType = (IndustryTypes)Enum.Parse(typeof(IndustryTypes), item.IndustryType);
            enterprise.OwnershipForm = (OwnershipForms)Enum.Parse(typeof(OwnershipForms), item.OwnershipForm);
        }
        catch (Exception)
        {
            enterprise.IndustryType = IndustryTypes.AgriculturalIndustry;
            enterprise.OwnershipForm = OwnershipForms.LimitedLiabilityPartnership;
            throw;
        }        
        
        return enterprise;
    }

    /// <summary>
    /// Преобразование из <see cref="Enterprise"/> в объект класса <see cref="EnterpriseDto"/>
    /// </summary>
    /// <param name="item">Объект для преобразования</param>
    /// <returns>Объект класса <see cref="EnterpriseDto"/></returns>
    public EnterpriseDto GetEnterpriseDto(Enterprise item)
    {
        var enterpriseDto = mapper.Map<EnterpriseDto>(item);
        try
        {
            enterpriseDto.IndustryType = item.IndustryType.ToString();
            enterpriseDto.OwnershipForm = item.OwnershipForm.ToString();
        }
        catch (Exception)
        {
            enterpriseDto.IndustryType = "AgriculturalIndustry";
            enterpriseDto.OwnershipForm = "LimitedLiabilityPartnership";
            throw;
        }

        return enterpriseDto;
    }
}
