using System.ComponentModel.DataAnnotations;


namespace PlatformService.Dtos;
public class PlatformCreateDto
{
    //using System.ComponentModel.DataAnnotations;
    [Required]
    public string Name { get; set; }


    [Required]
    public string Publisher { get; set; }


    [Required]
    public string Cost { get; set; }
}
