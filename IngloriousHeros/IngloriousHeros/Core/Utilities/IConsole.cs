namespace IngloriousHeros.Core.Utilities
{
    public interface IConsole
    {
        int BufferHeight { get; set; }

        int BufferWidth { get; set; }

        int WindowHeight { get; set; }

        int WindowWidth { get; set; }

        void Clear();

        void SetCursorPosition(int col, int row);

        void Write(string message);

        void WriteLine(string message);

        string ReadLine();
    }
}