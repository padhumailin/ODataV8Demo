using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataV8Demo.Entities
{
    public class Accounts
    {
        public int Id { get; set; }
        public string AccountName { get; set; }

        public string AccountType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public ICollection<LinkedAccounts> LinkedAccounts { get; set; }

    }

    public class LinkedAccounts
    {
        public Guid Id { get; set; }
        public int ParentId { get; set; }
        public string LinkedAccountName { get; set; }

        public Accounts Accounts { get; set; }
    }
}
