using ProtoBuf;

namespace StoxPlus.Core.Models.ApiLimit
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class Package_Api
    {
        public int APIID { get; set; }
        public string PackageCode { get; set; }
        public string ActionName { get; set; }
    }
}
