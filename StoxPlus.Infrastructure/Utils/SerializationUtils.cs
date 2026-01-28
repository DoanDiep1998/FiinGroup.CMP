using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StoxPlus.Infrastructure.Utils
{
    public static class SerializationUtils
    {
        public static byte[] GetSerializedData<T>(T item)
        {
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, item);
                return stream.ToArray();
            }
        }
    }
}
