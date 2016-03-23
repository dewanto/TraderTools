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
    public class Market
    {
        private List<MarketOHLC> _history;

        public Market(List<MarketOHLC> history)
        {
            _history = new List<MarketOHLC>(history);
        }

        public Market(TextReader historyTextReader, String delimiter = ",")
        {
            _history = new List<MarketOHLC>();
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
                    MarketOHLC datum = new MarketOHLC(time, open, high, low, close);
                    _history.Add(datum);
                }
            }
        }
        
        /// <summary>
        /// Inserts a market datum, preserving time-ordering.
        /// </summary>
        /// <param name="datum"></param>
        public void AddDatum(MarketOHLC datum)
        {
            throw new NotImplementedException();
        }

        public void Test1()
        {
            foreach (MarketOHLC datum in _history)
            {
                Console.WriteLine(datum);
            }
        }
    }
}