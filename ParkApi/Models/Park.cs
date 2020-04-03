using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ParkApi.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Type { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public int StateId { get; set; }
    public virtual State State { get; set; }

  }
}