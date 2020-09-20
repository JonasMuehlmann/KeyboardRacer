using System;


namespace LEA
{
    public static class Cursor
    {
        /// <summary>
        ///     Represents escape code to move cursor up n lines.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static void Up(int n)
        {
            Console.Write($"{Ansii.Csi}{n}A");
        }


        /// <summary>
        ///     Represents escape code to move cursor down n lines.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static void Down(int n)
        {
            Console.Write($"{Ansii.Csi}{n}B");
        }


        /// <summary>
        ///     Represents escape code to move cursor left n column.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static void Left(int n)
        {
            Console.Write($"{Ansii.Csi}{n}D");
        }


        /// <summary>
        ///     Represents escape code to move cursor right n columns.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static void Right(int n)
        {
            Console.Write($"{Ansii.Csi}{n}C");
        }


        /// <summary>
        ///     Move Cursor to the n'th column in the current line
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static void ToCol(int n)
        {
            Console.Write($"{Ansii.Csi}{n}G");
        }


        /// <summary>
        ///     Move to cursor to the position (row,column)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static void To(int row, int col)
        {
            Console.Write($"{Ansii.Csi}{row};{col}H");
        }
    }

    public static class Line
    {
        public static void EraseWhole()
        {
            Console.Write($"{Ansii.Csi}2K");
        }


        /// <summary>
        ///     Erase from the beginning of the line to the current cursor position
        /// </summary>
        /// <returns></returns>
        public static void EraseToCursors()
        {
            Console.Write($"{Ansii.Csi}1K");
        }


        /// <summary>
        ///     Erase from the current cursor position the the end of the line
        /// </summary>
        /// <returns></returns>
        public static void EraseFromCursors()
        {
            Console.Write($"{Ansii.Csi}0K");
        }
    }
}