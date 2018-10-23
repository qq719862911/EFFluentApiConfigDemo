using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using WebApp22.Entity;

namespace WebApp22.DB
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=conn1")
        {
            System.Data.Entity.Database.SetInitializer<MyDbContext>(null);//是 DBMigration 用的，也就 是由 EF 帮我们建数据库，现在我们用不到，用下面的代码禁用：
            this.Database.Log = MyDBLog;
        }
        public DbSet<Person> Persons { get; set; }//通过对Persons集合的操作就可以完成对T_Persons表的操作
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UsersSharedCar> UsersSharedCars { get; set; }
        public DbSet<SharedCar> SharedCars { get; set; }

        private void MyDBLog(string sql)
        { 
            byte[] myByte = System.Text.Encoding.UTF8.GetBytes(sql);
            using (FileStream fsWrite = new FileStream(@"D:\1.txt", FileMode.Append))
            {
                fsWrite.Write(myByte, 0, myByte.Length);
            };
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(
                Assembly.GetExecutingAssembly());//代表从这句话所在的程序集加载所有的继承自 EntityTypeConfiguration 为模型配置类。
        }
    }
}