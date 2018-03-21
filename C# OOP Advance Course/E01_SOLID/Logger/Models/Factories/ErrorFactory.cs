using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Models.Factories
{
    public class ErrorFactory
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateTimeString, string errorLevelString, string message)
        {
            DateTime dateTime
                = DateTime.ParseExact(dateTimeString, DateFormat, CultureInfo.InvariantCulture);

            ErrorLevel errorLevel = ParseErrorLevel(errorLevelString);

            IError erorr = new Error(dateTime, errorLevel, message);

            return erorr;
        }

        private ErrorLevel ParseErrorLevel(string levelString)
        {
            try
            {
                object levelObject = Enum.Parse(typeof(ErrorLevel), levelString);
                return (ErrorLevel)levelObject;
            }
            catch (ArgumentException ex)
            {

                throw new ArgumentException("Invalid ErrorLevel Type!", ex);
            }
        }
    }
}
