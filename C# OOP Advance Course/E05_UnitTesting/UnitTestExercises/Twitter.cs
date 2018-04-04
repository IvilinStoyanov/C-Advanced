using System;
using System.Collections.Generic;
using System.Text;
using UnitTestExercises.Interfaces;

namespace UnitTestExercises
{
    public class Twitter : ITweet
    {

        public Twitter(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException();
            }

            if (message.Length > 255)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Message = message;
        }

        public string Message { get; set; }
    }
}
