using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestExercises.Interfaces
{
    public interface IClient
    {
        IList<ITweet> Tweets { get; set; }

        string Tweet(ITweet tweet);

        string ShowLastTweet();
    }
}
