using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB.Core.Application.DTOModel;
using RB.Core.Application.Interface;
using RB.Infrastructure.RB.Infrastructure.Services.User;

namespace RB.Presentation.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRegistration _vehicleRegistration;
        private VehicleDTO vehicleDTO;

        public VehicleController(IVehicleRegistration vehicleRegistration)

        {
            _vehicleRegistration = vehicleRegistration;

        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromForm] VehicleDTO vehicleDTO, IFormFile ImageFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("not a valid request");
            }
            var response = _vehicleRegistration.RegisterVehicle(vehicleDTO, ImageFile);
            return Ok(response);
        }

        [HttpGet]
        [Route("getVehicle/{OwnerId}")]
        public IActionResult GetVehicle(string OwnerId)


        
        
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("not a valid request");
            }
            var response = _vehicleRegistration.GetAllVehicle(OwnerId, Request.Scheme, Request.Host, Request.PathBase);
            return Ok(response);




        }
        [HttpDelete]
        [Route("delete/{VehicleId}")]
        public IActionResult DeleteVehicle( int VehicleId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("not a valid request");
               
            }
            var response = _vehicleRegistration.DeleteVehicle(VehicleId);
            return Ok(response);
        }

    }
}