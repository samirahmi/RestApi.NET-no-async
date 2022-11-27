using AutoMapper;
using BelajarRESTApi.Application.DefaultServices.ProductService.Dto;
using BelajarRESTApi.Application.DefaultServices.SupplierService.Dto;
using BelajarRESTApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarRESTApi.Application.ConfigProfile
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<Product, CreateProductDto>();
            CreateMap<CreateProductDto, Product>();

            CreateMap<Product, UpdateProductDto>();
            CreateMap<UpdateProductDto, Product>();

            CreateMap<Product, ProductListDto>();
            CreateMap<ProductListDto, Product>();

            CreateMap<Supplier, CreateSupplierDto>();
            CreateMap<CreateSupplierDto, Supplier>();

            CreateMap<Supplier, UpdateSupplierDto>();
            CreateMap<UpdateSupplierDto, Supplier>();

            CreateMap<Supplier, SupplierListDto>();
            CreateMap<SupplierListDto, Supplier>();
        }
    }
}
