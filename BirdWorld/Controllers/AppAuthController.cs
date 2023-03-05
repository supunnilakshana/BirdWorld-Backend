using AutoMapper;
using BirdWorld.Config;
using BirdWorld.Helpers;
using BirdWorld.Models;
using BirdWorld.Models.RequestModels;
using BirdWorld.Models.ResponseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace BirdWorld.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AppAuthController : ControllerBase
    {

        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;

        public AppAuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }


        [HttpPost]
        [Route("signin")]
        public async Task<ActionResult<UserAuthResponse>> Signin(UserAuthRequest authRequest)
        {

               if (authRequest == null)
            {
                return BadRequest();    
            }
            else
            {
                var user = await userManager.FindByEmailAsync(authRequest.Email);
               if (user != null)
                {
                    var res = await signInManager.PasswordSignInAsync(user, authRequest.Password, false, false);
                    if (res.Succeeded) {
                      await  signInManager.SignOutAsync();
                        var roles = await userManager.GetRolesAsync(user);
                        var role = roles.First();
                        Console.WriteLine(role);
                         if (role is not null)
                        {
                            String acesstoken = new JwtHelper().createToken(user, role);
                            var mappedUser=  mapper.Map<AppUserDto>(user);
                            mappedUser.Role= role;
                            return Ok(
                                new UserAuthResponse{
                                    user = mappedUser,
                                    token = acesstoken
                                }
                           );
                        }
                        else
                        {
                            return BadRequest("registaion failed");
                        }



                      
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
        
        
        }

        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<UserAuthResponse>> Signup(NewUserRequest newUserRequest)
        {

            if (newUserRequest == null)
            {

                return BadRequest();
            }
            else if (newUserRequest.Role.Equals(((int)AppUserRoles.Admin).ToString()))
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    AppUser newuser = new AppUser
                    {
                        UserName = newUserRequest.Email,
                        Email = newUserRequest.Email,
                        FirstName = newUserRequest.FirstName,
                        LastName = newUserRequest.LastName
                        
                    };

                        
                   var res=  await userManager.CreateAsync(newuser,newUserRequest.Password);
                   
                   
                    if (res.Succeeded)
                    {
                        var role = await roleManager.FindByNameAsync(newUserRequest.Role);
                        var regiUser = await userManager.FindByEmailAsync(newuser.Email);  
                        
                        if (role !=null && regiUser!=null)
                        {
                            
                          var identityResult=  await userManager.AddToRoleAsync(regiUser,role.Name); 
                            if (identityResult.Succeeded)
                            {
                                String acesstoken = new JwtHelper().createToken(regiUser, role.Name);
                                var mappedUser = mapper.Map<AppUserDto>(newuser);
                                mappedUser.Role = role.Name;
                                return Ok(
                                    new {
                                   user=mappedUser,
                                   token=acesstoken
                                }
                               );
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
}
