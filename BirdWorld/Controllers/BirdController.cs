using AutoMapper;
using BirdWorld.Helpers;
using BirdWorld.Models;
using BirdWorld.Models.RequestModels;
using BirdWorld.Services.AppServices.BirdService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace BirdWorld.Controllers
{
   // [Authorize(Roles = AccessHelper.anyoneAccess)]
    [Route("api/bird")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        private readonly IBirdRepository _birdService;
        private readonly IMapper _mapper;

        public BirdController(IBirdRepository BirdRepository, IMapper mapper)
        {
            _birdService = BirdRepository;
            _mapper = mapper;
        }



        [HttpGet]
        [Route("Get/{id?}")]
        public ActionResult<BirdDto> Get(int id)
        {
            try
            {

                var res = _birdService.GetBird(id);
             
                if (res != null)
                {
                    return Ok(_mapper.Map<BirdDto>(res));
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


       /* [HttpGet]
        [Route("GetUsers/{id?}")]
        public ActionResult<Bird> GetPostBird(int id)
        {
            try
            {

                var res = _birdService.GetPostBirds(id);

                if (res != null)
                {
                    var mappedList = _mapper.Map<ICollection<BirdDto>>(res);
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
        }*/


        [HttpGet]
        [Route("Get")]
        public ActionResult<ICollection<BirdDto>> Get()
        {
            try
            {

                var res = _birdService.GetAllBirds();
                if (res != null)
                {
                    var mappedList = _mapper.Map<ICollection<BirdDto>>(res);
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
        public ActionResult Create(BirdRequest bird)
        {
            try
            {
                var dBird = new Bird
                { 
                    AvgLife = bird.AvgLife,
                    CommonName= bird.CommonName,
                    Deit= bird.Deit,
                    Description= bird.Description,  
                    Group = bird.Group,
                    Height= bird.Height,
                    Weight = bird.Weight,
                    ScienceName = bird.ScienceName,
                    Created= bird.Created,
                    Images= bird.Images,
                    
                    

       

                };
                var res = _birdService.CreatBird(dBird);
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
        public ActionResult Update(BirdRequest bird)
        {
            try
            {

                if (bird.Id is not null)
                {


                    var dBird = new Bird
                    {
                        Id = bird.Id.Value,
                        AvgLife = bird.AvgLife,
                        CommonName = bird.CommonName,
                        Deit = bird.Deit,
                        Description = bird.Description,
                        Group = bird.Group,
                        Height = bird.Height,
                        Weight = bird.Weight,
                        ScienceName = bird.ScienceName,
                        Created = bird.Created,
                        Images = bird.Images,
                    };
                    var res = _birdService.UpdateBird(dBird);
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

                var res = _birdService.DeleteBird(id);
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
