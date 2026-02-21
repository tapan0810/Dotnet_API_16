using Dotnet_API_16.Data;
using Dotnet_API_16.Entities.Dtos;
using Dotnet_API_16.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_16.Services
{
    public class CompanyService(CompanyDbContext _context) : ICompanyService
    {
        public async Task<GetCompanyByIdDtocs?> AddComapny(AddCompanyDto addCompanyDto)
        {
            var company = new Company
            {
                CompanyName = addCompanyDto.CompanyName,
                CompanyAddress = addCompanyDto.CompanyAddress,
                CompanyCity = addCompanyDto.CompanyCity,
                CompanyOwner = addCompanyDto.CompanyOwner,
                IsActive = addCompanyDto.IsActive
            };

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return new GetCompanyByIdDtocs
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                CompanyAddress = company.CompanyAddress,
                CompanyCity = company.CompanyCity,
                CompanyOwner = company.CompanyOwner,
                IsActive = company.IsActive
            };

        }

        public async Task<bool> DeleteCompany(int id)
        {
            var comapny = await _context.Companies.FirstOrDefaultAsync(x =>x.CompanyId == id);
            if (comapny is null)
                return false;

            _context.Companies.Remove(comapny);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<GetAllCompaniesDto>> GetAllCompaniesAsync()
        {
            var companies = _context.Companies
                .Select(s => new GetAllCompaniesDto
                {
                    CompanyName = s.CompanyName,
                    CompanyAddress = s.CompanyAddress,
                    CompanyCity = s.CompanyCity,
                    CompanyOwner = s.CompanyOwner,
                    IsActive = s.IsActive
                }
                ).ToListAsync();

            if(companies == null)
            {
                return null;
            }

            return companies;

        }

        public async Task<GetCompanyByIdDtocs?> GetCompanyById(int id)
        {
            var company = await _context.Companies
                 .Where(x => x.CompanyId == id)
                 .Select(s => new GetCompanyByIdDtocs
                 {
                     CompanyId = s.CompanyId,
                     CompanyName = s.CompanyName,
                     CompanyAddress = s.CompanyAddress,
                     CompanyCity = s.CompanyCity,
                     CompanyOwner = s.CompanyOwner,
                     IsActive = s.IsActive

                 }).FirstOrDefaultAsync();

            if (company is null)
                return null;

            return company;
        }

        public async Task<bool> UpdateCompany(int id, UpdateCompanyDto updateCompanyDto)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.CompanyId == id);

            if (company is null)
                return false;

            company.CompanyName = updateCompanyDto.CompanyName;
            company.CompanyAddress = updateCompanyDto.CompanyAddress;
            company.CompanyCity = updateCompanyDto.CompanyCity;
            company.CompanyOwner = updateCompanyDto.CompanyOwner;
            company.IsActive = updateCompanyDto.IsActive;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
