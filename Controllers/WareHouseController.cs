using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPatternAPI.Models;
using RepoPatternAPI.UoW;

namespace RepoPatternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public WareHouseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetWareHouses()
        {
            try
            {
                var warehouses = await _unitOfWork.Warehouses.GetAll();
                return Ok(warehouses);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouse>> GetWareHouse(int id)
        {
            try
            {
                var warehouse = await _unitOfWork.Warehouses.GetById(id);
                if (warehouse == null)
                {
                    return NotFound();
                }
                return Ok(warehouse);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Warehouse>> PostWareHouse(Warehouse warehouse)
        {
            try
            {
                await _unitOfWork.Warehouses.Add(warehouse);
                await _unitOfWork.CompleteAsync();
                return CreatedAtAction(nameof(GetWareHouse), new { id = warehouse.WarehouseId }, warehouse);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Warehouse warehouse)
        {
            if (id != warehouse.WarehouseId)
            {
                return BadRequest();
            }

            await _unitOfWork.Warehouses.Update(warehouse);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _unitOfWork.Warehouses.Delete(id);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }


    }
}
