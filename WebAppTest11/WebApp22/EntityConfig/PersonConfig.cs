using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApp22.Entity;

namespace WebApp22.EntityConfig
{
    class PersonConfig:EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
            this.ToTable("T_Persons");//
            this.Property(p => p.Name).HasMaxLength(50).IsRequired();//长度为50
            this.Property(p => p.CreateDateTime).HasColumnName("CreateDateTime").IsRequired();
            this.Property(p => p.RowVersionNum).IsRowVersion().IsRequired();
        }
    }
}