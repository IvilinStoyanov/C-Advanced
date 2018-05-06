namespace FestivalManager.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class Stage : IStage
    {
        //List<IPerformer> storePerformers;
        List<ISet> storeSets;
        //List<ISong> storeSongs;

        Performer performer;
        ISong songs;

        private IFestivalController festivalController;
        private ISetController setController;

        public Stage()
        {
            this.festivalController = new FestivalController(this);
            this.setController = new SetController(this);

            this.storeSets = new List<ISet>();
        }

        IReadOnlyCollection<ISet> IStage.Sets { get; }

        IReadOnlyCollection<ISong> IStage.Songs { get; }

        IReadOnlyCollection<IPerformer> IStage.Performers { get; }

        public void AddPerformer(IPerformer performer)
        {

        }

        public void AddSet(ISet set)
        {
            storeSets.Add(set);
        }

        public void AddSong(ISong song)
        {

        }

        public IPerformer GetPerformer(string name)
        {

            throw new System.NotImplementedException();
        }

        public ISet GetSet(string name)
        {
            return null;
        }

        public ISong GetSong(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool HasPerformer(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool HasSet(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool HasSong(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
