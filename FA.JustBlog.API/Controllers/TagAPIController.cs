using AutoMapper;
using FA.JustBlog.API.Models;
using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory.IResponsitory;
using FA.JustBlog.Service.IServices;
using FA.JustBlog.Service.Services;
using FA.JustBlog.ViewModel.PostViewModel;
using FA.JustBlog.ViewModel.TagViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace FA.JustBlog.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TagAPIController : ControllerBase
    {
        private readonly ITagService tagService;
        private readonly IMapper mapper;
        private readonly APIResponse _response;

        public TagAPIController(ITagService tagService, IMapper mapper, APIResponse response)
        {
            this.tagService = tagService;
            this.mapper = mapper;
            this._response = response;
        }
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> GetTags()
        {
            try
            {
                IEnumerable<Tag> taglist =  tagService.GetAllEntities();
                _response.Result = mapper.Map<List<TagVM>>(taglist);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id:int}", Name = "GetTag")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetTag(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var tag = tagService.Find(id);
                if (tag == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = mapper.Map<TagVM>(tag);
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
        [HttpPost]
        [Authorize(Roles = "Contributor,Blog Owner")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateTag([FromBody] TagCreateVM createVM)
        {
            try
            {
                //if (await tagService.Find(u => u.Name.ToLower() == createVM.Name.ToLower()) != null)
                //{
                //    ModelState.AddModelError("CustomError", "Tag Name already Exists !");
                //    return BadRequest(ModelState);
                //}
                if (createVM == null)
                {
                    return BadRequest(createVM);
                }
                Tag tag = mapper.Map<Tag>(createVM);
                tagService.AddTag(tag);
                _response.Result = mapper.Map<TagVM>(tag);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtRoute("GetTag", new { id = tag.TagId }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteTag")]
        [Authorize(Roles = "Blog Owner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteTag(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var tag =  tagService.Find(id);
                if (tag == null)
                {
                    return NotFound();
                }
                tagService.DeleteTag(tag);
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
        [HttpPut("{id:int}", Name = "UpdateTag")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateTag(int id, [FromBody] TagVM updateVM)
        {
            try
            {
                if (updateVM == null || id != updateVM.TagId)
                {
                    return BadRequest();
                }
                //if (tagService.Find(u => u.Name.ToLower() == updateVM.Name.ToLower()) != null)
                //{
                //    ModelState.AddModelError("CustomError", "Tag Name already Exists !");
                //    return BadRequest(ModelState);
                //}
                Tag model = mapper.Map<Tag>(updateVM);
                tagService.UpdateTag(model);
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
        [HttpPatch("{id:int}", Name = "UpdateTagPartial")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> UpdateTagPartial(int id, JsonPatchDocument<TagCreateVM> patchDTO)
        {
            try
            {
                if (patchDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var tag = tagService.Find(id);
                TagCreateVM TagVM = mapper.Map<TagCreateVM>(tag);
                if (tag == null)
                {
                    return BadRequest();
                }
                patchDTO.ApplyTo(TagVM, ModelState);
                Tag model = mapper.Map<Tag>(TagVM);
                tagService.UpdateTag(model);
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
        [HttpGet("GetTagByUrlSlug/{urlSlug}", Name = "GetTagByUrlSlug")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> GetTagByUrlSlug(string urlSlug)
        {
            var tag = tagService.GetTagByUrlSlug(urlSlug);
            _response.Result = mapper.Map<TagVM>(tag);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        [HttpGet("GetTagByName/{name}", Name = "GetTagByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> GetTagByName(string name)
        {
            var tag = tagService.GetTagByName(name);
            _response.Result = mapper.Map<TagVM>(tag);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        [HttpGet("GetTagsByPostId/{postId:int}", Name = "GetTagsByPostId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> GetTagsByPostId(int postId)
        {
            var tag = tagService.GetTagsByPostId(postId);
            _response.Result = mapper.Map<List<TagVM>>(tag);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
