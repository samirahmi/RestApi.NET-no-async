using BelajarRESTApi.Application.DefaultServices.SupplierService.Dto;
using BelajarRESTApi.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarRESTApi.Application.DefaultServices.SupplierService
{
    public interface ISupplierAppService
    {
        void Create(CreateSupplierDto model);
        void Update(UpdateSupplierDto model);
        void Delete(int Id);
        PagedResult<SupplierListDto> GetAllSuppliers(PageInfo pageInfo);
        UpdateSupplierDto GetSupplierById(int Id);
        PagedResult<SupplierListDto> SearchSupplier(string searchString, PageInfo pageInfo);
    }
}
