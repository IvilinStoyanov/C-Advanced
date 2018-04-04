using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestExercises;
using UnitTestExercises.Interfaces;
using UnitTestExercises.Models;

namespace UnitTests
{
    public class TwitterTest
    {
        private const int countsTweets = 0;
        private IClient tweeter;

        [SetUp]
        public void TestInit()
        {
            this.tweeter = new TweeterClient();
        }

        [Test]
        public void TweetNormalMessage()
        {
            this.tweeter.Tweet(new Twitter("Hello"));

            Assert.Pass();
        }

        [Test]
        public void TweetEmptyMessage()
        {
            Assert.Throws<ArgumentNullException>(() => this.tweeter.Tweet(new Twitter(string.Empty)));
        }

        [Test]
        public void TweetTooLongMessage()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.tweeter.Tweet(new Twitter(new string('a', 300))));
        }

        [Test]
        public void ClientRegistersTweet()
        {
            int countBefore = countsTweets;

            this.tweeter.Tweet(new Twitter("Test"));

            Assert.AreEqual(countBefore + 1, this.tweeter.Tweets.Count);
        }

        [Test]
        public void ClientReturnsTweetMessage()
        {
            string result = string.Empty;

            result = this.tweeter.Tweet(new Twitter("Test"));

            Assert.AreEqual("Test", result);
        }

        [Test]
        public void DisplayLastTweet()
        {
            this.tweeter.Tweet(new Twitter("Test0"));
            this.tweeter.Tweet(new Twitter("Test1"));
            this.tweeter.Tweet(new Twitter("Test2"));
            this.tweeter.Tweet(new Twitter("Test3"));

            string result = this.tweeter.ShowLastTweet();

            Assert.AreEqual("Test3", result);
        }

        [Test]
        public void DisplayLastTweetWhenTweetsAreZeroThrowsExc()
        {
            Assert.Throws<InvalidOperationException>(() => this.tweeter.ShowLastTweet());
        }
    }
}
