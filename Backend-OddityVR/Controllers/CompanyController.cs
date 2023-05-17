﻿using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.DTO.CompanyDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Controllers
{
    [Route("api/company")]
    [EnableCors]
    [ApiController]
    public class CompanyController : Controller
    {
        // properties
        private readonly ICompanyAppService _companyService;


        // constructor
        public CompanyController(ICompanyAppService companyService)
        {
            _companyService = companyService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public ActionResult<CompaniesDetailsDTO> CreateNewCompany(CreateCompanyCmd newCompanyCmd)
        {
            try
            {
                return Ok(_companyService.CreateNewCompany(newCompanyCmd));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("get_all")]
        [HttpGet]
        public ActionResult<List<CompaniesDetailsDTO>> GetAllCompanies()
        {
            try
            {
                return Ok(_companyService.GetAllCompanies());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public ActionResult<CompaniesDetailsDTO> GetCompany(int id)
        {
            try
            {
                return Ok(_companyService.GetCompanyById(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("update")]
        [HttpPut]
        public ActionResult<CompaniesDetailsDTO> UpdateCompany(UpdateCompanyCmd company)
        {
            try
            {
                return Ok(_companyService.UpdateCompany(company));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public ActionResult DeleteCompany(int id)
        {
            try
            {
                _companyService.DeleteCompany(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
