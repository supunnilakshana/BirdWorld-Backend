using BirdWorld.Config;
using BirdWorld.Helpers;
using BirdWorld.Models;
using BirdWorld.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BirdWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public ConfigController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        [HttpGet]
        [Route("AdminConfig")]
        public async Task<ActionResult> AdminConfig()
        {
            try
            {
                AppUser newuser = new AppUser
                {
                    UserName = "bwadmin@gmail.com",
                    Email = "bwadmin@gmail.com",
                    DisplayName = "Bird Word Admin"
                };


                var res = await userManager.CreateAsync(newuser, "B123456@123w");


                if (res.Succeeded)
                {
                    var role = await roleManager.FindByNameAsync(AppUserRoles.Admin.ToString());
                    var regiUser = await userManager.FindByEmailAsync(newuser.Email);

                    if (role != null && regiUser != null)
                    {

                        var identityResult = await userManager.AddToRoleAsync(regiUser, role.Name);
                        if (identityResult.Succeeded)
                        {
                            String acesstoken = new JwtHelper().createToken(regiUser, role.Name);
                            return Ok("configuration successfull");
                        }
                        else
                        {
                            return BadRequest("registaion failed");
                        }

                    }
                    else
                    {
                        return BadRequest("registaion failed");
                    }

                }
                else
                {
                    return BadRequest("registaion failed");
                }

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
