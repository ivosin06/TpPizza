namespace Pizzas.api.Controllers
{
using Microsoft.AspNetCore.Mvc;
using Pizzas.api.Models;
    [ApiController]
    [Route("[controller]")]
    public class PizzasController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(){
            List<Pizzas> lista = BD.ObtenerPizzas();
            return Ok(lista);
        }


         [HttpGet("(id)")]
    public IActionResult Get(int id){
        if(id<1){
            return BadRequest();
        }
        Pizzas p = BD.ObtenerP(id);
        if(p==null)
        {
            return NotFound();
        }
        return Ok(p);
    }
    }
}