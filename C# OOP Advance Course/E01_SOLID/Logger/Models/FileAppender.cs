using Logger.Models.Contracts;

namespace Logger.Models
{
    internal class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.Level = errorLevel;
            this.logFile = logFile;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        public int MessagesAppended { get; private set; }

        public void Appent(IError error)
        {
            string formatError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formatError);

            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layaoutType = this.Layout.GetType().Name;
            string level = this.Level.ToString();

            string result
                = $"Appender type: {appenderType}, Layout type: {layaoutType}, Report level: {level}, Messages appended: {this.MessagesAppended}, File size: {this.logFile.Size}";
            return result;
        }
    }
}