using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataV8Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataV8Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ODataController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableQuery]
        public IActionResult GetAccounts()
        {
            var accounts = new List<Accounts>()
            {
                new Accounts {Id = 1, AccountName = "Ac1", AccountType = "External", StartDate = new DateTime(2014,01,10), EndDate = new DateTime(2025,01,09), IsActive = true
                ,Licenses = new List<License> { new License { Name="LIC1", Id = Guid.NewGuid() , StartDate= new DateTime(2014,08,10), EndDate =new DateTime(2014,09,10)},
                                                       new License { Name="LIC2", Id = Guid.NewGuid(), StartDate= new DateTime(2014,08,10), EndDate =new DateTime(2015,08,10) },
                                                       new License { Name="LIC2", Id = Guid.NewGuid(), StartDate= new DateTime(2014,08,10), EndDate =new DateTime(2015,08,10) }} },
                new Accounts {Id = 2, AccountName = "Ac2", AccountType = "External", StartDate = new DateTime(2015,01,10), EndDate = new DateTime(2025,01,09), IsActive = true
                  ,Licenses = new List<License> { new License { Name="Loan1", Id = Guid.NewGuid()  , StartDate= new DateTime(2014,08,10), EndDate =new DateTime(2015,08,10)},
                                                       new License { Name="Loan2", Id = Guid.NewGuid() , StartDate= new DateTime(2014,08,10), EndDate =new DateTime(2015,08,10) },
                                                       new License { Name="Loan3", Id = Guid.NewGuid()  , StartDate= new DateTime(2014,08,10), EndDate =new DateTime(2015,08,10)}} },
                new Accounts {Id = 3, AccountName = "Ac3", AccountType = "Internal", StartDate = new DateTime(2021,01,10), EndDate = new DateTime(2025,01,09), IsActive = true
                  ,Licenses = new List<License> { new License { Name="Loan1", Id = Guid.NewGuid()  , StartDate= new DateTime(2014,08,10), EndDate =new DateTime(2015,08,10)},
                                                       new License { Name="Loan2", Id = Guid.NewGuid()  , StartDate= new DateTime(2014,08,10), EndDate =new DateTime(2015,08,10)},
                                                       new License { Name="Loan3", Id = Guid.NewGuid() , StartDate= new DateTime(2014,08,10), EndDate =new DateTime(2015,08,10) }} },
                new Accounts {Id = 4, AccountName = "Ac4", AccountType = "External", StartDate = new DateTime(2014,08,10), EndDate = new DateTime(2025,01,09), IsActive = true},
                new Accounts {Id = 5, AccountName = "Ac5", AccountType = "Internal", StartDate = new DateTime(2014,01,10), EndDate = new DateTime(2020,01,09), IsActive = false},
                new Accounts {Id = 6, AccountName = "Ac6", AccountType = "Internal", StartDate = new DateTime(2014,01,10), EndDate = new DateTime(2025,01,09), IsActive = true}
            };
            return Ok(accounts);
        }
    }
}
