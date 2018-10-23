using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p1 = new Person();
            //p1.Age = 30;
            //p1.Age++;
            //Console.Write(p1.Age);
            //int i = 2000; 
            //object o = i; 
            //i = 2001;
            //int j = (int)o;
            //Console.WriteLine("i={0},o={1},j={2}", i, o, j);

            // DoPlay((a) => { Console.WriteLine("玩的很哈啊朋友" + a); });
            // Child child = new Child();
            //child.Age = 89;
            //IList<Child> cs = new List<Child>();
            //for (int i = 0; i < 15; i++)
            //{
            //    Child c = new Child();
            //    c.Age = i;
            //    cs.Add(c);
            //}


            var s0 = new Person { Name = "tom", Age = 3, Gender = true, Salary = 6000 };
            var s1 = new Person { Name = "jerry", Age = 8, Gender = true, Salary = 5000 };
            var s2 = new Person { Name = "jim", Age = 3, Gender = true, Salary = 3000 };
            var s3 = new Person { Name = "lily", Age = 5, Gender = false, Salary = 9000 };
            var s4 = new Person { Name = "lucy", Age = 6, Gender = false, Salary = 2000 };
            var s5 = new Person { Name = "kimi", Age = 5, Gender = true, Salary = 1000 };

            List<Person> list = new List<Person>();
            list.Add(s0);
            list.Add(s1);
            list.Add(s2);
            list.Add(s3);
            list.Add(s4);
            list.Add(s5);
            //Teacher t1 = new Teacher { Name = "如鹏网张老师" };
            //t1.Students.Add(s1);
            //t1.Students.Add(s2);
            //Teacher t2 = new Teacher { Name = "如鹏网刘老师" };
            //t2.Students.Add(s2);
            //t2.Students.Add(s3);
            //t2.Students.Add(s5);
            //Teacher[] teachers = { t1, t2 };
            //IEnumerable<IGrouping<int, Person>> ages = list.GroupBy(p => p.Age);
            //foreach (IGrouping<int, Person> item in ages)
            //{
            //    Console.WriteLine(item.Key+"  "+item.Average(p=>p.Salary));
            //}


            Master m1 = new Master { Id = 1, Name = "杨中科" };
            Master m2 = new Master { Id = 2, Name = "比尔盖茨" };
            Master m3 = new Master { Id = 3, Name = "周星驰" };
            Master[] masters = { m1, m2, m3 };

            Dog d1 = new Dog { Id = 1, MasterId = 3, Name = "旺财" };
            Dog d2 = new Dog { Id = 2, MasterId = 3, Name = "汪汪" };
            Dog d3 = new Dog { Id = 3, MasterId = 1, Name = "京巴" };
            Dog d4 = new Dog { Id = 4, MasterId = 2, Name = "泰迪" };
            Dog d5 = new Dog { Id = 5, MasterId = 1, Name = "中华田园" };
            Dog[] dogs = { d1, d2, d3, d4, d5 };

          var res = dogs.Where(x => x.Id > 0).Join(masters, p => p.MasterId, m => m.Id, (d, m) => new { DogName = d.Name, MasterName = m.Name });
            foreach (var item in res)
            {
                Console.WriteLine(item.DogName+"  "+item.MasterName);
            }

            //linq 写法 查询id>0 的dog
            var t2 =  from d in dogs where d.Id > 0 select d;

            foreach (var item in t2)
            {
                Console.WriteLine(item.Name);
            }


            var list3 = from m in masters select m.Name;
            foreach (var item in list3)
            {
                Console.WriteLine(item);
            }

            var list4 = from d in dogs select new { DogName = d.Name, DogId = d.Id, Desc = "gougou" };

            foreach (var item in list4)
            {
                Console.WriteLine(item.DogId+" "+ item.DogName+" "+ item.Desc);
            }

            var list5 = from d in dogs orderby d.Id descending select d;
            foreach (var item in list5)
            {
                Console.WriteLine(item.Id+" "+item.Name);
            }

            var list6 = from d in dogs
                        join m in masters on d.MasterId equals m.Id
                        select new { DogName = d.Name, MasterName = m.Name };
            foreach (var item in list6)
            {
                Console.WriteLine(item.DogName + " " + item.MasterName);
            }

            var list7 = from d in dogs
                        group d by d.Id into g
                        select new { DogName = g.Key, MaxSalar = g.Max(p => p.Id), Count=g.Count() };

            Person p1 = new Person() { Age = 6, Name = "ss", Gender = true, Salary = 1200 };
            string nameP1 = nameof(p1);
            string ss2 = nameof(Person);
            string ss3 = nameof(p1.Age);
            string ss4 = nameof(Person.Age);
             string ss5 = nameof(p1.F1);
            Console.WriteLine(nameP1);
            Console.WriteLine(ss2);
            Console.WriteLine(ss3);
            Console.WriteLine(ss4);
            Console.WriteLine(ss5);
             

            string name = null;
            Console.WriteLine(name ?? "未知");
            Console.WriteLine(name==null?3:Convert.ToInt32(name));
            string s8 = null;
            string s9 = s8?.Trim();
            
            Console.WriteLine("");
            Console.Read();
        }


        public static void DoPlay(Action<string> play)
        {
            //  Func<int, int, string> ff = (i, j) => { return i + j + ""; };
            //Console.WriteLine("调用了");
            play("aaa");
        }

    }

    class Master
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    class Dog
    {
        public long Id { get; set; }
        public long MasterId { get; set; }
        public string Name { get; set; }
    }




    //学生
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public int Salary { get; set; }
        public override string ToString()
        {
            return string.Format("Name={0},Age={1},Gender={2},Salary={3}",
            Name, Age, Gender, Salary);
        }
        public static void F1()
        {
        }
    }
    //老师
    public class Teacher
    {
        public Teacher()
        {
            this.Students = new List<Person>();
        }
        public string Name { get; set; }
        public List<Person> Students { get; set; }
    }



    //public class Child : Person
    //{
    //    public Child(): base(19)
    //    { 

    //    }

    //    public override string GetAge()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    //public abstract class Person
    //{
    //    public Person() { }
    //    public Person(int age)
    //    {
    //        Age = 18;
    //    }
    //    private int age;
    //    public int Age
    //    {
    //        get
    //        {
    //            return age;
    //        }
    //        set
    //        {
    //            age = value;
    //        }
    //    }
    //    //在定义接口中不能有方法体，
    //    public virtual string GetName() {
    //        return "";
    //    }

    //   public abstract string GetAge();


    //}

    public class Singleton
    {
        public readonly static Singleton Instance = new Singleton();
        private Singleton() { }
    }




}