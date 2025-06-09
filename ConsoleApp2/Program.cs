using System;
using System.Collections;
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
        public override bool Equals(object obj)
        {
            if (obj is User other)
            {
                return this.username == other.username && this.password == other.password;
            }
            return false;
        }
    }
    public class Dorm
    {
        public string name { set; get; }
        public string address { set; get; }
        public int capacity { set; get; }
        public string dormboss { set; get; }
        public int[] blocks { set; get; }
        public Dorm(string name, string address, int capacity, string dormboss, int[] blocks)
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
            Console.Write("blocks : "); foreach (int i in blocks) Console.Write($"| {i} | ");
            Console.WriteLine();
        }
        public override bool Equals(object obj)
        {
            if (obj is Dorm other)
            {
                return this.name == other.name;
            }
            return false;
        }
    }
    public class Block
    {
        public int name { set; get; }
        public int level { set; get; }
        public int roomno { set; get; }
        public string blockboss { set; get; }
        public List<Room> rooms { set; get; }
        public Block(int name, int level, int roomno, string blockboss, List<Room> rooms)
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
            Console.Write("rooms : "); foreach (Room i in rooms) i.info();
            Console.WriteLine();
        }
        public override bool Equals(object obj)
        {
            if (obj is Block other)
            {
                return this.name == other.name;
            }
            return false;
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
        public List<Student> residentialstudents { set; get; }
        public int block { set; get; }
        public Room(int number, int level, int capacity, List<string> equipments, List<Student> residentialstudents, int block)
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
            Console.Write("equipments : "); foreach (string i in equipments) Console.Write($"| {i} | ");
            Console.WriteLine();
            Console.Write("residentialstudents : "); foreach (Student i in residentialstudents) Console.Write($"| {i} | ");
            Console.WriteLine();
        }
        public override bool Equals(object obj)
        {
            if (obj is Room other)
            {
                return this.number == other.number;
            }
            return false;
        }
        public virtual void Turn(List<Room> room, Room other)
        {
            foreach (Room e in room)
            {
                if (e.block == other.block)
                {
                    other.number = e.number;
                    other.level = e.level;
                    other.capacity = e.capacity;
                    other.equipments = e.equipments;
                    other.block = e.block;
                    return;
                }
            }
            Console.WriteLine($"Student hasn't been registered!");
        }
    }
    public class Equipment
    {
        public string belonging { set; get; }
        public int number { set; get; }
        public int n
        {
            set { if (n >= 1 && n <= 5) number = n; }
            get { return n; }
        }
        public string belongingid { set; get; }
        public string status { set; get; }
        public int room { set; get; }
        public string student { set; get; }
        public Equipment(string belonging, int number, string belongingid, string status, int room, string student)
        {
            this.belonging = belonging;
            this.number = number;
            this.belongingid = belongingid;
            this.status = status;
            this.room = room;
            this.student = student;
        }
        public virtual void info()
        {
            Console.WriteLine($"belonging : {belonging} | number : {number} | belongingid : {belongingid} | status : {status} | room : {room} | student : {student}");
            Console.WriteLine();
        }
        public override bool Equals(object obj)
        {
            if (obj is Equipment other)
            {
                return this.belonging == other.belonging && this.number == other.number && this.belongingid == other.belongingid && this.status == other.status;
            }
            return false;
        }
        public virtual void Find(List<Equipment> equipment, Equipment other)
        {
            foreach (Equipment e in equipment)
            {
                if (e.belonging == other.belonging && e.number == other.number && e.belongingid == other.belongingid && e.status == other.status)
                {
                    other.belonging = e.belonging;
                    other.number = e.number;
                    other.belongingid = e.belongingid;
                    other.status = e.status;
                    other.room = e.room;
                    other.student = e.student;
                    return;
                }
            }
            Console.WriteLine($"Student hasn't been registered!");
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
        public override bool Equals(object obj)
        {
            if (obj is Person other)
            {
                return this.fullname == other.fullname;
            }
            return false;
        }
    }
    public class Dormboss : Person
    {
        public string rank { set; get; }
        public string dorm { set; get; }
        public List<string> personalequipments { set; get; }
        public Dormboss(string fullname, string id, string phonenumber, string address, string rank, string dorm, List<string> personalequipments) : base(fullname, id, phonenumber, address)
        {
            this.rank = rank;
            this.dorm = dorm;
            this.personalequipments = personalequipments;
        }
        public override void info()
        {
            base.info();
            Console.WriteLine($"| rank : {rank} | dorm : {dorm}");
            Console.Write("personalequipments : "); foreach (string i in personalequipments) Console.Write($"| {i} | ");
            Console.WriteLine();
        }
        public override bool Equals(object obj)
        {
            if (obj is Dormboss other)
            {
                return this.fullname == other.fullname;
            }
            return false;
        }
    }
    public class Student : Person
    {
        public string studentid { set; get; }
        public int room { set; get; }
        public int block { set; get; }
        public string dorm { set; get; }
        public List<string> personalequipments { set; get; }
        public Student(string fullname, string id, string phonenumber, string address, string studentid, int room, int block, string dorm, List<string> personalequipments) : base(fullname, id, phonenumber, address)
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
            Console.Write("personalequipments : "); foreach (string i in personalequipments) Console.Write($"| {i} | ");
            Console.WriteLine();
        }
        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return this.fullname == other.fullname;
            }
            return false;
        }
        public virtual bool Dorm(object obj)
        {
            if (obj is Student other)
            {
                return this.dorm == other.dorm;
            }
            return false;
        }
        public virtual void ChangeDorm(List<Student> student, Student other)
        {
            foreach (Student s in student)
            {
                if (s.fullname == other.fullname)
                {
                    Console.WriteLine("Enter new dorm : ");
                    string a = Console.ReadLine();
                    Student b = s;
                    b.dorm = a;
                    Console.WriteLine("Dorm successfully changed!");
                    return;
                }
            }
        }
        public virtual void ChangeBlock(List<Student> student, Student other)
        {
            foreach (Student s in student)
            {
                if (s.fullname == other.fullname)
                {
                    Console.WriteLine("Enter new block : ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    Student b = s;
                    b.block = a;
                    Console.WriteLine("Block successfully changed!");
                    return;
                }
            }
        }
        public virtual void ChangeRoom(List<Student> student, Student other)
        {
            foreach (Student s in student)
            {
                if (s.fullname == other.fullname)
                {
                    Console.WriteLine("Enter new room : ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    Student b = s;
                    b.room = a;
                    Console.WriteLine("Room successfully changed!");
                    return;
                }
            }
        }
        public virtual void Find(List<Student> student, Student other)
        {
            foreach (Student s in student)
            {
                if (s.fullname == other.fullname)
                {
                    s.info();
                    return;
                }
            }
            Console.WriteLine($"Student hasn't been registered!");
        }
    }
    public class Blockboss : Student
    {
        public string rank { set; get; }
        public Blockboss(string fullname, string id, string phonenumber, string address, string studentid, int room, int block, string dorm, List<string> personalequipments, string rank) : base(fullname, id, phonenumber, address, studentid, room, block, dorm, personalequipments)
        {
            this.rank = rank;
        }
        public override void info()
        {
            base.info();
            Console.WriteLine($"rank : {rank}");
            Console.WriteLine();
        }
        public override bool Equals(object obj)
        {
            if (obj is Blockboss other)
            {
                return this.fullname == other.fullname;
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {

            }
        }
    }
}
/**/
