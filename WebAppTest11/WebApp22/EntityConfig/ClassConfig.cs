using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApp22.Entity;

namespace WebApp22.EntityConfig
{
    class ClassConfig:EntityTypeConfiguration<Class>
    {
        public ClassConfig() {
            this.ToTable("T_Classes");
            this.Property(p => p.Name).IsRequired().HasMaxLength(50);
            //this.HasMany(c => c.Students).WithRequired().HasForeignKey(c => c.ClassId);//entity中定义了导航属性 Students，配置了  this.HasMany(c => c.Students).WithRequired().HasForeignKey(c => c.ClassId);，就可以这样用
        }
    }
}