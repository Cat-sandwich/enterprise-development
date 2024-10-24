﻿using AutoMapper;
using EnterpriseStatistics.Application.DTO;
using EnterpriseStatistics.Domain.Models;

namespace EnterpriseStatistics.Application;

public class AutoMapperProfile : Profile
{
    /// <summary>
    /// Преобразование из DTO в объекты классов и обратно
    /// </summary>
    public AutoMapperProfile()
    {
        CreateMap<Enterprise, EnterpriseDto>().ReverseMap();
        CreateMap<Supplier, SupplierDto>().ReverseMap();
        CreateMap<Supply, SupplyDto>().ReverseMap();
    }
    
}
