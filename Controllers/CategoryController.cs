using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPatternAPI.Models;
using RepoPatternAPI.UoW;

namespace RepoPatternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _unitOfWork.Categories.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var categorie = await _unitOfWork.Categories.GetById(id);

            if (categorie == null)
            {
                return NotFound();
            }

            return Ok(categorie);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            try
            {
                await _unitOfWork.Categories.Add(category);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction(nameof(GetCategories), new { id=category.CategoryID},category);
            }
            catch (Exception)
            {

                throw;
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryID)
            {
                return BadRequest();
            }

            await _unitOfWork.Categories.Update(category);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _unitOfWork.Categories.Delete(id);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }



    }
}
