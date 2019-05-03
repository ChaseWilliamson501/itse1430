using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nile.Stores;

namespace Nile.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        public SqlProductDatabase( string connectionString )
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;


        protected override Product AddCore( Product product )
        {
            using (var connection = GetConnection())
            {
                connection.Open();

               
                var cmd = connection.CreateCommand();
                cmd.CommandText = "AddGame";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@owned", product.IsDiscontinued);

               
                var result = Convert.ToInt32(cmd.ExecuteScalar());

                product.Id = result;
                return product;
            };
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            var ds = new DataSet();

            using (var conn = GetConnection())
            {
                var cmd = new SqlCommand("GetProducts", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
                
            };
            
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                return from r in table.Rows.OfType<DataRow>()
                       select new Product() {

                           Id = Convert.ToInt32(r[0]),  //Ordinal, convert
                           Name = r["Name"].ToString(), //By name, convert
                           Description = r.IsNull("description") ? "" : r["description"].ToString(), //handle DB nulls 
                           Price = r.Field<decimal>("Price"),
                           IsDiscontinued = r.Field<bool>("IsDiscontinued"),
                           
                       };
            };

            return Enumerable.Empty<Product>();
        }

        protected override Product GetCore( int id )
        {
            using (var conn = GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetGames";
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var productId = reader.GetInt32(0);
                    if (productId == id)
                    {
                        var ordinal = reader.GetOrdinal("Name");

                        return new Product() {
                            Id = productId,
                            Name = GetString(reader, "Name"),
                            Description = GetString(reader, "Description"),
                            Price = reader.GetFieldValue<decimal>(3),
                            IsDiscontinued = Convert.ToBoolean(reader.GetValue(4)),
                             
                        };
                    };
                };
            };
            return null;
        }

        private string GetString( IDataReader reader, string name )
        {
            var ordinal = reader.GetOrdinal(name);

            if (reader.IsDBNull(ordinal))
                return "";


            return reader.GetString(ordinal);
        }

        protected override void RemoveCore( int id )
        {
            using (var connection = GetConnection())
            {
                connection.Open();

               
                var cmd = connection.CreateCommand();
                cmd.CommandText = "DeleteGame";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                
                var result = Convert.ToInt32(cmd.ExecuteScalar());

               
                cmd.ExecuteNonQuery();
            }
        }

        protected override Product UpdateCore( Product existing, Product newItem )
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                //var cmd = new SqlCommand("", connection);
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UpdateProduct";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Add parameter 1 - long way when you need control over parameter
                var parameter = new SqlParameter("@name", System.Data.SqlDbType.NVarChar);
                parameter.Value = newItem.Name;
                cmd.Parameters.Add(parameter);

                //Add parameter 2 - quick way when you just need type/value
                cmd.Parameters.AddWithValue("@description", newItem.Description);
                cmd.Parameters.AddWithValue("@price", newItem.Price);
                cmd.Parameters.AddWithValue("@IsDiscontinued", newItem.IsDiscontinued);
                cmd.Parameters.AddWithValue("@id", existing);

                // (int)cmd.ExecuteScalar();
                // cmd.ExecuteScalar() as int;  //reference types 
                var result = Convert.ToInt32(cmd.ExecuteScalar());

                //No results
                cmd.ExecuteNonQuery();

            };
            return newItem;
        }
    
    }
}
