using System;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace HomeWork5C
{
    public static class JSON
    {
        public static string Serialize(object graph, int numberOfRepetitions)
        {

            var jsonString = string.Empty;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i <= numberOfRepetitions; i++)
            {
                jsonString = JsonSerializer.Serialize(graph);

            }

            stopwatch.Stop();

            Console.WriteLine($"Serialize JSON Количество повторений: {numberOfRepetitions}, время выполнения: {stopwatch.ElapsedMilliseconds}");
            return jsonString;
        }

        public static object Deserialize<T>(string graph, int numberOfRepetitions)
        {
            var cSVSerializer = new CSVSerializer(typeof(T));
            var obj = Activator.CreateInstance<T>();


            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i <= numberOfRepetitions; i++)
            {
                obj = JsonSerializer.Deserialize<T>(graph);
            }

            stopwatch.Stop();
            Console.WriteLine($"Deserialize JSON Количество повторений: {numberOfRepetitions}, время выполнения: {stopwatch.ElapsedMilliseconds}");
            return obj;
        }

    }
}

