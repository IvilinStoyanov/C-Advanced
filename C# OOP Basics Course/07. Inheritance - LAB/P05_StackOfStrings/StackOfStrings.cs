using System;
using System.Collections.Generic;
using System.Text;


public class StackOfStrings
{
    private string newElement;

    List<string> data = new List<string>();

    public bool isEmpty()
    {
      if(data.Count == 0)
        {
            return true;
        }
        return false;
    }

    public void Push(string newElement)
    {
         data.Add(newElement);
    }

    public string Peek()
    {
        string result = string.Empty;
        if(!isEmpty())
        {
            result = data[data.Count - 1];
        }
        return result;
    }

    public string Pop()
    {
        string result = string.Empty;
        if (!isEmpty())
        {
            var lastIndex = data.Count - 1;
            result = data[data.Count - 1];
        }
        return result;
    }
}

