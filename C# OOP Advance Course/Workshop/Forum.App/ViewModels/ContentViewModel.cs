using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.ViewModels
{
    public abstract class ContentViewModel
    {
        private const int lineLenght = 37;

        protected ContentViewModel(string text)
        {
            this.Content = this.GetLines(text);
        }

        public string[] Content { get; }

        private string[] GetLines(string text)
        {
            char[] contentChars = text.ToCharArray();

            ICollection<string> lines = new List<string>();

            for (int i = 0; i < contentChars.Length; i += lineLenght)
            {
                char[] lineChars = contentChars.Skip(i).Take(lineLenght).ToArray();
                string line = string.Join("", lineChars);
                lines.Add(line);

            }
            return lines.ToArray();
        }
    }
}
