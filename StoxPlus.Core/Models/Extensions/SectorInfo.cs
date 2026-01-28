using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoxPlus.Core.Models
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class SectorInfo
    {
        public string IcbCode { get; set; }

        public string IcbName { get; set; }

        public string en_IcbName { get; set; }

        public string jp_IcbName { get; set; }

        public string ParentIcbCode { get; set; }

        public int IcbLevel { get; set; }

        public string IcbCodePath { get; set; }

        public string IcbNamePath { get; set; }

        public string en_IcbNamePath { get; set; }

        public string jp_IcbNamePath { get; set; }
    }
}
