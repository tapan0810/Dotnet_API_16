using Dotnet_API_16.Entities.Dtos;

namespace Dotnet_API_16.Services.CompanyService
{
    public interface ICompanyService
    {
        public Task<List<GetAllCompaniesDto>> GetAllCompaniesAsync(int pageNumebr,int pageSize);
        public Task<GetCompanyByIdDtocs?> GetCompanyById(int id);
        public Task<GetCompanyByIdDtocs?> AddComapny(AddCompanyDto addCompanyDto);
        public Task<bool> UpdateCompany(int id, UpdateCompanyDto updateCompanyDto);
        public Task<bool>DeleteCompany(int id);
    }
}
