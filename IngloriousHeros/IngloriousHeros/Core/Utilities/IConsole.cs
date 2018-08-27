using System;

namespace IngloriousHeros.Core.Utilities
{
    public interface IConsole
    {
        int BufferHeight { get; set; }

        int BufferWidth { get; set; }

        int WindowHeight { get; set; }

        int WindowWidth { get; set; }

        ConsoleColor ForegroundColor { get; set; }

        ConsoleColor BackgroundColor { get; set; }

        bool CursorVisible { get; set; }

        int LargestWindowHeight { get; }

        void Clear();

        void SetCursorPosition(int col, int row);

        void Write(string message);

        void WriteLine(string message);

        string ReadLine();

        ConsoleKeyInfo ReadKey(bool intercept = false);
    }
}