using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MyStoreModels;

namespace MyStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private async Task<Product> GetProduct(int id)
        {
            // Connection
            MySqlConnection con = new MySqlConnection(MyConst.dbconn);
            con.Open();
            // Command
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"SELECT  products.ProductName, products.ProductPrice, products.ProductDescription, products.ProductShippingOunces, producttypes.ProductTypeName
                                FROM    products INNER JOIN
                                        producttypes ON products.ProductTypeID = producttypes.ProductTypeID
                                WHERE   (products.ProductID = @ProductID)";
            cmd.Connection = con;
            cmd.Parameters.Add("@ProductID", MySqlDbType.Int32);
            cmd.Parameters["@ProductID"].Value = id;
            // DataReader (read only forward only recordset)
            MySqlDataReader r;
            r = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            // code for loop to present data
            if (r.HasRows)
            {
                r.Read();
                Product p = new Product();
                p.ProductID = id;
                p.ProductName = r.GetString(0);
                p.ProductPrice = r.GetDecimal(1);
                p.ProductDescription = r.GetString(2);
                p.ProductTypeName = r.GetString(4);
                p.ProductShippingOunces = r.GetInt16(3);
                // Close Connection
                con.Close();
                return p;
            }
            else
            {
                // Close Connection
                con.Close();
                return null;
            }
        }
        private async Task<List<Product>> GetAllProducts()
        {
            List<Product> lp = new List<Product>();
            // Connection
            MySqlConnection con = new MySqlConnection(MyConst.dbconn);
            con.Open();
            // Command
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"SELECT   products.ProductID, products.ProductName, products.ProductPrice, products.ProductDescription, producttypes.ProductTypeName, products.ProductShippingOunces
                                FROM     products INNER JOIN
                                         producttypes ON products.ProductTypeID = producttypes.ProductTypeID";
            cmd.Connection = con;
            // DataReader (read only forward only recordset)
            MySqlDataReader r;
            r = (MySqlDataReader)await cmd.ExecuteReaderAsync();
            // code for loop to present data
            while (r.Read())
            {
                int ProductID = r.GetInt16(0);
                string ProductName = r.GetString(1);
                Decimal ProductPrice = r.GetDecimal(2);
                string ProductDescription = r.GetString(3);
                string ProductTypeName = r.GetString(4);
                int ProductShippingOunces = r.GetInt16(5);
                Product p = new Product(ProductID, ProductName, ProductPrice, ProductDescription, ProductTypeName, ProductShippingOunces);
                lp.Add(p);
            }
            // Close Connection
            con.Close();
            return lp;
        }
        private async Task<Product> AddProduct(Product p)
        {
            // Connection
            MySqlConnection con = new MySqlConnection(MyConst.dbconn);
            con.Open();
            // Command
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"INSERT INTO products
                                (ProductName, ProductPrice, ProductDescription, ProductShippingOunces, ProductTypeID)
                                VALUES (@ProductName, @ProductPrice, @ProductDescription, @ProductShippingOunces, @ProductTypeID);
                                SELECT LAST_INSERT_ID();";
            cmd.Connection = con;

            cmd.Parameters.Add("@ProductName", MySqlDbType.VarChar);
            cmd.Parameters["@ProductName"].Value = p.ProductName;

            cmd.Parameters.Add("@ProductPrice", MySqlDbType.Decimal);
            cmd.Parameters["@ProductPrice"].Value = p.ProductPrice;

            cmd.Parameters.Add("@ProductDescription", MySqlDbType.VarChar);
            cmd.Parameters["@ProductDescription"].Value = p.ProductDescription;

            cmd.Parameters.Add("@ProductShippingOunces", MySqlDbType.Int32);
            cmd.Parameters["@ProductShippingOunces"].Value = p.ProductShippingOunces;

            cmd.Parameters.Add("@ProductTypeID", MySqlDbType.Int32);
            cmd.Parameters["@ProductTypeID"].Value = p.ProductTypeName;

            // insert product by run the SQL.
            Object idresult = await cmd.ExecuteScalarAsync();
            // Close Connection
            con.Close();
            int id;
            if (idresult != null)
            {
                id = Convert.ToInt32(idresult);
                // Get the last insert product.
                var result = await GetProduct(id);
                return result;
            }
            return null;
        }
        private async Task<Product> UpdateProduct(Product p)
        {
            // Connection
            MySqlConnection con = new MySqlConnection(MyConst.dbconn);
            con.Open();
            // Command
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"UPDATE products
                                SET ProductName = @ProductName, ProductPrice = @ProductPrice, ProductDescription = @ProductDescription, ProductShippingOunces = @ProductShippingOunces, ProductTypeID = @ProductTypeID
                                WHERE (products.ProductID = @ProductID);";
            cmd.Connection = con;

            cmd.Parameters.Add("@ProductName", MySqlDbType.VarChar);
            cmd.Parameters["@ProductName"].Value = p.ProductName;

            cmd.Parameters.Add("@ProductPrice", MySqlDbType.Decimal);
            cmd.Parameters["@ProductPrice"].Value = p.ProductPrice;

            cmd.Parameters.Add("@ProductDescription", MySqlDbType.VarChar);
            cmd.Parameters["@ProductDescription"].Value = p.ProductDescription;

            cmd.Parameters.Add("@ProductShippingOunces", MySqlDbType.Int32);
            cmd.Parameters["@ProductShippingOunces"].Value = p.ProductShippingOunces;

            cmd.Parameters.Add("@ProductTypeID", MySqlDbType.Int32);
            cmd.Parameters["@ProductTypeID"].Value = p.ProductTypeName;

            cmd.Parameters.Add("@ProductID", MySqlDbType.Int32);
            cmd.Parameters["@ProductID"].Value = p.ProductID;

            // update product by run the SQL.
            // Return Value: The number of rows affected.
            int num = await cmd.ExecuteNonQueryAsync();
            // Close Connection
            con.Close();
            if (num > 0)
            {
                // Get the update product.
                var result = await GetProduct(p.ProductID);
                return result;
            }
            return null;
        }
        private async Task<Product> DeleteProduct(int id)
        {
            // Get the product Before deleting
            var result = await GetProduct(id);


            // Connection
            MySqlConnection con = new MySqlConnection(MyConst.dbconn);
            con.Open();
            // Command
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"DELETE FROM products
                                WHERE (products.ProductID = @ProductID);";
            cmd.Connection = con;

            cmd.Parameters.Add("@ProductID", MySqlDbType.Int32);
            cmd.Parameters["@ProductID"].Value = id;

            // del product by run the SQL.
            // Return Value: The number of rows affected.
            int num = await cmd.ExecuteNonQueryAsync();
            // Close Connection
            con.Close();
            if (num > 0)
            {
                return result;
            }
            return null;
        }

        [HttpGet]
        public async Task<ActionResult> ApiGetAllProducts()
        {
            try
            {
                return Ok(await GetAllProducts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> ApiGetProduct(int id)
        {
            try
            {
                var result = await GetProduct(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> ApiCreateProduct([FromBody] Product p)
        {
            try
            {
                if (p == null)
                    return BadRequest();
                var result = await AddProduct(p);
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Product record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> ApiUpdateProduct(int id, Product p)
        {
            try
            {
                if (id != p.ProductID)
                    return BadRequest("Employee ID mismatch");

                var result = await GetProduct(id);
                if (result == null) return NotFound($"Product with id = {id} not found");

                return await UpdateProduct(p);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating Product data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> ApiDeleteProduct(int id)
        {
            try
            {
                var ProductToDelete = await GetProduct(id);
                if (ProductToDelete == null)
                {
                    return NotFound($"Product with id = {id} not found");
                }
                return await DeleteProduct(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting Product data");
            }
        }


    }
}
