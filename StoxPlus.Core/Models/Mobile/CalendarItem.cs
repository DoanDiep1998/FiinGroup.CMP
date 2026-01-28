using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Core.Models.Mobile
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class CalendarItem : Dictionary<string, object>
    {
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
            if (ContainsKey(name))
            {
                return (T)this[name];
            }
            return default(T);
        }
    }
}
