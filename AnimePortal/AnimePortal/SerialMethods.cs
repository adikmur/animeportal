using System;
using System.Collections.Generic;
// Для потоков и файлов.
using System.IO;
using System.Linq;
// Для (де)сериализации.
using System.Xml.Serialization;

namespace AnimePortal
{
    public class SerialMethods
    {
        private const string _file = "../../Data/serials.xml";

        private List<Serial> _allSerials = new List<Serial>();
        private List<Genre> _allGenres = new List<Genre>();

        public List<Serial> AllSerials
        {
            get
            {
                return _allSerials;
            }
        }

        public List<Genre> AllGenres
        {
            get
            {
                return _allGenres;
            }
        }

        public SerialMethods()
        {
            Deserialize();
        }

        public void AddSerial(Serial serial)
        {
            foreach (Serial s in _allSerials)
            {
                if (s.Name == serial.Name)
                    throw new Exception("Такой сериал уже существует!");
            }

            _allSerials.Add(serial);
            Logger.Log($"Добавлен новый сериал \"{serial.Name}\"");
            Serialize();
        }

        public void AddEpisode(Episode episode, Serial serial)
        {
            foreach (Episode e in serial.Episodes)
            {
                if (e.Name == episode.Name)
                    throw new Exception($"В сериале \"{serial.Name}\" уже есть такой эпизод!");
            }

            serial.Episodes.Add(episode);
            Logger.Log($"Добавлен новый эпизод \"{episode.Name}\" в сериал \"{serial.Name}\"");
            Serialize();
        }

        public void AddGenre(Genre genre)
        {
            _allGenres.Add(genre);
        }

        public void RemoveGenre(Genre genre)
        {
            foreach (Serial serial in _allSerials)
            {
                serial.Genres.Remove(genre);
            }

            _allGenres.Remove(genre);
        }

        public void RemoveSerial(Serial serial)
        {
            _allSerials.Remove(serial);
            Logger.Log($"Удален сериал: \"{serial.Name}\"");
            Serialize();
        }

        public void RemoveEpisode(Serial serial, Episode episode)
        {
            serial.Episodes.Remove(episode);
            Logger.Log($"Удален эпизод: \"{episode.Name}\"");
            Serialize();
        }

        public List<Serial> GetTop100()
        {
            List<Serial> result = AllSerials;
            // Тут сортировка по рейтингу.
            return result;
        }

        public List<Serial> SearchByString(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return _allSerials;

            search = search.ToLower().Trim();
            List<Serial> result = new List<Serial>();
            foreach (Serial s in _allSerials)
            {
                if (s.AllGenres.ToLower().Contains(search) || s.Name.ToLower().Contains(search))
                {
                    result.Add(s);
                }
            }
            return result;
        }

        private void Serialize()
        {
            using (FileStream fs = new FileStream(_file, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Serial>));
                serializer.Serialize(fs, _allSerials);
            }
        }

        private void Deserialize()
        {
            if (File.Exists(_file))
            {
                using (FileStream fs = new FileStream(_file, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Serial>));
                    _allSerials = (List<Serial>)serializer.Deserialize(fs);
                }
            }
        }
    }
}