namespace FiinGroup.CMP.PM.Models.ViewModels
{
    public class SaveConsentRequest
    {
        public string ProductCode { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? UserIdHash { get; set; }   // nếu đã login
        public string? UserInfo { get; set; }
        public string? DeviceId { get; set; }     // anonymous
        public List<ConsentItemDto> Consents { get; set; } = new();
    }
    public class ConsentItemDto
    {
        public string PolicyCode { get; set; } = string.Empty;
        public bool Accepted { get; set; }
    }
}
