using PlatformService.Models;


namespace PlatformService.Data;
public interface IPlatformRepo
{
    bool SaveChanges();


    //using PlatformService.Models;
    IEnumerable<Platform> GetAllPlatforms();
    Platform GetPlatformById(int id);
    void CreatePlatform(Platform plat);
}
