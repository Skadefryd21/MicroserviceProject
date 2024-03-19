using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        //Inject repository & automapper
        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms. . .");

            IEnumerable<Platform> platformEntities = _repository.GetAllPlatforms();

                            //Map<target>(source)
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformEntities));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            Console.WriteLine($"--> Getting Platform by id: {id} . . .");

            Platform platformEntity = _repository.GetPlatformById(id);

            if(platformEntity != null)
            return Ok(_mapper.Map<PlatformReadDto>(platformEntity));

            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            Platform platformModel = _mapper.Map<Platform>(platformCreateDto);

            bool result = _repository.CreatePlatform(platformModel);

            if (result){
            
            _repository.SaveChanges();

            PlatformReadDto platformResponse = _mapper.Map<PlatformReadDto>(platformModel);

            //Returns Http201(Created), method signature is CreatedAtRoute(string? route, Object? value)
            return CreatedAtRoute(nameof(GetPlatformById), new {Id = platformResponse.Id}, platformResponse);
            }

            return BadRequest(nameof(platformModel));
        }
    }
}