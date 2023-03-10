using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

namespace Pizzas.api.Models
{


    public class BD{
        private static string _connectionString = @"Server=A-PHZ2-CIDI-007;DataBase=DAI-Pizzas;Trusted_Connection=True";
        public static List<Pizzas> ObtenerPizzas()
        {
            List<Pizzas> lista = new List<Pizzas>();
            string sql = "SELECT * FROM Pizzas";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                lista = db.Query<Pizzas>(sql).ToList();
            }
            return lista;
        }

        public static List<Pizzas> ObtenerP(int id)
        {
            List<Pizzas> pizza = new List<Pizzas>();
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                pizza = connection.QueryFirstOnDefault<Pizzas>("SELECT * FROM Pizzas WHERE Id = @pId", new {pId = id});
            }
            return pizza;
        }
    }

}
