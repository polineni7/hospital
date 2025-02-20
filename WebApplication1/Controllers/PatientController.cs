﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PatientRegWrapper
    {
        public PatientRegistrations preg { get; set; }
        public int trans { get; set; }
        public String result { get; set; }
    }
    public class PatientController : Controller
    {
        [HttpPost]
        [Route("api/Labc/getRegi")]

        public PatientRegWrapper getRegi([FromBody] PatientRegWrapper lc)
        {
            hospitalsContext db = new hospitalsContext();
            String msg = "";

            try
            {
                if (descision(lc.preg.PatientId))
                {
                    switch (lc.trans)
                    {
                        case 1:
                            db.PatientRegistrations.Add(lc.preg);
                            db.SaveChanges();
                            msg = "ok";
                            break;
                        case 2:
                            var ld = db.PatientRegistrations.Where(a => a.PatientId == lc.preg.PatientId).FirstOrDefault();
                            ld.PatientId = lc.preg.PatientId;
                            ld.PatientName = lc.preg.PatientName;
                            ld.Mobilenumber = lc.preg.Mobilenumber;
                            ld.Addr = lc.preg.Addr;
                            ld.City = lc.preg.City;
                            db.SaveChanges();
                            msg = "ok";
                            break;
                        case 3:
                            var del = db.PatientRegistrations.Where(a => a.PatientId == lc.preg.PatientId).FirstOrDefault();
                            db.PatientRegistrations.Remove(del);
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
        public Boolean descision(int? pid)
        {
            var b = false;
            hospitalsContext db = new hospitalsContext();
            var y = db.PatientRegistrations.Where(a => a.PatientId == pid).FirstOrDefault();
            if (y != null)
            {
                b = true;
            }

            return b;
        }

    }
}
