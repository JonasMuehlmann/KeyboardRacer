using System;
using NStack;


namespace KeyboardRacer
{
    namespace Fronted
    {
        public class Helpers
        {
            public static ustring IncrementStringNumber(ustring str, int max)
            {
                var asInt = Convert.ToInt32(str);

                if (asInt < max)
                {
                    var incremented = ++asInt;

                    return Convert.ToString(incremented);
                }

                return str;
            }


            public static ustring DecrementStringNumber(ustring str, int min)
            {
                var asInt = Convert.ToInt32(str);

                if (asInt > min)
                {
                    var incremented = --asInt;

                    return Convert.ToString(incremented);
                }

                return str;
            }
        }
    }
}