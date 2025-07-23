using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
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
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                                      |");
            Console.WriteLine($" Dorm : | name : {name} | address : {address} | capacity : {capacity} | dormboss : {dormboss} |");
            Console.WriteLine(" | blocks || |");
            Console.WriteLine(" |        || |");
            Console.WriteLine(" |        \\/ |");
            if (blocks != null && blocks.Count != 0)
            {
                foreach (Block i in blocks)
                {
                    Console.WriteLine($" | {i.name} |");
                }
            }
            else
            {
                Console.WriteLine(" | There are no registered blocks for this dorm! |");
            }
            Console.WriteLine("|                                                                                                      |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
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
        }
        public virtual void DeleteBlock(List<Dorm> dorm, Block other)
        {
            foreach (Dorm e in dorm)
            {
                if (e.blocks.Contains(other))
                {
                    e.blocks.Remove(other);
                    return;
                }
            }
        }
    }
    public class Block
    {
        public int name { set; get; }
        public int level { set; get; }
        public int roomno { set; get; }
        public string blockboss { set; get; }
        public string dorm { set; get; }
        public List<Room> rooms { set; get; }
        public Block(int name, int level, int roomno, string blockboss, string dorm, List<Room> rooms)
        {
            this.name = name;
            this.level = level;
            this.roomno = roomno;
            this.blockboss = blockboss;
            this.dorm = dorm;
            this.rooms = rooms;
        }
        public virtual void info()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                                      |");
            Console.WriteLine($" Block : | name : {name} | number of floors : {level} | number of rooms : {roomno} | blockboss : {blockboss} | related dorm : {dorm} |");
            Console.WriteLine(" | rooms || |");
            Console.WriteLine(" |       \\/ |");
            if (rooms != null && rooms.Count != 0)
            {
                foreach (Room i in rooms)
                {
                    Console.WriteLine($" | Room number : {i.number} & Room floor : {i.level} |");
                }
            }
            else
            {
                Console.WriteLine(" | There are no registered rooms! |");
            }
            Console.WriteLine("|                                                                                                      |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }
        public override bool Equals(object obj)
        {
            if (obj is Block other)
            {
                return this.name == other.name && this.dorm == other.dorm;
            }
            return false;
        }
        public virtual void Turn(List<Block> block, Block other)
        {
            foreach (Block e in block)
            {
                if (e.name == other.name && e.dorm == other.dorm)
                {
                    other.name = e.name;
                    other.dorm = e.dorm;
                    other.level = e.level;
                    other.roomno = e.roomno;
                    other.blockboss = e.blockboss;
                    other.rooms = e.rooms;
                    return;
                }
            }
        }
        public virtual void DeleteRoom(List<Room> room, List<Room> other)
        {
            foreach (Room e in room)
            {
                foreach (Room r in other)
                {
                    if (e.number == r.number)
                    {
                        room.Remove(r);
                    }
                }
            }
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
        public int block { set; get; }
        public Room(int number, int level, int capacity, List<string> equipments, List<string> residentialstudents, int block)
        {
            this.number = number;
            this.level = level;
            this.capacity = 6;
            this.equipments = equipments;
            this.residentialstudents = residentialstudents;
            this.block = block;
        }
        public virtual void info()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                                      |");
            Console.WriteLine($" Room : | number : {number} | level : {level} | capacity : {capacity} | block : {block} |");
            Console.WriteLine(" | equipments || |");
            Console.WriteLine(" |            \\/ |");
            if (equipments != null && equipments.Count != 0)
            {
                foreach (string i in equipments)
                {
                    Console.WriteLine($" | {i} |");
                }
            }
            else
            {
                Console.WriteLine(" | There are no registered equipments! |");
            }
            Console.WriteLine();
            Console.WriteLine(" | residentialstudents || | ");
            Console.WriteLine(" |                     \\/ |");
            if (residentialstudents != null && residentialstudents.Count != 0)
            {
                foreach (string i in residentialstudents)
                {
                    Console.WriteLine($" | name : {i} |");
                }
            }
            else
            {
                Console.WriteLine(" | There are no registered residential student! |");
            }
            Console.WriteLine();
            Console.WriteLine("|                                                                                                      |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
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
                if (e.number == other.number && e.level == other.level && e.block == other.block)
                {
                    other.number = e.number;
                    other.level = e.level;
                    other.capacity = e.capacity;
                    other.equipments = e.equipments;
                    other.residentialstudents = e.residentialstudents;
                    other.block = e.block;
                    return;
                }
            }
        }
        public virtual void Terminate(List<Room> room, Room other, string a)
        {
            foreach (Room e in room)
            {
                if (e.number == other.number && e.block == other.block)
                {
                    other.number = e.number;
                    other.level = e.level;
                    other.capacity = e.capacity;
                    other.equipments = e.equipments;
                    other.residentialstudents = e.residentialstudents;
                    other.block = e.block;
                    room.Remove(other);
                    other.residentialstudents.Remove(a);
                    room.Add(other);
                    other.capacity++;
                    return;
                }
            }
        }
        public virtual void Delete(List<Room> room, List<Room> other)
        {
            foreach (Room e in room)
            {
                foreach (Room r in other)
                {
                    if (e.number == r.number)
                    {
                        room.Remove(r);
                    }
                }
            }
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
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                                                                                          |");
            Console.WriteLine($" Equipment : | belonging : {belonging} | number : {number} | belongingid : {belongingid} | status : {status} | room : {room} | student : {student} |");
            Console.WriteLine("|                                                                                                                                                          |");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }
        public override bool Equals(object obj)
        {
            if (obj is Equipment other)
            {
                return this.belonging == other.belonging && this.number == other.number && this.belongingid == other.belongingid;
            }
            return false;
        }
        public virtual void Turn(List<Equipment> equipment, Equipment other)
        {
            foreach (Equipment e in equipment)
            {
                if (e.belonging == other.belonging && e.number == other.number && e.belongingid == other.belongingid)
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
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                                      |");
            Console.WriteLine($" Person : | fullname : {fullname} | id : {id} | phonenumber : {phonenumber} | address : {address} |");
            Console.WriteLine("|                                                                                                      |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
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
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                                                                                  |");
            Console.WriteLine($" Dormboss : | fullname : {fullname} | id : {id} | phonenumber : {phonenumber} | address : {address} | rank : {rank} | dorm : {dorm} |");
            Console.WriteLine("|                                                                                                                                                  |");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");
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
        }
    }
    public class Student : Person
    {
        public string studentid { set; get; }
        public int room { set; get; }
        public int block { set; get; }
        public string dorm { set; get; }
        public List<Equipment> personalequipments { set; get; }
        public Student(string fullname, string id, string phonenumber, string address, string studentid, int room, int block, string dorm, List<Equipment> personalequipments) : base(fullname, id, phonenumber, address)
        {
            this.studentid = studentid;
            this.room = room;
            this.block = block;
            this.dorm = dorm;
            this.personalequipments = personalequipments;
        }
        public override void info()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                                                                                           |");
            Console.WriteLine($" Student : | fullname : {fullname} | id : {id} | phonenumber : {phonenumber} | address : {address} | sudentid : {studentid} | room : {room} | block : {block} | dorm : {dorm} |");
            Console.WriteLine(" | personal equipments || |");
            Console.WriteLine(" |                     \\/ |");
            if (personalequipments != null && personalequipments.Count != 0)
            {
                foreach (Equipment i in personalequipments)
                {
                    Console.WriteLine($" | belonging : {i.belonging} | part number : {i.number} | id : {i.belongingid}");
                }
            }
            else
            {
                Console.WriteLine(" | There are no registered personal equipments! |");
            }
            Console.WriteLine("|                                                                                                                                                           |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------");
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
        }
        public virtual void Turn(List<Student> student, Student other)
        {
            foreach (Student e in student)
            {
                if (e.fullname == other.fullname)
                {
                    other.fullname = e.fullname;
                    other.id = e.id;
                    other.address = e.address;
                    other.phonenumber = e.phonenumber;
                    other.studentid = e.studentid;
                    other.room = e.room;
                    other.block = e.block;
                    other.dorm = e.dorm;
                    other.personalequipments = e.personalequipments;
                    return;
                }
            }
        }
    }
    public class Blockboss : Student
    {
        public string rank { set; get; }
        public Blockboss(string fullname, string id, string phonenumber, string address, string studentid, int room, int block, string dorm, List<Equipment> personalequipments, string rank) : base(fullname, id, phonenumber, address, studentid, room, block, dorm, personalequipments)
        {
            this.rank = rank;
        }
        public override void info()
        {
            {
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("|                                                                                                                                                    |");
                Console.WriteLine($" Blockboss : | fullname : {fullname} | id : {id} | phonenumber : {phonenumber} | address : {address} | sudentid : {studentid} | room : {room} | block : {block} | dorm : {dorm} | rank : {rank} |");
                Console.WriteLine(" | personal equipments || |");
                Console.WriteLine(" |                     \\/ |");
                if (personalequipments != null && personalequipments.Count != 0)
                {
                    foreach (Equipment i in personalequipments)
                    {
                        Console.WriteLine($" | belonging : {i.belonging} | part number : {i.number} | id : {i.belongingid}");
                    }
                }
                else
                {
                    Console.WriteLine(" | There are no registered personal equipments! |");
                }
                Console.WriteLine("|                                                                                                                                                    |");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
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
                    other.address = e.address;
                    other.phonenumber = e.phonenumber;
                    other.studentid = e.studentid;
                    other.room = e.room;
                    other.block = e.block;
                    other.dorm = e.dorm;
                    other.personalequipments = e.personalequipments;
                    other.rank = e.rank;
                    return;
                }
            }
        }
    }
    class Program
    {
        static void Login(List<User> user, List<Dorm> dorm, List<Block> block, List<Room> room, List<Equipment> equipment, List<Dormboss> dormboss, List<Student> student, List<Blockboss> blockboss)
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
                            Managementpage(dorm, block, room, equipment, dormboss, student, blockboss);
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
        static void Signup(List<User> user)
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
        static void Managementpage(List<Dorm> dorm, List<Block> block, List<Room> room, List<Equipment> equipment, List<Dormboss> dormboss, List<Student> student, List<Blockboss> blockboss)
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("     -------------------------------------------------");
                Console.Write("    /                                                  \\                "); Console.BackgroundColor = ConsoleColor.White; Console.WriteLine(" _____ "); Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("   /                  Management page                   \\              "); Console.BackgroundColor = ConsoleColor.White; Console.WriteLine(" /     \\ "); Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("  /                                                      \\            "); Console.BackgroundColor = ConsoleColor.White; Console.WriteLine(" | . .   | "); Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("  --------------------------------------------------------             "); Console.BackgroundColor = ConsoleColor.White; Console.WriteLine(" \\ .   / "); Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(" |                                                        |             "); Console.BackgroundColor = ConsoleColor.White; Console.WriteLine(" ----- "); Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(" |  ----------------------------------------------------  |");
                Console.WriteLine(" | |    1.Dorm management     |   2.Block management    | |");
                Console.WriteLine(" |  ----------------------------------------------------  |");
                Console.WriteLine(" |                                                        |");
                Console.WriteLine(" |  ----------------------------------------------------  |");
                Console.WriteLine(" | |  3.personal management   | 4.Belongings management | |");
                Console.WriteLine(" |  ----------------------------------------------------  |");
                Console.WriteLine(" |                                                        |");
                Console.WriteLine(" |  ----------------------------------------------------  |");
                Console.WriteLine(" | |      5.View report       |        6.Go back        | |");
                Console.WriteLine(" |  ----------------------------------------------------  |");
                Console.WriteLine(" |                                                        |");
                Console.WriteLine(" |                                        ___             |");
                Console.WriteLine(" |       [Pick a number from (1-6)]      |   |            |");
                Console.WriteLine(" |                                       |.  |            |");
                Console.WriteLine(" |                                       |   |            |");
                Console.WriteLine("  -------------------------------------------------------- ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                                           ");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("                                                           ");
                var x = Console.ReadKey();
                switch (x.KeyChar)
                {
                    case '1':
                        Dormmanagement(dorm, block, dormboss);
                        break;
                    case '2':
                        Blockmanagement(block, student, blockboss, room, dorm);
                        break;
                    case '3':
                        Personalmanagement(student, dormboss, blockboss, room, dorm, equipment, block);
                        break;
                    case '4':
                        Belongingsmanagement(equipment, room, student, blockboss);
                        break;
                    case '5':
                        Viewreport(dorm, block, room, equipment, dormboss, student, blockboss);
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
        static void Dormmanagement(List<Dorm> dorm, List<Block> block, List<Dormboss> dormboss)
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
                                                    Console.WriteLine("Enter dormbosse's rank : ");
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
                                        Console.WriteLine("Enter list of blocks : ");
                                        List<Block> h = new List<Block>();
                                        Console.WriteLine("Enter '0' to stop listing blocks");
                                        while (true)
                                        {
                                            o = Console.ReadLine();
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
                                                    Block k = new Block(j, 0, 0, null, a, null);
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
                                string[] gg = g.dormboss.Split(" and ");
                                for (int i = 0; i < gg.Length; i++)
                                {
                                    Dormboss b = new Dormboss(gg[i], null, null, null, null, null);
                                    if (dormboss.Contains(b))
                                    {
                                        dormboss.Remove(b);
                                    }
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
                                        if (dormboss.Contains(n))
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
                                                        Console.WriteLine("Enter dormbosse's rank : ");
                                                        string r = Console.ReadLine();
                                                        if (r != "")
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
                                            Console.WriteLine("Enter list of blocks : ");
                                            List<Block> h = new List<Block>();
                                            Console.WriteLine("Enter '0' to stop listing blocks");
                                            while (true)
                                            {
                                                o = Console.ReadLine();
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
                                                        Block k = new Block(j, 0, 0, null, a, null);
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
                                            Console.WriteLine("Dorm info successfully changed!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("This dormboss hasn't been registered!");
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
                        {
                            foreach (Dorm i in dorm)
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
        static void Blockmanagement(List<Block> block, List<Student> student, List<Blockboss> blockboss, List<Room> room, List<Dorm> dorm)
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
                        string h = null;
                        Dorm m = null;
                        Block g = null;
                        Console.Clear();
                        Console.WriteLine("Enter block number : ");
                        string p = Console.ReadLine();
                        if (int.TryParse(p, out int a))
                        {
                            Console.WriteLine("Enter related dorm : ");
                            h = Console.ReadLine();
                            if (h != "")
                            {
                                m = new Dorm(h, null, 0, null, null);
                                if (!dorm.Contains(m))
                                {
                                    Console.WriteLine("This dorm hasn't been registered!");
                                }
                                else
                                {
                                    m.Turn(dorm, m);
                                    int dc = 0;
                                    if (m.capacity != 0)
                                    {
                                        dc = m.capacity;
                                        Block G = new Block(a, 0, 0, null, h, null);
                                        if (block.Contains(G))
                                        {
                                            Console.WriteLine("This block is already registered!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Enter number of floors : ");
                                            string q = Console.ReadLine();
                                            if (int.TryParse(q, out int b))
                                            {
                                                Console.WriteLine("Enter number of rooms : ");
                                                string r = Console.ReadLine();
                                                if (int.TryParse(r, out int c))
                                                {
                                                    Console.WriteLine("Enter blockbosse's fullname : ");
                                                    string d = Console.ReadLine();
                                                    if (d != "")
                                                    {
                                                        Student A = new Student(d, null, null, null, null, 0, a, h, null);
                                                        Blockboss C = new Blockboss(d, null, null, null, null, 0, a, h, null, null);
                                                        if (!student.Contains(A))
                                                        {
                                                            Dorm D = new Dorm(h, null, 0, null, null);
                                                            D.Turn(dorm, D);
                                                            dc--;
                                                            D.capacity = dc;
                                                            dorm.Remove(D);
                                                            dorm.Add(D);
                                                        }
                                                        if (!student.Contains(A) && !blockboss.Contains(C))
                                                        {
                                                            student.Add(A);
                                                            blockboss.Add(C);
                                                        }
                                                        else if (student.Contains(A) && !blockboss.Contains(C))
                                                        {
                                                            blockboss.Add(C);
                                                        }
                                                        else if (!student.Contains(A) && blockboss.Contains(C))
                                                        {
                                                            student.Add(A);
                                                        }
                                                        List<Room> f = new List<Room>();
                                                        for (int i = 0; i < c; i++)
                                                        {
                                                            Console.WriteLine("Enter room number : ");
                                                            string t = Console.ReadLine();
                                                            if (int.TryParse(t, out int aa))
                                                            {
                                                                Console.WriteLine("Enter room floor : ");
                                                                string u = Console.ReadLine();
                                                                if (int.TryParse(u, out int bb))
                                                                {
                                                                    if (bb <= b && bb >= 0)
                                                                    {
                                                                        Room B = new Room(aa, bb, 6, null, null, a);
                                                                        if (f.Contains(B))
                                                                        {
                                                                            Console.WriteLine("This room has already been registered!");
                                                                            i--;
                                                                        }
                                                                        else
                                                                        {
                                                                            f.Add(B);
                                                                            Console.WriteLine("Room successfully added!");
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("This floor doesn't exist!");
                                                                        i--;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Error, try again!");
                                                                    i--;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Error, try again!");
                                                                i--;
                                                            }
                                                        }
                                                        G = new Block(a, b, c, d, h, f);
                                                        m.Turn(dorm, m);
                                                        if (!m.blocks.Contains(G))
                                                        {
                                                            m.blocks.Add(G);
                                                            dorm.Remove(m);
                                                            dorm.Add(m);
                                                        }
                                                        foreach (Room s in f)
                                                        {
                                                            if (!room.Contains(s))
                                                            {
                                                                room.Add(s);
                                                            }
                                                        }
                                                        block.Add(G);
                                                        Console.WriteLine("Block and rooms successfully added!");
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
                                    }
                                    else
                                    {
                                        Console.WriteLine("This dorm is full!");
                                    }
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
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Enter name : ");
                        p = Console.ReadLine();
                        if (int.TryParse(p, out a))
                        {
                            Console.WriteLine("Enter related dorm : ");
                            h = Console.ReadLine();
                            if (h != "")
                            {
                                g = new Block(a, 0, 0, null, h, null);
                                if (!block.Contains(g))
                                {
                                    Console.WriteLine("Block doesn't exist!");
                                }
                                else
                                {
                                    g.Turn(block, g);
                                    if (g.rooms != null)
                                    {
                                        foreach (Room v in g.rooms)
                                        {
                                            if (room.Contains(v))
                                            {
                                                room.Remove(v);
                                            }
                                        }
                                    }
                                    string[] gg = g.blockboss.Split(" and ");
                                    for (int i = 0; i < gg.Length; i++)
                                    {
                                        Blockboss b = new Blockboss(gg[i], null, null, null, null, 0, a, h, null, null);
                                        if (blockboss.Contains(b))
                                        {
                                            blockboss.Remove(b);
                                        }
                                    }
                                    m = new Dorm(h, null, 0, null, null);
                                    m.Turn(dorm, m);
                                    if (m.blocks.Contains(g))
                                    {
                                        m.blocks.Remove(g);
                                        dorm.Remove(m);
                                        dorm.Add(m);
                                    }
                                    block.Remove(g);
                                    Console.WriteLine("Block and rooms successfully removed!");
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
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Enter block number : ");
                        p = Console.ReadLine();
                        if (int.TryParse(p, out a))
                        {
                            Console.WriteLine("Enter related dorm : ");
                            h = Console.ReadLine();
                            if (h != "")
                            {
                                m = new Dorm(h, null, 0, null, null);
                                if (!dorm.Contains(m))
                                {
                                    Console.WriteLine("This dorm hasn't been registered!");
                                }
                                else
                                {
                                    m.Turn(dorm, m);
                                    int dc = 0;
                                    dc = m.capacity;
                                    Block G = new Block(a, 0, 0, null, h, null);
                                    if (block.Contains(G))
                                    {
                                        g = new Block(a, 0, 0, null, h, null);
                                        g.Turn(block, g);
                                        Console.WriteLine("Enter number of floors : ");
                                        string q = Console.ReadLine();
                                        if (int.TryParse(q, out int b))
                                        {
                                            Console.WriteLine("Enter number of rooms : ");
                                            string r = Console.ReadLine();
                                            if (int.TryParse(r, out int c))
                                            {
                                                Console.WriteLine("Enter blockbosse's fullname : ");
                                                string d = Console.ReadLine();
                                                if (d != "")
                                                {
                                                    Student A = new Student(d, null, null, null, null, 0, a, h, null);
                                                    Blockboss C = new Blockboss(d, null, null, null, null, 0, a, h, null, null);
                                                    if (!student.Contains(A))
                                                    {
                                                        Dorm D = new Dorm(h, null, 0, null, null);
                                                        D.Turn(dorm, D);
                                                        dc--;
                                                        D.capacity = dc;
                                                        dorm.Remove(D);
                                                        dorm.Add(D);
                                                    }
                                                    if (!student.Contains(A) && !blockboss.Contains(C))
                                                    {
                                                        student.Add(A);
                                                        blockboss.Add(C);
                                                    }
                                                    else if (student.Contains(A) && !blockboss.Contains(C))
                                                    {
                                                        blockboss.Add(C);
                                                    }
                                                    else if (!student.Contains(A) && blockboss.Contains(C))
                                                    {
                                                        student.Add(A);
                                                    }
                                                    List<Room> f = new List<Room>();
                                                    for (int i = 0; i < c; i++)
                                                    {
                                                        Console.WriteLine("Enter room number : ");
                                                        string t = Console.ReadLine();
                                                        if (int.TryParse(t, out int aa))
                                                        {
                                                            Console.WriteLine("Enter room floor : ");
                                                            string u = Console.ReadLine();
                                                            if (int.TryParse(u, out int bb))
                                                            {
                                                                if (bb <= b && bb >= 0)
                                                                {
                                                                    Room B = new Room(aa, bb, 6, null, null, a);
                                                                    if (f.Contains(B))
                                                                    {
                                                                        Console.WriteLine("This room has already been registered!");
                                                                        i--;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (g.rooms != null)
                                                                        {
                                                                            foreach (Room v in g.rooms)
                                                                            {
                                                                                if (room.Contains(v))
                                                                                {
                                                                                    room.Remove(v);
                                                                                }
                                                                            }
                                                                        }
                                                                        m = new Dorm(h, null, 0, null, null);
                                                                        m.Turn(dorm, m);
                                                                        if (m.blocks.Contains(g))
                                                                        {
                                                                            m.blocks.Remove(g);
                                                                            m.blocks.Add(g);
                                                                            dorm.Remove(m);
                                                                            dorm.Add(m);
                                                                        }
                                                                        block.Remove(g);
                                                                        f.Add(B);
                                                                        Console.WriteLine("Room successfully added!");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("This floor doesn't exist!");
                                                                    i--;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Error, try again!");
                                                                i--;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Error, try again!");
                                                            i--;
                                                        }
                                                    }
                                                    G = new Block(a, b, c, d, h, f);
                                                    m.Turn(dorm, m);
                                                    if (!m.blocks.Contains(G))
                                                    {
                                                        m.blocks.Add(G);
                                                        dorm.Remove(m);
                                                        dorm.Add(m);
                                                    }
                                                    foreach (Room s in f)
                                                    {
                                                        if (!room.Contains(s))
                                                        {
                                                            room.Add(s);
                                                        }
                                                    }
                                                    block.Add(G);
                                                    Console.WriteLine("Block and rooms successfully added!");
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
                                    else
                                    {
                                        Console.WriteLine("This block hasn't been registered!");
                                    }
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
        static void Personalmanagement(List<Student> student, List<Dormboss> dormboss, List<Blockboss> blockboss, List<Room> room, List<Dorm> dorm, List<Equipment> equipment, List<Block> block)
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
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                switch (x.KeyChar)
                {
                    case '1':
                        Dormboss(dormboss, dorm);
                        break;
                    case '2':
                        Blockboss(blockboss, student, room, dorm, block);
                        break;
                    case '3':
                        Student(student, blockboss, room, dorm, equipment, block);
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
        static void Dormboss(List<Dormboss> dormboss, List<Dorm> dorm)
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
                        Dorm h = new Dorm(null, null, 0, null, null);
                        Dormboss g = new Dormboss(null, null, null, null, null, null);
                        Console.WriteLine("Enter fullname : ");
                        string a = Console.ReadLine();
                        if (a != "")
                        {
                            g = new Dormboss(a, null, null, null, null, null);
                            if (dormboss.Contains(g))
                            {
                                Console.WriteLine("This dormboss is already registered!");
                            }
                            else
                            {
                                Console.WriteLine("Enter dorm name : ");
                                string f = Console.ReadLine();
                                if (f != "")
                                {
                                    h = new Dorm(f, null, 0, a, null);
                                    if (dorm.Contains(h))
                                    {
                                        Console.WriteLine("Enter personal id : ");
                                        string b = Console.ReadLine();
                                        if (b != "")
                                        {
                                            Console.WriteLine("Enter phone number :");
                                            string c = Console.ReadLine();
                                            if (c != "")
                                            {
                                                Console.WriteLine("Enter address : ");
                                                string d = Console.ReadLine();
                                                if (d != "")
                                                {
                                                    Console.WriteLine("Enter rank : ");
                                                    string e = Console.ReadLine();
                                                    if (e != "")
                                                    {
                                                        g = new Dormboss(a, b, c, d, e, f);
                                                        dormboss.Add(g);
                                                        h.name = f;
                                                        h.Turn(dorm, h);
                                                        if (h.dormboss == "dormboss has been removed!" || h.dormboss == null || h.dormboss == "")
                                                        {
                                                            h.dormboss = a;
                                                        }
                                                        else
                                                        {
                                                            a = " and " + a;
                                                            h.dormboss += a;
                                                        }
                                                        dorm.Remove(h);
                                                        dorm.Add(h);
                                                        Console.WriteLine("Dormboss successfully registered!");
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
                                        else
                                        {
                                            Console.WriteLine("Error, try again later!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("This dorm hasn,t been registered!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error, try again later!");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, try again later!");
                        }
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        string j = null;
                        Console.WriteLine("Enter fullname");
                        a = Console.ReadLine();
                        if (a != null)
                        {
                            g = new Dormboss(a, null, null, null, null, null);
                            if (!dormboss.Contains(g))
                            {
                                Console.WriteLine("Dormboss hasn't been registered!");
                            }
                            else
                            {
                                g.Turn(dormboss, g);
                                h = new Dorm(g.dorm, null, 0, a, null);
                                h.Turn(dorm, h);
                                if (h.dormboss.Contains(a))
                                {
                                    string i = $"{a} and";
                                    string k = $"and {a}";
                                    if (h.dormboss.Contains(i))
                                    {
                                        j = h.dormboss.Replace(i, "").Replace("  ", " ").Trim();
                                    }
                                    else if (h.dormboss.Contains(k))
                                    {
                                        j = h.dormboss.Replace(k, "").Replace("  ", " ").Trim();
                                    }
                                    else if (h.dormboss.Contains(a))
                                    {
                                        j = h.dormboss.Replace(a, "").Replace("  ", " ").Trim();
                                    }
                                }
                                if (j == "")
                                {
                                    j = h.dormboss = "dormboss has been removed!";
                                }
                                h.dormboss = j;
                                dorm.Remove(h);
                                dorm.Add(h);
                                dormboss.Remove(g);
                                Console.WriteLine("Dormboss successfully removed!");
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
                        Console.WriteLine("Enter fullname : ");
                        a = Console.ReadLine();
                        g = new Dormboss(a, null, null, null, null, null);
                        if (dormboss.Contains(g))
                        {
                            Console.WriteLine("Enter dorm name : ");
                            string f = Console.ReadLine();
                            if (f != "")
                            {
                                h = new Dorm(f, null, 0, a, null);
                                if (dorm.Contains(h))
                                {
                                    Console.WriteLine("Enter personal id : ");
                                    string b = Console.ReadLine();
                                    if (b != "")
                                    {
                                        Console.WriteLine("Enter phone number :");
                                        string c = Console.ReadLine();
                                        if (c != "")
                                        {
                                            Console.WriteLine("Enter address : ");
                                            string d = Console.ReadLine();
                                            if (d != "")
                                            {
                                                Console.WriteLine("Enter rank : ");
                                                string e = Console.ReadLine();
                                                if (e != "")
                                                {
                                                    g = new Dormboss(a, b, c, d, e, f);
                                                    dormboss.Remove(g);
                                                    dormboss.Add(g);
                                                    Console.WriteLine("Dormboss successfully changed!");
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
                                    else
                                    {
                                        Console.WriteLine("Error, try again later!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This dorm hasn,t been registered!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error, try again later!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("This dormboss hasn't been registered!");
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
        static void Blockboss(List<Blockboss> blockboss, List<Student> student, List<Room> room, List<Dorm> dorm, List<Block> block)
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
                        Blockboss A = new Blockboss(null, null, null, null, null, 0, 0, null, null, null);
                        Student B = new Student(null, null, null, null, null, 0, 0, null, null);
                        Console.WriteLine("Enter fullname : ");
                        string a = Console.ReadLine();
                        if (a != "")
                        {
                            A = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                            if (!blockboss.Contains(A))
                            {
                                Console.WriteLine("Enter personal id : ");
                                string b = Console.ReadLine();
                                if (b != "")
                                {
                                    Console.WriteLine("Enter phone number : ");
                                    string c = Console.ReadLine();
                                    if (c != "")
                                    {
                                        Console.WriteLine("Enter address : ");
                                        string d = Console.ReadLine();
                                        if (d != "")
                                        {
                                            Console.WriteLine("Enter student id : ");
                                            string e = Console.ReadLine();
                                            if (e != "")
                                            {
                                                Console.WriteLine("Enter stationary dorm : ");
                                                string f = Console.ReadLine();
                                                if (f != "")
                                                {
                                                    Dorm dd = new Dorm(f, null, 0, null, null);
                                                    if (dorm.Contains(dd))
                                                    {
                                                        dd.Turn(dorm, dd);
                                                        int dc = 0;
                                                        if (dd.capacity != 0)
                                                        {
                                                            dc = dd.capacity;
                                                            Console.WriteLine("Enter stationary block number : ");
                                                            string gg = Console.ReadLine();
                                                            if (int.TryParse(gg, out int g))
                                                            {
                                                                Console.WriteLine("Enter stationary room number : ");
                                                                string hh = Console.ReadLine();
                                                                if (int.TryParse(hh, out int h))
                                                                {
                                                                    Console.WriteLine("Enter stationary room floor : ");
                                                                    string ii = Console.ReadLine();
                                                                    if (int.TryParse(ii, out int i))
                                                                    {
                                                                        Room D = new Room(h, i, 6, null, null, g);
                                                                        if (room.Contains(D))
                                                                        {
                                                                            D.Turn(room, D);
                                                                            int k = 0;
                                                                            if (D.residentialstudents == null)
                                                                            {
                                                                                k = 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                k = D.residentialstudents.Count;
                                                                            }
                                                                            if (k < 6)
                                                                            {
                                                                                Console.WriteLine("Enter rank : ");
                                                                                string j = Console.ReadLine();
                                                                                if (j != "")
                                                                                {
                                                                                    List<Equipment> s = new List<Equipment>();
                                                                                    A = new Blockboss(a, b, c, d, e, h, g, f, s, j);
                                                                                    B = new Student(a, b, c, d, e, h, g, f, s);
                                                                                    List<string> t = new List<string>();
                                                                                    if (!student.Contains(B))
                                                                                    {
                                                                                        dc--;
                                                                                        student.Add(B);
                                                                                    }
                                                                                    dd.capacity = dc;
                                                                                    dorm.Remove(dd);
                                                                                    dorm.Add(dd);
                                                                                    if (D.residentialstudents != null)
                                                                                    {
                                                                                        t = D.residentialstudents;
                                                                                    }
                                                                                    t.Add(a);
                                                                                    D.residentialstudents = t;
                                                                                    room.Remove(D);
                                                                                    room.Add(D);
                                                                                    blockboss.Add(A);
                                                                                    Block E = new Block(g, 0, 0, null, f, null);
                                                                                    E.Turn(block, E);
                                                                                    if (E.blockboss == "Blockboss has been removed!" || E.blockboss == null || E.blockboss == "")
                                                                                    {
                                                                                        E.blockboss = a;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        a = " and " + a;
                                                                                        E.blockboss += a;
                                                                                    }
                                                                                    block.Remove(E);
                                                                                    block.Add(E);
                                                                                    Console.WriteLine("Blockboss successfully added!");
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("Error, try again later!");
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("This room is full!");
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("This room hasn't been registered!");
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
                                                            else
                                                            {
                                                                Console.WriteLine("Error, try again later!");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("This dorm is full!");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("This dorm hasn't been registered!");
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
                            else
                            {
                                Console.WriteLine("Blockboss has already been registered!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, try again later!");
                        }
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Enter fullname");
                        a = Console.ReadLine();
                        if (a != null)
                        {
                            Blockboss G = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                            G.Turn(blockboss, G);
                            if (!blockboss.Contains(G))
                            {
                                Console.WriteLine("Blockboss hasn't been registered!");
                            }
                            else
                            {
                                Block h = new Block(G.block, 0, 0, a, G.dorm, null);
                                h.Turn(block, h);
                                string j = h.blockboss;
                                if (j == null)
                                {
                                    j = h.blockboss = "Blockboss has been removed!";
                                }
                                else if (j.Contains(a))
                                {
                                    string i = $"{a} and";
                                    string k = $"and {a}";
                                    if (h.blockboss.Contains(i))
                                    {
                                        j = h.blockboss.Replace(i, "").Replace("  ", " ").Trim();
                                    }
                                    else if (h.blockboss.Contains(k))
                                    {
                                        j = h.blockboss.Replace(k, "").Replace("  ", " ").Trim();
                                    }
                                    else if (h.blockboss.Contains(a))
                                    {
                                        j = h.blockboss.Replace(a, "").Replace("  ", " ").Trim();
                                    }
                                }
                                if (j == "")
                                {
                                    j = h.blockboss = "Blockboss has been removed!";
                                }
                                h.blockboss = j;
                                block.Remove(h);
                                block.Add(h);
                                blockboss.Remove(G);
                                Console.WriteLine("Blockboss successfully removed!");
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
                        A = new Blockboss(null, null, null, null, null, 0, 0, null, null, null);
                        B = new Student(null, null, null, null, null, 0, 0, null, null);
                        Console.WriteLine("Enter fullname : ");
                        a = Console.ReadLine();
                        if (a != "")
                        {
                            A = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                            if (blockboss.Contains(A))
                            {
                                Console.WriteLine("Enter personal id : ");
                                string b = Console.ReadLine();
                                if (b != "")
                                {
                                    Console.WriteLine("Enter phone number : ");
                                    string c = Console.ReadLine();
                                    if (c != "")
                                    {
                                        Console.WriteLine("Enter address : ");
                                        string d = Console.ReadLine();
                                        if (d != "")
                                        {
                                            Console.WriteLine("Enter student id : ");
                                            string e = Console.ReadLine();
                                            if (e != "")
                                            {
                                                Console.WriteLine("Enter stationary dorm : ");
                                                string f = Console.ReadLine();
                                                if (f != "")
                                                {
                                                    Dorm dd = new Dorm(f, null, 0, null, null);
                                                    if (dorm.Contains(dd))
                                                    {
                                                        dd.Turn(dorm, dd);
                                                        int dc = 0;
                                                        if (dd.capacity != 0)
                                                        {
                                                            dc = dd.capacity;
                                                            Console.WriteLine("Enter stationary block number : ");
                                                            string gg = Console.ReadLine();
                                                            if (int.TryParse(gg, out int g))
                                                            {
                                                                Console.WriteLine("Enter stationary room number : ");
                                                                string hh = Console.ReadLine();
                                                                if (int.TryParse(hh, out int h))
                                                                {
                                                                    Console.WriteLine("Enter stationary room floor : ");
                                                                    string ii = Console.ReadLine();
                                                                    if (int.TryParse(ii, out int i))
                                                                    {
                                                                        Room D = new Room(h, i, 6, null, null, g);
                                                                        if (room.Contains(D))
                                                                        {
                                                                            D.Turn(room, D);
                                                                            int k = 0;
                                                                            if (D.residentialstudents == null)
                                                                            {
                                                                                k = 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                k = D.residentialstudents.Count;
                                                                            }
                                                                            if (k < 6)
                                                                            {
                                                                                Console.WriteLine("Enter rank : ");
                                                                                string j = Console.ReadLine();
                                                                                if (j != "")
                                                                                {
                                                                                    A.Turn(student, A);
                                                                                    string dn = A.dorm;
                                                                                    Dorm ddd = new Dorm(dn, null, 0, null, null);
                                                                                    ddd.Turn(dorm, ddd);
                                                                                    int ddc = ddd.capacity;
                                                                                    ddc++;
                                                                                    ddd.capacity = ddc;
                                                                                    dorm.Remove(ddd);
                                                                                    dorm.Add(ddd);
                                                                                    List<Equipment> s = new List<Equipment>();
                                                                                    A = new Blockboss(a, b, c, d, e, h, g, f, s, j);
                                                                                    B = new Student(a, b, c, d, e, h, g, f, s);
                                                                                    List<string> t = new List<string>();
                                                                                    dc--;
                                                                                    student.Remove(B);
                                                                                    student.Add(B);
                                                                                    dd.capacity = dc;
                                                                                    dorm.Remove(dd);
                                                                                    dorm.Add(dd);
                                                                                    if (D.residentialstudents != null)
                                                                                    {
                                                                                        t = D.residentialstudents;
                                                                                    }
                                                                                    t.Remove(a);
                                                                                    t.Add(a);
                                                                                    D.residentialstudents = t;
                                                                                    room.Remove(D);
                                                                                    D.residentialstudents.Remove(a);
                                                                                    D.residentialstudents.Add(a);
                                                                                    room.Add(D);
                                                                                    blockboss.Remove(A);
                                                                                    blockboss.Add(A);
                                                                                    Block E = new Block(g, 0, 0, null, f, null);
                                                                                    E.Turn(block, E);
                                                                                    Block H = E;
                                                                                    string l = H.blockboss;
                                                                                    if (l == null)
                                                                                    {
                                                                                        l = H.blockboss = "Blockboss has been removed!";
                                                                                    }
                                                                                    else if (l.Contains(a))
                                                                                    {
                                                                                        string m = $"{a} and";
                                                                                        string n = $"and {a}";
                                                                                        if (H.blockboss.Contains(m))
                                                                                        {
                                                                                            l = H.blockboss.Replace(m, "").Replace("  ", " ").Trim();
                                                                                        }
                                                                                        else if (H.blockboss.Contains(n))
                                                                                        {
                                                                                            l = H.blockboss.Replace(n, "").Replace("  ", " ").Trim();
                                                                                        }
                                                                                        else if (H.blockboss.Contains(a))
                                                                                        {
                                                                                            l = H.blockboss.Replace(a, "").Replace("  ", " ").Trim();
                                                                                        }
                                                                                    }
                                                                                    if (l == "")
                                                                                    {
                                                                                        l = H.blockboss = "Blockboss has been removed!";
                                                                                    }
                                                                                    H.blockboss = l;
                                                                                    block.Remove(H);
                                                                                    block.Add(H);
                                                                                    if (E.blockboss == "Blockboss has been removed!" || E.blockboss == null || E.blockboss == "")
                                                                                    {
                                                                                        E.blockboss = a;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        a = " and " + a;
                                                                                        E.blockboss += a;
                                                                                    }
                                                                                    block.Remove(E);
                                                                                    block.Add(E);
                                                                                    Console.WriteLine("Blockboss successfully changed!");
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("Error, try again later!");
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("This room is full!");
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("This room hasn't been registered!");
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
                                                            else
                                                            {
                                                                Console.WriteLine("Error, try again later!");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("This dorm is full!");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("This dorm hasn't been registered!");
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
                            else
                            {
                                Console.WriteLine("Blockboss hasn't been registered!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, try again later!");
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
                            foreach (Blockboss Boss in blockboss)
                            {
                                Boss.info();
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
        static void Student(List<Student> student, List<Blockboss> blockboss, List<Room> room, List<Dorm> dorm, List<Equipment> equipment, List<Block> block)
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
                        Student B = new Student(null, null, null, null, null, 0, 0, null, null);
                        Console.WriteLine("Enter fullname : ");
                        string a = Console.ReadLine();
                        if (a != "")
                        {
                            B = new Student(a, null, null, null, null, 0, 0, null, null);
                            if (!student.Contains(B))
                            {
                                Console.WriteLine("Enter personal id : ");
                                string b = Console.ReadLine();
                                if (b != "")
                                {
                                    Console.WriteLine("Enter phone number : ");
                                    string c = Console.ReadLine();
                                    if (c != "")
                                    {
                                        Console.WriteLine("Enter address : ");
                                        string d = Console.ReadLine();
                                        if (d != "")
                                        {
                                            Console.WriteLine("Enter student id : ");
                                            string e = Console.ReadLine();
                                            if (e != "")
                                            {
                                                Console.WriteLine("Enter stationary dorm : ");
                                                string f = Console.ReadLine();
                                                if (f != "")
                                                {
                                                    Dorm dd = new Dorm(f, null, 0, null, null);
                                                    if (dorm.Contains(dd))
                                                    {
                                                        dd.Turn(dorm, dd);
                                                        int dc = 0;
                                                        if (dd.capacity != 0)
                                                        {
                                                            dc = dd.capacity;
                                                            Console.WriteLine("Enter stationary block number : ");
                                                            string gg = Console.ReadLine();
                                                            if (int.TryParse(gg, out int g))
                                                            {
                                                                Console.WriteLine("Enter stationary room number : ");
                                                                string hh = Console.ReadLine();
                                                                if (int.TryParse(hh, out int h))
                                                                {
                                                                    Console.WriteLine("Enter stationary room floor : ");
                                                                    string ii = Console.ReadLine();
                                                                    if (int.TryParse(ii, out int i))
                                                                    {
                                                                        Room D = new Room(h, i, 6, null, null, g);
                                                                        if (room.Contains(D))
                                                                        {
                                                                            D.Turn(room, D);
                                                                            int k = 0;
                                                                            if (D.residentialstudents == null)
                                                                            {
                                                                                k = 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                k = D.residentialstudents.Count;
                                                                            }
                                                                            if (k < 6)
                                                                            {
                                                                                List<Equipment> s = new List<Equipment>();
                                                                                B = new Student(a, b, c, d, e, h, g, f, s);
                                                                                List<string> t = new List<string>();
                                                                                if (D.residentialstudents != null)
                                                                                {
                                                                                    t = D.residentialstudents;
                                                                                }
                                                                                t.Add(a);
                                                                                D.residentialstudents = t;
                                                                                room.Remove(D);
                                                                                room.Add(D);
                                                                                dc--;
                                                                                dd.capacity = dc;
                                                                                dorm.Remove(dd);
                                                                                dorm.Add(dd);
                                                                                student.Add(B);
                                                                                Console.WriteLine("Student successfully added!");
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("This room is full!");
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("This room hasn't been registered!");
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
                                                            else
                                                            {
                                                                Console.WriteLine("Error, try again later!");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("This dorm is full!");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("This dorm hasn't been registered!");
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
                            else
                            {
                                Console.WriteLine("Student has already been registered!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, try again later!");
                        }
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Enter fullname");
                        a = Console.ReadLine();
                        if (a != null)
                        {
                            B = new Student(a, null, null, null, null, 0, 0, null, null);
                            if (!student.Contains(B))
                            {
                                Console.WriteLine("Student hasn't been registered!");
                            }
                            else
                            {
                                B.Turn(student, B);
                                Blockboss G = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                                if (blockboss.Contains(G))
                                {
                                    blockboss.Remove(G);
                                    Block h = new Block(B.block, 0, 0, a, B.dorm, null);
                                    h.Turn(block, h);
                                    string j = h.blockboss;
                                    if (j == null)
                                    {
                                        j = h.blockboss = "Blockboss has been removed!";
                                    }
                                    else if (j.Contains(a))
                                    {
                                        string i = $"{a} and";
                                        string k = $"and {a}";
                                        if (h.blockboss.Contains(i))
                                        {
                                            j = h.blockboss.Replace(i, "").Replace("  ", " ").Trim();
                                        }
                                        else if (h.blockboss.Contains(k))
                                        {
                                            j = h.blockboss.Replace(k, "").Replace("  ", " ").Trim();
                                        }
                                        else if (h.blockboss.Contains(a))
                                        {
                                            j = h.blockboss.Replace(a, "").Replace("  ", " ").Trim();
                                        }
                                    }
                                    if (j == "")
                                    {
                                        j = h.blockboss = "Blockboss has been removed!";
                                    }
                                    h.blockboss = j;
                                    block.Remove(h);
                                    block.Add(h);
                                }
                                Room R = new Room(B.room, 0, 0, null, null, B.block);
                                if (room.Contains(R))
                                {
                                    R.Terminate(room, R, a);
                                }
                                if (B.personalequipments != null && B.personalequipments.Count != 0)
                                {
                                    foreach (Equipment equipment1 in B.personalequipments)
                                    {
                                        if (equipment.Contains(equipment1))
                                        {
                                            equipment.Remove(equipment1);
                                        }
                                    }
                                }
                                B.Turn(student, B);
                                string dn = B.dorm;
                                Dorm ddd = new Dorm(dn, null, 0, null, null);
                                ddd.Turn(dorm, ddd);
                                int ddc = ddd.capacity;
                                ddc++;
                                ddd.capacity = ddc;
                                dorm.Remove(ddd);
                                dorm.Add(ddd);
                                student.Remove(B);
                                Console.WriteLine("Student successfully removed!");
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
                        B = new Student(null, null, null, null, null, 0, 0, null, null);
                        Console.WriteLine("Enter fullname : ");
                        a = Console.ReadLine();
                        if (a != "")
                        {
                            B = new Student(a, null, null, null, null, 0, 0, null, null);
                            if (student.Contains(B))
                            {
                                Console.WriteLine("Enter personal id : ");
                                string b = Console.ReadLine();
                                if (b != "")
                                {
                                    Console.WriteLine("Enter phone number : ");
                                    string c = Console.ReadLine();
                                    if (c != "")
                                    {
                                        Console.WriteLine("Enter address : ");
                                        string d = Console.ReadLine();
                                        if (d != "")
                                        {
                                            Console.WriteLine("Enter student id : ");
                                            string e = Console.ReadLine();
                                            if (e != "")
                                            {
                                                Blockboss G = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                                                if (blockboss.Contains(G))
                                                {
                                                    G.Turn(blockboss, G);
                                                    G.id = b;
                                                    G.phonenumber = c;
                                                    G.address = d;
                                                    G.studentid = e;
                                                    blockboss.Remove(G);
                                                    blockboss.Add(G);
                                                }
                                                Student C = new Student(a, null, null, null, null, 0, 0, null, null);
                                                C.Turn(student, C);
                                                B = new Student(a, b, c, d, e, C.room, C.block, C.dorm, C.personalequipments);
                                                student.Remove(B);
                                                student.Add(B);
                                                Console.WriteLine("Student successfully changed!");
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
                                else
                                {
                                    Console.WriteLine("Error, try again later!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Student hasn't been registered!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, try again later!");
                        }
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.Clear();
                        Console.WriteLine("Enter fullname : ");
                        a = Console.ReadLine();
                        if (a != "")
                        {
                            B = new Student(a, null, null, null, null, 0, 0, null, null);
                            if (student.Contains(B))
                            {
                                B.Find(student, B);
                            }
                            else
                            {
                                Console.WriteLine("This student hasn't been registered!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, try again later!");
                        }
                        Console.ReadKey();
                        break;
                    case '5':
                        Console.Clear();
                        if (student.Count == 0)
                        {
                            Console.WriteLine("There are no registered students!");
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
                        Console.WriteLine("Enter fullname : ");
                        a = Console.ReadLine();
                        if (a != "")
                        {
                            B = new Student(a, null, null, null, null, 0, 0, null, null);
                            if (student.Contains(B))
                            {
                                Console.WriteLine("Enter new dorm : ");
                                string b = Console.ReadLine();
                                if (b != "")
                                {
                                    Dorm D = new Dorm(b, null, 0, null, null);
                                    if (dorm.Contains(D))
                                    {
                                        D.Turn(dorm, D);
                                        int dc = 0;
                                        if (D.capacity != 0)
                                        {
                                            dc = D.capacity;
                                            Console.WriteLine("Enter new block number : ");
                                            string gg = Console.ReadLine();
                                            if (int.TryParse(gg, out int g))
                                            {
                                                Block H = new Block(g, 0, 0, null, b, null);
                                                if (block.Contains(H))
                                                {
                                                    Console.WriteLine("Enter new room number : ");
                                                    string hh = Console.ReadLine();
                                                    if (int.TryParse(hh, out int h))
                                                    {
                                                        Console.WriteLine("Enter new room floor : ");
                                                        string ii = Console.ReadLine();
                                                        if (int.TryParse(ii, out int i))
                                                        {
                                                            Room E = new Room(h, i, 6, null, null, g);
                                                            if (room.Contains(E))
                                                            {
                                                                int k = 0;
                                                                if (E.residentialstudents == null)
                                                                {
                                                                    k = 0;
                                                                }
                                                                else
                                                                {
                                                                    k = E.residentialstudents.Count;
                                                                }
                                                                if (k < 6)
                                                                {
                                                                    B.Turn(student, B);
                                                                    string dn = B.dorm;
                                                                    Dorm ddd = new Dorm(dn, null, 0, null, null);
                                                                    ddd.Turn(dorm, ddd);
                                                                    int ddc = ddd.capacity;
                                                                    ddc++;
                                                                    ddd.capacity = ddc;
                                                                    dorm.Remove(ddd);
                                                                    dorm.Add(ddd);
                                                                    dc--;
                                                                    D.capacity = dc;
                                                                    dorm.Remove(D);
                                                                    dorm.Add(D);
                                                                    E.Turn(room, E);
                                                                    Student F = B;
                                                                    F.Turn(student, F);
                                                                    Blockboss G = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                                                                    if (blockboss.Contains(G))
                                                                    {
                                                                        blockboss.Remove(G);
                                                                        Block X = new Block(F.block, 0, 0, a, F.dorm, null);
                                                                        H.Turn(block, H);
                                                                        string j = X.blockboss;
                                                                        if (j == null)
                                                                        {
                                                                            j = X.blockboss = "Blockboss has been removed!";
                                                                        }
                                                                        else if (j.Contains(a))
                                                                        {
                                                                            string Y = $"{a} and";
                                                                            string Z = $"and {a}";
                                                                            if (X.blockboss.Contains(Y))
                                                                            {
                                                                                j = X.blockboss.Replace(Y, "").Replace("  ", " ").Trim();
                                                                            }
                                                                            else if (X.blockboss.Contains(Z))
                                                                            {
                                                                                j = X.blockboss.Replace(Z, "").Replace("  ", " ").Trim();
                                                                            }
                                                                            else if (X.blockboss.Contains(a))
                                                                            {
                                                                                j = X.blockboss.Replace(a, "").Replace("  ", " ").Trim();
                                                                            }
                                                                        }
                                                                        if (j == "")
                                                                        {
                                                                            j = X.blockboss = "Blockboss has been removed!";
                                                                        }
                                                                        X.blockboss = j;
                                                                        block.Remove(X);
                                                                        block.Add(X);
                                                                    }
                                                                    Room R = new Room(F.room, 0, 0, null, null, F.block);
                                                                    if (room.Contains(R))
                                                                    {
                                                                        R.Terminate(room, R, a);
                                                                    }
                                                                    if (F.personalequipments != null && F.personalequipments.Count != 0)
                                                                    {
                                                                        foreach (Equipment equipment1 in F.personalequipments)
                                                                        {
                                                                            if (equipment.Contains(equipment1))
                                                                            {
                                                                                equipment.Remove(equipment1);
                                                                            }
                                                                        }
                                                                    }
                                                                    B = new Student(a, F.id, F.phonenumber, F.address, F.studentid, h, g, b, F.personalequipments);
                                                                    List<string> t = new List<string>();
                                                                    student.Remove(B);
                                                                    student.Add(B);
                                                                    if (E.residentialstudents != null)
                                                                    {
                                                                        t = E.residentialstudents;
                                                                    }
                                                                    t.Add(a);
                                                                    E.residentialstudents = t;
                                                                    room.Remove(E);
                                                                    room.Add(E);
                                                                    Console.WriteLine("Student dorm successfully changed!");
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("This room is full!");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("This room hasn't been registered!");
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
                                                else
                                                {
                                                    Console.WriteLine("Error, try again later!");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("This block hasn't been registered!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("This dorm is full!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("This dorm hasn't been registered!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error, try again later!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("This student hasn't been registered!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, try again later!");
                        }
                        Console.ReadKey();
                        break;
                    case '7':
                        Console.Clear();
                        Change(student, room, dorm, block, blockboss, equipment);
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
        static void Change(List<Student> student, List<Room> room, List<Dorm> dorm, List<Block> block, List<Blockboss> blockboss, List<Equipment> equipment)
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
                        Console.WriteLine("Enter fullname : ");
                        string a = Console.ReadLine();
                        if (a != "")
                        {
                            Student B = new Student(a, null, null, null, null, 0, 0, null, null);
                            if (student.Contains(B))
                            {
                                Console.WriteLine("Enter new dorm : ");
                                string b = Console.ReadLine();
                                if (b != "")
                                {
                                    Dorm D = new Dorm(b, null, 0, null, null);
                                    if (dorm.Contains(D))
                                    {
                                        D.Turn(dorm, D);
                                        int dc = 0;
                                        if (D.capacity != 0)
                                        {
                                            dc = D.capacity;
                                            Console.WriteLine("Enter new block number : ");
                                            string gg = Console.ReadLine();
                                            if (int.TryParse(gg, out int g))
                                            {
                                                Block H = new Block(g, 0, 0, null, b, null);
                                                if (block.Contains(H))
                                                {
                                                    Console.WriteLine("Enter new room number : ");
                                                    string hh = Console.ReadLine();
                                                    if (int.TryParse(hh, out int h))
                                                    {
                                                        Console.WriteLine("Enter new room floor : ");
                                                        string ii = Console.ReadLine();
                                                        if (int.TryParse(ii, out int i))
                                                        {
                                                            Room E = new Room(h, i, 6, null, null, g);
                                                            if (room.Contains(E))
                                                            {
                                                                int k = 0;
                                                                if (E.residentialstudents == null)
                                                                {
                                                                    k = 0;
                                                                }
                                                                else
                                                                {
                                                                    k = E.residentialstudents.Count;
                                                                }
                                                                if (k < 6)
                                                                {
                                                                    B.Turn(student, B);
                                                                    string dn = B.dorm;
                                                                    Dorm ddd = new Dorm(dn, null, 0, null, null);
                                                                    ddd.Turn(dorm, ddd);
                                                                    int ddc = ddd.capacity;
                                                                    ddc++;
                                                                    ddd.capacity = ddc;
                                                                    dorm.Remove(ddd);
                                                                    dorm.Add(ddd);
                                                                    dc--;
                                                                    D.capacity = dc;
                                                                    dorm.Remove(D);
                                                                    dorm.Add(D);
                                                                    E.Turn(room, E);
                                                                    Student F = B;
                                                                    F.Turn(student, F);
                                                                    Blockboss G = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                                                                    if (blockboss.Contains(G))
                                                                    {
                                                                        blockboss.Remove(G);
                                                                        Block X = new Block(F.block, 0, 0, a, F.dorm, null);
                                                                        H.Turn(block, H);
                                                                        string j = X.blockboss;
                                                                        if (j == null)
                                                                        {
                                                                            j = X.blockboss = "Blockboss has been removed!";
                                                                        }
                                                                        else if (j.Contains(a))
                                                                        {
                                                                            string Y = $"{a} and";
                                                                            string Z = $"and {a}";
                                                                            if (X.blockboss.Contains(Y))
                                                                            {
                                                                                j = X.blockboss.Replace(Y, "").Replace("  ", " ").Trim();
                                                                            }
                                                                            else if (X.blockboss.Contains(Z))
                                                                            {
                                                                                j = X.blockboss.Replace(Z, "").Replace("  ", " ").Trim();
                                                                            }
                                                                            else if (X.blockboss.Contains(a))
                                                                            {
                                                                                j = X.blockboss.Replace(a, "").Replace("  ", " ").Trim();
                                                                            }
                                                                        }
                                                                        if (j == "")
                                                                        {
                                                                            j = X.blockboss = "Blockboss has been removed!";
                                                                        }
                                                                        X.blockboss = j;
                                                                        block.Remove(X);
                                                                        block.Add(X);
                                                                    }
                                                                    Room R = new Room(F.room, 0, 0, null, null, F.block);
                                                                    if (room.Contains(R))
                                                                    {
                                                                        R.Terminate(room, R, a);
                                                                    }
                                                                    if (F.personalequipments != null && F.personalequipments.Count != 0)
                                                                    {
                                                                        foreach (Equipment equipment1 in F.personalequipments)
                                                                        {
                                                                            if (equipment.Contains(equipment1))
                                                                            {
                                                                                equipment.Remove(equipment1);
                                                                            }
                                                                        }
                                                                    }
                                                                    B = new Student(a, F.id, F.phonenumber, F.address, F.studentid, h, g, b, F.personalequipments);
                                                                    List<string> t = new List<string>();
                                                                    student.Remove(B);
                                                                    student.Add(B);
                                                                    if (E.residentialstudents != null)
                                                                    {
                                                                        t = E.residentialstudents;
                                                                    }
                                                                    t.Add(a);
                                                                    E.residentialstudents = t;
                                                                    room.Remove(E);
                                                                    room.Add(E);
                                                                    Console.WriteLine("Student dorm successfully changed!");
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("This room is full!");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("This room hasn't been registered!");
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
                                                else
                                                {
                                                    Console.WriteLine("Error, try again later!");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("This block hasn't been registered!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("This dorm is full!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("This dorm hasn't been registered!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error, try again later!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("This student hasn't been registered!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, try again later!");
                        }
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Enter fullname : ");
                        a = Console.ReadLine();
                        if (a != "")
                        {
                            Student B = new Student(a, null, null, null, null, 0, 0, null, null);
                            if (student.Contains(B))
                            {
                                Student MM = B;
                                MM.Turn(student, MM);
                                Console.WriteLine("Enter new block number : ");
                                string gg = Console.ReadLine();
                                if (int.TryParse(gg, out int g))
                                {
                                    Block H = new Block(g, 0, 0, null, MM.dorm, null);
                                    if (block.Contains(H))
                                    {
                                        Console.WriteLine("Enter new room number : ");
                                        string hh = Console.ReadLine();
                                        if (int.TryParse(hh, out int h))
                                        {
                                            Console.WriteLine("Enter new room floor : ");
                                            string ii = Console.ReadLine();
                                            if (int.TryParse(ii, out int i))
                                            {
                                                Room E = new Room(h, i, 6, null, null, g);
                                                if (room.Contains(E))
                                                {
                                                    int k = 0;
                                                    if (E.residentialstudents == null)
                                                    {
                                                        k = 0;
                                                    }
                                                    else
                                                    {
                                                        k = E.residentialstudents.Count;
                                                    }
                                                    if (k < 6)
                                                    {
                                                        E.Turn(room, E);
                                                        Student F = B;
                                                        F.Turn(student, F);
                                                        Blockboss G = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                                                        if (blockboss.Contains(G))
                                                        {
                                                            blockboss.Remove(G);
                                                            Block X = new Block(F.block, 0, 0, a, F.dorm, null);
                                                            H.Turn(block, H);
                                                            string j = X.blockboss;
                                                            if (j == null)
                                                            {
                                                                j = X.blockboss = "Blockboss has been removed!";
                                                            }
                                                            else if (j.Contains(a))
                                                            {
                                                                string Y = $"{a} and";
                                                                string Z = $"and {a}";
                                                                if (X.blockboss.Contains(Y))
                                                                {
                                                                    j = X.blockboss.Replace(Y, "").Replace("  ", " ").Trim();
                                                                }
                                                                else if (X.blockboss.Contains(Z))
                                                                {
                                                                    j = X.blockboss.Replace(Z, "").Replace("  ", " ").Trim();
                                                                }
                                                                else if (X.blockboss.Contains(a))
                                                                {
                                                                    j = X.blockboss.Replace(a, "").Replace("  ", " ").Trim();
                                                                }
                                                            }
                                                            if (j == "")
                                                            {
                                                                j = X.blockboss = "Blockboss has been removed!";
                                                            }
                                                            X.blockboss = j;
                                                            block.Remove(X);
                                                            block.Add(X);
                                                        }
                                                        Room R = new Room(F.room, 0, 0, null, null, F.block);
                                                        if (room.Contains(R))
                                                        {
                                                            R.Terminate(room, R, a);
                                                        }
                                                        if (F.personalequipments != null && F.personalequipments.Count != 0)
                                                        {
                                                            foreach (Equipment equipment1 in F.personalequipments)
                                                            {
                                                                if (equipment.Contains(equipment1))
                                                                {
                                                                    equipment.Remove(equipment1);
                                                                }
                                                            }
                                                        }
                                                        B = new Student(a, F.id, F.phonenumber, F.address, F.studentid, h, g, MM.dorm, F.personalequipments);
                                                        List<string> t = new List<string>();
                                                        student.Remove(B);
                                                        student.Add(B);
                                                        if (E.residentialstudents != null)
                                                        {
                                                            t = E.residentialstudents;
                                                        }
                                                        t.Add(a);
                                                        E.residentialstudents = t;
                                                        room.Remove(E);
                                                        room.Add(E);
                                                        Console.WriteLine("Student block successfully changed!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("This room is full!");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("This room hasn't been registered!");
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
                                    else
                                    {
                                        Console.WriteLine("Error, try again later!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This block hasn't been registered!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("This student hasn't been registered!");
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
                        Console.WriteLine("Enter fullname : ");
                        a = Console.ReadLine();
                        if (a != "")
                        {
                            Student B = new Student(a, null, null, null, null, 0, 0, null, null);
                            if (student.Contains(B))
                            {
                                Student MM = B;
                                MM.Turn(student, MM);
                                Console.WriteLine("Enter new room number : ");
                                string hh = Console.ReadLine();
                                if (int.TryParse(hh, out int h))
                                {
                                    Console.WriteLine("Enter new room floor : ");
                                    string ii = Console.ReadLine();
                                    if (int.TryParse(ii, out int i))
                                    {
                                        Room E = new Room(h, i, 6, null, null, MM.block);
                                        if (room.Contains(E))
                                        {
                                            int k = 0;
                                            if (E.residentialstudents == null)
                                            {
                                                k = 0;
                                            }
                                            else
                                            {
                                                k = E.residentialstudents.Count;
                                            }
                                            if (k < 6)
                                            {
                                                E.Turn(room, E);
                                                Student F = B;
                                                F.Turn(student, F);
                                                Room R = new Room(F.room, 0, 0, null, null, F.block);
                                                if (room.Contains(R))
                                                {
                                                    R.Terminate(room, R, a);
                                                }
                                                if (F.personalequipments != null && F.personalequipments.Count != 0)
                                                {
                                                    foreach (Equipment equipment1 in F.personalequipments)
                                                    {
                                                        if (equipment.Contains(equipment1))
                                                        {
                                                            equipment.Remove(equipment1);
                                                        }
                                                    }
                                                }
                                                B = new Student(a, F.id, F.phonenumber, F.address, F.studentid, h, MM.block, MM.dorm, F.personalequipments);
                                                List<string> t = new List<string>();
                                                student.Remove(B);
                                                student.Add(B);
                                                if (E.residentialstudents != null)
                                                {
                                                    t = E.residentialstudents;
                                                }
                                                t.Add(a);
                                                E.residentialstudents = t;
                                                room.Remove(E);
                                                room.Add(E);
                                                Console.WriteLine("Student room successfully changed!");
                                            }
                                            else
                                            {
                                                Console.WriteLine("This room is full!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("This room hasn't been registered!");
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
                            else
                            {
                                Console.WriteLine("This student hasn't been registered!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, try again later!");
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
        static void Belongingsmanagement(List<Equipment> equipment, List<Room> room, List<Student> student, List<Blockboss> blockboss)
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
                        Equipment A = new Equipment(null, 0, null, null, 0, null);
                        Console.WriteLine("Enter belonging's name : ");
                        string a = Console.ReadLine();
                        if (a != "")
                        {
                            Console.WriteLine("Enter belonging's part number : ");
                            string bb = Console.ReadLine();
                            if (int.TryParse(bb, out int b))
                            {
                                Console.WriteLine("Enter belonging's id : ");
                                string c = Console.ReadLine();
                                if (c != "")
                                {
                                    Console.WriteLine("Choose belonging's status : ");
                                    Console.WriteLine("1.ok.");
                                    Console.WriteLine("2.broken.");
                                    string d = null;
                                    while (true)
                                    {
                                        var e = Console.ReadKey();
                                        Console.WriteLine();
                                        if (e.KeyChar == '1')
                                        {
                                            d = "ok";
                                            break;
                                        }
                                        else if (e.KeyChar == '2')
                                        {
                                            d = "broken";
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("try again!");
                                        }
                                    }
                                    A = new Equipment(a, b, c, d, 0, null);
                                    if (!equipment.Contains(A))
                                    {
                                        equipment.Add(A);
                                        Console.WriteLine("Equipment successfully added!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("This equipment has already been registered!");
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
                        else
                        {
                            Console.WriteLine("Error, try again later!");
                        }
                        Console.ReadKey();
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
                        A = new Equipment(null, 0, null, null, 0, null);
                        Room B = new Room(0, 0, 6, null, null, 0);
                        Room C = new Room(0, 0, 6, null, null, 0);
                        Console.WriteLine("Enter belonging's name : ");
                        a = Console.ReadLine();
                        if (a != "")
                        {
                            Console.WriteLine("Enter belonging's part number : ");
                            string bb = Console.ReadLine();
                            if (int.TryParse(bb, out int b))
                            {
                                Console.WriteLine("Enter belonging's id : ");
                                string c = Console.ReadLine();
                                if (c != "")
                                {
                                    A = new Equipment(a, b, c, null, 0, null);
                                    if (equipment.Contains(A))
                                    {
                                        A.Turn(equipment, A);
                                        Console.WriteLine("Enter room's number : ");
                                        string dd = Console.ReadLine();
                                        if (int.TryParse(dd, out int d))
                                        {
                                            Console.WriteLine("Enter room's floor : ");
                                            string ee = Console.ReadLine();
                                            if (int.TryParse(ee, out int e))
                                            {
                                                Console.WriteLine("Enter room's block : ");
                                                string ff = Console.ReadLine();
                                                if (int.TryParse(ff, out int f))
                                                {
                                                    B = new Room(d, e, 6, null, null, f);
                                                    if (room.Contains(B))
                                                    {
                                                        C = new Room(A.room % 10, (A.room / 10) % 10, 6, null, null, A.room / 100);
                                                        if (room.Contains(C))
                                                        {
                                                            C.Turn(room, C);
                                                            List<string> k = new List<string>();
                                                            if (C.equipments != null)
                                                            {
                                                                k = C.equipments;
                                                            }
                                                            string j = a + "|" + b + "|" + c;
                                                            k.Remove(j);
                                                            C.equipments = k;
                                                            room.Remove(C);
                                                            room.Add(C);
                                                        }
                                                        B.Turn(room, B);
                                                        List<string> g = new List<string>();
                                                        if (B.equipments != null)
                                                        {
                                                            g = B.equipments;
                                                        }
                                                        string h = a + "|" + b + "|" + c;
                                                        g.Add(h);
                                                        B.equipments = g;
                                                        room.Remove(B);
                                                        room.Add(B);
                                                        int i = f * 100 + e * 10 + d;
                                                        A.room = i;
                                                        equipment.Remove(A);
                                                        equipment.Add(A);
                                                        Console.WriteLine("Belonging successfully assigned to a room!");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("This room hasn't been registered!");
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
                                        else
                                        {
                                            Console.WriteLine("Error, try again later!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("This belonging hasn't been registered!");
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
                        else
                        {
                            Console.WriteLine("Error, try again later!");
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
                        Console.WriteLine("Enter the belonging's details that you want to assign to an owner(student) : ");
                        Console.WriteLine();
                        A = new Equipment(null, 0, null, null, 0, null);
                        Student D = new Student(null, null, null, null, null, 0, 0, null, null);
                        Blockboss E = new Blockboss(null, null, null, null, null, 0, 0, null, null, null);
                        Console.WriteLine("Enter belonging's name : ");
                        a = Console.ReadLine();
                        if (a != "")
                        {
                            Console.WriteLine("Enter belonging's part number : ");
                            string bb = Console.ReadLine();
                            if (int.TryParse(bb, out int b))
                            {
                                Console.WriteLine("Enter belonging's id : ");
                                string c = Console.ReadLine();
                                if (c != "")
                                {
                                    A = new Equipment(a, b, c, null, 0, null);
                                    if (equipment.Contains(A))
                                    {
                                        A.Turn(equipment, A);
                                        Console.WriteLine("Enter student's fullname : ");
                                        string d = Console.ReadLine();
                                        if (d != "")
                                        {
                                            D = new Student(d, null, null, null, null, 0, 0, null, null);
                                            if (student.Contains(D))
                                            {
                                                A.student = a;
                                                equipment.Remove(A);
                                                equipment.Add(A);
                                                D.Turn(student, D);
                                                List<Equipment> e = new List<Equipment>();
                                                if (D.personalequipments != null)
                                                {
                                                    e = D.personalequipments;
                                                }
                                                e.Add(A);
                                                D.personalequipments = e;
                                                student.Remove(D);
                                                student.Add(D);
                                                E = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                                                if (blockboss.Contains(E))
                                                {
                                                    E.Turn(blockboss, E);
                                                    E.personalequipments = e;
                                                    blockboss.Remove(E);
                                                    blockboss.Add(E);
                                                }
                                                Console.WriteLine("Belonging successfully assigned to a student!");
                                            }
                                            else
                                            {
                                                Console.WriteLine("This student hasn't been registered!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error, try again later!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("This belonging hasn't been registered!");
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
                        else
                        {
                            Console.WriteLine("Error, try again later!");
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
                        A = new Equipment(null, 0, null, null, 0, null);
                        D = new Student(null, null, null, null, null, 0, 0, null, null);
                        E = new Blockboss(null, null, null, null, null, 0, 0, null, null, null);
                        Student F = new Student(null, null, null, null, null, 0, 0, null, null);
                        Blockboss G = new Blockboss(null, null, null, null, null, 0, 0, null, null, null);
                        Console.WriteLine("Enter belonging's name : ");
                        a = Console.ReadLine();
                        if (a != "")
                        {
                            Console.WriteLine("Enter belonging's part number : ");
                            string bb = Console.ReadLine();
                            if (int.TryParse(bb, out int b))
                            {
                                Console.WriteLine("Enter belonging's id : ");
                                string c = Console.ReadLine();
                                if (c != "")
                                {
                                    A = new Equipment(a, b, c, null, 0, null);
                                    if (equipment.Contains(A))
                                    {
                                        A.Turn(equipment, A);
                                        Console.WriteLine("Enter student's fullname : ");
                                        string d = Console.ReadLine();
                                        if (d != "")
                                        {
                                            D = new Student(d, null, null, null, null, 0, 0, null, null);
                                            if (student.Contains(D))
                                            {
                                                F = new Student(A.student, null, null, null, null, 0, 0, null, null);
                                                F.Turn(student, F);
                                                List<Equipment> f = new List<Equipment>();
                                                if (F.personalequipments != null)
                                                {
                                                    f = F.personalequipments;
                                                }
                                                f.Remove(A);
                                                F.personalequipments = f;
                                                student.Remove(F);
                                                student.Add(F);
                                                E = new Blockboss(A.student, null, null, null, null, 0, 0, null, null, null);
                                                if (blockboss.Contains(G))
                                                {
                                                    G.Turn(blockboss, G);
                                                    G.personalequipments = f;
                                                    blockboss.Remove(G);
                                                    blockboss.Add(G);
                                                }
                                                A.student = a;
                                                equipment.Remove(A);
                                                equipment.Add(A);
                                                D.Turn(student, D);
                                                List<Equipment> e = new List<Equipment>();
                                                if (D.personalequipments != null)
                                                {
                                                    e = D.personalequipments;
                                                }
                                                e.Add(A);
                                                D.personalequipments = e;
                                                student.Remove(D);
                                                student.Add(D);
                                                E = new Blockboss(a, null, null, null, null, 0, 0, null, null, null);
                                                if (blockboss.Contains(E))
                                                {
                                                    E.Turn(blockboss, E);
                                                    E.personalequipments = e;
                                                    blockboss.Remove(E);
                                                    blockboss.Add(E);
                                                }
                                                Console.WriteLine("Belonging successfully reassigned to another student!");
                                            }
                                            else
                                            {
                                                Console.WriteLine("This student hasn't been registered!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error, try again later!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("This belonging hasn't been registered!");
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
                        else
                        {
                            Console.WriteLine("Error, try again later!");
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
                        A = new Equipment(null, 0, null, null, 0, null);
                        Console.WriteLine("Enter belonging's name : ");
                        a = Console.ReadLine();
                        if (a != "")
                        {
                            Console.WriteLine("Enter belonging's part number : ");
                            string bb = Console.ReadLine();
                            if (int.TryParse(bb, out int b))
                            {
                                Console.WriteLine("Enter belonging's id : ");
                                string c = Console.ReadLine();
                                if (c != "")
                                {
                                    A = new Equipment(a, b, c, null, 0, null);
                                    if (equipment.Contains(A))
                                    {
                                        A.Turn(equipment, A);
                                        Console.WriteLine("Choose belonging's new status : ");
                                        Console.WriteLine("1.ok.");
                                        Console.WriteLine("2.broken.");
                                        string d = null;
                                        while (true)
                                        {
                                            var e = Console.ReadKey();
                                            Console.WriteLine();
                                            if (e.KeyChar == '1')
                                            {
                                                d = "ok";
                                                break;
                                            }
                                            else if (e.KeyChar == '2')
                                            {
                                                d = "broken";
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("try again!");
                                            }
                                        }
                                        A.status = d;
                                        equipment.Remove(A);
                                        equipment.Add(A);
                                        Console.WriteLine($"Belonging is now considered {d}!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("This belonging hasn't been registered!");
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
                        else
                        {
                            Console.WriteLine("Error, try again later!");
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
        static void Viewreport(List<Dorm> dorm, List<Block> block, List<Room> room, List<Equipment> equipment, List<Dormboss> dormboss, List<Student> student, List<Blockboss> blockboss)
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
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                switch (x.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Stationary students list : ");
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
                        Console.WriteLine("Registered rooms list : ");
                        Console.WriteLine();
                        if (room.Count != 0)
                        {
                            foreach (Room s in room)
                            {
                                s.info();
                                if (s.residentialstudents == null || s.residentialstudents.Count == 0)
                                {
                                    Console.WriteLine("This room is empty!");
                                }
                                else if (s.residentialstudents.Count == 6)
                                {
                                    Console.WriteLine("This room is full!");
                                }
                                else if (s.residentialstudents.Count < 6 && s.residentialstudents.Count > 0)
                                {
                                    Console.WriteLine("This room is available!");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no registered rooms!");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Every dorm's remaining capacities : ");
                        Console.WriteLine();
                        if (dorm.Count != 0)
                        {
                            foreach (Dorm d in dorm)
                            {
                                Console.WriteLine($" | dorm : {d.name} | remaining capacity : {d.capacity} |");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no registered dorms!");
                        }
                        Console.WriteLine();
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Belongings list : ");
                        Console.WriteLine();
                        if (equipment.Count != 0)
                        {
                            foreach (Equipment d in equipment)
                            {
                                d.info();
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no registered belongings!");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Every room's belongings : ");
                        Console.WriteLine();
                        if (room.Count != 0)
                        {
                            foreach (Room r in room)
                            {
                                Console.WriteLine($" | room : {r.number} | ");
                                if (r.equipments != null)
                                {
                                    foreach (string s in r.equipments)
                                    {
                                        Console.WriteLine($" | {s} | ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There are no registered belongings in this room!");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no registered rooms!");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Every student's belongings : ");
                        Console.WriteLine();
                        if (student.Count != 0)
                        {
                            foreach (Student t in student)
                            {
                                List<Equipment> equipmentslist = t.personalequipments;
                                Console.WriteLine($" | student : {t.fullname} | ");
                                if (equipmentslist != null)
                                {
                                    foreach (Equipment s in t.personalequipments)
                                    {
                                        Console.WriteLine($" | {s.belonging} | {s.number} | {s.belongingid} | ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There are no registered belongings for this student!");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no registered students!");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Every belonging that needs to be repaired : ");
                        Console.WriteLine();
                        int a = 0;
                        foreach (Equipment e in equipment)
                        {
                            if (e.status == "broken")
                            {
                                a++;
                            }
                        }
                        if (a != 0)
                        {
                            foreach (Equipment e in equipment)
                            {
                                if (e.status == "broken")
                                {
                                    e.info();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no equipments that need repair!");
                        }
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Every belonging that needs to be repaired : ");
                        Console.WriteLine();
                        a = 0;
                        foreach (Equipment e in equipment)
                        {
                            if (e.status == "broken")
                            {
                                a++;
                            }
                        }
                        if (a != 0)
                        {
                            foreach (Equipment e in equipment)
                            {
                                if (e.status == "broken")
                                {
                                    e.info();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no equipments that need repair!");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Students list : ");
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
                        Signup(user);
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
/**/