using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieflix_api.ViewModels
{
    public class ListMoviesViewModel
    {
    public int MovieId { get; set; }
    public string Title { get; set; } ="";
    public int ReleaseYear { get; set; }
    public string Length { get; set; } ="";
    public string Director { get; set; } ="";
    public string Genre { get; set; } ="";
    public string ImageUrl { get; set; } ="";
    }
}