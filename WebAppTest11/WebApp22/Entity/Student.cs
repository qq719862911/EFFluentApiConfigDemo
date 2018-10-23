using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp22.Entity
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public long ClassId { get; set; } //如果是可以为null的话得标注为long?,配置处 HasOptional(s => s.Class).WithMany().HasForeignKey(s => s.ClassId);
        public virtual Class Class { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}