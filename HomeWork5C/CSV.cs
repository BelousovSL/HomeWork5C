using System;
using System.Diagnostics;
using System.Text;

namespace HomeWork5C
{
    public static class CSV
    {
        public static string Serialize<T>(object graph, int numberOfRepetitions)
        {
            var cSVSerializer = new CSVSerializer(typeof(T));
            string value = String.Empty;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i <= numberOfRepetitions; i++)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    cSVSerializer.Serialize(ms, graph);

                    ms.Position = 0;
                    StreamReader sr = new StreamReader(ms);
                    value = sr.ReadToEnd();
                }
            }

            stopwatch.Stop();

            Console.WriteLine($"Serialize CSV Количество повторений: {numberOfRepetitions}, время выполнения: {stopwatch.ElapsedMilliseconds}");
            return value;
        }

        public static object Deserialize<T>(string graph, int numberOfRepetitions)
        {
            var cSVSerializer = new CSVSerializer(typeof(T));
            var obj = Activator.CreateInstance<T>();

            byte[] byteArray = Encoding.ASCII.GetBytes(graph);            

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i <= numberOfRepetitions; i++)
            {
                var stream = new MemoryStream(byteArray);
                obj = (T)cSVSerializer.Deserialize(stream);
            }

            stopwatch.Stop();
            Console.WriteLine($"Deserialize CSV Количество повторений: {numberOfRepetitions}, время выполнения: {stopwatch.ElapsedMilliseconds}");
            return obj;
        }

    }
}

