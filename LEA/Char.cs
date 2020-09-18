namespace LEA
{
    public class Char
    {
        private char   _char;
        private string _color;
        private string _reset;

        #region Properties

        public char C
        {
            get => _char;
            set => _char = value;
        }

        public string Color
        {
            get => _color;
            set => _color = value;
        }

        public string Reset
        {
            get => _reset;
            set => _reset = value;
        }

        #endregion


        public Char(char c)
        {
            C     = c;
            Color = Fg.BrightBlack;
            Reset = Fg.Reset;
        }


        public Char(char c, string color, string reset)
        {
            C     = c;
            Color = color;
            Reset = reset;
        }


        public override string ToString()
        {
            return $"{Color}{C}{Reset}";
        }
    }
}