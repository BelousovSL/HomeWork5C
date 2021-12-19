using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace HomeWork5C
{
    public class CSVSerializer : IFormatter
    {
        private readonly Type _type;

        public CSVSerializer(Type type)
        {
            _type = type;
        }

        public SerializationBinder? Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISurrogateSelector? SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Deserialize(Stream serializationStream)
        {
            var obj = Activator.CreateInstance(_type);

            using (var sr = new StreamReader(serializationStream))
            {
                var contents = sr.ReadToEnd();
                var arr = contents.Split(',');

                var propertysInfo = _type.GetProperties();

                for (int i = 0; i < propertysInfo.Length; i++)
                {
                    propertysInfo[i].SetValue(obj, ConvertValue(propertysInfo[i].PropertyType, arr[i]), null);
                }
            }

            return obj;
        }


        private object ConvertValue(Type type, string value)
        {

            if (type == typeof(string))
                return value;

            if (type == typeof(int))
                return int.Parse(value);

            if (type == typeof(long))
                return long.Parse(value);

            if (type == typeof(DateTime))
                return DateTime.Parse(value);

            throw new Exception("Не поддерживаемый тип данных");
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            var arr = _type.GetProperties().Select(t => t.GetValue(graph)).ToArray();

            StreamWriter streamWriter = new StreamWriter(serializationStream);
            streamWriter.Write(String.Join(',', arr));

            streamWriter.Flush();
        }
    }
}

