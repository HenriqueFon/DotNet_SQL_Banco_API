using Concessonaria.Models;
using Concessonaria.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Concessonaria.Controllers
{
    [Route("/")]
    [ApiController]
    public class ConcessonariaController : ControllerBase
    {
        private readonly IConcessonariaRepository _concessonaria;

        public ConcessonariaController(IConcessonariaRepository concessonaria)
        {
            _concessonaria = concessonaria;
        }

        [HttpGet("Cars")]
        public async Task<IActionResult> GetCars(int skip, int take)
        {
            var cars = await _concessonaria.GetCarsAsync(skip, take);
            return Ok(cars);
        }

        [HttpPost("Create", Name = "Post")]
        [ActionName(nameof(CreateCars))]
        public async Task<ActionResult<Cars>> CreateCars(Cars car){
            
            var newCar = await _concessonaria.CreateCarsAsync(car);

            if(newCar != null)
            {
                return new JsonResult(Ok(newCar));
            }

            return Problem("Failed to insert the contact");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCars(int id, Cars car)
        {
            await _concessonaria.UpdateCar(id, car);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCars(int id)
        {
            await _concessonaria.DeleteCar(id);

            return NoContent();
        }
    }
}
