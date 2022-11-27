using BelajarRESTApi.Application.DefaultServices.SupplierService;
using BelajarRESTApi.Application.DefaultServices.SupplierService.Dto;
using BelajarRESTApi.Application.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace BelajarRESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierAppService _supplierAppService;
        public SupplierController(ISupplierAppService supplierAppService)
        {
            _supplierAppService = supplierAppService;
        }

        [HttpGet("GetAllSupplier")]
        [Produces("application/json")]
        public PagedResult<SupplierListDto> GetAllSupplier([FromQuery]PageInfo pageInfo)
        {
            var supplierList = _supplierAppService.GetAllSuppliers(pageInfo);

            return supplierList;
        }

        [HttpPost("SaveSupplier")]
        public void SaveSupplier([FromBody] CreateSupplierDto model)
        {
            _supplierAppService.Create(model);
        }

        [HttpGet("GetSupplierById")]
        public UpdateSupplierDto GetSupplierById(int Id)
        {
            var data = _supplierAppService.GetSupplierById(Id);
            
            return data;
        }

        [HttpDelete("DeleteSupplier")]
        public void DeleteSupplier(int Id)
        {
            _supplierAppService.Delete(Id);
        }

        [HttpPatch("UpdateSupplier")]
        public void UpdateSupplier([FromBody] UpdateSupplierDto model)
        {
            _supplierAppService.Update(model);
        }

        [HttpGet("SearchSupplier")]
        public PagedResult<SupplierListDto> SearchSupplier(string searchString, [FromQuery] PageInfo pageInfo)
        {
            var data = _supplierAppService.SearchSupplier(searchString, pageInfo);
            return data;
        }
    }
}
