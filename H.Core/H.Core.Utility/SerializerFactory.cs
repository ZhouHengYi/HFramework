using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace H.Core.Utility
{
    public interface ISerializer
    {
        string Serialization(object target, Type type);
        object Deserialize(Stream stream, Type type);
        T Deserialize<T>(string str);
    }

    public class JsonSerializer : ISerializer
    {
        #region ISerializer Members

        public string Serialization(object target, Type type)
        {
            if (target == null)
            {
                return "";
            }

            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(type);

                serializer.WriteObject(stream, target);
                byte[] s = stream.ToArray();
                return Encoding.UTF8.GetString(s, 0, s.Length);
            }
        }


        public object Deserialize(Stream stream, Type type)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(type);
            return serializer.ReadObject(stream);
        }

        public T Deserialize<T>(string str)
        {
            return (T)Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(str)), typeof(T));
        }

        #endregion
    }

    public class XmlSerializer : ISerializer
    {
        #region ISerializer Members
        public string Serialization(object target, Type type)
        {
            //if (target == null)
            //{
            //    return "";
            //}
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    DataContractSerializer serializer = new DataContractSerializer(type);
            //    serializer.WriteObject(stream, target);

            //    byte[] s = stream.ToArray();
            //    return Encoding.UTF8.GetString(s, 0, s.Length);
            //}

            StringBuilder sb = new StringBuilder(5000);
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(type);
            using (TextWriter writer = new StringWriter(sb))
            {
                ser.Serialize(writer, target);
                return writer.ToString();
            }
        }

        public object Deserialize(Stream stream, Type type)
        {
            DataContractSerializer serializer = new DataContractSerializer(type);
            return serializer.ReadObject(stream);
        }

        public T Deserialize<T>(string str)
        {
            return (T)Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(str)), typeof(T));
        }

        #endregion
    }

    public class BinarySerializer : ISerializer
    {
        #region ISerializer Members
        public string Serialization(object target, Type type)
        {
            var ms = new MemoryStream();
            var ser = new DataContractSerializer(type);
            ser.WriteObject(ms, target);
            var array = ms.ToArray();
            ms.Close();
            string serializeString = Encoding.UTF8.GetString(array, 0, array.Length);
            return serializeString;
        }

        public object Deserialize(Stream stream, Type type)
        {
            DataContractSerializer serializer = new DataContractSerializer(type);
            return serializer.ReadObject(stream);
        }

        public T Deserialize<T>(string str)
        {
            return (T)Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(str)), typeof(T));
        }
        #endregion
    }

    public static class SerializerFactory
    {
        private static readonly Dictionary<string, ISerializer> Items;

        static SerializerFactory()
        {
            Items = new Dictionary<string, ISerializer>();
            Items.Add(ContentTypes.Json, new JsonSerializer());
            Items.Add(ContentTypes.Xml, new XmlSerializer());
        }

        public static ISerializer GetSerializer(string serializerName)
        {
            ISerializer serializer = null;
            if (!string.IsNullOrEmpty(serializerName))
            {
                Items.TryGetValue(serializerName, out serializer);
            }
            return serializer;
        }

        public static void Register(string serializerName, ISerializer serializer)
        {
            Items.Add(serializerName, serializer);
        }
    }
}
