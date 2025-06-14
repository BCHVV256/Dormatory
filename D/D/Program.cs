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
            Console.Write("blocks : "); foreach (int i in blocks) Console.Write($"{i} ");
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
        public string name { set; get; }
        public int level { set; get; }
        public int roomno { set; get; }
        public string blockboss { set; get; }
        public int[] rooms { set; get; }
        public Block(string name, int level, int roomno, string blockboss, int[] rooms)
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
            Console.Write("rooms : "); foreach (int i in rooms) Console.Write($"{i} ");
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
        public override bool Equals(object obj)
        {
            if (obj is Room other)
            {
                return this.number == other.number;
            }
            return false;
        }
    }
    public class Equipment
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
        public Equipment(string[] belongings, int number, string belongingid, string status, string room, string student)
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
        public override bool Equals(object obj)
        {
            if (obj is Equipment other)
            {
                return this.belongings == other.belongings && this.number == other.number && this.belongingid == other.belongingid && this.status == other.status && this.room == other.room && this.student == other.student;
            }
            return false;
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
            Console.Write("personalequipments : "); foreach (string i in personalequipments) Console.Write($"{i} ");
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
        static async void Login(List<User> user, List<Dorm> dorm, List<Block> block, List<Room> room, List<Equipment> equipment, List<Equipment> repair, List<Person> person, List<Dormboss> dormboss, List<Student> student, List<Blockboss> blockboss)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("  --------------------------------");
                Console.WriteLine(" |                                |");
                Console.WriteLine(" |           Username:            |");
                Console.WriteLine(" |                                |");
                Console.WriteLine("  --------------------------------");
                Console.WriteLine(" |                                |");
                Console.WriteLine(" |           Password:            |");
                Console.WriteLine(" |                                |");
                Console.WriteLine("  --------------------------------");
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                Console.WriteLine();
                User temp = new User(a, b);
                if (a == "" || b == "")
                {
                    Console.WriteLine("Error! Going back.");
                    Console.ReadKey();
                    break;
                }
                if (user.Contains(temp))
                {
                    managementpage(dorm, block, room, equipment, repair, person, dormboss, student, blockboss);
                    break;
                }
                else
                {
                    Console.WriteLine("Account not found, try again later.");
                    Console.ReadKey();
                    return;
                }
            }
        }
        static void signup(List<User> user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("  --------------------------------");
                Console.WriteLine(" |                                |");
                Console.WriteLine(" |           Username:            |");
                Console.WriteLine(" |                                |");
                Console.WriteLine("  --------------------------------");
                Console.WriteLine(" |                                |");
                Console.WriteLine(" |           Password:            |");
                Console.WriteLine(" |                                |");
                Console.WriteLine("  --------------------------------");
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                Console.WriteLine();

                if (a == "" || b == "")
                {
                    Console.WriteLine("Error! Going back.");
                    Console.ReadKey();
                    break;
                }
                User c = new User(a, b);
                if (user.Contains(c))
                {
                    Console.WriteLine("Account already exists!");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Account successfully added!");
                    Console.ReadKey();
                    user.Add(c);
                    return;
                }
            }
        }
        static void managementpage(List<Dorm> dorm, List<Block> block, List<Room> room, List<Equipment> equipment, List<Equipment> repair, List<Person> person, List<Dormboss> dormboss, List<Student> student, List<Blockboss> blockboss)
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("     --------------------------------------------------");
                Console.WriteLine("    /                                                  \\                _____");
                Console.WriteLine("   /                  Management page                   \\              /     \\");
                Console.WriteLine("  /                                                      \\            | . .   |");
                Console.WriteLine("  --------------------------------------------------------             \\ .   /");
                Console.WriteLine(" |                                                        |             -----");
                Console.WriteLine(" |  ----------------------------------------------------  |");
                Console.WriteLine(" | |    1.Dorm management     |   2.Block management    | |");
                Console.WriteLine(" |  ----------------------------------------------------  |");
                Console.WriteLine(" |                                                        |");
                Console.WriteLine(" |  ----------------------------------------------------  |");
                Console.WriteLine(" | |  3.personal management   | 4.Belongings management | |");
                Console.WriteLine(" |  ----------------------------------------------------  |");
                Console.WriteLine(" |                                                        |");
                Console.WriteLine(" |  ----------------------------------------------------  |");
                Console.WriteLine(" | |      5.View report       |        6.Return         | |");
                Console.WriteLine(" |  ----------------------------------------------------  |");
                Console.WriteLine(" |                                                        |");
                Console.WriteLine(" |                                        ___             |");
                Console.WriteLine(" |       [Pick a number from (1-6)]      |   |            |");
                Console.WriteLine(" |                                       |.  |            |");
                Console.WriteLine(" |                                       |   |            |");
                Console.WriteLine("  -------------------------------------------------------- ");
                var x = Console.ReadKey();
                switch (x.KeyChar)
                {
                    case '1':
                        dormmanagement(dorm);
                        break;
                    case '2':
                        blockmanagement(block, student, blockboss);
                        break;
                    case '3':
                        personalmanagement(student, dormboss, blockboss);
                        break;
                    case '4':
                        belongingsmanagement(equipment, room, student, repair);
                        break;
                    case '5':
                        viewreport(dorm, block, room, equipment, repair, person, dormboss, student, blockboss);
                        break;
                    case '6':
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void dormmanagement(List<Dorm> dorm)
        {

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                                                                ");
                Console.WriteLine("    1.Add new dorm      2.Remove dorm    3.Edit dorm info   4.View dorm list       5.Go back    ");
                Console.WriteLine("                                                                                                ");
                Console.WriteLine("         ____               ____               ____               ____               ____       ");
                Console.WriteLine("        |    |             |    |             |    |             |    |             |    |      ");
                Console.WriteLine("        |.   |             |.   |             |.   |             |.   |             |.   |      ");
                Console.WriteLine("        |    |             |    |             |    |             |    |             |    |      ");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                                                                ");
                Console.WriteLine("                          [Pick a number from (1-5)]                                            ");
                Console.WriteLine("                                                                                                ");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                var x = Console.ReadKey();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                switch (x.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Enter name : ");
                        string a = Console.ReadLine();
                        Console.WriteLine("Enter address : ");
                        string b = Console.ReadLine();
                        Console.WriteLine("Enter capacity : ");
                        int c = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter dormboss : ");
                        string d = Console.ReadLine();
                        Console.WriteLine("Enter number of blocks : ");
                        int e = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter list of blocks : ");
                        int[] f = new int[e];
                        for (int i = 0; i < e; i++)
                        {
                            f[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        Dorm g = new Dorm(a, b, c, d, f);
                        if (dorm.Contains(g))
                        {
                            Console.WriteLine("This dorm is already registered!");
                        }
                        else
                        {
                            dorm.Add(g);
                            Console.WriteLine("Dorm successfully added!");
                        }
                        Console.ReadKey();

                        break;
                    case '2':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("Enter name : ");
                        a = Console.ReadLine();
                        g = new Dorm(a, null, 0, null, null);
                        if (!dorm.Contains(g))
                        {
                            Console.WriteLine("Dorm doesn't exist!");
                        }
                        else
                        {
                            dorm.Remove(g);
                            Console.WriteLine("Dorm successfully removed!");
                        }
                        Console.ReadKey();

                        break;
                    case '3':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("Enter name : ");
                        a = Console.ReadLine();
                        g = new Dorm(a, null, 0, null, null);
                        if (dorm.Contains(g))
                        {
                            Console.WriteLine("Enter address :");
                            b = Console.ReadLine();
                            Console.WriteLine("Enter capacity :");
                            c = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter dormbosse's fullname : ");
                            d = Console.ReadLine();
                            Console.WriteLine("Enter number of blocks : ");
                            e = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter list of blocks : ");
                            f = new int[e];
                            for (int i = 0; i < e; i++)
                            {
                                f[i] = Convert.ToInt32(Console.ReadLine());
                            }
                            g = new Dorm(a, b, c, d, f);
                            dorm.Remove(g);
                            dorm.Add(g);
                            Console.WriteLine("Dorm info successfully changed!");
                        }
                        else
                        {
                            Console.WriteLine("Dorm hasn't been registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        if (dorm.Count == 0)
                        {
                            Console.WriteLine("There are no registered dorms!");
                        }
                        else
                            foreach (Dorm i in dorm)
                            {
                                i.info();
                            }
                        Console.WriteLine();
                        Console.ReadKey();
                        break;
                    case '5':
                        return;
                    default:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void blockmanagement(List<Block> block, List<Student> students, List<Blockboss> blockbosses)
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                                                                        ");
                Console.WriteLine("    1.Add new block      2.Remove block      3.Edit block info    4.View block list        5.Go back    ");
                Console.WriteLine("                                                                                                        ");
                Console.WriteLine("         ____                 ____                 ____                 ____                 ____       ");
                Console.WriteLine("        |    |               |    |               |    |               |    |               |    |      ");
                Console.WriteLine("        |.   |               |.   |               |.   |               |.   |               |.   |      ");
                Console.WriteLine("        |    |               |    |               |    |               |    |               |    |      ");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                                                                        ");
                Console.WriteLine("                                       [Pick a number from (1-5)]                                       ");
                Console.WriteLine("                                                                                                        ");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                var x = Console.ReadKey();
                switch (x.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Enter name : ");
                        string a = Console.ReadLine();
                        Console.WriteLine("Enter floor number : ");
                        int b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter room number : ");
                        int c = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter blockbosse's fullname : ");
                        string d = Console.ReadLine();
                        Console.WriteLine("Enter number of room : ");
                        int e = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter list of rooms : ");
                        string h = Console.ReadLine();
                        int[] f = Array.ConvertAll(h.Split(' '), int.Parse);
                        Block g = new Block(a, b, c, d, f);
                        if (block.Contains(g))
                        {
                            Console.WriteLine("This block is already registered!");
                        }
                        else
                        {
                            block.Add(g);
                            Console.WriteLine("Block successfully added!");
                        }
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("Enter name : ");
                        a = Console.ReadLine();
                        g = new Block(a, 0, 0, null, null);
                        if (!block.Contains(g))
                        {
                            Console.WriteLine("Block doesn't exist!");
                        }
                        else
                        {
                            block.Remove(g);
                            Console.WriteLine("Block successfully removed!");
                        }
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("Enter name : ");
                        a = Console.ReadLine();
                        g = new Block(a, 0, 0, null, null);
                        if (block.Contains(g))
                        {
                            Console.WriteLine("Enter floor number");
                            b = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter room number");
                            c = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter blockboss");
                            d = Console.ReadLine();
                            Console.WriteLine("Enter number of room");
                            e = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter list of rooms");
                            h = Console.ReadLine();
                            f = Array.ConvertAll(h.Split(' '), int.Parse);
                            g = new Block(a, b, c, d, f);
                            block.Remove(g);
                            block.Add(g);
                            Console.WriteLine("Block info successfully changed!");
                        }
                        else
                        {
                            Console.WriteLine("Block hasn't been registered!");
                        }
                        Console.ReadKey();

                        break;
                    case '4':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        if (block.Count == 0)
                        {
                            Console.WriteLine("There are no registered blocks!");
                        }
                        else
                            foreach (Block i in block)
                            {
                                i.info();
                            }
                        Console.WriteLine();
                        Console.ReadKey();

                        break;
                    case '5':
                        return;
                    default:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void personalmanagement(List<Student> student, List<Dormboss> dormboss, List<Blockboss> blockboss)
        {

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                                                              ");
                Console.WriteLine("    1.Manage dormbosses    2.Manage blockbosses      3.Manage students           4.Go back    ");
                Console.WriteLine("                                                                                              ");
                Console.WriteLine("           ____                    ____                    ____                    ____       ");
                Console.WriteLine("          |    |                  |    |                  |    |                  |    |      ");
                Console.WriteLine("          |.   |                  |.   |                  |.   |                  |.   |      ");
                Console.WriteLine("          |    |                  |    |                  |    |                  |    |      ");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                                                              ");
                Console.WriteLine("                                  [Pick a number from (1-4)]                                  ");
                Console.WriteLine("                                                                                              ");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                var x = Console.ReadKey();
                switch (x.KeyChar)
                {
                    case '1':
                        Dormboss(dormboss);
                        break;
                    case '2':
                        Blockboss(blockboss);
                        break;
                    case '3':
                        Student(student);
                        break;
                    case '4':
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Dormboss(List<Dormboss> dormboss)
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("  ----------------------------------------------------------------- ");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine(" |       1.Add new dormboss       |       2.Remove dormboss        |");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine("  ----------------------------------------------------------------- ");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine(" |       3.Edit dormboss info     |      4.View dormboss list      |");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine("  ----------------------------------------------------------------- ");
                Console.WriteLine(" |                                |");
                Console.WriteLine(" |           5.Go back            |");
                Console.WriteLine(" |                                |");
                Console.WriteLine("  -------------------------------- ");
                var x = Console.ReadKey();
                switch (x.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Enter fullname : ");
                        string a = Console.ReadLine();
                        Dormboss g = new Dormboss(a, null, null, null, null, null);
                        if (dormboss.Contains(g))
                        {
                            Console.WriteLine("This dormboss is already registered!");
                        }
                        else
                        {
                            Console.WriteLine("Enter dormboss id : ");
                            string b = Console.ReadLine();
                            Console.WriteLine("Enter phone number :");
                            string c = Console.ReadLine();
                            Console.WriteLine("Enter address : ");
                            string d = Console.ReadLine();
                            Console.WriteLine("Enter rank : ");
                            string e = Console.ReadLine();
                            Console.WriteLine("Enter dorm name : ");
                            string f = Console.ReadLine();
                            g = new Dormboss(a, b, c, d, e, f);
                            dormboss.Add(g);
                            Console.WriteLine("Dormboss successfully registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("Enter fullname");
                        a = Console.ReadLine();
                        g = new Dormboss(a, null, null, null, null, null);
                        if (!dormboss.Contains(g))
                        {
                            Console.WriteLine("Dormboss hasn't been registered!");
                        }
                        else
                        {
                            dormboss.Remove(g);
                            Console.WriteLine("Dormboss successfully removed!");
                        }
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("Enter fullname : ");
                        a = Console.ReadLine();
                        g = new Dormboss(a, null, null, null, null, null);
                        if (dormboss.Contains(g))
                        {
                            Console.WriteLine("Enter dormbosse's id : ");
                            string b = Console.ReadLine();
                            Console.WriteLine("Enter phone number :");
                            string c = Console.ReadLine();
                            Console.WriteLine("Enter address : ");
                            string d = Console.ReadLine();
                            Console.WriteLine("Enter rank : ");
                            string e = Console.ReadLine();
                            Console.WriteLine("Enter dorm name : ");
                            string f = Console.ReadLine();
                            g = new Dormboss(a, b, c, d, e, f);
                            dormboss.Remove(g);
                            dormboss.Add(g);
                            Console.WriteLine("Dormboss info successfully changed!");
                        }
                        else
                        {
                            Console.WriteLine("Dormboss hasn't been registered!");
                        }
                        Console.ReadKey();

                        break;
                    case '4':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        if (dormboss.Count == 0)
                        {
                            Console.WriteLine("There are no registered dormbosses!");
                        }
                        else
                        {
                            foreach (Dormboss i in dormboss)
                            {
                                i.info();
                            }
                        }
                        Console.WriteLine();
                        Console.ReadKey();

                        break;
                    case '5':
                        return;
                    default:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Blockboss(List<Blockboss> blockboss)
        {
            while (true)
            {

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("  ----------------------------------------------------------------- ");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine(" |      1.Add new blockboss       |       2.Remove blockboss       |");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine("  ----------------------------------------------------------------- ");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine(" |     3.Edit blockboss info      |     4.View blockboss list      |");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine("  ----------------------------------------------------------------- ");
                Console.WriteLine(" |                                |");
                Console.WriteLine(" |           5.Go back            |");
                Console.WriteLine(" |                                |");
                Console.WriteLine("  -------------------------------- ");
                var x = Console.ReadKey();
                switch (x.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Enter fullname : ");
                        string a = Console.ReadLine();
                        Blockboss l = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                        if (blockboss.Contains(l))
                        {
                            Console.WriteLine("This blockboss is already registered!");
                        }
                        else
                        {
                            Console.WriteLine("Enter blockboss id : ");
                            string b = Console.ReadLine();
                            Console.WriteLine("Enter phone number :");
                            string c = Console.ReadLine();
                            Console.WriteLine("Enter address : ");
                            string d = Console.ReadLine();
                            Console.WriteLine("Enter blockboss studentid : ");
                            string k = Console.ReadLine();
                            Console.WriteLine("Enter room number : ");
                            int e = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter block number : ");
                            int f = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter dorm name : ");
                            string g = Console.ReadLine();
                            Console.WriteLine("Enter personal equipments list : ");
                            List<string> h = new List<string>();
                            Console.WriteLine("Enter ''0'' to finish listing : ");
                            while (true)
                            {
                                string i = Console.ReadLine();
                                if (i != "0")
                                {
                                    if (h.Contains(i))
                                    {
                                        Console.WriteLine("Item already registered!");
                                    }
                                    else
                                    {
                                        h.Add(i);
                                        Console.WriteLine("Item added to the list!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Listing equipments ended!");
                                    break;
                                }
                            }
                            Console.WriteLine("Enter rank : ");
                            string j = Console.ReadLine();
                            l = new Blockboss(a, b, c, d, k, e, f, g, h, j);
                            blockboss.Add(l);
                            Console.WriteLine("Blockboss successfully added!");
                        }
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("Enter fullname");
                        a = Console.ReadLine();
                        l = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                        if (!blockboss.Contains(l))
                        {
                            Console.WriteLine("Blockboss hasn't been registered!");
                        }
                        else
                        {
                            blockboss.Remove(l);
                            Console.WriteLine("Blockboss successfully removed!");
                        }
                        Console.ReadKey();

                        break;
                    case '3':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("Enter fullname : ");
                        a = Console.ReadLine();
                        l = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                        if (blockboss.Contains(l))
                        {
                            Console.WriteLine("Enter blockboss id : ");
                            string b = Console.ReadLine();
                            Console.WriteLine("Enter phone number :");
                            string c = Console.ReadLine();
                            Console.WriteLine("Enter address : ");
                            string d = Console.ReadLine();
                            Console.WriteLine("Enter blockbosse's studentid : ");
                            string k = Console.ReadLine();
                            Console.WriteLine("Enter room number : ");
                            int e = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter block number : ");
                            int f = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter dorm name : ");
                            string g = Console.ReadLine();
                            Console.WriteLine("Enter personal equipments list : ");
                            List<string> h = new List<string>();
                            Console.WriteLine("Enter 0 to finish listing : ");
                            while (true)
                            {
                                string i = Console.ReadLine();
                                if (i != "0")
                                {
                                    if (h.Contains(i))
                                    {
                                        Console.WriteLine("Item already registered!");
                                    }
                                    else
                                    {
                                        h.Add(i);
                                        Console.WriteLine("Item added to the list!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Listing equipments ended!");
                                    break;
                                }
                            }
                            Console.WriteLine("Enter rank : ");
                            string j = Console.ReadLine();
                            l = new Blockboss(a, b, c, d, k, e, f, g, h, j);
                            blockboss.Remove(l);
                            blockboss.Add(l);
                            Console.WriteLine("Blockboss info successfully changed!");
                        }
                        else
                        {
                            Console.WriteLine("Blockboss hasn't been registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        if (blockboss.Count == 0)
                        {
                            Console.WriteLine("There are no registered blockbosses!");
                        }
                        else
                        {
                            foreach (Blockboss i in blockboss)
                            {
                                i.info();
                            }
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                        break;
                    case '5':
                        return;
                    default:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Student(List<Student> student)
        {
            while (true)
            {

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("  ----------------------------------------------------------------- ");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine(" |        1.Add new student       |        2.Remove student        |");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine("  ----------------------------------------------------------------- ");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine(" |      3.Edit student info       |         4.Find student         |");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine("  ----------------------------------------------------------------- ");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine(" |      5.Edit student info       |    6.Add student to a dorm     |");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine("  ----------------------------------------------------------------- ");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine(" |7.Change student Dorm/Block/Room|           8.Go back            |");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine("  ----------------------------------------------------------------- ");
                var x = Console.ReadKey();
                switch (x.KeyChar)
                {
                    case '1':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '2':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '3':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '4':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '5':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '6':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '7':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '8':
                        return;
                    default:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void belongingsmanagement(List<Equipment> equipment, List<Room> room, List<Student> student, List<Equipment> repair)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            while (true)
            {
                Console.Clear(); ;
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                                                                              ");
                Console.WriteLine("      1.Add new belongings         2.Attaching belongings to rooms    3.Attaching belongings to students      ");
                Console.WriteLine("                                                                                                              ");
                Console.WriteLine("              ____                               ____                                 ____                    ");
                Console.WriteLine("             |    |                             |    |                               |    |                   ");
                Console.WriteLine("             |.   |                             |.   |                               |.   |                   ");
                Console.WriteLine("             |    |                             |    |                               |    |                   ");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                                                                              ");
                Console.WriteLine("  4.Changing ownership management         5.Repair management                      6.Go back                  ");
                Console.WriteLine("                                                                                                              ");
                Console.WriteLine("              ____                               ____                                 ____                    ");
                Console.WriteLine("             |    |                             |    |                               |    |                   ");
                Console.WriteLine("             |.   |                             |.   |                               |.   |                   ");
                Console.WriteLine("             |    |                             |    |                               |    |                   ");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                                                                              ");
                Console.WriteLine("                                          [Pick a number from (1-6)]                                          ");
                Console.WriteLine("                                                                                                              ");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
                var x = Console.ReadKey();
                switch (x.KeyChar)
                {
                    case '1':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '2':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '3':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '4':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '5':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '6':
                        return;
                    default:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void viewreport(List<Dorm> dorm, List<Block> block, List<Room> room, List<Equipment> equipment, List<Equipment> repair, List<Person> person, List<Dormboss> dormboss, List<Student> student, List<Blockboss> blockboss)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            while (true)
            {
                Console.Clear();
                Console.Clear();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                                                                                  ");
                Console.WriteLine("    1.Residential personal report    2.Belongings report           3.Advanced reports                4.Go back    ");
                Console.WriteLine("                                                                                                                  ");
                Console.WriteLine("                ____                         ____                         ____                         ____       ");
                Console.WriteLine("               |    |                       |    |                       |    |                       |    |      ");
                Console.WriteLine("               |.   |                       |.   |                       |.   |                       |.   |      ");
                Console.WriteLine("               |    |                       |    |                       |    |                       |    |      ");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                                                                                  ");
                Console.WriteLine("                                            [Pick a number from (1-4)]                                            ");
                Console.WriteLine("                                                                                                                  ");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                var x = Console.ReadKey();
                switch (x.KeyChar)
                {
                    case '1':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '2':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '3':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        break;
                    case '4':
                        return;
                    default:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            List<User> user = new List<User>();
            List<Dorm> dorm = new List<Dorm>();
            List<Block> block = new List<Block>();
            List<Room> room = new List<Room>();
            List<Equipment> equipment = new List<Equipment>();
            List<Equipment> repair = new List<Equipment>();
            List<Person> person = new List<Person>();
            List<Dormboss> dormboss = new List<Dormboss>();
            List<Student> student = new List<Student>();
            List<Blockboss> blockboss = new List<Blockboss>();
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("  --------------------------------");
                Console.WriteLine(" |                                |");
                Console.WriteLine(" |      Dormitory Management      |");
                Console.WriteLine(" |                                |");
                Console.WriteLine("  -------------------------------- ");
                Console.WriteLine(" |            1.Log in            |");
                Console.WriteLine(" |            2.Sign up           |");
                Console.WriteLine(" |            3.Exit              |");
                Console.WriteLine(" |                                |");
                Console.WriteLine(" |[Choose an option (1-3)]        |");
                Console.WriteLine("  -------------------------------- ");
                var x = Console.ReadKey();
                switch (x.KeyChar)
                {
                    case '1':
                        Login(user, dorm, block, room, equipment, repair, person, dormboss, student, blockboss);
                        break;
                    case '2':
                        signup(user);
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        return;
                    dafault:
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
/*



*/