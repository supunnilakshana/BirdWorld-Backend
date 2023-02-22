using BirdWorld.Models;
using BirdWorld.Services.AppServices.PostService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
       private readonly PostService postService;

        public PostController()
        {
            postService=new PostService();


        }



        [HttpGet]
        [Route("Get/{id?}")]
        public  ActionResult<Post> Get(int id)
        {
            return Ok();
        }


        [HttpGet]
        [Route("Get")]
        public ActionResult<ICollection<Post>> Get()
        {
            return Ok();
        }


        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Post post)
        {
            try
            {
                var dPost = new Post
                {
                    Id = post.Id,
                    Description = post.Description,
                    ImageUrl = post.ImageUrl,
                    Title = post.Title,
                    UserId = post.UserId,

                };
             var res=  postService.CreatePost(dPost);
                if(res)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

                
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

          
        }


        [HttpPut]
        [Route("Update")]
        public ActionResult Update()
        {
            return Ok();
        }


        [HttpDelete]
        [Route("Delete")]
        public  ActionResult Delete()
        {
            return Ok();
        }

    }
}
