using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp22.Entity
{
    public class Class
    {
        public long Id { get; set; }
        public string Name { get; set; }
     //   public virtual ICollection<Student> Students { get; set; } = new List<Student>();
      //业界大佬介意不用这个导航属性，不要配置 双向

    }
}