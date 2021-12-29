using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logika
{
    public class FilePrinter:IPrinter
    {
        private string name;

        public FilePrinter(string name)
        {
            this.name = name;
        }

        public void print( Weather[] weathers)
        {
            using (StreamWriter writer = new StreamWriter(name))
            {
            
                for(int i=0;i<weathers.Length;i++)
                writer.WriteLine(weathers[i].ToString());
            }
        }
    }
}
