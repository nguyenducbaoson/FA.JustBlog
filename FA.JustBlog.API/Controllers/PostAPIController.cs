using AutoMapper;
using FA.JustBlog.API.Models;
using FA.JustBlog.Entities.Models;
using FA.JustBlog.Responsitory.IResponsitory;
using FA.JustBlog.Responsitory.Responsitory;
using FA.JustBlog.Service.IServices;
using FA.JustBlog.Service.Services;
using FA.JustBlog.ViewModel.PostViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Drawing;
using System.Net;

namespace FA.JustBlog.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PostAPIController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly IMapper mapper;
        private readonly APIResponse _response;

        public PostAPIController(IPostService postService, IMapper mapper, APIResponse response)
        {
            this.postService = postService;
            this.mapper = mapper;
            this._response = response;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> GetPosts()
        {
            try
            {
                var postlist = postService.GetAllEntities();
                _response.Result = mapper.Map<List<PostVM>>(postlist);
                _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id:int}", Name = "GetPost")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> GetPost(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var post = postService.Find(id);
                if (post == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = mapper.Map<PostVM>(post);
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
        //[Authorize(Roles = "Contributor,Blog Owner")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreatePost([FromBody] PostCreateVM createVM)
        {
            try
            {
                //if (await postService.GetAsync(u => u.PostContent.ToLower() == createVM.PostContent.ToLower()) != null)
                //{
                //    ModelState.AddModelError("CustomError", "Post Content already Exists !");
                //    return BadRequest(ModelState);
                //}
                if (createVM == null)
                {
                    return BadRequest(createVM);
                }
                Post post = mapper.Map<Post>(createVM);
                post.PostOn = DateTime.Now;
                postService.AddPost(post);
                _response.Result = mapper.Map<PostVM>(post);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtRoute("GetPost", new { id = post.PostId }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeletePost")]
        [Authorize(Roles = "Blog Owner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeletePost(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var post = postService.Find(id);
                if (post == null)
                {
                    return NotFound();
                }
                 postService.DeletePost(post);
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
        [HttpPut("{id:int}", Name = "UpdatePost")]
        //[Authorize(Roles = "Contributor,Blog Owner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdatePost(int id, [FromBody] PostVM updateVM)
        {
            try
            {
                if (updateVM == null || id != updateVM.PostId)
                {
                    return BadRequest();
                }
                //if (await pos.GetAsync(u => u.PostContent.ToLower() == updateVM.PostContent.ToLower()) != null)
                //{
                //    ModelState.AddModelError("CustomError", "Post Content already Exists !");
                //    return BadRequest(ModelState);
                //}
                Post model = mapper.Map<Post>(updateVM);
                postService.UpdatePost(model);
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
        [HttpPatch("{id:int}", Name = "UpdatePostPartial")]
        //[Authorize(Roles = "Contributor,Blog Owner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> UpdatePostPartial(int id, JsonPatchDocument<PostCreateVM> patchDTO)
        {
            try
            {
                if (patchDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var post =  postService.Find(id);
                PostCreateVM createVM = mapper.Map<PostCreateVM>(post);
                if (post == null)
                {
                    return BadRequest();
                }
                patchDTO.ApplyTo(createVM, ModelState);
                Post model = mapper.Map<Post>(createVM);
                postService.UpdatePost(model);
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
        [HttpGet("GetPostsByCategory/{categoryName}", Name = "GetPostsByCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> GetPostsByCategory(string categoryName)
        {
            var posts =  postService.GetPostsByCategory(categoryName);
            _response.Result = mapper.Map<List<PostVM>>(posts);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        [HttpGet("MostViewedPosts/{size:int}", Name = "MostViewedPosts")]
        public ActionResult<APIResponse> MostViewedPosts(int size)
        {
            var posts = postService.GetMostViewedPost(size).ToList();
            _response.Result = mapper.Map<List<PostVM>>(posts);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        [HttpGet("LatestPosts/{size:int}", Name = "LatestPosts")]
        public ActionResult<APIResponse> LatestPosts(int size)
        {
            var posts = postService.GetLatestPost(size).ToList();
            _response.Result = mapper.Map<List<PostVM>>(posts);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        [HttpGet("PostPagination/{pageSize:int}/{pageIndex:int}",Name = "PostPagination")]
        public ActionResult<APIResponse> PostPagination(int pageSize,int pageIndex)
        {
            var posts = postService.PostPagination(pageSize,pageIndex).ToList();
            _response.Result = mapper.Map<List<PostVM>>(posts);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

    }
}
