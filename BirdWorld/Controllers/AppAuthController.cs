using AutoMapper;
using BirdWorld.Config;
using BirdWorld.Helpers;
using BirdWorld.Models;
using BirdWorld.Models.RequestModels;
using BirdWorld.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IConfiguration config;

        public AppAuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration config)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.config = config;
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
                        await signInManager.SignOutAsync();
                        var roles = await userManager.GetRolesAsync(user);
                        var role = roles.First();
                        Console.WriteLine(role);
                        if (role is not null)
                        {
                            String acesstoken = new JwtHelper().createToken(user, role);
                            var mappedUser = mapper.Map<AppUserDto>(user);
                            mappedUser.Role = role;
                            return Ok(
                                new UserAuthResponse {
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
                        LastName = newUserRequest.LastName,
                        

                    };


                    var res = await userManager.CreateAsync(newuser, newUserRequest.Password);


                    if (res.Succeeded)
                    {
                        var role = await roleManager.FindByNameAsync(newUserRequest.Role);
                        var regiUser = await userManager.FindByEmailAsync(newuser.Email);



                        if (role != null && regiUser != null)
                        {

                            var identityResult = await userManager.AddToRoleAsync(regiUser, role.Name);
                            if (identityResult.Succeeded)
                            {

                                String acesstoken = new JwtHelper().createToken(regiUser, role.Name);
                                var mappedUser = mapper.Map<AppUserDto>(newuser);
                                mappedUser.Role = role.Name;
                                return Ok(
                                    new {
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





        [Authorize]
        [HttpPost]
        [Route("authcheck")]
       
        public async Task<ActionResult> AuthCheck()
        {

           

            /*if (newUserRequest == null)
            {

                return BadRequest();
            }
           
            else
            {
                try
                {
                   


                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }

            }*/

            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("changepassword")]
        public async Task<ActionResult> ChangePassword(ChangePasswordRequest changePasswordRequest)
        {

            if (changePasswordRequest == null)
            {
                
                

                return BadRequest();
            }

            else
            {
                try
                {
                    var appuser =await  userManager.FindByIdAsync(changePasswordRequest.UserId);

                   

                    if (appuser is not null)
                    {
                      await   userManager.ChangePasswordAsync(appuser, changePasswordRequest.oldPassword, changePasswordRequest.newPassword);

                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }



                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }


            }
        }


   
        [HttpGet]
        [Route("verifyuser")]

        public async Task<ActionResult<bool>> VerifyUser(String email) {

           EmailHelper emailHelper = new EmailHelper(config);
            await emailHelper.SendPwRestEmail("supunnikz@gmail.com", "ssdsdsd");
     
            return Ok(true);

           /* if (email == null)
            {

                return BadRequest();
            }

            else
            {
                try
                {
                    var appuser=await userManager.FindByEmailAsync(email);
                    if (appuser !=null) {

                        return Ok(true);

                    }
                    else
                    {
                          return Ok(false);
                    }



                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }


            }*/


        }

        [HttpGet]
        [Route("reqpwrest")]

        public async Task<ActionResult<bool>> ReqPWRest(String email)
        {



            if (email == null)
            {

                return BadRequest();
            }

            else
            {
                try
                {
                    var appuser = await userManager.FindByEmailAsync(email);
                    if (appuser != null)
                    {
                        String resetToken = await userManager.GeneratePasswordResetTokenAsync(appuser);

                        FirebaseDynamicLinksService dynamicLinksService = new FirebaseDynamicLinksService();
                        String? dlink=await dynamicLinksService.CreateDynamicLinkAsync(resetToken);
                        if (dlink is not null)
                        {
                            return Ok(true);
                        }
                        else
                        {
                            return BadRequest();
                        }

                    }
                    else
                    {
                        return Ok(false);
                    }



                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }


            }


        }

        [HttpGet]
        [Route("resetpassword")]

        public async Task<ActionResult<bool>> RestPassword(ResetPasswordRequest resetPasswordRequest)
        {



            if (resetPasswordRequest == null)
            {

                return BadRequest();
            }

            else
            {
                try
                {
                    var appuser = await userManager.FindByEmailAsync(resetPasswordRequest.email);
                    if (appuser != null)
                    {
                        var res = await userManager.ResetPasswordAsync(
                            appuser,resetPasswordRequest.token,
                            resetPasswordRequest.newPassword
                            );

                  
                        if (res.Succeeded)
                        {
                            return Ok(true);
                        }
                        else
                        {
                            return BadRequest();
                        }

                    }
                    else
                    {
                        return Ok(false);
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
