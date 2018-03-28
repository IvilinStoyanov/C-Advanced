using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Lake : IEnumerable<int>
{
    private int[] stones;

    public Lake(int[] stones)
    {
        this.stones = stones;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.stones.Length; i += 2)
        {
            yield return this.stones[i];
        }

        int len = this.stones.Length;

        int lastOddIndex = len % 2 == 0 ? len - 1 : len - 2;

        for (int i = lastOddIndex; i > 0; i -= 2)
        {
            yield return this.stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
