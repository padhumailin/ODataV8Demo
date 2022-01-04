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
                new Accounts {Id = Guid.NewGuid(), AccountName = "Ac1", AccountType = "External", StartDate = new DateTime(2014,01,10), EndDate = new DateTime(2025,01,09), IsActive = true},
                new Accounts {Id = Guid.NewGuid(), AccountName = "Ac2", AccountType = "External", StartDate = new DateTime(2015,01,10), EndDate = new DateTime(2025,01,09), IsActive = true},
                new Accounts {Id = Guid.NewGuid(), AccountName = "Ac3", AccountType = "Internal", StartDate = new DateTime(2021,01,10), EndDate = new DateTime(2025,01,09), IsActive = true},
                new Accounts {Id = Guid.NewGuid(), AccountName = "Ac4", AccountType = "External", StartDate = new DateTime(2014,08,10), EndDate = new DateTime(2025,01,09), IsActive = true},
                new Accounts {Id = Guid.NewGuid(), AccountName = "Ac5", AccountType = "Internal", StartDate = new DateTime(2014,01,10), EndDate = new DateTime(2020,01,09), IsActive = false},
                new Accounts {Id = Guid.NewGuid(), AccountName = "Ac6", AccountType = "Internal", StartDate = new DateTime(2014,01,10), EndDate = new DateTime(2025,01,09), IsActive = true}
            };
            return Ok(accounts);
        }
    }
}
