using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieflix_api.ViewModels
{
    public class GetGenreViewModel
    {
        public int Id {get; set;}
        public string GenreName { get; set; } = "";
    }
}