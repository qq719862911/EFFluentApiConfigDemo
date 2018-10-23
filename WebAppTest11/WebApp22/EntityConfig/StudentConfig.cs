using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApp22.Entity;

namespace WebApp22.EntityConfig
{
    class StudentConfig : EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            this.ToTable("T_Students");
            this.Property(s => s.Name).IsRequired().HasMaxLength(50);
            Property(s => s.ClassId).IsOptional();

            // 总结一对多、多对多的“最佳实践”一对多最佳方法（不配置一端的集合属性
            this.HasRequired(s => s.Class).WithMany().HasForeignKey(s => s.ClassId);

            //只在多端配置一次
            //  this.HasRequired(s => s.Class).WithMany(c => c.Students).HasForeignKey(s => s.ClassId);//表示“我需要(Require)一个 Class，Class 有很多(Many)的 Student；ClassId 是这样一个外键”。
            // HasOptional(s => s.Class).WithMany().HasForeignKey(s => s.ClassId);//班级可空
            //如果是可以为null的话得标注为long?,配置处 HasOptional(s => s.Class).WithMany().HasForeignKey(s => s.ClassId);

        }
    }
}