using System;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;
using System.Net;
using System.Xml.Linq;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace CSharpTutorials
{
    public class User
    {
        public string username;
        public string password;
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public virtual void info()
        {
            Console.WriteLine($"username : {username} | password : {password}");
            Console.WriteLine();
        }
    }
    public class Dorm
    {
        public string name { set; get; }
        public string address { set; get; }
        public int capacity { set; get; }
        public string dormboss { set; get; }
        public List<string> blocks { set; get; }
        public Dorm(string name, string address, int capacity, string dormboss, List<string> blocks)
        {
            this.name = name;
            this.address = address;
            this.capacity = capacity;
            this.dormboss = dormboss;
            this.blocks = blocks;
        }
        public virtual void info()
        {
            Console.WriteLine($"name : {name} | address : {address} | capacity : {capacity} | dormboss : {dormboss}");
            Console.Write("blocks : "); foreach (string i in blocks) Console.Write($"{i} ");
            Console.WriteLine();
        }
    }
    public class Block
    {
        public string name { set; get; }
        public int level { set; get; }
        public int roomno { set; get; }
        public string blockboss { set; get; }
        public List<string> rooms { set; get; }
        public Block(string name, int level, int roomno, string blockboss, List<string> rooms)
        {
            this.name = name;
            this.level = level;
            this.roomno = roomno;
            this.blockboss = blockboss;
            this.rooms = rooms;
        }
        public virtual void info()
        {
            Console.WriteLine($"name : {name} | level : {level} | roomno : {roomno} | blockboss : {blockboss}");
            Console.Write("rooms : "); foreach (string i in rooms) Console.Write($"{i} ");
            Console.WriteLine();
        }
    }
    public class Room
    {
        public int number { set; get; }
        public int level { set; get; }
        public int capacity { set; get; }
        public int c
        {
            set { if (c >= 0 && c <= 6) capacity = c; }
            get { return c; }
        }
        public List<string> equipments { set; get; }
        public List<string> residentialstudents { set; get; }
        public string block { set; get; }
        public Room(int number, int level, int capacity, List<string> equipments, List<string> residentialstudents, string block)
        {
            this.number = number;
            this.level = level;
            this.capacity = capacity;
            this.equipments = equipments;
            this.residentialstudents = residentialstudents;
            this.block = block;
        }
        public virtual void info()
        {
            Console.WriteLine($"number : {number} | level : {level} | capacity : {capacity} | block : {block}");
            Console.Write("equipments : "); foreach (string i in equipments) Console.Write($"{i} ");
            Console.WriteLine();
            Console.Write("residentialstudents : "); foreach (string i in residentialstudents) Console.Write($"{i} ");
            Console.WriteLine();
        }
    }
    public class Equipments
    {
        public string[] belongings { set; get; }
        public int number { set; get; }
        public int n
        {
            set { if (n >= 1 && n <= 5) number = n; }
            get { return n; }
        }
        public string belongingid { set; get; }
        public string status { set; get; }
        public string room { set; get; }
        public string student { set; get; }
        public Equipments(string[] belongings, int number, string belongingid, string status, string room, string student)
        {
            this.belongings = belongings;
            this.number = n;
            this.belongingid = belongingid;
            this.status = status;
            this.room = room;
            this.student = student;
        }
        public virtual void info()
        {
            Console.WriteLine($"number : {number} | belongingid : {belongingid} | status : {status} | room : {room} | student : {student}");
            Console.Write("equipments : "); foreach (string i in belongings) Console.Write($"{i} ");
            Console.WriteLine();
        }
    }
    public class Person
    {
        public string fullname { set; get; }
        public string id { set; get; }
        public string phonenumber { set; get; }
        public string address { set; get; }
        public Person(string fullname, string id, string phonenumber, string address)
        {
            this.fullname = fullname;
            this.id = id;
            this.phonenumber = phonenumber;
            this.address = address;
        }
        public virtual void info()
        {
            Console.WriteLine($"fullname : {fullname} | id : {id} | phonenumber : {phonenumber} | address : {address} ");
        }
    }
    public class Dormboss : Person
    {
        public string rank { set; get; }
        public string dorm { set; get; }
        public Dormboss(string fullname, string id, string phonenumber, string address, string rank, string dorm) : base(fullname, id, phonenumber, address)
        {
            this.rank = rank;
            this.dorm = dorm;
        }
        public override void info()
        {
            base.info();
            Console.WriteLine($"| rank : {rank} | dorm : {dorm}");
            Console.WriteLine();
        }
    }
    public class Student : Person
    {
        public string studentid { set; get; }
        public int room { set; get; }
        public string block { set; get; }
        public string dorm { set; get; }
        public List<string> personalequipments { set; get; }
        public Student(string fullname, string id, string phonenumber, string address, string studentid, int room, string block, string dorm, List<string> personalequipments) : base(fullname, id, phonenumber, address)
        {
            this.studentid = studentid;
            this.room = room;
            this.block = block;
            this.dorm = dorm;
            this.personalequipments = personalequipments;
        }
        public override void info()
        {
            base.info();
            Console.WriteLine($"| sudentid : {studentid} | room : {room} | block : {block} | dorm : {dorm}");
            Console.Write("personalequipments : "); foreach (string i in personalequipments) Console.Write($"{i} ");
            Console.WriteLine();
        }
    }
    public class Blockboss : Student
    {
        public string rank { set; get; }
        public Blockboss(string fullname, string id, string phonenumber, string address, string studentid, int room, string block, string dorm, List<string> personalequipments, string rank) : base(fullname, id, phonenumber, address, studentid, room, block, dorm, personalequipments)
        {
            this.rank = rank;
        }
        public override void info()
        {
            base.info();
            Console.WriteLine($"rank : {rank}");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Login(List<User> user)
        {
            Console.Clear();
            Console.WriteLine(" --------------------------------");
            Console.WriteLine("|                                |");
            Console.WriteLine("|           Username:            |");
            Console.WriteLine("|                                |");
            Console.WriteLine("|           Password:            |");
            Console.WriteLine("|                                |");
            Console.WriteLine(" --------------------------------");

            string a = Console.ReadLine();
            string b = Console.ReadLine();
            User c = new User(a, b);
            if (user.Contains(c))
            {
                managementpage();
                Console.WriteLine("kkkkkkkkkk");
            }
            else
            {
                return;
            }
        }
        static void signup(List<User> user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" --------------------------------");
                Console.WriteLine("|                                |");
                Console.WriteLine("|           Username:            |");
                Console.WriteLine("|                                |");
                Console.WriteLine("|           Password:            |");
                Console.WriteLine("|                                |");
                Console.WriteLine(" --------------------------------");

                string a = Console.ReadLine();
                string b = Console.ReadLine();
                User c = new User(a, b);
                user.Add(c);
                return;
            }
        }
        static void dormbosspage()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
        static void blockbosspage()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
        static void studentpage()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }

        }
        static void managementpage()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==============================");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
        static void dormmanagement()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
        static void blockmanagement()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
        static void personalmanagement()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
        static void belongingsmanagement()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
        static void viewreport()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(Console.ForegroundColor);
            List<User> user = new List<User>();

            List<Dorm> dorm = new List<Dorm>();
            List<Block> block = new List<Block>();
            List<Room> room = new List<Room>();
            List<Equipments> equipment = new List<Equipments>();
            List<Person> person = new List<Person>();
            List<Dormboss> doormboss = new List<Dormboss>();
            List<Student> student = new List<Student>();
            List<Blockboss> blockboss = new List<Blockboss>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" --------------------------------");
                Console.WriteLine("|                                |");
                Console.WriteLine("|      Dormitory Management      |");
                Console.WriteLine("|                                |");
                Console.WriteLine(" -------------------------------- ");
                Console.WriteLine("|            1.Log in            |");
                Console.WriteLine("|            2.Sign up           |");
                Console.WriteLine("|            3.Exit              |");
                Console.WriteLine("|                                |");
                Console.WriteLine("|[Choose an option (1-3)]        |");
                Console.WriteLine(" -------------------------------- ");
                var x = Console.ReadKey();
                Console.WriteLine();

                switch (x.KeyChar)
                {
                    case '1':
                        Login(user);
                        break;
                    case '2':
                        signup(user);
                        break;
                    case '3':
                        Console.WriteLine("Goodbye!");
                        return;
                    dafault:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }

            }
        }
    }
}
// 