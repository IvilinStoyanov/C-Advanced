using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4_CopyBinaryFile
{
    class CopyBinaryFile
    {
        private static void Main(string[] args)
        {
            FileStream fsIN = new FileStream(@"..\..\copyMe.PNG", FileMode.Open);
            FileStream fsOUT = new FileStream(@"..\..\copyMeCopy.PNG", FileMode.Create);

            using (fsIN)
            {
                using (fsOUT)
                {
                    while (fsIN.Position < fsIN.Length)
                    {
                        fsOUT.WriteByte((byte)fsIN.ReadByte());
                    }
                }
            }
        }
    }
}