namespace AnimePortal
{
    public class Episode
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
                    return "Нет описания";
                return _description;
            }
            set { _description = value; }
        }

        private int _seasonNumber;

        public int SeasonNumber
        {
            get { return _seasonNumber; }
            set { _seasonNumber = value; }
        }

        public Episode(string name, string description, int seasonNumber)
        {
            Name = name;
            Description = description;
            SeasonNumber = seasonNumber;
        }

        public Episode()
        {

        }
    }
}