using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercises_Models.Models
{
    public class Database<T> : IEnumerable<int>
    {
        //Exceptions messages : 
        private const string DATABASE_FULL = "Database is currently full";
        private const string DATABASE_EMPTY = "Database is empty!";

        private const int Capacity = 16;

        private int[] data;
        private int count;

        public Database(params int[] items)
        {
            this.data = new int[16];
            InitializeValues(items);
        }

        private void InitializeValues(int[] items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public int Count { get { return this.count; } }

        public void Add(int number)
        {
            if (this.count == Capacity)
            {
                throw new InvalidOperationException(DATABASE_FULL);
            }

            this.data[this.count] = number;
            this.count++;
        }

        public int Remove()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException(DATABASE_EMPTY);
            }

            int item = this.data[this.count - 1];
            this.data[this.count - 1] = default(int);
            this.count--;
            return item;
        }

        public int[] Fetch()
        {
            int[] result = new int[this.count];
            Array.Copy(this.data, result, this.count);

            return result;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}