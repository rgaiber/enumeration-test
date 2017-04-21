using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IEnumerablePOC
{
    class Program
    {
        static Stopwatch sw;

        static void Main(string[] args)
        {
            sw = new Stopwatch();
            IEnumerable<SampleObject> data2 = SetupTest();
            TestWithSingleEnumeration(data2);
            IEnumerable<SampleObject> data = SetupTest();
            TestWithDoubleEnumeration(data);
        }

        private static void TestWithDoubleEnumeration(IEnumerable<SampleObject> data)
        {
            sw.Restart();
            List<SampleObject> onceEnumerated = data.ToList();
            List<SampleObject> twiceEnumerated = data.Where(x => true).ToList();
            sw.Stop();
            Console.WriteLine($"Time with double enumeration (ms): {sw.ElapsedMilliseconds}");
        }

        private static void TestWithSingleEnumeration(IEnumerable<SampleObject> data)
        {
            sw.Restart();
            List<SampleObject> onceEnumerated = data.Where(x => true).ToList();
            sw.Stop();
            Console.WriteLine($"Time with single enumeration (ms): {sw.ElapsedMilliseconds}");
        }

        private static IEnumerable<SampleObject> SetupTest()
        {
            List<SampleObject> testData = new List<SampleObject>();
            Random r = new Random();
            int maxValue = 1000000;
            for(int i = 0; i < maxValue; i++)
            {
                int value = r.Next(maxValue);
                testData.Add(new SampleObject(value));
            }

            IEnumerable<SampleObject> output = testData.Where(x => true);
            return output;
        }
    }
}
