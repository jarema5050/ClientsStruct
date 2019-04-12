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
namespace ClientsStruct.Controllers
{
    public class CompanyAccountsController : ApiController
    {
        private ClientsStructContext db = new ClientsStructContext();

        // GET: api/CompanyAccounts
        public IQueryable<CompanyAccount> GetCompanyAccounts()
        {
            return db.CompanyAccounts;
        }

        // GET: api/CompanyAccounts/5
        [ResponseType(typeof(CompanyAccount))]
        public async Task<IHttpActionResult> GetCompanyAccount(int id)
        {
            CompanyAccount companyAccount = await db.CompanyAccounts.FindAsync(id);
            if (companyAccount == null)
            {
                return NotFound();
            }

            return Ok(companyAccount);
        }

        // PUT: api/CompanyAccounts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCompanyAccount(int id, CompanyAccount companyAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyAccount.Id)
            {
                return BadRequest();
            }

            db.Entry(companyAccount).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CompanyAccounts
        [ResponseType(typeof(CompanyAccount))]
        public async Task<IHttpActionResult> PostCompanyAccount(AccountDto accountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = new Company
            {
                Id = accountDto.CompanyId,
                Name = accountDto.CompanyName,
                Nip = accountDto.Nip
            };
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AccountDto, CompanyAccount>();
            });
            IMapper mapper = config.CreateMapper();
            var companyAccount = mapper.Map<AccountDto, CompanyAccount>(accountDto);
            db.CompanyAccounts.Add(companyAccount);
            db.Companies.Add(company);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = companyAccount.Id }, companyAccount);
        }

        // DELETE: api/CompanyAccounts/5
        [ResponseType(typeof(CompanyAccount))]
        public async Task<IHttpActionResult> DeleteCompanyAccount(int id)
        {
            CompanyAccount companyAccount = await db.CompanyAccounts.FindAsync(id);
            if (companyAccount == null)
            {
                return NotFound();
            }

            db.CompanyAccounts.Remove(companyAccount);
            await db.SaveChangesAsync();

            return Ok(companyAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyAccountExists(int id)
        {
            return db.CompanyAccounts.Count(e => e.Id == id) > 0;
        }
    }
}