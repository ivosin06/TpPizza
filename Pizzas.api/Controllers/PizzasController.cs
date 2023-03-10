using Microsoft.AspNetCore.Mvc;
using Pizzas.api.Models;
namespace Pizzas.api.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzasController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll(){
        List<Pizzas> lista = BD.ObtenerPizzas();
        return Ok(lista);
    }

}
