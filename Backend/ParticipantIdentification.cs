#region

using System;

#endregion


namespace Backend
{
    /// <summary>
    ///     Describes properties, that identify a participant
    /// </summary>
    public class ParticipantIdentification
    {
        #region Fields

        private string _name;

        #endregion

        #region Properties

        /// <summary>
        ///     The name of the competitor
        /// </summary>
        private string Name
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
        ///     A string containing the ANSII escape sequence representing his color
        /// </summary>
        private string Color { get; }

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