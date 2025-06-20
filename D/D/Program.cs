﻿using System;
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
            Console.WriteLine($" | username : {username} | password : {password} |");
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
        public List<Block> blocks { set; get; }
        public Dorm(string name, string address, int capacity, string dormboss, List<Block> blocks)
        {
            this.name = name;
            this.address = address;
            this.capacity = capacity;
            this.dormboss = dormboss;
            this.blocks = blocks;
        }
        public virtual void info()
        {
            Console.WriteLine($" | name : {name} | address : {address} | capacity : {capacity} | dormboss : {dormboss} |");
            if (blocks != null)
            {
                Console.WriteLine("blocks : "); foreach (Block i in blocks) Console.WriteLine($" | {i.name} |");
            }
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
        public virtual void Turn(List<Dorm> dorm, Dorm other)
        {
            foreach (Dorm e in dorm)
            {
                if (e.name == other.name)
                {
                    other.name = e.name;
                    other.address = e.address;
                    other.capacity = e.capacity;
                    other.dormboss = e.dormboss;
                    other.blocks = e.blocks;
                    return;
                }
            }
            Console.WriteLine($"Dorm hasn't been registered!");
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
            Console.WriteLine($" | name : {name} | floor : {level} | roomno : {roomno} | blockboss : {blockboss} |");
            if (rooms != null)
            {
                Console.WriteLine("rooms : "); foreach (Room i in rooms) Console.WriteLine($" | Room number : {i.number} & Room floor : {i.level} |");
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is Block other)
            {
                return this.name == other.name;
            }
            return false;
        }
        public virtual void Turn(List<Block> block, Block other)
        {
            foreach (Block e in block)
            {
                if (e.name == other.name)
                {
                    other.name = e.name;
                    other.level = e.level;
                    other.roomno = e.roomno;
                    other.blockboss = e.blockboss;
                    other.rooms = e.rooms;
                    return;
                }
            }
            Console.WriteLine($"Block hasn't been registered!");
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
        public List<Equipment> equipments { set; get; }
        public List<Student> residentialstudents { set; get; }
        public int block { set; get; }
        public Room(int number, int level, int capacity, List<Equipment> equipments, List<Student> residentialstudents, int block)
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
            Console.WriteLine($" | number : {number} | level : {level} | capacity : {capacity} | block : {block} |");
            if (equipments != null)
            {
                Console.WriteLine("equipments : "); foreach (Equipment i in equipments) Console.WriteLine($" | {i.belonging} |");
                Console.WriteLine();
            }
            if (residentialstudents != null)
            {
                Console.WriteLine("residentialstudents : "); foreach (Student i in residentialstudents) Console.WriteLine($" | {i.fullname} |");
                Console.WriteLine();
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is Room other)
            {
                return this.number == other.number && this.level == other.level && this.block == other.block;
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
            Console.WriteLine($"Room hasn't been registered!");
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
            Console.WriteLine($" | belonging : {belonging} | number : {number} | belongingid : {belongingid} | status : {status} | room : {room} | student : {student} |");
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
        public virtual void Turn(List<Equipment> equipment, Equipment other)
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
            Console.WriteLine($"Equipment hasn't been registered!");
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
            Console.WriteLine($" | fullname : {fullname} | id : {id} | phonenumber : {phonenumber} | address : {address} |");
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
            Console.WriteLine($" | fullname : {fullname} | id : {id} | phonenumber : {phonenumber} | address : {address} | rank : {rank} | dorm : {dorm} |");
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
        public virtual void Turn(List<Dormboss> dormboss, Dormboss other)
        {
            foreach (Dormboss e in dormboss)
            {
                if (e.fullname == other.fullname)
                {
                    other.fullname = e.fullname;
                    other.id = e.id;
                    other.phonenumber = e.phonenumber;
                    other.address = e.address;
                    other.rank = e.rank;
                    other.dorm = e.dorm;
                    return;
                }
            }
            Console.WriteLine($"Dormboss hasn't been registered!");
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
            Console.WriteLine($" | fullname : {fullname} | id : {id} | phonenumber : {phonenumber} | address : {address} | sudentid : {studentid} | room : {room} | block : {block} | dorm : {dorm} |");
            if (personalequipments != null)
            {
                Console.WriteLine("personalequipments : "); foreach (string i in personalequipments) Console.WriteLine($"| {i} | ");
            }
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
        public virtual void Turn(List<Student> student, Student other)
        {
            foreach (Student e in student)
            {
                if (e.fullname == other.fullname)
                {
                    other.fullname = e.fullname;
                    other.id = e.id;
                    other.phonenumber = e.phonenumber;
                    other.address = e.address;
                    other.studentid = e.studentid;
                    other.room = e.room;
                    other.block = e.block;
                    other.dorm = e.dorm;
                    other.personalequipments = e.personalequipments;
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
            {
                Console.WriteLine($" | fullname : {fullname} | id : {id} | phonenumber : {phonenumber} | address : {address} | sudentid : {studentid} | room : {room} | block : {block} | dorm : {dorm} |");
                Console.WriteLine($"rank : {rank}");
                if (personalequipments != null)
                {
                    Console.WriteLine("personalequipments : "); foreach (string i in personalequipments) Console.WriteLine($" | {i} | ");
                }
                Console.WriteLine();
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is Blockboss other)
            {
                return this.fullname == other.fullname;
            }
            return false;
        }
        public virtual void Turn(List<Blockboss> blockboss, Blockboss other)
        {
            foreach (Blockboss e in blockboss)
            {
                if (e.fullname == other.fullname)
                {
                    other.fullname = e.fullname;
                    other.id = e.id;
                    other.phonenumber = e.phonenumber;
                    other.address = e.address;
                    other.studentid = e.studentid;
                    other.room = e.room;
                    other.block = e.block;
                    other.dorm = e.dorm;
                    other.personalequipments = e.personalequipments;
                    other.rank = e.rank;
                    return;
                }
            }
            Console.WriteLine($"Student hasn't been registered!");
        }
    }
    class Program
    {
        static async void Login(List<User> user, List<Dorm> dorm, List<Block> block, List<Room> room, List<Equipment> equipment, List<Dormboss> dormboss, List<Student> student, List<Blockboss> blockboss)
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
                if (a != "")
                {
                    string b = Console.ReadLine();
                    Console.WriteLine();
                    if (b != "")
                    {
                        User temp = new User(a, b);
                        if (user.Contains(temp))
                        {
                            managementpage(dorm, block, room, equipment, dormboss, student, blockboss);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Account not found, try again later.");
                            Console.ReadKey();
                            return;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Error, try again later!");
                        Console.ReadKey();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Error, try again later!");
                    Console.ReadKey();
                    break;
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
                if (a != "")
                {
                    string b = Console.ReadLine();
                    if (b != "")
                    {
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
                            user.Add(c);
                            Console.ReadKey();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error, try again later!");
                        Console.ReadKey();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Error, try again later!");
                    Console.ReadKey();
                    break;
                }
            }
        }
        static void managementpage(List<Dorm> dorm, List<Block> block, List<Room> room, List<Equipment> equipment, List<Dormboss> dormboss, List<Student> student, List<Blockboss> blockboss)
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
                        dormmanagement(dorm, block, dormboss);
                        break;
                    case '2':
                        blockmanagement(block, student, blockboss, room);
                        break;
                    case '3':
                        personalmanagement(student, dormboss, blockboss, room, dorm);
                        break;
                    case '4':
                        belongingsmanagement(equipment, room, student);
                        break;
                    case '5':
                        viewreport(dorm, block, room, equipment, dormboss, student, blockboss);
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
        static void dormmanagement(List<Dorm> dorm, List<Block> block, List<Dormboss> dormboss)
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
                        Dorm g = new Dorm(a, null, 0, null, null);
                        if (dorm.Contains(g))
                        {
                            Console.WriteLine("This dorm has already been registered!");
                        }
                        else if (a == "")
                        {
                            Console.WriteLine("Error, try again later!");
                        }
                        else
                        {
                            Console.WriteLine("Enter address : ");
                            string b = Console.ReadLine();
                            if (b != "")
                            {
                                Console.WriteLine("Enter capacity : ");
                                string m = Console.ReadLine();
                                if (int.TryParse(m, out int c))
                                {
                                    Console.WriteLine("Enter dormboss fullname : ");
                                    string d = Console.ReadLine();
                                    if (d != "")
                                    {
                                        Dormboss n = new Dormboss(d, null, null, null, null, null);
                                        if (!dormboss.Contains(n))
                                        {
                                            Console.WriteLine("Enter dormbosse's personal id : ");
                                            string o = Console.ReadLine();
                                            if (o != "")
                                            {
                                                Console.WriteLine("Enter dormbosse's phone number : ");
                                                string p = Console.ReadLine();
                                                if (p != "")
                                                {
                                                    Console.WriteLine("Enter dormbosse's address : ");
                                                    string q = Console.ReadLine();
                                                    if (q != "")
                                                    {
                                                        Console.WriteLine("Enter dormbosse's personal id : ");
                                                        string r = Console.ReadLine();
                                                        if (r != "")
                                                        {
                                                            n = new Dormboss(d, o, p, q, r, a);
                                                            dormboss.Add(n);
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Error, try again later!");
                                                            Console.ReadKey();
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Error, try again later!");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Error, try again later!");
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Error, try again later!");
                                                Console.ReadKey();
                                                break;
                                            }
                                        }
                                        Console.WriteLine("Enter list of blocks : ");
                                        List<Block> h = new List<Block>();
                                        Console.WriteLine("Enter '0' to stop listing blocks");
                                        while (true)
                                        {
                                            string o = Console.ReadLine();
                                            if (int.TryParse(o, out int j))
                                            {
                                                if (j == 0)
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine("Listing blocks has ended!");
                                                    break;
                                                }
                                                else
                                                {
                                                    Block k = new Block(j, 0, 0, null, null);
                                                    if (!h.Contains(k))
                                                    {
                                                        h.Add(k);
                                                        Console.WriteLine("Block added successfully!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Block already added!");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Error, try again!");
                                            }
                                        }
                                        foreach (Block l in h)
                                        {
                                            if (!block.Contains(l))
                                            {
                                                block.Add(l);
                                            }
                                        }
                                        g = new Dorm(a, b, c, d, h);
                                        dorm.Add(g);
                                        Console.WriteLine();
                                        Console.WriteLine("Dorm successfully added!");

                                    }
                                    else
                                    {
                                        Console.WriteLine("Error, try again later!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error, try again later!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error, try again later!");
                            }
                        }
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Enter name : ");
                        a = Console.ReadLine();
                        if (a != "")
                        {
                            g = new Dorm(a, null, 0, null, null);
                            if (!dorm.Contains(g))
                            {
                                Console.WriteLine("Dorm hasn't beem registered!");
                            }
                            else
                            {
                                g.Turn(dorm, g);
                                foreach (Block l in g.blocks)
                                {
                                    if (block.Contains(l))
                                    {
                                        block.Remove(l);
                                    }
                                }
                                Dormboss b = new Dormboss(g.dormboss, null, null, null, null, null);
                                if (dormboss.Contains(b))
                                {
                                    dormboss.Remove(b);
                                }
                                dorm.Remove(g);
                                Console.WriteLine("Dorm, it's dormboss and all it's blocks have been successfully removed!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, try again later!");
                        }
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Enter name : ");
                        a = Console.ReadLine();
                        g = new Dorm(a, null, 0, null, null);
                        if (dorm.Contains(g))
                        {
                            Dorm s = new Dorm(a, null, 0, null, null);
                            s.Turn(dorm, s);

                            foreach (Block l in s.blocks)
                            {
                                if (block.Contains(l))
                                {
                                    block.Remove(l);
                                }
                            }
                            Dormboss t = new Dormboss(s.dormboss, null, null, null, null, null);
                            if (dormboss.Contains(t))
                            {
                                dormboss.Remove(t);
                            }
                            dorm.Remove(g);
                            Console.WriteLine("Enter address : ");
                            string b = Console.ReadLine();
                            if (b != "")
                            {
                                Console.WriteLine("Enter capacity : ");
                                string m = Console.ReadLine();
                                if (int.TryParse(m, out int c))
                                {
                                    Console.WriteLine("Enter dormboss fullname : ");
                                    string d = Console.ReadLine();
                                    if (d != "")
                                    {
                                        Dormboss n = new Dormboss(d, null, null, null, null, null);
                                        if (!dormboss.Contains(n))
                                        {
                                            Console.WriteLine("Enter dormbosse's personal id : ");
                                            string o = Console.ReadLine();
                                            if (o != "")
                                            {
                                                Console.WriteLine("Enter dormbosse's phone number : ");
                                                string p = Console.ReadLine();
                                                if (p != "")
                                                {
                                                    Console.WriteLine("Enter dormbosse's address : ");
                                                    string q = Console.ReadLine();
                                                    if (q != "")
                                                    {
                                                        Console.WriteLine("Enter dormbosse's personal id : ");
                                                        string r = Console.ReadLine();
                                                        if (r != "")
                                                        {
                                                            n = new Dormboss(d, o, p, q, r, a);
                                                            dormboss.Add(n);
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Error, try again later!");
                                                            Console.ReadKey();
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Error, try again later!");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Error, try again later!");
                                                    Console.ReadKey();
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Error, try again later!");
                                                Console.ReadKey();
                                                break;
                                            }
                                        }
                                        Console.WriteLine("Enter list of blocks : ");
                                        List<Block> h = new List<Block>();
                                        Console.WriteLine("Enter '0' to stop listing blocks");
                                        while (true)
                                        {
                                            string o = Console.ReadLine();
                                            if (int.TryParse(o, out int j))
                                            {
                                                if (j == 0)
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine("Listing blocks has ended!");
                                                    break;
                                                }
                                                else
                                                {
                                                    Block k = new Block(j, 0, 0, null, null);
                                                    if (!h.Contains(k))
                                                    {
                                                        h.Add(k);
                                                        Console.WriteLine("Block added successfully!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Block already added!");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Error, try again!");
                                            }
                                        }
                                        foreach (Block l in h)
                                        {
                                            if (!block.Contains(l))
                                            {
                                                block.Add(l);
                                            }
                                        }
                                        g = new Dorm(a, b, c, d, h);
                                        dorm.Add(g);
                                        Console.WriteLine();
                                        Console.WriteLine("Dorm successfully added!");

                                    }
                                    else
                                    {
                                        Console.WriteLine("Error, try again later!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error, try again later!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error, try again later!");
                            }
                        }
                        else if (a == "")
                        {
                            Console.WriteLine("Error, try again later!");
                        }
                        else
                        {
                            Console.WriteLine("This dorm hasn't been registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '4':
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
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void blockmanagement(List<Block> block, List<Student> student, List<Blockboss> blockboss, List<Room> room)
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
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                switch (x.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Enter block number : ");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Block G = new Block(a, 0, 0, null, null);
                        if (block.Contains(G))
                        {
                            Console.WriteLine("This block is already registered!");
                        }
                        else
                        {
                            Console.WriteLine("Enter floor number : ");
                            int b = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter number of rooms : ");
                            int c = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter blockbosse's fullname : ");
                            string d = Console.ReadLine();
                            Student A = new Student(d, null, null, null, null, 0, 0, null, null);
                            Blockboss C = new Blockboss(d, null, null, null, null, 0, 0, null, null, null);
                            if (student.Contains(A) && blockboss.Contains(C))
                            {
                                List<Room> f = new List<Room>();
                                for (int i = 0; i < c; i++)
                                {
                                    Console.WriteLine("Enter room number : ");
                                    int aa = Convert.ToInt32(Console.ReadLine());
                                    Room B = new Room(aa, b, 6, null, null, a);
                                    if (f.Contains(B))
                                    {
                                        Console.WriteLine("This room has already been registered!");
                                        i--;
                                    }
                                    else
                                    {
                                        f.Add(B);
                                        Console.WriteLine();
                                        Console.WriteLine("Room successfully added!");
                                    }
                                }
                                G = new Block(a, b, c, d, f);
                                foreach (Room r in f)
                                {
                                    room.Add(r);
                                }
                                block.Add(G);
                                Console.WriteLine("Block and rooms successfully added!");
                            }
                            else
                            {
                                Console.WriteLine("The blockboss isn't registered as a student!");
                            }
                        }
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Enter name : ");
                        a = Convert.ToInt32(Console.ReadLine());
                        Block g = new Block(a, 0, 0, null, null);
                        if (!block.Contains(g))
                        {
                            Console.WriteLine("Block doesn't exist!");
                        }
                        else
                        {
                            g.Turn(block, g);
                            foreach (Room r in g.rooms)
                            {
                                if (room.Contains(r))
                                {
                                    room.Remove(r);
                                }
                            }
                            block.Remove(g);
                            Console.WriteLine("Block and rooms successfully removed!");
                        }
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Enter name : ");
                        a = Convert.ToInt32(Console.ReadLine());
                        g = new Block(a, 0, 0, null, null);
                        if (block.Contains(g))
                        {
                            Console.WriteLine("Enter floor number : ");
                            int b = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter number of rooms : ");
                            int c = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter blockbosse's fullname : ");
                            string d = Console.ReadLine();
                            Student A = new Student(d, null, null, null, null, 0, 0, null, null);
                            Blockboss C = new Blockboss(d, null, null, null, null, 0, 0, null, null, null);
                            if (student.Contains(A) && blockboss.Contains(C))
                            {
                                List<Room> f = new List<Room>();
                                for (int i = 0; i < c; i++)
                                {
                                    Console.WriteLine("Enter room number : ");
                                    int aa = Convert.ToInt32(Console.ReadLine());
                                    Room vv = new Room(aa, b, 6, null, null, a);
                                    if (f.Contains(vv))
                                    {
                                        Console.WriteLine("This room has already been registered!");
                                        i--;
                                    }
                                    else
                                    {
                                        f.Add(vv);
                                        Console.WriteLine();
                                        Console.WriteLine("Room successfully added!");
                                    }
                                }
                                g.Turn(block, g);
                                foreach (Room r in g.rooms)
                                {
                                    room.Remove(r);
                                }
                                block.Remove(g);
                                g = new Block(a, b, c, d, f);
                                foreach (Room r in g.rooms)
                                {
                                    room.Add(r);
                                }
                                block.Add(g);
                                Console.WriteLine("Block and rooms info successfully changed!");
                            }
                            else
                            {
                                Console.WriteLine("The blockboss isn't registered as a student!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Block hasn't been registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '4':
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
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void personalmanagement(List<Student> student, List<Dormboss> dormboss, List<Blockboss> blockboss, List<Room> room, List<Dorm> dorm)
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
                        Blockboss(blockboss, student, room, dorm);
                        break;
                    case '3':
                        Student(student, blockboss, room, dorm);
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
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
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
                            Console.WriteLine("Enter personal id : ");
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
                        Console.Clear();
                        Console.WriteLine("Enter fullname : ");
                        a = Console.ReadLine();
                        g = new Dormboss(a, null, null, null, null, null);
                        if (dormboss.Contains(g))
                        {
                            Console.WriteLine("Enter personal id : ");
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
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Blockboss(List<Blockboss> blockboss, List<Student> student, List<Room> room, List<Dorm> dorm)
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
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                switch (x.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Enter fullname : ");
                        string a = Console.ReadLine();
                        Blockboss l = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                        Student m = new Student(a, null, null, null, null, 0, 0, null, null);
                        if (blockboss.Contains(l) && student.Contains(m))
                        {
                            Console.WriteLine("This blockboss is already registered!");
                        }
                        else
                        {
                            Console.WriteLine("Enter personal id : ");
                            string b = Console.ReadLine();
                            Console.WriteLine("Enter phone number :");
                            string c = Console.ReadLine();
                            Console.WriteLine("Enter address : ");
                            string d = Console.ReadLine();
                            Console.WriteLine("Enter blockboss studentid : ");
                            string k = Console.ReadLine();
                            Console.WriteLine("Enter room number : ");
                            int e = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter room floor : ");
                            int n = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter block number : ");
                            int f = Convert.ToInt32(Console.ReadLine());
                            Room o = new Room(e, n, 0, null, null, f);
                            if (room.Contains(o))
                            {
                                o.Turn(room, o);
                                if (o.capacity - o.residentialstudents.Count >= 0)
                                {
                                    Console.WriteLine("Enter dorm name : ");
                                    string g = Console.ReadLine();
                                    Console.WriteLine("Enter personal equipments list : ");
                                    List<string> h = new List<string>();
                                    Console.WriteLine("Enter (0) to finish listing : ");
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
                                    m = l;
                                    blockboss.Add(l);
                                    if (!student.Contains(m))
                                    {
                                        student.Add(m);
                                    }
                                    Console.WriteLine("Blockboss successfully added!");
                                }
                                else
                                {
                                    Console.WriteLine("This room is full!");
                                }
                            }
                        }
                        Console.ReadKey();
                        break;
                    case '2':
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
                        Console.Clear();
                        Console.WriteLine("Enter fullname : ");
                        a = Console.ReadLine();
                        l = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                        m = new Student(a, null, null, null, null, 0, 0, null, null);
                        if (blockboss.Contains(l) || student.Contains(m))
                        {
                            Console.WriteLine("Enter personal id : ");
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
                            m = new Student(a, b, c, d, k, e, f, g, h);
                            student.Remove(m);
                            blockboss.Remove(l);
                            student.Add(m);
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
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Student(List<Student> student, List<Blockboss> blockboss, List<Room> room, List<Dorm> dorm)
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
                Console.WriteLine(" |      5.View student info       |    6.Add student to a dorm     |");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine("  ----------------------------------------------------------------- ");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine(" |7.Change student Dorm/Block/Room|           8.Go back            |");
                Console.WriteLine(" |                                |                                |");
                Console.WriteLine("  ----------------------------------------------------------------- ");
                var x = Console.ReadKey();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                switch (x.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Enter fullname : ");
                        string a = Console.ReadLine();
                        Student l = new Student(a, null, null, null, null, 0, 0, null, null);
                        if (student.Contains(l))
                        {
                            Console.WriteLine("This student is already registered!");
                        }
                        else
                        {
                            Console.WriteLine("Enter personal id : ");
                            string b = Console.ReadLine();
                            Console.WriteLine("Enter phone number :");
                            string c = Console.ReadLine();
                            Console.WriteLine("Enter address : ");
                            string d = Console.ReadLine();
                            Console.WriteLine("Enter student id : ");
                            string j = Console.ReadLine();
                            Console.WriteLine("Enter room number : ");
                            int e = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter block number : ");
                            int f = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter dorm name : ");
                            string g = Console.ReadLine();
                            Dorm k = new Dorm(g, null, 0, null, null);
                            if (dorm.Contains(k))
                            {
                                Console.WriteLine("Enter personal equipments list : ");
                                List<string> h = new List<string>();
                                Console.WriteLine("Enter (0) to finish listing : ");
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
                                l = new Student(a, b, c, d, j, e, f, g, h);
                                student.Add(l);
                                Console.WriteLine("Student successfully added!");
                            }
                            else
                            {
                                Console.WriteLine("This dorm doesn't exist!");
                            }
                        }
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Enter fullname");
                        a = Console.ReadLine();
                        l = new Student(a, null, null, null, null, 0, 0, null, null);
                        Blockboss m = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                        if (!student.Contains(l))
                        {
                            Console.WriteLine("Student hasn't been registered!");
                        }
                        else
                        {
                            student.Remove(l);
                            blockboss.Remove(m);
                            Console.WriteLine("Student successfully removed!");
                        }
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Enter fullname");
                        a = Console.ReadLine();
                        l = new Student(a, null, null, null, null, 0, 0, null, null);
                        if (student.Contains(l))
                        {
                            Console.WriteLine("Enter personal id : ");
                            string b = Console.ReadLine();
                            Console.WriteLine("Enter phone number :");
                            string c = Console.ReadLine();
                            Console.WriteLine("Enter address : ");
                            string d = Console.ReadLine();
                            Console.WriteLine("Enter student id : ");
                            string j = Console.ReadLine();
                            Console.WriteLine("Enter room number : ");
                            int e = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter block number : ");
                            int f = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter dorm name : ");
                            string g = Console.ReadLine();
                            Console.WriteLine("Enter personal equipments list : ");
                            List<string> h = new List<string>();
                            Console.WriteLine("Enter (0) to finish listing : ");
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
                            l = new Student(a, b, c, d, j, e, f, g, h);
                            student.Remove(l);
                            student.Add(l);
                            Console.WriteLine("Student successfully changed!");
                        }
                        else
                        {
                            Console.WriteLine("Student hasn't been registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.Clear();
                        Console.WriteLine("Enter fullname");
                        a = Console.ReadLine();
                        l = new Student(a, null, null, null, null, 0, 0, null, null);
                        if (student.Contains(l))
                        {
                            l.Find(student, l);
                        }
                        else
                        {
                            Console.WriteLine("Student hasn't been registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '5':
                        Console.Clear();
                        if (student.Count == 0)
                        {
                            Console.WriteLine("There are no registered blockbosses!");
                        }
                        else
                        {
                            foreach (Student i in student)
                            {
                                i.info();
                                Console.WriteLine();
                            }
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                        break;
                    case '6':
                        Console.Clear();
                        Console.WriteLine("Enter fullname");
                        a = Console.ReadLine();
                        l = new Student(a, null, null, null, null, 0, 0, null, null);
                        if (student.Contains(l))
                        {
                            l.ChangeDorm(student, l);
                        }
                        else
                        {
                            Console.WriteLine("Student hasn't been registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '7':
                        Console.Clear();
                        Change(student, room);
                        break;
                    case '8':
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Change(List<Student> student, List<Room> room)
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("  --------------------------------");
                Console.WriteLine(" |                                |");
                Console.WriteLine(" |         1.Change dorm          |");
                Console.WriteLine(" |                                |");
                Console.WriteLine("  --------------------------------");
                Console.WriteLine(" |                                |");
                Console.WriteLine(" |         2.Change block         |");
                Console.WriteLine(" |                                |");
                Console.WriteLine("  --------------------------------");
                Console.WriteLine(" |                                |");
                Console.WriteLine(" |         3.Change room          |");
                Console.WriteLine(" |                                |");
                Console.WriteLine("  --------------------------------");
                Console.WriteLine(" |                                |");
                Console.WriteLine(" |           4.Go back            |");
                Console.WriteLine(" |                                |");
                Console.WriteLine("  --------------------------------");
                Console.WriteLine(" |                                |");
                Console.WriteLine(" |   [Pick a number from (1-4)]   |");
                Console.WriteLine(" |                                |");
                Console.WriteLine("  --------------------------------");
                var x = Console.ReadKey();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                switch (x.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Enter fullname");
                        string a = Console.ReadLine();
                        Student l = new Student(a, null, null, null, null, 0, 0, null, null);
                        if (student.Contains(l))
                        {
                            l.ChangeDorm(student, l);
                        }
                        else
                        {
                            Console.WriteLine("Student hasn't been registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Enter fullname");
                        a = Console.ReadLine();
                        l = new Student(a, null, null, null, null, 0, 0, null, null);
                        if (student.Contains(l))
                        {
                            l.ChangeBlock(student, l);
                        }
                        else
                        {
                            Console.WriteLine("Student hasn't been registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Enter fullname");
                        a = Console.ReadLine();
                        l = new Student(a, null, null, null, null, 0, 0, null, null);
                        if (student.Contains(l))
                        {
                            l.ChangeRoom(student, l);
                        }
                        else
                        {
                            Console.WriteLine("Student hasn't been registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '4':
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void belongingsmanagement(List<Equipment> equipment, List<Room> room, List<Student> student)
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
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
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                switch (x.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("How many items are you adding ? ");
                        int A = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < A; i++)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter belonging name : ");
                            string a = Console.ReadLine();
                            Console.WriteLine("Enter Part number : ");
                            int b = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter belonging id : ");
                            string c = Console.ReadLine();
                            Console.WriteLine("Choose belonging status : ");
                            Console.WriteLine("1.ok.");
                            Console.WriteLine("2.broken.");
                            Console.WriteLine();
                            string d = null;
                            Equipment B = new Equipment(null, 0, null, null, 0, null);
                            while (true)
                            {
                                var e = Console.ReadKey();
                                Console.WriteLine();
                                if (e.KeyChar == '1')
                                {
                                    d = "ok"; ;
                                    Console.WriteLine("Enter room number : ");
                                    int g = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter owner(student) name : ");
                                    string f = Console.ReadLine();
                                    B = new Equipment(a, b, c, d, g, f);
                                    if (!equipment.Contains(B))
                                    {
                                        equipment.Add(B);
                                        Console.WriteLine("Item added to the list!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The item is already registered!");
                                    }
                                    break;
                                }
                                else if (e.KeyChar == '2')
                                {
                                    d = "broken";
                                    Console.WriteLine("Enter room number : ");
                                    int g = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter owner(student) name : ");
                                    string f = Console.ReadLine();
                                    B = new Equipment(a, b, c, d, g, f);
                                    if (!equipment.Contains(B))
                                    {
                                        equipment.Add(B);
                                        Console.WriteLine("Item added to the list!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The item is already registered!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("try again!");
                                }
                                break;
                            }

                            Console.ReadKey();
                        }
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("belongings : ");
                        Console.WriteLine();
                        foreach (Equipment i in equipment)
                        {
                            i.info();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Enter the belonging's details that you want to reassign to another room : ");
                        Console.WriteLine();
                        Console.WriteLine("Enter belonging name : ");
                        string z = Console.ReadLine();
                        Console.WriteLine("Enter Part number : ");
                        int y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter belonging id : ");
                        string w = Console.ReadLine();
                        Console.WriteLine("Choose status : ");
                        Console.WriteLine("1.ok.");
                        Console.WriteLine("2.broken.");
                        Console.WriteLine();
                        string X = null;
                        while (true)
                        {
                            var a = Console.ReadKey();
                            Console.WriteLine();
                            if (a.KeyChar == '1')
                            {
                                X = "ok";
                                break;
                            }
                            else if (a.KeyChar == '2')
                            {
                                X = "broken";
                                break;
                            }
                            else
                            {
                                Console.WriteLine("try again!");
                                Console.ReadKey();
                            }
                        }
                        Equipment C = new Equipment(z, y, w, X, 0, null);
                        if (equipment.Contains(C))
                        {
                            C.Turn(equipment, C);
                            equipment.Remove(C);
                            Console.WriteLine("Enter room number : ");
                            int u = Convert.ToInt32(Console.ReadLine());
                            C.room = u;
                            equipment.Add(C);
                            Console.WriteLine("Equipment's room has been changed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Equipment hasn't been registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("belongings : ");
                        Console.WriteLine();
                        foreach (Equipment i in equipment)
                        {
                            i.info();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Enter the belonging's details that you want to reassign to another owner(student) : ");
                        Console.WriteLine();
                        Console.WriteLine("Enter belonging name : ");
                        z = Console.ReadLine();
                        Console.WriteLine("Enter Part number : ");
                        y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter belonging id : ");
                        w = Console.ReadLine();
                        Console.WriteLine("Choose status : ");
                        Console.WriteLine("1.ok.");
                        Console.WriteLine("2.broken.");
                        Console.WriteLine();
                        string Y = null;
                        while (true)
                        {
                            var a = Console.ReadKey();
                            Console.WriteLine();
                            if (a.KeyChar == '1')
                            {
                                Y = "ok";
                                break;
                            }
                            else if (a.KeyChar == '2')
                            {
                                Y = "broken";
                                break;
                            }
                            else
                            {
                                Console.WriteLine("try again!");
                                Console.ReadKey();
                            }
                        }
                        C = new Equipment(z, y, w, Y, 0, null);
                        if (equipment.Contains(C))
                        {
                            C.Turn(equipment, C);
                            equipment.Remove(C);
                            Console.WriteLine("Enter owner(student) name : ");
                            string f = Console.ReadLine();
                            C.student = f;
                            equipment.Add(C);
                            Console.WriteLine("Equipment's owner(student) name has been changed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Equipment hasn't been registered!");
                        }
                        Console.ReadKey();

                        break;
                    case '4':
                        Console.Clear();
                        Console.WriteLine("belongings : ");
                        Console.WriteLine();
                        foreach (Equipment i in equipment)
                        {
                            i.info();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Enter the belonging's details that you want to reassign to another owner(student) : ");
                        Console.WriteLine();
                        Console.WriteLine("Enter belonging name : ");
                        z = Console.ReadLine();
                        Console.WriteLine("Enter Part number : ");
                        y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter belonging id : ");
                        w = Console.ReadLine();
                        Console.WriteLine("Choose status : ");
                        Console.WriteLine("1.ok.");
                        Console.WriteLine("2.broken.");
                        Console.WriteLine();
                        string Z = null;
                        while (true)
                        {
                            var a = Console.ReadKey();
                            Console.WriteLine();
                            if (a.KeyChar == '1')
                            {
                                Z = "ok";
                                break;
                            }
                            else if (a.KeyChar == '2')
                            {
                                Z = "broken";
                                break;
                            }
                            else
                            {
                                Console.WriteLine("try again!");
                                Console.ReadKey();
                            }
                        }
                        C = new Equipment(z, y, w, Z, 0, null);
                        if (equipment.Contains(C))
                        {
                            C.Turn(equipment, C);
                            equipment.Remove(C);
                            Console.WriteLine("Enter owner(student) name : ");
                            string f = Console.ReadLine();
                            C.student = f;
                            equipment.Add(C);
                            Console.WriteLine("Equipment's owner(student) name has been changed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Equipment hasn't been registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '5':
                        Console.Clear();
                        Console.WriteLine("belongings : ");
                        Console.WriteLine();
                        foreach (Equipment i in equipment)
                        {
                            i.info();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Enter the belonging's details that you want to change the status of : ");
                        Console.WriteLine();
                        Console.WriteLine("Enter belonging name : ");
                        z = Console.ReadLine();
                        Console.WriteLine("Enter Part number : ");
                        y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter belonging id : ");
                        w = Console.ReadLine();
                        Console.WriteLine("Choose status : ");
                        Console.WriteLine("1.ok.");
                        Console.WriteLine("2.broken.");
                        Console.WriteLine();
                        string Zz = null;
                        while (true)
                        {
                            var a = Console.ReadKey();
                            Console.WriteLine();
                            if (a.KeyChar == '1')
                            {
                                Zz = "ok";
                                break;
                            }
                            else if (a.KeyChar == '2')
                            {
                                Zz = "broken";
                                break;
                            }
                            else
                            {
                                Console.WriteLine("try again!");
                                Console.ReadKey();
                            }
                            Console.WriteLine();
                        }
                        C = new Equipment(z, y, w, Zz, 0, null);
                        if (equipment.Contains(C))
                        {
                            C.Turn(equipment, C);
                            Equipment D = C;
                            equipment.Remove(C);
                            Console.WriteLine("Choose new status : ");
                            Console.WriteLine("1.ok.");
                            Console.WriteLine("2.broken.");
                            Console.WriteLine();
                            string f = null;
                            while (true)
                            {
                                var a = Console.ReadKey();
                                Console.WriteLine();
                                if (a.KeyChar == '1')
                                {
                                    f = "ok";
                                    break;
                                }
                                else if (a.KeyChar == '2')
                                {
                                    f = "broken";
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("try again!");
                                    Console.ReadKey();
                                }
                            }
                            D.status = f;
                            equipment.Add(D);
                            Console.WriteLine("Equipment's status has been changed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Equipment hasn't been registered!");
                        }
                        Console.ReadKey();
                        break;
                    case '6':
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void viewreport(List<Dorm> dorm, List<Block> block, List<Room> room, List<Equipment> equipment, List<Dormboss> dormboss, List<Student> student, List<Blockboss> blockboss)
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
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
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                switch (x.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("All stationary students : ");
                        Console.WriteLine();
                        if (student.Count != 0)
                        {
                            foreach (Student s in student)
                            {
                                s.info();
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no registered students!");
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.ReadKey();
                        break;
                    case '4':
                        return;
                    default:
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
            List<User> user = new List<User>();
            List<Dorm> dorm = new List<Dorm>();
            List<Block> block = new List<Block>();
            List<Room> room = new List<Room>();
            List<Equipment> equipment = new List<Equipment>();
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
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                switch (x.KeyChar)
                {
                    case '1':
                        Login(user, dorm, block, room, equipment, dormboss, student, blockboss);
                        break;
                    case '2':
                        signup(user);
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.Clear();
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