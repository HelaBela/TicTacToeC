namespace TicTacToe
{
    public interface IConsoleService
    {
        void Write(string content);
        void Write(string content, string content2, string content3, string content4);
        string Read();
    }
}