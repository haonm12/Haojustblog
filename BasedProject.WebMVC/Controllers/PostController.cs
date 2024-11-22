using BasedProject.DataAccess.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace BasedProject.WebMVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            var posts = _postRepository.GetAllPosts();
            return View(posts);
        }
        public IActionResult Details(int id)
        {
            var post = _postRepository.FindPost(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
    }
}
