﻿using AutoMapper;
using BelajarRESTApi.Application.DefaultServices.ProductService.Dto;
using BelajarRESTApi.Application.Helpers;
using BelajarRESTApi.Database.Databases;
using BelajarRESTApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarRESTApi.Application.DefaultServices.ProductService
{
    public class ProductAppService : IProductAppService
    {
        private readonly SalesContext _salesContext;
        private IMapper _mapper;

        public ProductAppService(SalesContext salesContext, IMapper mappper)
        {
            _salesContext = salesContext;
            _mapper = mappper;
        }

        public void Create(CreateProductDto model)
        {
            //var countId = _salesContext.Products.Count();
            //countId = countId + 1;
            var product = _mapper.Map<Product>(model);
            //product.ProductId = countId;
            _salesContext.Products.Add(product);
            _salesContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _salesContext.Products.FirstOrDefault(w => w.ProductId == id);
            if (product != null)
            {
                _salesContext.Products.Remove(product);
                _salesContext.SaveChanges();
            }
        }

        public PagedResult<ProductListDto> GetAllProducts(PageInfo pageInfo)
        {
            var pageResult = new PagedResult<ProductListDto>
            {
                Data = (from product in _salesContext.Products
                        join supplier in _salesContext.Suppliers
                                on product.SupplierId equals supplier.SupplierId
                        select new ProductListDto
                        {
                            ProductCode = product.ProductCode,
                            ProductName = product.ProductName,
                            ProductPrice = product.ProductPrice,
                            ProductQty = product.ProductQty,
                            SupplierName = supplier.SupplierName,
                        })
                        .Skip(pageInfo.Skip)
                        .Take(pageInfo.PageSize)
                        .OrderBy(w => w.ProductCode),
                Total = _salesContext.Products.Count()
            };

            return pageResult;
        }

        public UpdateProductDto GetProductByCode(string code)
        {
            var product = _salesContext.Products.FirstOrDefault(w => w.ProductCode == code);
            var productDto = _mapper.Map<UpdateProductDto>(product);
            return productDto;
        }

        public PagedResult<ProductListDto> SearchProduct(string searchString, PageInfo pageInfo)
        {
            var products = from product in _salesContext.Products
                           select product;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.Contains(searchString)
                                    || s.ProductCode.Contains(searchString));
            }

            var pagedResult = new PagedResult<ProductListDto>
            {
                Data = (from product in products
                        join supplier in _salesContext.Suppliers
                                    on product.SupplierId equals supplier.SupplierId
                        select new ProductListDto
                        {
                            ProductCode = product.ProductCode,
                            ProductName = product.ProductName,
                            ProductPrice = product.ProductPrice,
                            ProductQty = product.ProductQty,
                            SupplierName = supplier.SupplierName
                        })
                       .Skip(pageInfo.Skip)
                       .Take(pageInfo.PageSize)
                       .OrderBy(w => w.ProductCode),
                Total = _salesContext.Products.Count()
            };

            return pagedResult;
        }

        public void Update(UpdateProductDto model)
        {
            var product = _mapper.Map<Product>(model);
            _salesContext.Products.Update(product);
            _salesContext.SaveChanges();
        }
    }
}
