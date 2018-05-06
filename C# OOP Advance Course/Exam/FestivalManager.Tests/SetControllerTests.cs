// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using NUnit.Framework;

    using FestivalManager.Core.Controllers;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Sets;
    using System.Text;
    using System.Linq;

    [TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void AddPerformerToStage()
	    {
            IStage stage = new Stage();

            Song song = new Song("TestSong", new System.TimeSpan(0, 15, 0));
            
            ISet set1 = new Short("ShortSet1");
            ISet set2 = new Short("ShortSet2");
            ISet set3 = new Short("ShortSet3");

            SetController setController = new SetController(stage);

            var sb = new StringBuilder();

            stage.AddSong(song);

            stage.AddSet(set1);
            stage.AddSet(set2);
            stage.AddSet(set3);

            setController.PerformSets();

            Assert.That(stage.Sets.Count, Is.EqualTo(3));
        }

        [Test]
        public void CheckCountOf()
        {
            IStage stage = new Stage();
;
            ISet set1 = new Short("ShortSet1");
            ISet set2 = new Short("ShortSet2");
            ISet set3 = new Short("ShortSet3");

            SetController setController = new SetController(stage);

            var sb = new StringBuilder();

            stage.AddSet(set1);
            stage.AddSet(set2);
            stage.AddSet(set3);

            setController.PerformSets();
            var stringBuilderMessage = sb.ToString().Trim();

            Assert.That(stringBuilderMessage, Is.EqualTo("-- Set Successful"));
        }

        [Test]
        public void CheckMinutes()
        {
            IStage stage = new Stage();
            ;
            ISet set1 = new Short("ShortSet1");
            ISet set2 = new Short("ShortSet2");
            ISet set3 = new Short("ShortSet3");

            SetController setController = new SetController(stage);

            var sb = new StringBuilder();

            Song song1 = new Song("TestSong", new System.TimeSpan(0, 15, 0));
            Song song2 = new Song("TestSong", new System.TimeSpan(0, 15, 0));
            Song song3 = new Song("TestSong", new System.TimeSpan(0, 15, 0));
    
            stage.AddSong(song1);
            stage.AddSong(song2);
            stage.AddSong(song3);

            setController.PerformSets();

            
        }
    }
}