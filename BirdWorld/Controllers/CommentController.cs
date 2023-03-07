using AutoMapper;
using BirdWorld.Models;
using BirdWorld.Models.RequestModels;
using BirdWorld.Services.AppServices.CommentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdWorld.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentRepository CommentRepository, IMapper mapper)
        {
            _commentService = CommentRepository;
            _mapper = mapper;
        }



        [HttpGet]
        [Route("Get/{id?}")]
        public ActionResult<CommentDto> Get(int id)
        {
            try
            {

                var res = _commentService.GetComment(id);
                if (res != null)
                {
                    return Ok(_mapper.Map<CommentDto>(res));
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
        public ActionResult<Comment> GetPostComment(int id)
        {
            try
            {

                var res = _commentService.GetPostComments(id);

                if (res != null)
                {
                    var mappedList = _mapper.Map<ICollection<CommentDto>>(res);
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
        public ActionResult<ICollection<CommentDto>> Get()
        {
            try
            {

                var res = _commentService.GetAllComments();
                if (res != null)
                {
                    var mappedList = _mapper.Map<ICollection<CommentDto>>(res);
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
        public ActionResult Create(CommentRequest Comment)
        {
            try
            {
                var dComment = new Comment
                {
                   Context = Comment.Context,
                   PostID = Comment.PostID,
                    UserId = Comment.UserId,

                };
                var res = _commentService.CreatComment(dComment);
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
                Console.WriteLine(ex.Message);

                return BadRequest(ex.Message);
            }


        }


        [HttpPut]
        [Route("Update")]
        public ActionResult Update(CommentRequest Comment)
        {
            try
            {

                if (Comment.Id is not null)
                {

                    Console.WriteLine(Comment.Id.ToString());

                    var dComment = new Comment
                    {
                        Id = Comment.Id.Value,
                        Context = Comment.Context,
                        PostID = Comment.PostID,
                        UserId = Comment.UserId,
                        Updated=DateTime.Now,
                    };
                    var res = _commentService.UpdateComment(dComment);
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
        public ActionResult Delete(int id)
        {
            try
            {

                var res = _commentService.DeleteComment(id);
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
