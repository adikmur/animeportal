using System.Collections.Generic;
using System.Linq;

namespace AnimePortal
{
    public class Serial
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Episode> Episodes { get; set; } = new List<Episode>();
        public List<Genre> Genres { get; set; } = new List<Genre>();

        public string AllGenres
        {
            get
            {
                if (Genres.Count == 0)
                    return "Не указан жанр";

                string allGenres = "Жанры: ";
                foreach (var genre in Genres)
                    allGenres += genre.Name + (genre == Genres.Last() ? "" : ", ");
                return allGenres;
            }
        }
    }
}
