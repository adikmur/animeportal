using System.Collections.Generic;

namespace AnimePortal
{
    public class SerialMethods
    {
        private List<Serial> _allSerials = new List<Serial>();

        public List<Serial> AllSerials
        {
            get
            {
                return _allSerials;
            }
        }

        public SerialMethods()
        {
            _allSerials.AddRange(new[]
            {
                new Serial
                {
                    Name = "Наруто",
                    Description = "Сериал про мальчика героя",
                    Genres = new List<Genre>
                    {
                        new Genre { Name = "комедия" }
                    },
                    Episodes = new List<Episode>
                    {
                        new Episode { Name = "Наруто родился", Description = "Рождение героя", SeasonNumber = 1 },
                        new Episode { Name = "Наруто ходит в школу", Description = "Школа героя", SeasonNumber = 2 },
                        new Episode { Name = "Смерть наруто", Description = "Смерть героя", SeasonNumber = 3 }
                    }
                },
                new Serial { Name = "Дневник дьявола", Genres = new List<Genre> { new Genre { Name = "ужастик" } } },
                new Serial { Name = "Аниме мульт", Genres = new List<Genre> { new Genre { Name = "приключения" }, new Genre { Name = "романтика" } } },
                new Serial { Name = "Что-то странное", Genres = new List<Genre> { new Genre { Name = "комедия" } } },
                new Serial { Name = "Какие-то заметки", Genres = new List<Genre> { new Genre { Name = "романтика" } } }
            });
        }

        public void AddSerial(Serial serial)
        {
            _allSerials.Add(serial);
        }

        public void AddEpisode(Episode episode, Serial serial)
        {
            serial.Episodes.Add(episode);
        }
    }
}