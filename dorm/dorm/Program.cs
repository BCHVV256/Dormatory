using System;
namespace CSharpTutorials
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
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
            this.number = number;
            this.belongingid = belongingid;
            this.status = status;
            this.room = room;
            this.student = student;
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
    }
    public class Blockboss : Student
    {
        public string rank { set; get; }
        public Blockboss(string fullname, string id, string phonenumber, string address, string studentid, int room, string block, string dorm, List<string> personalequipments, string rank) : base(fullname, id, phonenumber, address, studentid, room, block, dorm, personalequipments)
        {
            this.rank = rank;
        }
    }
    class Program
    {
        static void Login(List<User> user, List<Dormboss> dormboss, List<Blockboss> blockboss, List<Student> student)
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
                Dormboss d = new Dormboss(a, null, null, null, null, null);
                Blockboss e = new Blockboss(a, null, null, null, null, 0, null, null, null, null);
                Student f = new Student(a, null, null, null, null, 0, null, null, null);

                if (user.Contains(c) && dormboss.Contains(d))
                {

                }
                else if (user.Contains(c) && blockboss.Contains(e))
                {

                }
                else if (user.Contains(c) && student.Contains(f))
                {

                }
                else
                {
                    return;
                }

            }
        }
        static void signup()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" --------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
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
            List<Block> blocks = new List<Block>();
            List<Room> room = new List<Room>();
            List<Equipments> equipments = new List<Equipments>();
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
                switch (x.KeyChar)
                {
                    case '1':
                        Login(user, doormboss, blockboss, student);
                        break;
                    case '2':

                        break;
                    case '3':

                        break;
                    dafault:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }
    }
}
// 