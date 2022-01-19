using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VillageAPP.Models;

namespace VillageAPP.Controllers.api
{
    public class MajorController : ApiController
    {
        static string StringConnection = "Data Source=SHIMONSAMAY;Initial Catalog=OldersDB;Integrated Security=True;Pooling=False";
        OldersDBDataContext dataContext = new OldersDBDataContext(StringConnection);

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(dataContext.OldersTabs.ToList());
            }
            catch(SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

       
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(dataContext.OldersTabs.First(older => older.Id == id));
            }
             catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        
        public IHttpActionResult Post([FromBody]OldersTab newOlder)
        {
            try
            {
                dataContext.OldersTabs.InsertOnSubmit(newOlder);
                dataContext.SubmitChanges();
                return Ok(dataContext.OldersTabs.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

       
        public IHttpActionResult Put(int id, [FromBody] OldersTab newOlder)
        {
            try
            {
                OldersTab olderToUpdate = dataContext.OldersTabs.First(older => older.Id == id);
                olderToUpdate.Experience = newOlder.Experience;
                olderToUpdate.BirthDate = newOlder.BirthDate;
                olderToUpdate.FullName = newOlder.FullName;
                dataContext.SubmitChanges();
                return Ok(dataContext.OldersTabs.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        
        public IHttpActionResult Delete(int id)
        {
            try
            {
                dataContext.OldersTabs.DeleteOnSubmit(dataContext.OldersTabs.First(older => older.Id == id));
                dataContext.SubmitChanges();
                return Ok(dataContext.OldersTabs.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
