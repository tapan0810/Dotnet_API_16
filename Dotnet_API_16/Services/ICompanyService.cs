using Dotnet_API_16.Entities.Dtos;

namespace Dotnet_API_16.Services
{
    public interface ICompanyService
    {
        public Task<List<GetAllCompaniesDto>> GetAllCompaniesAsync();
        public Task<GetCompanyByIdDtocs?> GetCompanyById(int id);
        public Task<GetCompanyByIdDtocs?> AddComapny(AddCompanyDto addCompanyDto);
        public Task<bool> UpdateCompany(int id, UpdateCompanyDto updateCompanyDto);
        public Task<bool>DeleteCompany(int id);
    }
}
