using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder sb;

    public ConsoleWriter()
    {
        this.sb = new StringBuilder();
    }

    public string StoredMessage
    {
        get => this.sb.ToString();
    }

    public void StoreMessage(string message)
    {
        sb.AppendLine(message.Trim());
    }

    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }
}
