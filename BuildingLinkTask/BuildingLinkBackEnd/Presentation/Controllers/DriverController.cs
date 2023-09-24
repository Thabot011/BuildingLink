using Contract;
using Domain.Constants;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/drivers")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        [Route("getAllDrivers")]
        public async Task<ActionResult<List<DriverDto>>> GetAllDrivers(Constants.SortDirection sortDirection)
        {
            var drivers = await _driverService.GetAllAsync(sortDirection);

            return Ok(drivers);
        }

        [HttpGet]
        [Route("getDriverById/{id}")]
        public async Task<ActionResult<DriverDto>> GetDriverById(int id, Constants.SortDirection sortDirection)
        {
            var driver = await _driverService.GetByIdAsync(id, sortDirection);

            if (driver == null)
            {
                return Ok("Driver doesn't exist");
            }
            return Ok(driver);
        }

        [HttpPost]
        [Route("createDriver")]
        public async Task<IActionResult> CreateDriver([FromBody] CreateDriverDto model)
        {
            await _driverService.CreateAsync(model);

            return Ok();
        }

        [HttpPut]
        [Route("updateDriver")]
        public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverDto model)
        {
            await _driverService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete]
        [Route("deleteDriver/{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            await _driverService.DeleteAsync(id);

            return Ok();
        }


        [HttpPost]
        [Route("createDriversRandomly")]
        public async Task<IActionResult> CreateDriversRandomly()
        {

            await _driverService.BulkCreateAsync(10);// 10 Drivers randomly;

            return Ok();
        }

    }
}
