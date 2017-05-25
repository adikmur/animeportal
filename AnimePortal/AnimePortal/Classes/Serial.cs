using System;
using System.Collections.Generic;

namespace AnimePortal
{
    public class Serial
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;

        public string Description
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_description))
                    return "нет описания";
                return _description;
            }
            set { _description = value; }
        }

        private double _rating;

        public double Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        private List<Episode> _episodes = new List<Episode>();

        public List<Episode> Episodes
        {
            get { return _episodes; }
            set { _episodes = value; }
        }

        private string _genres;

        public string Genres
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_genres))
                    return "не указан жанр";
                return _genres;
            }
            set { _genres = value; }
        }

        public string GenresName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_genres))
                    return "Не указан жанр";
                return "Жанры: " + _genres;
            }
        }

        public string RatingName
        {
            get
            {
                return $"{Name} (рейтинг: {Math.Round(Rating, 2)})";
            }
        }

        public Serial(string name, string description, string genres, double rating)
        {
            Name = name;
            Description = description;
            Genres = genres;
            Rating = rating;
        }

        public Serial()
        {

        }   
    }
}
