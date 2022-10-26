using AutoMapper;
using FA.JustBlog.Service.IServices;
using FA.JustBlog.ViewModel.PostViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FA.JustBlog.Web.Controllers
{
    //public class PostController : Controller
    //{
    //    private readonly IPostService postService;
    //    private readonly IMapper _mapper;
    //    public PostController(IPostService postService, IMapper mapper)
    //    {
    //        this.postService = postService;
    //        _mapper = mapper;
    //    }
    //    public async Task<IActionResult> Create()
    //    {
    //        return View();
    //    }
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create(PostCreateVM postCreate)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var response = await postService.CreateAsync<APIResponse>(postCreate);
    //            if (response != null && response.IsSuccess)
    //            {
    //                return RedirectToAction(nameof(Index));
    //            }
    //        }
    //        return View(postCreate);
    //    }
    //    public async Task<IActionResult> Index()
    //    {
    //        List<PostVM> list = new();
    //        var response = await postService.GetAllASync<APIResponse>();
    //        if (response != null && response.IsSuccess)
    //        {
    //            list = JsonConvert.DeserializeObject<List<PostVM>>(Convert.ToString(response.Result));
    //        }
    //        return View(list);
    //    }
    //}
}
