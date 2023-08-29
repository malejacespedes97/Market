using Azure;
using Market.API.Data;
using Market.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.API.Controllers
{
    //las interfaces se implementan colocando : ejemplo ContriesController:ControllerBase
    //para que se entienda que es un controlador de APi, hay que ponerle una etiqueta que se pone encima del nombre de la clase [ApiController]

    [ApiController]
    [Route("api/countries")]
    //El nombre puede quedar en minuscula,es por una regla de Camelcase (cuando declaro una clave inicio con una palabra Mayuscula)
    //La ruta va responder a la ruta que siempre va a responder a la ruta que se ejecuta en el navegador, es decir Api/Countries

    
    public class CountriesController: ControllerBase
    {
        private readonly DataContext _context;
        
        public CountriesController(DataContext context)
        {

            _context = context;
        }
        /*Tener en cuenta en el CRUD

        C->[httpPOST]
        R->[httpGet]-> responden a un select, es decir a una consulta
        U->[HTTPPut]
        D->[HTTPDelete]*/

        [HttpGet]
        public async Task <ActionResult> Get() 
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        //los errores en rojo en los metodos hacen referencia a los retornos
        /*(las cosas deben seguir funcionando mientras se ejecutan otras (debe llevar la notción diamante y se envia la acción <actionresult>)
        Ejemplo:  public async tast <actionresult>
        TODOS los metos los debermos convertir a asincronos*/

        [HttpPost]
        public async Task<ActionResult> Post(Country country) //siempre los post son iguales, solo cambia el nombre de la entidad
        {

            _context.Add(country);
                await _context.SaveChangesAsync();        
            return Ok(country);    
        }
    }
}
