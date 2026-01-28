using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Core.Models.Extensions
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class IndicatorInfo
    {
        public string Name { get; set; }
        public string en_Name { get; set; }
        public string jp_Name { get; set; }
        public string Code { get; set; }
    }
}
