using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp_4.Server.Data;

namespace BlazorApp_4.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateLabelController : ControllerBase
    {
        private readonly Digitalshop_V2Context _context;
        public GenerateLabelController(Digitalshop_V2Context context)
        {
            this._context = context;
        }
        public class GenLabel {
            public string Labelid { get; set; }
        }
        [HttpGet("{id}")]
        public async Task<GenLabel> Get(int id)
        {
            GenLabel Label = new GenLabel();
            string refName = string.Empty;
            TblDeviceTypes type = _context.TblDeviceTypes.SingleOrDefault(t => t.Typeid == id);
            if (type != null)
            {
                string shortName = type.Shortname;
                var device = _context.Set<GenLabel>().FromSqlRaw("EXECUTE sp_GenerateDeviceLabelID {0}",shortName).ToArray();
                if (device == null || device.FirstOrDefault() == null)
                    refName = shortName + "1";
                else
                    refName = shortName + device.FirstOrDefault().Labelid;
                Label.Labelid = refName;
            }
            return Label;
        }
    }
}
