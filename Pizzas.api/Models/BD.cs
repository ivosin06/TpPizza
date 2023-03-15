using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

namespace Pizzas.api.Models
{


    public class BD{
        private static string _connectionString = @"Server=A-PHZ2-AMI-005;DataBase=DAI-Pizzas;Trusted_Connection=True";
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
        public static List<Pizzas> CrearPizza(Pizzas p){
            using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute("INSERT INTO Pizzas VALUES (@pNombre, @pLibreGluten, @pImporte, @pDescripcion)", new { pNombre = p.Nombre, pLibreGluten = p.LibreGluten, pImporte = p.Importe, pDescripcion = p.Descripcion});
        }
        
        }
         public static void UpdatePizza(int id, Pizzas p)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute("UPDATE Pizzas SET Nombre = @pNombre, LibreGluten = @pLibreGluten, Importe = @pImporte, Descripciom = @pDescripcion WHERE Id = @pId", new { pNombre = p.Nombre, pLibreGluten = p.LibreGluten, pImporte = p.Importe, pDescripcion = p.Descripcion});
        }
    }
        
         public static void EliminarPizza(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute("DELETE FROM Pizzas WHERE Id = @pId", new { pId = id });
        }
    }
        
    }

}
