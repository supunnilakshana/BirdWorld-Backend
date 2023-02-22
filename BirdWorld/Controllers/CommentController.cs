using BirdWorld.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        [HttpGet]
        [Route("Get")]
        public ActionResult<Comment> Get(int id)
        {
            return Ok();
        }


        [HttpGet]
        [Route("Get")]
        public ActionResult<ICollection<Comment>> Get()
        {
            return Ok();
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult Create()
        {
            return Ok();
        }


        [HttpPut]
        [Route("Update")]
        public IActionResult Update()
        {
            return Ok();
        }


        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
