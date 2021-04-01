using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdmissionWrapper
    {
        public PatientAdmissions padmi { get; set; }
        public int trans { get; set; }
        public String result { get; set; }
    }
    public class PatientAdmissionsController : Controller
    {
        [HttpPost]
        [Route("api/Labc/getAdmissions")]

        public AdmissionWrapper getAdmissions([FromBody] AdmissionWrapper lc)
        {
            hospitalsContext db = new hospitalsContext();
            String msg = "";

            try
            {
                if (descision(lc.padmi.PatientId))
                {
                    switch (lc.trans)
                    {
                        case 1:
                            db.PatientAdmissions.Add(lc.padmi);
                            db.SaveChanges();
                            msg = "ok";
                            break;
                        case 2:
                            var ld = db.PatientAdmissions.Where(a => a.AdminssionId == lc.padmi.AdminssionId).FirstOrDefault();
                            ld.PatientId = lc.padmi.PatientId;
                            ld.JoiningDate = lc.padmi.JoiningDate;
                            ld.Roomno = lc.padmi.Roomno;
                            ld.DailyAmt = lc.padmi.DailyAmt;
                            db.SaveChanges();
                            msg = "ok";
                            break;
                        case 3:
                            var del = db.PatientAdmissions.Where(a => a.AdminssionId == lc.padmi.AdminssionId).FirstOrDefault();
                            db.PatientAdmissions.Remove(del);
                            db.SaveChanges();
                            msg = "OK";
                            break;

                    }
                }
                else
                {
                    msg = "not exists";
                }
            }
            catch (Exception eee)
            {
                msg = eee.Message;
            }
            lc.result = msg;
            return lc;


        }
        public Boolean descision(int? aid)
        {
            var b = false;
            hospitalsContext db = new hospitalsContext();
            var y = db.PatientAdmissions.Where(a => a.AdminssionId == aid).FirstOrDefault();
            if (y != null)
            {
                b = true;
            }

            return b;
        }

    }
}
