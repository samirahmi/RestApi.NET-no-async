using AutoMapper;
using BelajarRESTApi.Application.DefaultServices.ProductService.Dto;
using BelajarRESTApi.Application.DefaultServices.SupplierService.Dto;
using BelajarRESTApi.Application.Helpers;
using BelajarRESTApi.Database.Databases;
using BelajarRESTApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarRESTApi.Application.DefaultServices.SupplierService
{
    public class SupplierAppService : ISupplierAppService
    {
        private readonly SalesContext _salesContext;
        private IMapper _mapper;
        public SupplierAppService(SalesContext salesContext, IMapper mapper)
        {
            _salesContext = salesContext;
            _mapper = mapper;
        }

        public void Create(CreateSupplierDto model)
        {
            var supplier = _mapper.Map<Supplier>(model);
            _salesContext.Suppliers.Add(supplier);
            _salesContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var supplier = _salesContext.Suppliers.FirstOrDefault(w => w.SupplierId == Id);
            if (supplier != null)
            {
                _salesContext.Suppliers.Remove(supplier);
                _salesContext.SaveChanges();
            }
        }

        public PagedResult<SupplierListDto> GetAllSuppliers(PageInfo pageInfo)
        {
            var pageResult = new PagedResult<SupplierListDto>
            {
                Data = (from supplier in _salesContext.Suppliers
                        select new SupplierListDto
                        {
                            SupplierName = supplier.SupplierName,
                            SupplierAddress = supplier.SupplierAddress, 
                        })
                        .Skip(pageInfo.Skip)
                        .Take(pageInfo.PageSize)
                        .OrderBy(w => w.SupplierName),
                Total = _salesContext.Products.Count()
            };

            return pageResult;
        }

        public UpdateSupplierDto GetSupplierById(int Id)
        {
            var supplier = _salesContext.Suppliers.FirstOrDefault(w => w.SupplierId == Id);
            var supplierDto = _mapper.Map<UpdateSupplierDto>(supplier);
            return supplierDto;
        }

        public PagedResult<SupplierListDto> SearchSupplier(string searchString, PageInfo pageInfo)
        {
            var suppliers = from supplier in _salesContext.Suppliers
                            select supplier;
            if(!String.IsNullOrEmpty(searchString))
            {
                suppliers = suppliers.Where(s => s.SupplierName.Contains(searchString));
            }

            var pageResult = new PagedResult<SupplierListDto>
            {
                Data = (from supplier in suppliers
                        select new SupplierListDto
                        {
                            SupplierName = supplier.SupplierName,
                            SupplierAddress = supplier.SupplierAddress,
                        })
                        .Skip(pageInfo.Skip)
                        .Take(pageInfo.PageSize)
                        .OrderBy(w => w.SupplierName),
                Total = _salesContext.Products.Count()
            };

            return pageResult;
        }

        public void Update(UpdateSupplierDto model)
        {
            var supplier = _mapper.Map<Supplier>(model);
            _salesContext.Suppliers.Update(supplier);
            _salesContext.SaveChanges();
        }
    }
}
