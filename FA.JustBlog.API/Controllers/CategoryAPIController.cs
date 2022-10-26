using AutoMapper;
using FA.JustBlog.API.Models;
using FA.JustBlog.Entities.Models;
using FA.JustBlog.Service.IServices;
using FA.JustBlog.ViewModel.CategoryViewModel;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Net;

namespace FA.JustBlog.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoryAPIController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly APIResponse _response;
        public CategoryAPIController(ICategoryService categoryService, IMapper mapper, APIResponse response)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
            _response = response;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetCategories()
        {
            try
            {
                IEnumerable<Category> categories =  categoryService.GetAllEntities();
                _response.Result = mapper.Map<List<CategoryVM>>(categories);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        [Authorize(Roles = "Contributor,Blog Owner")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateCategory([FromBody] CategoryCreateVM createVM)
        {
            try
            {
                //if (await categoryResponsitory.GetAsync(u => u.Name.ToLower() == createVM.Name.ToLower()) != null)
                //{
                //    ModelState.AddModelError("CustomError", "Category Name already Exists !");
                //    return BadRequest(ModelState);
                //}
                if (createVM == null)
                {
                    return BadRequest(createVM);
                }
                Category category = mapper.Map<Category>(createVM);
                categoryService.AddCategory(category);
                _response.Result = mapper.Map<CategoryVM>(category);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtRoute("GetCategory", new { id = category.CategoryId }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id:int}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetCategory(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var category = categoryService.Find(id);
                if (category == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = mapper.Map<CategoryVM>(category);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteCategory")]
        [Authorize(Roles = "Blog Owner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteCategory(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var post = categoryService.Find(id);
                if (post == null)
                {
                    return NotFound();
                }
                categoryService.DeleteCategory(post);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPut("{id:int}", Name = "UpdateCategory")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateCategory(int id, [FromBody] CategoryVM updateVM)
        {
            try
            {
                if (updateVM == null || id != updateVM.CategoryId)
                {
                    return BadRequest();
                }
                //if (categoryService.GetAsync(u => u.Name.ToLower() == updateVM.Name.ToLower()) != null)
                //{
                //    ModelState.AddModelError("CustomError", "Category Name already Exists !");
                //    return BadRequest(ModelState);
                //}
                Category model = mapper.Map<Category>(updateVM);
                categoryService.UpdateCategory(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPatch("{id:int}", Name = "UpdateCategoryPartial")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateCategoryPartial(int id, JsonPatchDocument<CategoryUpdateVM> patchDTO)
        {
            try
            {
                if (patchDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var category =  categoryService.Find(id);
                CategoryUpdateVM categoryUpdate = mapper.Map<CategoryUpdateVM>(category);
                if (category == null)
                {
                    return BadRequest();
                }
                patchDTO.ApplyTo(categoryUpdate, ModelState);
                Category model = mapper.Map<Category>(categoryUpdate);
                categoryService.UpdateCategory(model);
                if (ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("GetCategoryByName/{name}", Name = "GetCategoryByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> GetCategoryByName(string name)
        {

            var category = categoryService.GetCategoryByName(name);
            if(category==null)
            {
                ModelState.AddModelError("CustomError", "Category Name is not Exists !");
                return BadRequest(ModelState);
            }
            _response.Result = mapper.Map<CategoryVM>(category);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        [HttpGet("GetCategoriesByPostId/{Id:int}", Name = "GetCategoriesByPostId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> GetCategoriesByPostId(int Id)
        {

            var category = categoryService.GetCategoriesByPostId(Id);
            if (category == null)
            {
                ModelState.AddModelError("CustomError", "Category Id is not Exists !");
                return BadRequest(ModelState);
            }
            _response.Result = mapper.Map<CategoryVM>(category);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
