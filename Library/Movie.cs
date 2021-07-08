using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Movie
    {
        public Movie()
        {

        }

        public Movie(string title, DateTime releaseDate)
        {
            Title = title;
            ReleaseDate = releaseDate;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
