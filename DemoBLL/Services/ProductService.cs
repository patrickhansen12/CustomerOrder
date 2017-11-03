using System;
using System.Collections.Generic;
using System.Text;
using DemoBLL.BusinessObjects;
using DemoBLL.Converters;
using DemoDAL.Facade;
using System.Linq;

namespace DemoBLL.Services
{
    public class ProductService : IProductService
    {
        ProductConverter conv = new ProductConverter();

        private DALFacade _facade;

        public ProductService(DALFacade _facade)
        {
            this._facade = _facade;
        }

        public ProductBO Create(ProductBO product)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var productEntity = uow.ProductRepository.Create(conv.Convert(product));
                uow.Complete();
                return conv.Convert(productEntity);
            }
        }

        public ProductBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var productEntity = uow.ProductRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(productEntity);
            }
        }

        public ProductBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var productEntity = uow.ProductRepository.Get(Id);
                return conv.Convert(productEntity);
            }
        }

        public List<ProductBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.ProductRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public ProductBO Update(ProductBO product)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var productEntity = uow.ProductRepository.Get(product.Id);
                if (productEntity == null)
                {
                    throw new InvalidOperationException("product not found");
                }
                productEntity.Name = product.Name;
                uow.Complete();
                return conv.Convert(productEntity);
            }
        }
    }
}

