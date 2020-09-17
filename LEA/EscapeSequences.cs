namespace LEA
{
    public static class Constants
    {
        public const string Csi = "\x1b[";

        public const string Car = @"         ¸______¸
        ɍ___ǁ____ƪ___
        ¬(˽)----¬(˽)-'";

        public const int CarHeight = 4;
    }

    public static class Fg
    {
        public static readonly string Black   = $"{Constants.Csi}30m";
        public static readonly string Red     = $"{Constants.Csi}31m";
        public static readonly string Green   = $"{Constants.Csi}32m";
        public static readonly string Yellow  = $"{Constants.Csi}33m";
        public static readonly string Blue    = $"{Constants.Csi}34m";
        public static readonly string Magenta = $"{Constants.Csi}35m";
        public static readonly string Cyan    = $"{Constants.Csi}36m";
        public static readonly string White   = $"{Constants.Csi}37m";

        public static readonly string BrightBlack   = $"{Constants.Csi}90m";
        public static readonly string BrightRed     = $"{Constants.Csi}91m";
        public static readonly string BrightGreen   = $"{Constants.Csi}92m";
        public static readonly string BrightYellow  = $"{Constants.Csi}93m";
        public static readonly string BrightBlue    = $"{Constants.Csi}94m";
        public static readonly string BrightMagenta = $"{Constants.Csi}95m";
        public static readonly string BrightCyan    = $"{Constants.Csi}96m";
        public static readonly string BrightWhite   = $"{Constants.Csi}97m";

        public static readonly string Reset = $"{Constants.Csi}39m";
    }

    public static class Bg
    {
        public static readonly string Black   = $"{Constants.Csi}40m";
        public static readonly string Red     = $"{Constants.Csi}41m";
        public static readonly string Green   = $"{Constants.Csi}42m";
        public static readonly string Yellow  = $"{Constants.Csi}43m";
        public static readonly string Blue    = $"{Constants.Csi}44m";
        public static readonly string Magenta = $"{Constants.Csi}45m";
        public static readonly string Cyan    = $"{Constants.Csi}46m";
        public static readonly string White   = $"{Constants.Csi}47m";

        public static readonly string BrightBlack   = $"{Constants.Csi}100m";
        public static readonly string BrightRed     = $"{Constants.Csi}101m";
        public static readonly string BrightGreen   = $"{Constants.Csi}102m";
        public static readonly string BrightYellow  = $"{Constants.Csi}103m";
        public static readonly string BrightBlue    = $"{Constants.Csi}104m";
        public static readonly string BrightMagenta = $"{Constants.Csi}105m";
        public static readonly string BrightCyan    = $"{Constants.Csi}106m";
        public static readonly string BrightWhite   = $"{Constants.Csi}107m";

        public static readonly string Reset = $"{Constants.Csi}49m";
    }

    public static class Effects
    {
        public static readonly string Reset   = $"{Constants.Csi}0m";
        public static readonly string Reverse = $"{Constants.Csi}7m";

        public static readonly string Bold   = $"{Constants.Csi}1m";
        public static readonly string NoBold = $"{Constants.Csi}21m";

        // Fix: Broken
        public static readonly string Faint   = $"{Constants.Csi}2m";
        public static readonly string NoFaint = $"{Constants.Csi}22m";

        // Fix: Broken
        public static readonly string Italic    = $"{Constants.Csi}3m";
        public static readonly string NoItalics = $"{Constants.Csi}23m";

        public static readonly string Underline   = $"{Constants.Csi}4m";
        public static readonly string NoUnderline = $"{Constants.Csi}24m";

        // Fix: Broken
        public static readonly string Overline   = $"{Constants.Csi}53m";
        public static readonly string NoOverline = $"{Constants.Csi}55m";

        public static readonly string Blink   = $"{Constants.Csi}5m";
        public static readonly string NoBlink = $"{Constants.Csi}25m";
    }

    public static class Cursor
    {
        /// <summary>
        /// Represents escape code to move cursor up n lines.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Up(int n)
        {
            return $"{Constants.Csi}{n}A";
        }


        /// <summary>
        /// Represents escape code to move cursor down n lines.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Down(int n)
        {
            return $"{Constants.Csi}{n}B";
        }


        /// <summary>
        /// Represents escape code to move cursor left n column.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Left(int n)
        {
            return $"{Constants.Csi}{n}D";
        }


        /// <summary>
        /// Represents escape code to move cursor right n columns.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Right(int n)
        {
            return $"{Constants.Csi}{n}C";
        }


        /// <summary>
        /// Move Cursor to the n'th column in the current line
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string ToCol(int n)
        {
            return $"{Constants.Csi}{n}G";
        }


        /// <summary>
        /// Move to cursor to the position (row,column)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static string To(int row, int col)
        {
            return $"{Constants.Csi}{row};{col}H";
        }
    }

    public static class Line
    {
        public static string EraseWhole()
        {
            return $"{Constants.Csi}2K";
        }


        /// <summary>
        /// Erase from the beginning of the line to the current cursor position
        /// </summary>
        /// <returns></returns>
        public static string EraseToCursors()
        {
            return $"{Constants.Csi}1K";
        }


        /// <summary>
        /// Erase from the current cursor position the the end of the line
        /// </summary>
        /// <returns></returns>
        public static string EraseFromCursors()
        {
            return $"{Constants.Csi}0K";
        }
    }
}