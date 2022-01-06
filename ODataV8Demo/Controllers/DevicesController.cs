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
    //[Route("api/[controller]")]
    //[ApiController]
    public class DevicesController : ODataController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableQuery]
        public IActionResult GetDevices()
        {
            var devices = new List<Devices>()
            {
                new Devices {Id = Guid.NewGuid(), DeviceName = "Dv1", DeviceSerialNumber = "xyz", ActivePolicy= true, DateOfPurchase = new DateTime(2014,01,10), VendorName = "v1"},
                new Devices {Id = Guid.NewGuid(), DeviceName = "Dv2", DeviceSerialNumber = "123", ActivePolicy= true, DateOfPurchase = new DateTime(2014,01,10), VendorName = "v1"},
                new Devices {Id = Guid.NewGuid(), DeviceName = "Dv3", DeviceSerialNumber = "abc", ActivePolicy= true, DateOfPurchase = new DateTime(2014,01,10), VendorName = "v2"},
                new Devices {Id = Guid.NewGuid(), DeviceName = "Dv4", DeviceSerialNumber = "999", ActivePolicy= false, DateOfPurchase = new DateTime(2014,01,10), VendorName = "v2"},
                new Devices {Id = Guid.NewGuid(), DeviceName = "Dv5", DeviceSerialNumber = "111", ActivePolicy= true, DateOfPurchase = new DateTime(2014,01,10), VendorName = "v3"},
                new Devices {Id = Guid.NewGuid(), DeviceName = "Dv6", DeviceSerialNumber = "800", ActivePolicy= true, DateOfPurchase = new DateTime(2014,01,10), VendorName = "v3"},
                new Devices {Id = Guid.NewGuid(), DeviceName = "Dv7", DeviceSerialNumber = "111", ActivePolicy= true, DateOfPurchase = new DateTime(2014,01,10), VendorName = "v3"},
                new Devices {Id = Guid.NewGuid(), DeviceName = "Dv8", DeviceSerialNumber = "800", ActivePolicy= false, DateOfPurchase = new DateTime(2014,01,10), VendorName = "v3"},
            };
            return Ok(devices);
        }
    }
}
