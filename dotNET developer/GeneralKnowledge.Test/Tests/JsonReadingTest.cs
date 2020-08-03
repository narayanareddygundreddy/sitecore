
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic data retrieval from JSON test
    /// </summary>
    public class JsonReadingTest : ITest
    {
        public string Name { get { return "JSON Reading Test"; } }

        public void Run()
        {
            var jsonData = Resources.SamplePoints;
            PrintOverview(jsonData);
        }

        private void PrintOverview(byte[] data)
        {
            var jsonDataString = string.Empty;
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (StreamReader str = new StreamReader(ms))
                {
                    jsonDataString = str.ReadToEnd();
                }
            }
            var lst = JsonConvert.DeserializeObject<Set>(jsonDataString);
            List<Sample> lstSample = lst.Samples.ToList();
            Console.WriteLine("Parameter   " + "LOW " + "AVG " + "MAX");
            Console.WriteLine("Temperature " + lstSample.Min(x => x.temperature)+" "+ Math.Round(lstSample.Sum(x => x.temperature) / lstSample.Count, 1) + " " + lstSample.Max(x => x.temperature));
            Console.WriteLine("pH          " + lstSample.Min(x => x.pH) + " " + lstSample.Sum(x => x.pH) / lstSample.Count + " " + lstSample.Max(x => x.pH));
            Console.WriteLine("Chloride    " + lstSample.Min(x => x.chloride) + " " + lstSample.Sum(x => x.chloride) / lstSample.Count + " " + lstSample.Max(x => x.chloride));
            Console.WriteLine("Phosphate   " + lstSample.Min(x => x.phosphate) + " " + lstSample.Sum(x => x.phosphate) / lstSample.Count + " " + lstSample.Max(x => x.phosphate));
            Console.WriteLine("Nitrate     " + lstSample.Min(x => x.nitrate) + " " + lstSample.Sum(x => x.nitrate) / lstSample.Count + " " + lstSample.Max(x => x.nitrate));
        }
    }
    public class Set
    {
        public List<Sample> Samples { get; set;}
    }
    public class Sample
    {        
        public DateTime date { get; set; }
        public double temperature { get; set; }
        public int pH { get; set; }
        public int phosphate { get; set; }
        public int chloride { get; set; }
        public int nitrate { get; set; }
    }
}
