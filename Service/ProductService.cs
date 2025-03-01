using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperPrac.Dto;
using DapperPrac.Model;
using Microsoft.Data.SqlClient;

namespace DapperPrac.Service
{
    public class ProductService
    {
        protected readonly IConfiguration _config;
        protected readonly SqlConnection _connection;

        public ProductService(IConfiguration config)
        {
            _config = config;
            _connection = new SqlConnection(_config.GetConnectionString("Default"));
        }

        public async Task<List<JoinProduct>> GetProductsAsync()
        {
            return [.. await _connection.QueryAsync<JoinProduct>("SELECT p.Id, p.ProductName AS Name, p.Price, i.IndustryName, i.Cnpj " + 
            "FROM Products AS p INNER JOIN Industries AS i ON p.IndustryId=i.Id")];
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _connection.QueryFirstOrDefaultAsync<Product>("SELECT * FROM Products WHERE Id=@ProductId", new { ProductId = productId});
        }

        public async Task<bool> CreateProductAsync(InputProduct product)
        {
            int rowsAffected = await _connection.ExecuteAsync("INSERT INTO Products(ProductName, Price, IndustryId) " +
            "VALUES(@ProductName, @Price, @IndustryId)", product);

            return rowsAffected != 0;
        }
        public async Task<bool> UpdateProductAsync(int id, InputProduct product)
        {
            int rowsAffected = await _connection.ExecuteAsync("UPDATE Products SET ProductName=@ProductName, Price=@Price, IndustryId=@IndustryId WHERE Id=@ProductId",
             new { product.ProductName, product.Price, product.IndustryId, ProductId = id});

            return rowsAffected != 0;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            int rowsAffected = await _connection.ExecuteAsync("DELETE FROM Products WHERE Id=@Id", new {Id = id});

            return rowsAffected != 0;

        }
    }
}