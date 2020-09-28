namespace KeyboardRacer
{
    namespace Backend
    {
        public static class Ansii
        {
            public static readonly string Csi = "\x1b[";
        }

        public static class Car
        {
        // @formatter:off
        public static readonly string Model = @" ¸______¸
ɍ___ǁ____ƪ___
¬(˽)----¬(˽)-'";
            // @formatter:on

            public static readonly int Height = 4;
            public static readonly int Width  = 14;
        }

        public static class RaceView
        {
            public static readonly int MaxWidth   = Car.Width  + 100;
            public static readonly int LaneHeight = Car.Height + 1;
        }

        public static class Banners
        {
            // Font: small slant
            public static readonly string Name = @"
   __ __               __                          __        ___                       
  / //_/ ___   __ __  / /   ___   ___ _  ____  ___/ /       / _ \  ___ _  ____  ___   ____
 / ,<   / -_) / // / / _ \ / _ \ / _ `/ / __/ / _  /       / , _/ / _ `/ / __/ / -_) / __/
/_/|_|  \__/  \_, / /_.__/ \___/ \_,_/ /_/    \_,_/       /_/|_|  \_,_/  \__/  \__/ /_/   
             /___/                                                                  
";

            public static readonly string Winner = @"
  _      __  _                          __
 | | /| / / (_) ___   ___  ___   ____  / /
 | |/ |/ / / / / _ \ / _ \/ -_) / __/ /_/ 
 |__/|__/ /_/ /_//_//_//_/\__/ /_/   (_)  
";

            public static readonly string Completed = @"
  _____                      __       __           __   __
 / ___/ ___   __ _    ___   / / ___  / /_ ___  ___/ /  / /
/ /__  / _ \ /  ' \  / _ \ / / / -_)/ __// -_)/ _  /  /_/ 
\___/  \___//_/_/_/ / .__//_/  \__/ \__/ \__/ \_,_/  (_)  
                   /_/                                    
";

            public static readonly string TimedOut = @"
 ______  _                   __    ____           __    __
/_  __/ (_) __ _   ___   ___/ /   / __ \  __ __  / /_  / /
 / /   / / /  ' \ / -_) / _  /   / /_/ / / // / / __/ /_/ 
/_/   /_/ /_/_/_/ \__/  \_,_/    \____/  \_,_/  \__/ (_)  
";
        }

        public static class Network
        {
            // ReSharper disable once InconsistentNaming
            public static readonly string IPAddress  = "85.202.163.32";
            public static readonly int    Port       = 100;
            public static readonly int    BufferSize = 33;
        }

        public static class Fg
        {
            public static readonly string Black   = $"{Ansii.Csi}30m";
            public static readonly string Red     = $"{Ansii.Csi}31m";
            public static readonly string Green   = $"{Ansii.Csi}32m";
            public static readonly string Yellow  = $"{Ansii.Csi}33m";
            public static readonly string Blue    = $"{Ansii.Csi}34m";
            public static readonly string Magenta = $"{Ansii.Csi}35m";
            public static readonly string Cyan    = $"{Ansii.Csi}36m";
            public static readonly string White   = $"{Ansii.Csi}37m";

            public static readonly string BrightBlack   = $"{Ansii.Csi}90m";
            public static readonly string BrightRed     = $"{Ansii.Csi}91m";
            public static readonly string BrightGreen   = $"{Ansii.Csi}92m";
            public static readonly string BrightYellow  = $"{Ansii.Csi}93m";
            public static readonly string BrightBlue    = $"{Ansii.Csi}94m";
            public static readonly string BrightMagenta = $"{Ansii.Csi}95m";
            public static readonly string BrightCyan    = $"{Ansii.Csi}96m";
            public static readonly string BrightWhite   = $"{Ansii.Csi}97m";

            public static readonly string Reset = $"{Ansii.Csi}39m";
        }

        public static class Bg
        {
            public static readonly string Black   = $"{Ansii.Csi}40m";
            public static readonly string Red     = $"{Ansii.Csi}41m";
            public static readonly string Green   = $"{Ansii.Csi}42m";
            public static readonly string Yellow  = $"{Ansii.Csi}43m";
            public static readonly string Blue    = $"{Ansii.Csi}44m";
            public static readonly string Magenta = $"{Ansii.Csi}45m";
            public static readonly string Cyan    = $"{Ansii.Csi}46m";
            public static readonly string White   = $"{Ansii.Csi}47m";

            public static readonly string BrightBlack   = $"{Ansii.Csi}100m";
            public static readonly string BrightRed     = $"{Ansii.Csi}101m";
            public static readonly string BrightGreen   = $"{Ansii.Csi}102m";
            public static readonly string BrightYellow  = $"{Ansii.Csi}103m";
            public static readonly string BrightBlue    = $"{Ansii.Csi}104m";
            public static readonly string BrightMagenta = $"{Ansii.Csi}105m";
            public static readonly string BrightCyan    = $"{Ansii.Csi}106m";
            public static readonly string BrightWhite   = $"{Ansii.Csi}107m";

            public static readonly string Reset = $"{Ansii.Csi}49m";
        }

        public static class Effects
        {
            public static readonly string Reset   = $"{Ansii.Csi}0m";
            public static readonly string Reverse = $"{Ansii.Csi}7m";

            public static readonly string Bold   = $"{Ansii.Csi}1m";
            public static readonly string NoBold = $"{Ansii.Csi}21m";

            // Fix: Broken
            public static readonly string Faint   = $"{Ansii.Csi}2m";
            public static readonly string NoFaint = $"{Ansii.Csi}22m";

            // Fix: Broken
            public static readonly string Italic    = $"{Ansii.Csi}3m";
            public static readonly string NoItalics = $"{Ansii.Csi}23m";

            public static readonly string Underline   = $"{Ansii.Csi}4m";
            public static readonly string NoUnderline = $"{Ansii.Csi}24m";

            // Fix: Broken
            public static readonly string Overline   = $"{Ansii.Csi}53m";
            public static readonly string NoOverline = $"{Ansii.Csi}55m";

            public static readonly string Blink   = $"{Ansii.Csi}5m";
            public static readonly string NoBlink = $"{Ansii.Csi}25m";
        }
    }
}