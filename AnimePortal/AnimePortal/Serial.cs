using System.Collections.Generic;
using System.Linq;

namespace AnimePortal
{
    class Serial
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Season> Seasons { get; set; }
        public List<Genre> Genres { get; set; }

        public string AllGenres
        {
            get
            {
                string allGenres = "Жанры: ";
                foreach (var genre in Genres)
                    allGenres += genre.Name + (genre == Genres.Last() ? "" : ", ");
                return allGenres;
            }
        }
    }
}
