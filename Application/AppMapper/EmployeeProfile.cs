﻿using Application.DTO;
using Application.ViewModel;
using AutoMapper;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppMapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDatatable, EmployeeDatatableViewModel>();
            CreateMap<Employee,EmployeeViewModel>();
            CreateMap<Employee,EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();

            CreateMap<AspNetUsers, AspNetUsersViewModel>();
            CreateMap<AspNetUsers, AspNetUsersDTO>();
            CreateMap<AspNetUsersDTO, AspNetUsers>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
