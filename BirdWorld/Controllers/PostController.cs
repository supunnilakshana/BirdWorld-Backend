using BirdWorld.Models;
using BirdWorld.Models.RequestModels;
using BirdWorld.Services.AppServices.PostService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

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
            try
            {

                var res = postService.GetPost(id);
                if (res!=null)
                {
                    return Ok(res);
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }


        [HttpGet]
        [Route("Get")]
        public ActionResult<ICollection<Post>> Get()
        {
            try
            {

                var res = postService.GetAllPosts();
                if (res != null)
                {
                    return Ok( res );
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [Route("Create")]
        public ActionResult Create(PostRequest post)
        {
            try
            {
                var dPost = new Post
                { 
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
                Console.WriteLine(ex.Message);
                
                return BadRequest();
            }

          
        }


        [HttpPut]
        [Route("Update")]
        public ActionResult Update(Post post)
        {
            try
            {
               
                var res = postService.UpdatePost(post);
                if (res)
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


        [HttpDelete]
        [Route("Delete/{id?}")]
        public  ActionResult Delete(int id)
        {
            try
            {

                var res = postService.DeletePost(id);
                if (res)
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

    }
}
