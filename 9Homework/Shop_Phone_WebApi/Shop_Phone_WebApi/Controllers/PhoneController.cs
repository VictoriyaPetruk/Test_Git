using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LibraryWorkWithADONET;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop_Phone_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        List<ClassPhone> phones = new List<ClassPhone>();
        // GET: api/Phone
        [HttpGet]
        public IEnumerable<ClassPhone> Get()
        {
            ClassADONET ado = new ClassADONET();
            SqlConnection conn = ado.GetConncection();
            return ado.SelectPhone(conn).Result;
            // return new string[] { "value1", "value2" };
        }


        // GET: api/Phone/5
        [HttpGet("{id}", Name = "Get")]
        public object Get(int id)
        {
            ClassADONET ado = new ClassADONET();
            SqlConnection conn = ado.GetConncection();
            phones = ado.SelectPhone(conn).Result;
            foreach (ClassPhone p in phones)
            {
                if (p.IDPhone == id)
                {
                    return p;
                }
            }
            return "can't found";
        }

        // POST: api/Phone
        //[FromBody]?? нужно ?
        [HttpPost]
        public string Post(ClassPhone value)
        {
            ClassADONET ado = new ClassADONET();
            SqlConnection conn = ado.GetConncection();
            ado.InsertPhone(conn, value).Wait();
            return " create";
        }
        //
        [HttpPost("{id}")]
        [Route("change")]
        public string Post2([FromBody]ClassPhone value,[FromQuery]int id)
        {
            ClassADONET ado = new ClassADONET();
            SqlConnection conn = ado.GetConncection();
            ado.UpdatePhone(conn, value,id).Wait();
            return "phone is chaged";
        }
        // PUT: api/Phone/5
        //[FromBody]
        [HttpPut("{name}")]
        public object Put(string name)
        {
            ClassADONET ado = new ClassADONET();
            SqlConnection conn = ado.GetConncection();
            phones = ado.SelectPhone(conn).Result;
            foreach (ClassPhone p in phones)
            {  //{  if(p==phone)
                //    {
                //        return p;
                //    }
                if (p.Marka.Trim() == name)
                {
                    return p;
                }
            }
            return "can't found";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            ClassADONET ado = new ClassADONET();
            SqlConnection conn = ado.GetConncection();
            ado.Delete(conn,id).Wait();
            return "Данные удалились";
        }
    }
}
