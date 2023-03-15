 using Microsoft.AspNetCore.Mvc;
        using Pizzas.api.Models;
namespace Pizzas.api.Controllers

{
        
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
            
            [HttpPost]
        public IActionResult Create(Pizzas pizza){
            BD.CrearPizza(pizza);
            return Ok();
        }


        [HttpPut("{id}")]
    public IActionResult Update(int id, Pizzas pizza)
    {

    if(id < 1){
            return BadRequest();
        }
        Pizzas p = BD.ObtenerP(id);

        if(p == null) {
            return NotFound();
        }

        BD.UpdatePizza(id, pizza);
        return Ok();

    }


        [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        if(id < 1){
            return BadRequest();
        }
        Pizzas p = BD.ObtenerP(id);

        if(p == null) {
            return NotFound();
        }

        BD.EliminarPizza(id);
        return Ok();
    }




    }
}