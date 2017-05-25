using System;
using System.Collections.Generic;
// Для потоков и файлов
using System.IO;
using System.Linq;
// Для (де)сериализации
using System.Xml.Serialization;

namespace AnimePortal
{
    public class SerialMethods
    {
        private const string _file = "../../Data/serials.xml";

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
            Deserialize();
        }

        // Добавление сериала
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

        // Добавление эпизода
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

        // Редактирование сериала
        public void EditSerial(Serial serial, string name, string description, string genres, double rating)
        {
            string oldName = serial.Name;

            serial.Name = name;
            serial.Description = description;
            serial.Genres = genres;
            serial.Rating = rating;

            if (oldName == name)
                Logger.Log($"Редактирован сериал \"{name}\"");
            else
                Logger.Log($"Редактирован сериал \"{oldName}\". Новое имя: \"{name}\"");
            Serialize();
        }

        // Редактирование эпизода
        public void EditEpisode(Episode episode, string name, string description, int seasonNumber)
        {
            string oldName = episode.Name;

            episode.Name = name;
            episode.Description = description;
            episode.SeasonNumber = seasonNumber;

            if (oldName == name)
                Logger.Log($"Редактирован эпизод \"{name}\"");
            else
                Logger.Log($"Редактирован эпизод \"{oldName}\". Новое имя: \"{name}\"");
            Serialize();
        }

        // Удаление сериала
        public void RemoveSerial(Serial serial)
        {
            _allSerials.Remove(serial);
            Logger.Log($"Удален сериал \"{serial.Name}\"");
            Serialize();
        }

        // Удаление эпизода
        public void RemoveEpisode(Serial serial, Episode episode)
        {
            serial.Episodes.Remove(episode);
            Logger.Log($"Удален эпизод \"{episode.Name}\" из сериала \"{serial.Name}\"");
            Serialize();
        }

        // ТОП-100
        public List<Serial> GetTop100()
        {
            // Сортировка по рейтингу (по убыванию)
            List<Serial> sorted = AllSerials.OrderByDescending(s => s.Rating).ToList();
            // Если больше 100, то вернем элементы от 0 (100 штук)
            if (sorted.Count >= 100)
                return sorted.GetRange(0, 100);
            return sorted;
        }

        // Поиск по строке
        public List<Serial> SearchByString(string search)
        {
            // Если пустая - исходный лист
            if (string.IsNullOrWhiteSpace(search))
                return _allSerials;

            search = search.ToLower().Trim();
            List<Serial> result = new List<Serial>();
            foreach (Serial s in _allSerials)
            {
                if (s.GenresName.ToLower().Contains(search) || s.Name.ToLower().Contains(search))
                {
                    result.Add(s);
                }
            }
            return result;
        }

        // Сериализация
        private void Serialize()
        {
            // Чтобы не было ошибок, каждый раз будем создавать по новой
            using (FileStream fs = new FileStream(_file, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Serial>));
                serializer.Serialize(fs, _allSerials);
            }
        }

        // Десериализация
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