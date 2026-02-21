using Dotnet_API_16.Entities.Dtos;
using Dotnet_API_16.Entities.Models;
using Dotnet_API_16.Services.CompanyService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_API_16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController(ICompanyService companyService) : ControllerBase
    {
        [HttpGet("GetAllCompanies")]
        public async Task<ActionResult<List<GetAllCompaniesDto>>> GetAlLCompanies(int pageNumber =1,int pageSize=10)
        {
            var companies = await companyService.GetAllCompaniesAsync(pageNumber,pageSize);
            return Ok(companies);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetCompanyByIdDtocs>> GetCompanyById(int id)
        {
            var company = await companyService.GetCompanyById(id);

            if(company is null)
            {
                return NotFound("Company with this ID: {id} does not exists");
            }
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<GetCompanyByIdDtocs>> AddCompany(AddCompanyDto addCompanyDto)
        {
            var company = await companyService.AddComapny(addCompanyDto);

            if(company is null)
            {
                return BadRequest("Company could not be added");
            }

            return CreatedAtAction(nameof(GetCompanyById), new { id = company.CompanyId }, company);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> UpdateCompany(int id, UpdateCompanyDto updateCompanyDto)
        {
           var company = await companyService.UpdateCompany(id, updateCompanyDto);
           
            if(company is false)
            {
                return NotFound("Company with this ID: {id} does not exists");
            }

            return Ok(company);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteCompany(int id)
        {
            var comapny = await companyService.DeleteCompany(id);
            if (!comapny)
            {
                return NotFound("Company with this ID: {id} not found");
            }

            return NoContent();
        }
    }
}
