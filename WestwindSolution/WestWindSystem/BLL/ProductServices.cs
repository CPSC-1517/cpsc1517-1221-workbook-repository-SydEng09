﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.BLL;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        private readonly WestwindContext _dbContext;
        internal ProductServices(WestwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> FindProductsByCategoryId(int categoryId)
        {
            var query = _dbContext.Products.Where(item => item.CategoryId == categoryId)
            .Where(currentProduct => currentProduct.Discontinued == false);
            return query.ToList();
        }
        public List<Product> FindProductByProductName(string partialProductName)
        {
            var query = _dbContext.Products.Where(currentProduct => currentProduct.ProductName.Contains(partialProductName))
                .Where(currentProduct => currentProduct.Discontinued == false);
            return query.ToList();
        }
        public int AddProduct(Product newProduct)
        {
            bool exists = _dbContext.Products.Any(c => c.ProductName == newProduct.ProductName);
            if (exists)
            {
                throw new Exception($"The Product Name {newProduct.ProductName} already exists!");
            }
            if (newProduct.CategoryId == 0)
            {
                throw new Exception($"CategoryId is required.");
            }
            if (newProduct.SupplierId == 0)
            {
                throw new Exception($"SupplierId is required.");
            }
            bool categoryExists = _dbContext.Categories.Any(c => c.Id == newProduct.CategoryId);
            if (!categoryExists)
            {
                throw new Exception($"The CategoryId {newProduct.CategoryId} is not valid.");
            }
            bool supplierExists = _dbContext.Suppliers.Any(s => s.SupplierId == newProduct.SupplierId);
            if (!supplierExists)
            {
                throw new Exception($"The SupplierId {newProduct.SupplierId} is not valid.");
            }

            newProduct.Discontinued = false;
            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();
            return newProduct.Id;
        }
        public int UpdateProduct(Product existingProduct)
        {
            _dbContext.Products.Attach(existingProduct).State = EntityState.Modified;
            int rowsUpdated = _dbContext.SaveChanges();
            return rowsUpdated;
        }
        public int DeleteProduct(Product existingProduct)
        {
            // To mark a record as deleted but keep record in database
            existingProduct.Discontinued = true;
            _dbContext.Products.Attach(existingProduct).State = EntityState.Modified;

            int rowsDeleted = _dbContext.SaveChanges();
            return rowsDeleted;
        }
        public Product GetByID(int productID)
        {
            var query = _dbContext
                .Products
                .Where(p => p.Id == productID);

            return query.FirstOrDefault();
        }
        public List<Product> GetByPartialProductName(string partialProductName)
        {
            var query = _dbContext
                .Products
                .Where(p => p.ProductName.Contains(partialProductName));

            return query.ToList();
        }
        public Product GetById(int productId)
        {
            var query = _dbContext
                .Products
                .Where(p => p.Id == productId);
            return query.FirstOrDefault();
        }
    }
}
