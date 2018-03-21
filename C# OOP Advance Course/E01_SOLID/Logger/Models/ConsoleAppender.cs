using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public class ConsoleAppender : IAppender
    {
        public int MessagesAppended { get; private set; }

        public ConsoleAppender(ILayout layout, ErrorLevel level)
        {
            this.Layout = layout;
            this.Level = level;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }
        
        public ErrorLevel Level { get; }

        public void Appent(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            Console.WriteLine(formattedError);
           
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layaoutType = this.Layout.GetType().Name;
            string level = this.Level.ToString();

            string result
                = $"Appender type: {appenderType}, Layout type: {layaoutType}, Report level: {level}, Messages appended: {this.MessagesAppended}";
            return result;
        }
    }
}
