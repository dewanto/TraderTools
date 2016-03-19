using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace TraderTools
{
    /// <summary>
    /// Stores market history.
    /// </summary>
    class Market
    {
        private List<MarketDatum> _history;

        public Market(List<MarketDatum> history)
        {
            _history = new List<MarketDatum>(history);
        }

        public Market(TextReader historyTextReader, String delimiter = ",")
        {
            _history = new List<MarketDatum>();
            using (TextFieldParser parser = new TextFieldParser(historyTextReader))
            {
                //parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(delimiter);
                while (!parser.EndOfData)
                {
                    String[] fields = parser.ReadFields();
                    String fieldTime = fields[0] + " " + fields[1];
                    DateTime time = DateTime.Parse(fieldTime);
                    float open = float.Parse(fields[2]);
                    float high = float.Parse(fields[3]);
                    float low = float.Parse(fields[4]);
                    float close = float.Parse(fields[5]);
                    MarketDatum datum = new MarketDatum(time, open, high, low, close);
                    _history.Add(datum);
                }
            }
        }
        
        /// <summary>
        /// Inserts a market datum, preserving time-ordering.
        /// </summary>
        /// <param name="datum"></param>
        public void AddDatum(MarketDatum datum)
        {
            throw new NotImplementedException();
        }

        public void Test1()
        {
            foreach (MarketDatum datum in _history)
            {
                Console.WriteLine(datum);
            }
        }
    }
}