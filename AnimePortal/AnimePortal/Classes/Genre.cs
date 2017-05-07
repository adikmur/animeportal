namespace AnimePortal
{
    public class Genre
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Genre(string name)
        {
            Name = name;
        }
        
        public Genre()
        {

        }
    }
}