using ProtoBuf;
using System;
using System.Collections.Generic;

namespace StoxPlus.Core.Models.Chart
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class ChartEvent : Dictionary<string, object>
    {
        public long Id
        {
            get
            {
                return GetProperty<long>("Id");
            }
        }

        public string Type
        {
            get
            {
                return GetProperty<string>("Type");
            }
        }

        public DateTime PublicDate
        {
            get
            {
                return GetProperty<DateTime>("PublicDate");
            }
        }

        public T GetProperty<T>(string name)
        {
            if(ContainsKey(name))
            {
                return (T)this[name];
            }
            return default(T);
        }
    }
}
