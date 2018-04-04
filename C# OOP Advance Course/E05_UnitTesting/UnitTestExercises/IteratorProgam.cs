using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestExercises
{
    public class IteratorProgam
    {
        private int currentIndex;
        private List<string> stringListCollection;

        public IteratorProgam(IEnumerable<string> stringListCollection)
        {
            this.IsNullPassedToContructor(stringListCollection);

            this.currentIndex = 0;
            this.stringListCollection = new List<string>(stringListCollection);
        }

        private void IsNullPassedToContructor(IEnumerable<string> listOfStrings)
        {
            if (listOfStrings == null)
            {
                throw new ArgumentNullException();
            }
        }

        public bool Move() => ++this.currentIndex < this.stringListCollection.Count;

        public bool HasNext()
            => this.currentIndex < this.stringListCollection.Count - 1;

        public string Print()
        {
            if (this.stringListCollection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            return this.stringListCollection[this.currentIndex];
        }
    }
}
