using System;
using System.Collections.Generic;
using System.Text;


public class Scale<T> where T : IComparable<T>
{
    public T Left { get; set; }

    public T Right { get; set; }

    public Scale(T left, T right)
    {
        this.Left = left;
        this.Right = right;
    }


    public T GetHeavier()
    {
        if (this.Left.CompareTo(this.Right) > 0)
        {
            return this.Left;
        }
        if (this.Right.CompareTo(this.Left) > 0)
        {
            return this.Right;
        }
        return default(T);
    }
}

