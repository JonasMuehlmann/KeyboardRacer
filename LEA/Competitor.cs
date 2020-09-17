namespace LEA
{
    /// <summary>
    /// Describes a competitor in the context of a clients view
    /// </summary>
    public class Competitor
    {
        private string _color;
        private string _name;

        #region Properties

        /// <summary>
        /// The name of the competitor
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// A string containing the ANSII escape sequence representing his color
        /// </summary>
        public string Color
        {
            get => _color;
            set => _color = value;
        }

        #endregion


        public Competitor(string name, string color)
        {
            Name  = name;
            Color = color;
        }
    }
}