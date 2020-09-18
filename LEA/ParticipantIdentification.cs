using System;


namespace LEA
{
    /// <summary>
    /// Describes properties, that identify a participant
    /// </summary>
    public class ParticipantIdentification
    {
        private string _color;
        private string _name;

        #region Properties

        /// <summary>
        /// The name of the competitor
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length > 20)
                {
                    throw new ArgumentException("Name cannot be longer than 20 characters");
                }

                _name = value;
            }
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

        #region Constructors

        public ParticipantIdentification(string name, string color)
        {
            Name  = name;
            Color = color;
        }

        #endregion
    }
}