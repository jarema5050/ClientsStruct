using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ClientsStruct.Models;
using ClientsStruct.DTOS;
using AutoMapper;
using FluentValidation.Results;

namespace ClientsStruct.Controllers
{
    public class CusComAccountsController : ApiController
    {
        private ClientsStructContext db = new ClientsStructContext();

        
        // POST: api/CusComAccounts
        public async Task<IHttpActionResult> PostCusComAccount(AccountDto accountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (String.IsNullOrEmpty(accountDto.CompanyName))
            {
                //entering private customer 
                var customer = db.Customers.SingleOrDefault(c => c.Name + c.Surname == accountDto.Name + accountDto.Surname);
                if (customer == null)
                {
                    //create customer
                    customer = new Customer
                    {
                        Name = accountDto.Name,
                        Surname = accountDto.Surname
                    };
                    db.Customers.Add(customer);
                }
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AccountDto, CustomerAccount>();
                });
                IMapper mapper = config.CreateMapper();

                var customerWithSameEmail = db.CustomerAccounts.SingleOrDefault(c => c.Email == accountDto.Email && c.IsThisEmailCurrent == true);
                if (customerWithSameEmail != null)
                {
                    customerWithSameEmail.IsThisEmailCurrent = false;
                }

                if (db.CustomerAccounts.SingleOrDefault(c => c.Login == accountDto.Login) != null)
                {
                    return BadRequest("Login you've used is not unique.");
                }
                var customerAccount = mapper.Map<AccountDto, CustomerAccount>(accountDto);
                customerAccount.CustomerId = customer.Id;
                customerAccount.IsThisEmailCurrent = true;
                db.CustomerAccounts.Add(customerAccount);
                await db.SaveChangesAsync();
                return CreatedAtRoute("DefaultApi", new { id = customerAccount.Id }, customerAccount);
            }
            else if (String.IsNullOrEmpty(accountDto.CompanyName) == false && String.IsNullOrEmpty(accountDto.Nip) == false)
            {
                //entering company
                var company = db.Companies.SingleOrDefault(c => c.Name == accountDto.CompanyName);
                if (company == null)
                {
                    //new company
                    if (db.Companies.SingleOrDefault(c => c.Nip == accountDto.Nip) != null)
                        return BadRequest("uniqueness NIP id violation");
                    company = new Company
                    {
                        Name = accountDto.CompanyName,
                        Nip = accountDto.Nip
                    };
                    db.Companies.Add(company);
                }
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AccountDto, CompanyAccount>();
                });
                IMapper mapper = config.CreateMapper();
                //Email uniqness
                var companyAccountWithSameEmail = db.CompanyAccounts.SingleOrDefault(c => c.Email == accountDto.Email && c.IsThisEmailCurrent == true);
                if (companyAccountWithSameEmail != null)
                {
                    companyAccountWithSameEmail.IsThisEmailCurrent = false;
                }
                if (db.CompanyAccounts.SingleOrDefault(c => c.Login == accountDto.Login) != null)
                {
                    return BadRequest("Login you've used is not unique.");
                }
                var companyAccount = mapper.Map<AccountDto, CompanyAccount>(accountDto);
                companyAccount.CompanyId = company.Id;
                companyAccount.IsThisEmailCurrent = true;
                db.CompanyAccounts.Add(companyAccount);
                await db.SaveChangesAsync();
                return CreatedAtRoute("DefaultApi", new { id = companyAccount.Id }, companyAccount);
            }
            else
            {
                return BadRequest("If You want to create new company NIP has to be filled");
            }
            }
    }
}