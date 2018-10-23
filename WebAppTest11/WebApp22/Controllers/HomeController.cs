using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApp22;
using WebApp22.DB;
using WebApp22.Entity;

namespace WebApp22.Controllers
{
    public class HomeController : Controller
    {
        [GetControllerName]
        public ActionResult Index()
        {
            //using (MyDbContext ctx = new MyDbContext())
            //{

            //Person p = new Person();
            //p.CreateDateTime = DateTime.Now;
            //p.Name = "rupeng888";
            //ctx.Persons.Add(p);
            //ctx.SaveChanges();

            // ctx.Database.ExecuteSqlCommand("update T_Persons set Name={0},CreateDateTime=GetDate()", "haiyi.com");
            //  long[] ids = { 2, 5, 6 };//不要写成int[]
            //var result = ctx.Persons.Where(p => ids.Contains(p.Id));
            //var result = ctx.Persons.Where(p => p.Name.StartsWith("rupeng"));
            // result.ToList();

            //DbRawSqlQuery<Item1> ql = ctx.Database.SqlQuery<Item1>("select Name,3 Count from T_Persons where Id>{0} and CreateDateTime<={1}", 2, DateTime.Now);
            //foreach (var item in ql)
            //{
            //    var name = item.Name;
            //}

            //  var result = ctx.Persons.Where(p => SqlFunctions.DateDiff("hour", p.CreateDateTime, DateTime.Now) > 1);
            // result.ToList();

            // var result = ctx.Persons.Where(p => Convert.ToString(p.Id) == "3");//会报错
            //SqlFunction
            //   var result = ctx.Persons.Where(p => SqlFunctions.DateDiff("hour", p.CreateDateTime, DateTime.Now) > 1);

            //var p1 = ctx.Persons.AsNoTracking().Where(p => p.Name == "如鹏").FirstOrDefault();

            /*
             * 1.
             如 果 插 入 一 个 Person 对 象 ， Name 属 性 的 值 非 常 长 ， 保 存 的 时 候 就 会 报 DbEntityValidationException 异常，这个异常的 Message 中看不到详细的报错消息，要看 EntityValidationErrors 属性的值
             */

            //Person p3 = new Person()
            //{
            //    Name = "aaaaaaa",
            //    CreateDateTime = DateTime.Now
            //};
            //try
            //{
            //    ctx.Persons.Add(p3);
            //    ctx.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{ 
            //    EFHelper.LogEFConfigError(ex);//把错误记录到文件
            //}

            //没有在student类中配置class时，先保存班级再 把班级id给学生存
            //Class c1 = new Class();
            //c1.Name = "net1Class";
            //ctx.Classes.Add(c1);
            //ctx.SaveChanges();

            //Student s1 = new Student();
            //s1.Name = "zhangsan1";
            //s1.Age = 30;
            //s1.ClassId = c1.Id;

            //Student s2 = new Student();
            //s2.Name = "lisi2";
            //s2.Age = 20;
            //s2.ClassId = c1.Id;

            //ctx.Students.Add(s1);
            //ctx.Students.Add(s2);
            //try
            //{
            //    ctx.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    EFHelper.LogEFConfigError(ex);//把错误记录到文件
            //}

            //配置导航属性（virtual Class）
            //Class c1 = new Class {Name="tree Class" };
            //ctx.Classes.Add(c1);

            //Student s1 = new Student { Age = 11, Name = "sharme" };
            //Student s2= new Student {  Name = "Joe" };

            //s1.Class = c1;
            //s2.Class = c1;

            //ctx.Students.Add(s1);
            //ctx.Students.Add(s2);
            //ctx.SaveChanges();

            //如果classId可为null
            //    Class c1 = new Class { Name = "red Class" };
            //    ctx.Classes.Add(c1);

            //    Student s1 = new Student { Age = 11, Name = "haha" };
            //    Student s2 = new Student { Name = "lolo" };

            //    ctx.Students.Add(s1);
            //    ctx.Students.Add(s2);
            //    ctx.SaveChanges();

            //}
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetClassInfo()
        {
            StringBuilder sb = new StringBuilder();
            using (MyDbContext ctx = new MyDbContext())
            {
                var classInfo = ctx.Classes.First();
                var stus = ctx.Students.Where(s => s.ClassId == classInfo.Id);
                //var classInfo = ctx.Classes.First();
                //  foreach (var s in classInfo.Students)//entity中定义了导航属性 Students，配置了  this.HasMany(c => c.Students).WithRequired().HasForeignKey(c => c.ClassId);，就可以这样用
                foreach (var s in stus)
                {
                    sb.Append(s.Name).Append("  Age:").Append(s.Age).Append("  class:").Append(s.Class.Name);
                }
            }
            return Content(sb.ToString());
        }

        public ActionResult UpdateTeacher()
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                Teacher t = ctx.Teachers.FirstOrDefault();
                if (t != null)
                {
                    Student s1 = t.Students.First();
                    t.Students.Remove(s1);
                    ctx.SaveChanges();
                }
            }
            return Content("OK");
        }

        public ActionResult AddTeacherAndStudent()
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                Teacher t1 = new Teacher();
                t1.Name = "ZhangT";
                t1.Students = new List<Student>();

                Teacher t2 = new Teacher();
                t2.Name = "WangT";
                t2.Students = new List<Student>();

                Class c1 = new Class();
                c1.Name = "Java";

                Class c2 = new Class();
                c2.Name = "C#";

                Student s1 = new Student();
                s1.Name = "tom";
                s1.Teachers = new List<Teacher>();
                s1.Class = c1;

                Student s2 = new Student();
                s2.Name = "jerry";
                s2.Teachers = new List<Teacher>();
                s2.Class = c2;

                t1.Students.Add(s1);
                t1.Students.Add(s2);
                t2.Students.Add(s2);

                ctx.Teachers.Add(t1);
                ctx.Teachers.Add(t2);
                ctx.Classes.Add(c1);
                ctx.Classes.Add(c2);
                ctx.Students.Add(s1);
                ctx.Students.Add(s2);
                try
                {
                    ctx.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    EFHelper.LogEFConfigError(ex);
                }
            }
            return Content("ok");
        }

        public ActionResult AddUserSharedCar()
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                User u1 = new User();
                u1.Name = "Tom";
                u1.Gender = true;

                SharedCar sc = new SharedCar();
                sc.Name = "blue shared bicycle";

                UsersSharedCar usc = new UsersSharedCar();
                usc.IntimacyValue = 19;
                usc.SharedCar = sc;
                usc.User = u1;

                ctx.Users.Add(u1);
                ctx.SharedCars.Add(sc);
                ctx.UsersSharedCars.Add(usc);

                ctx.SaveChanges();
            }
            return Content("ok");

        }

        class Item1
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GetAction()
        {
            return Content("");
        }

        public void Say(string name)
        {
            Console.WriteLine(name);
        }

        public ActionResult Contact()
        {
            DoPlay((a) => { Console.WriteLine("玩的很哈啊朋友" + a); });
            return View();
        }

        public void DoPlay(Action<string> play)
        {
            //  Func<int, int, string> ff = (i, j) => { return i + j + ""; };
            //Console.WriteLine("调用了");
            play("aaa");
        }

    }
}