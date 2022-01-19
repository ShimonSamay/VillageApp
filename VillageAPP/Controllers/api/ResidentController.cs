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
    public class ResidentController : ApiController
    {
        VillageDB DBcontext = new VillageDB();
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(DBcontext.Residents.ToList());
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

        
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(DBcontext.Residents.First(res => res.Id == id));
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

        
        public IHttpActionResult Post([FromBody]Resident newResident)
        {
            try
            {
                
                    DBcontext.Residents.Add(newResident);
                    DBcontext.SaveChanges();
                    return Ok(DBcontext.Residents.ToList());
                
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

        
        public IHttpActionResult Put(int id, [FromBody] Resident newResident)
        {
            try
            {
                Resident ressidentToUpdate = DBcontext.Residents.First(res => res.Id == id);
                ressidentToUpdate.FirstName = newResident.FirstName;
                ressidentToUpdate.BirthDate = newResident.BirthDate;
                ressidentToUpdate.BornAtVillage = newResident.BornAtVillage;
                ressidentToUpdate.Gender = newResident.Gender;
                ressidentToUpdate.FatherName = newResident.FatherName;
                DBcontext.SaveChanges();
                return Ok(DBcontext.Residents.ToList());
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
                DBcontext.Residents.Remove(DBcontext.Residents.First(resident => resident.Id == id));   
                DBcontext.SaveChanges();
                return Ok(DBcontext.Residents.ToList());
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
