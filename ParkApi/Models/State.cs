using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ParkApi.Models
{
  public class State
  {
    public int StateId { get; set; }
    [Required]
    public string Name { get; set; }
    public int NumberParks { get; set; }
    [JsonIgnore]
    public virtual ICollection<Park> Parks { get; set; }

    public State()
    {
      this.Parks = new HashSet<Park>();
    }

  }
}