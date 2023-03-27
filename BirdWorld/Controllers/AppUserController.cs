using AutoMapper;
using BirdWorld.Models;
using BirdWorld.Services.AppServices.AppUserService;
using BirdWorld.Services.AppServices.PostService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdWorld.Controllers
{
    [Route("api/appuser")]
    [ApiController]
    public class AppUserController : ControllerBase
    {

        private readonly IAppUserRepository _userService;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserRepository userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }



        [HttpGet]
        [Route("Get/{id?}")]
        public ActionResult<AppUserDto> Get(string id)
        {
            try
            {

                var res = _userService.GetAppUser(id);
                if (res != null)
                {
                    return Ok(_mapper.Map<AppUserDto>(res));
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





    }
}
