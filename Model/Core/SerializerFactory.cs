using Model.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public static class SerializerFactory
    {
        public static Serializer Create(SerializationFormat format)
        {
            return format switch
            {
                SerializationFormat.Json => new Json(),
                SerializationFormat.Xml => new Xml(),
                _ => throw new NotSupportedException($"Формат {format} не поддерживается")
            };
        }
    }

    public enum SerializationFormat { Json, Xml }
}
