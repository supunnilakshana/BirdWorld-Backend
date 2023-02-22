using BirdWorld.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        [HttpGet]
        [Route("Get/{id?}")]
        public ActionResult<Bird> Get(int id)
        {
            return Ok();
        }


        [HttpGet]
        [Route("Get")]
        public ActionResult<ICollection<Bird>> Get()
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
