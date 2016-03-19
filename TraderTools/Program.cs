using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderTools
{
    class Program
    {
        static void Main(string[] args)
        {
            //TextReader reader = File.OpenText(Path.Combine(Environment.CurrentDirectory, "historyTest.csv"));
            TextReader reader = File.OpenText("historyTest.csv");
            Market market = new Market(reader);
            market.Test1();
        }
    }
}
