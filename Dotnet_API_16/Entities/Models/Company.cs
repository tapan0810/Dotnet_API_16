namespace Dotnet_API_16.Entities.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyAddress { get; set; } = string.Empty;
        public string CompanyCity { get; set; } = string.Empty;
        public string CompanyOwner { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
