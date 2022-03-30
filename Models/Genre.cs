using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieflix_api.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; } = "";
        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}