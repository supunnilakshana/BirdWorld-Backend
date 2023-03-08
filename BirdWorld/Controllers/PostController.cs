using AutoMapper;
using BirdWorld.Config;
using BirdWorld.Helpers;
using BirdWorld.Models;
using BirdWorld.Models.RequestModels;
using BirdWorld.Services.AppServices.PostService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BirdWorld.Controllers
{
  //  [Authorize(Roles =AccessHelper.anyoneAccess)]
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
       private readonly IPostRepository _postService;
        private readonly IMapper _mapper;

        public PostController(IPostRepository  postRepository, IMapper mapper)
        {
            _postService = postRepository;
            _mapper = mapper;
        }

       

        [HttpGet]
        [Route("Get/{id?}")]
        public  ActionResult<PostDto > Get(int id)
        {
            try
            {

                var res = _postService.GetPost(id);
                if (res!=null)
                {
                    return Ok(_mapper.Map<PostDto>(res));
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("GetUsers/{id?}")]
        public ActionResult<Post> GetuserPost(String id)
        {
            try
            {

                var res = _postService.GetAllPostsByUid(id);

                if (res != null)
                {
                    var mappedList = _mapper.Map<ICollection<PostDto>>(res);
                    return Ok(mappedList);
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("Get")]
        public ActionResult<ICollection<PostDto>> Get()
        {
            try
            {

                var res = _postService.GetAllPosts();
                if (res != null)
                {
                    var mappedList=_mapper.Map<ICollection<PostDto>>(res);
                    return Ok(mappedList);
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
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
             var res=  _postService.CreatePost(dPost);
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
                
                return BadRequest(ex.Message);
            }

          
        }


        [HttpPut]
        [Route("Update")]
        public ActionResult Update(PostRequest post)
        {
            try
            {
               
                if (post.Id is not null)
                {

                  Console.WriteLine(post.Id.ToString());

                   var dPost = new Post
                    {
                        Id = post.Id.Value,
                        Title = post.Title,
                        Description= post.Description,
                        UserId = post.UserId,
                        Updated=DateTime.Now,
                    };
                    var res = _postService.UpdatePost(dPost);
                    Console.WriteLine(res);
                    if (res)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

           
        }


        [HttpDelete]
        [Route("Delete/{id?}")]
        public  ActionResult Delete(int id)
        {
            try
            {

                var res = _postService.DeletePost(id);
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

                return BadRequest(ex.Message);
            }
        }

    }
}
