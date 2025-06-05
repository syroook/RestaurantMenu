using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public abstract class Serializer
    {
        public abstract void Serialize<T>(T data, string filePath);
        public abstract T Deserialize<T>(string filePath);
        public abstract string GetFileExtension();
    }
}
