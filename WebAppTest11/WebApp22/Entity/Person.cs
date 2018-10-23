using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp22.Entity
{
    [Table("T_Persons")]
    public class Person
    {
        [Key]
        public long Id { set; get; }
        public string Name { get; set; }
        public DateTime CreateDateTime { get; set; }

        public byte[] RowVersionNum { get; set; }
    }
}