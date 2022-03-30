using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace movieflix_api.Models
{
  public class Movie
  {
    public Movie()
    {
      Title = string.Empty;
      Length = string.Empty;
      Director = string.Empty;
      ImageUrl = string.Empty;
      Genre = new Genre();
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public string Length { get; set; }
    public string Director { get; set; }
    public int GenreId { get; set; }
    public string ImageUrl { get; set; }

    // Navigationprop(FK)
    [ForeignKey("GenreId")]
    public virtual Genre Genre {get; set;}
  }
}