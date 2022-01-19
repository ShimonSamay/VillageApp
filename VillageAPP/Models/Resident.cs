using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VillageAPP.Models
{
    public class Resident
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public bool BornAtVillage { get; set; }
        public string BirthDate { get; set; }

        public Resident (int _id , string _firstName , string _fatherName , string _gender , bool _bornAt , string _birthDate)
        {
            this.Id = _id ; 
            this.FirstName = _firstName ;
            this.FatherName = _fatherName ;
            this.Gender = _gender ;
            this.BornAtVillage = _bornAt ;
            this.BirthDate = _birthDate ;
            

        }
        public Resident () { }

    }
}