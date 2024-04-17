using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        //Inject repository & automapper
        public PlatformsController(IPlatformRepo repository, IMapper mapper, ICommandDataClient commandDataClient)
        {
            
            _repository = repository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
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
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            Platform platformModel = _mapper.Map<Platform>(platformCreateDto);

            bool result = _repository.CreatePlatform(platformModel);

            if (result)
            {
            _repository.SaveChanges();
            PlatformReadDto platformResponse = _mapper.Map<PlatformReadDto>(platformModel);

            Console.WriteLine("--> Trying to send platform to dataclient service");
            try
            {
                await _commandDataClient.SendPlatformToCommand(platformResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            //Returns Http201(Created), method signature is CreatedAtRoute(string? route, Object? value)
            return CreatedAtRoute(nameof(GetPlatformById), new {Id = platformResponse.Id}, platformResponse);
            }

            return BadRequest(nameof(platformModel));
        }
    }
}