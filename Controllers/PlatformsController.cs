using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;


namespace PlatformService.Controllers;
//using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    //using PlatformService.Data;
    private readonly IPlatformRepo _repository;
    //using AutoMapper;
    private readonly IMapper _mapper;
    public PlatformsController(IPlatformRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    [HttpGet]
    //using PlatformService.Dtos;
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        Console.WriteLine("--> Getting Platforms....");


        var platformItem = _repository.GetAllPlatforms();




        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
    }


    [HttpGet("{id}", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platformItem = _repository.GetPlatformById(id);
        if (platformItem != null)
        {
            return Ok(_mapper.Map<PlatformReadDto>(platformItem));
        }
        return NotFound();
    }


    [HttpPost]
    public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
        //using PlatformService.Models;
        var platformModel = _mapper.Map<Platform>(platformCreateDto);
        _repository.CreatePlatform(platformModel);
        _repository.SaveChanges();


        var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);


        //Send Sync Message




        //Send Async Message


        return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id}, platformReadDto);
    }
}
