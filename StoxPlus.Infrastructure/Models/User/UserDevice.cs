using ProtoBuf;
using StoxPlus.Infrastructure.Enums;
using System;

namespace StoxPlus.Infrastructure.Models.User
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, InferTagFromName = true)]
    public class UserDevice
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string DeviceId { get; set; }
        public string Devicename { get; set; }
        public UserDeviceStatus Status { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public DateTime ActivatedDate { get; set; }
    }
}
