using AutoMapper;
using FA.JustBlog.API.Models;
using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory.IResponsitory;
using FA.JustBlog.Service.IServices;
using FA.JustBlog.Service.Services;
using FA.JustBlog.ViewModel.CommentViewModel;
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
    public class CommentAPIController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;
        private readonly APIResponse _response;

        public CommentAPIController(ICommentService commentService, IMapper mapper, APIResponse response)
        {
            this.commentService = commentService;
            this.mapper = mapper;
            this._response = response;
        }
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> GetComments()
        {
            try
            {
                IEnumerable<Comment> commentlist =  commentService.GetAllEntities();
                _response.Result = mapper.Map<List<CommentVM>>(commentlist);
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
        [HttpGet("{id:int}", Name = "GetComment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetComment(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var comment =  commentService.Find(id);
                if (comment == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = mapper.Map<CommentVM>(comment);
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
        [Authorize(Roles = "Blog Owner")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateComment([FromBody] CommentCreateVM createVM)
        {
            try
            {
                //if ( commentService.GetAsync(u => u.CommentHeader.ToLower() == createVM.CommentHeader.ToLower()) != null)
                //{
                //    ModelState.AddModelError("CustomError", "Comment Header already Exists !");
                //    return BadRequest(ModelState);
                //}
                if (createVM == null)
                {
                    return BadRequest(createVM);
                }
                Comment comment = mapper.Map<Comment>(createVM);
                commentService.AddComment(comment);
                _response.Result = mapper.Map<CommentVM>(comment);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtRoute("GetCommnent", new { id = comment.CommentId }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteComment")]
        [Authorize(Roles = "Blog Owner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteComment(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var comment =  commentService.Find(id);
                if (comment == null)
                {
                    return NotFound();
                }
                commentService.DeleteComment(comment);
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
        [HttpPut("{id:int}", Name = "UpdateComment")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateComment(int id, [FromBody] CommentVM updateVM)
        {
            try
            {
                if (updateVM == null || id != updateVM.PostId)
                {
                    return BadRequest();
                }
                //if (commentService.GetAsync(u => u.CommentHeader.ToLower() == updateVM.CommentHeader.ToLower()) != null)
                //{
                //    ModelState.AddModelError("CustomError", "Comment Header already Exists !");
                //    return BadRequest(ModelState);
                //}
                Comment model = mapper.Map<Comment>(updateVM);
                commentService.UpdateComment(model);
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
        [HttpPatch("{id:int}", Name = "UpdateCommentPartial")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> UpdateCommentPartial(int id, JsonPatchDocument<CommentCreateVM> patchDTO)
        {
            try
            {
                if (patchDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var comment = commentService.Find(id);
                CommentCreateVM commentCreate = mapper.Map<CommentCreateVM>(comment);
                if (comment == null)
                {
                    return BadRequest();
                }
                patchDTO.ApplyTo(commentCreate, ModelState);
                Comment model = mapper.Map<Comment>(commentCreate);
                commentService.UpdateComment(model);
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
        [HttpGet("GetCommentsForPost/{postId:int}", Name = "GetCommentsForPost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> GetCommentsForPost(int postId)
        {
            var comments = commentService.GetCommentsForPost(postId);
            _response.Result = mapper.Map<List<CommentVM>>(comments);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

    }
}
