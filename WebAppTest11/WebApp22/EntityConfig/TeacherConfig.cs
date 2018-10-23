using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApp22.Entity;

namespace WebApp22.EntityConfig
{
    class TeacherConfig:EntityTypeConfiguration<Teacher>
    {
        public TeacherConfig()
        {
            this.ToTable("T_Teachers");
            this.Property(t => t.Name).IsRequired().HasMaxLength(50);

            //老师有多个学生
            /*
            关系配置到任何一方都可以
这样不用中间表建实体（也可以为中间表建立一个实体，其实思路更清晰），就可以完
成多对多映射。当然如果中间关系表还想有其他字段，则要必须为中间表建立实体类。。
            */

            //为左外键配置列的名称。 左外键指向HasMany调用中指定的导航属性的父实体。

            this.HasMany(t => t.Students).WithMany(s => s.Teachers).Map(x => x.ToTable("T_StudentsTeachers").MapLeftKey("TeacherId").MapRightKey("StudentId"));//配置一端就可以了。
           


        }
    }
}