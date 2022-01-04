using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataV8Demo.Entities
{
    public class Devices
    {
        public Guid Id { get; set; }
        public string DeviceName { get; set; }

        public string DeviceSerialNumber { get; set; }

        public string VendorName { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public bool ActivePolicy { get; set; }
    }
}
