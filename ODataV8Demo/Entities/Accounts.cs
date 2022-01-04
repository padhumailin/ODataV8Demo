using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataV8Demo.Entities
{
    public class Accounts
    {
        public Guid Id { get; set; }
        public string AccountName { get; set; }

        public string AccountType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

    }
}
