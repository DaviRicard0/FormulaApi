using FormulaApi.Data;
using FormulaApi.DTOs;
using FormulaApi.Models;
using FormulaApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DriversController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<DriversController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           return Ok(await _unitOfWork.Drivers.GetAll());
        }

        // GET api/<DriversController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);

            if (driver is null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        // POST api/<DriversController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DriverDTO driverDTO)
        {
            var driver = new Driver()
            {
                Id = Guid.NewGuid(),
                DriverNumber= driverDTO.DriverNumber,
                Name= driverDTO.Name,
                Team = driverDTO.Team
            };

            await _unitOfWork.Drivers.Create(driver);
            await _unitOfWork.CompleteAsync();

            return Created($"https://localhost:7245/api/Drivers/{driver.Id}", driver.Id);
        }

        // PUT api/<DriversController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] DriverDTO driverDTO)
        {
            var _driver = await _unitOfWork.Drivers.GetById(id);

            if (_driver is null)
            {
                return NotFound();
            }

            _driver.Name = driverDTO.Name;
            _driver.DriverNumber = driverDTO.DriverNumber;
            _driver.Team = driverDTO.Team;

            await _unitOfWork.Drivers.Update(_driver);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        // DELETE api/<DriversController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);

            if (driver is null)
            {
                return NotFound();
            }

            await _unitOfWork.Drivers.Delete(driver);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
