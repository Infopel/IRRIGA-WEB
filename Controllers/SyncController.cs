using IRRIGA.Repositories;
using IRRIGA.Models;
using IRRIGA.WatermemonSync;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRRIGA.Request;
using Microsoft.Extensions.Logging;
using IRRIGA.Data;

namespace IRRIGA.Controllers
{
    public class SyncController : Controller
    {
        private SyncRepository _syncRepository;

        private readonly ILogger<SyncController> _logger;
        public SyncController(ILogger<SyncController> logger, dbIRRIGAContext context)
        {
            _logger = logger;
            _syncRepository = new SyncRepository(context);
        }

        [HttpGet("v1.0/Sync")]
        public PullResponse Get([FromQuery] long lastSyncAt, [FromQuery] string user, [FromQuery] string deviceIMEI)
        {
            if (lastSyncAt == null || lastSyncAt == 0)
                return new PullResponse() { Changes = _syncRepository.Pull(null, null, null), Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds() };
            return new PullResponse() { Changes = _syncRepository.Pull(UnixTimeStampToDateTime(lastSyncAt), user, deviceIMEI), Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds() };
        }

        [HttpPost("v1.0/Sync")]
        public ActionResult Post([FromBody] PushRequest request)
        {
            try { 
                var dbStatus = _syncRepository.Push(request.Changes, request.User, request.DeviceIMEI);

                if (dbStatus.Count() <= 15)
                    return Ok(new { sucess = dbStatus });
                else
                    return StatusCode(500, dbStatus);

            } catch (Exception ex)
            {
               return StatusCode(500, ex.InnerException.Message);
            }
        }

        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            double dTimeSpan = Convert.ToDouble(unixTimeStamp);
            DateTime dtReturn = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Math.Round(dTimeSpan / 1000d)).ToLocalTime();
            return dtReturn;
        }
    }
}
