namespace LEA
{
    public static class Constants
    {
        public static readonly string Csi = "\x1b[";
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

        public static readonly string Reset = $"{Constants.Csi}39m";
    }

    public static class FgBright
    {
        public static readonly string Black   = $"{Constants.Csi}90m";
        public static readonly string Red     = $"{Constants.Csi}91m";
        public static readonly string Green   = $"{Constants.Csi}92m";
        public static readonly string Yellow  = $"{Constants.Csi}93m";
        public static readonly string Blue    = $"{Constants.Csi}94m";
        public static readonly string Magenta = $"{Constants.Csi}95m";
        public static readonly string Cyan    = $"{Constants.Csi}96m";
        public static readonly string White   = $"{Constants.Csi}97m";

        public static readonly string Reset = Fg.Reset;
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

        public static readonly string Reset = $"{Constants.Csi}49m";
    }

    public static class BgBright
    {
        public static readonly string Black   = $"{Constants.Csi}100m";
        public static readonly string Red     = $"{Constants.Csi}101m";
        public static readonly string Green   = $"{Constants.Csi}102m";
        public static readonly string Yellow  = $"{Constants.Csi}103m";
        public static readonly string Blue    = $"{Constants.Csi}104m";
        public static readonly string Magenta = $"{Constants.Csi}105m";
        public static readonly string Cyan    = $"{Constants.Csi}106m";
        public static readonly string White   = $"{Constants.Csi}107m";

        public static readonly string Reset = Bg.Reset;
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

        public static readonly string SlowBlink = $"{Constants.Csi}5m";
        public static readonly string NoBlink   = $"{Constants.Csi}25m";
    }
}