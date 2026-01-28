namespace FiinGroup.CMP.PM.Models
{
    public class SubmitConsentRequest
    {
        public string IdentityKey { get; set; } = null!;
        public string UserInfo { get; set; } = null!;
        public string ClientInfo { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CreateBy { get; set; } = null!;
        public List<SubmitPolicyItem> Policies { get; set; } = new();
    }
}
