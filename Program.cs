using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
namespace боибЕж
{
    class Program
    {
        static void Task1()
        {
            var myHome = new Adress("Ukraine", "Kyiv", "Petrovskogo", 3, 0, "B");
            Console.WriteLine(myHome.apartment);
            Console.WriteLine(myHome.street);
            Console.WriteLine(myHome.index);
        }
        class Adress
        {
            public int index;
            private string city;
            public int apartment;
            private string house;
            public string street;
            private string country;
            public Adress(string country, string city, string street, int index, int apartment, string house)
            {
                this.index = index;
                this.city = city;
                this.apartment = apartment;
                this.house = house;
                this.street = street;
                this.country = country;
            }
        }
        static void Task2()
        {
            Console.WriteLine("write the size of rectangular sides");
            var output = new Rectangle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine("Area is " + output.Area);
            Console.WriteLine("Perimiter is " + output.Perimiter);
        }
        class Rectangle
        {
            double side1;
            double side2;
            public Rectangle(int side1, int side2)
            {
                this.side1 = side1;
                this.side2 = side2;
            }
            public double AreaCalculator()
            {
                return side1 * side2;
            }
            public double PerimiterCalculator()
            {
                return (side1 + side2) * 2;
            }
            public double Area
            {
                get { return AreaCalculator(); }
            }
            public double Perimiter
            {
                get { return PerimiterCalculator(); }
            }
        }
        static void Task3()
        {
            Console.WriteLine("create your book");
            var mass = new string[] { "name", "author", "content" };
            var taker = new string[3];
            for (int i = 0; i < mass.Length; i++)
            {
                Console.WriteLine("Write its " + mass[i]);
                taker[i] = Console.ReadLine();
            }
            new Book(taker);
        }
        class Book
        {
            public Book(string[] mass)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                new Title(mass[0]).Show();
                Console.ForegroundColor = ConsoleColor.Magenta;
                new Author(mass[1]).Show();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                new Content(mass[2]).Show();
            }
        }
        class Title
        {
            string item;
            public Title(string item)
            {
                this.item = item;
            }
            public void Show()
            {
                Console.WriteLine(item);
            }
        }
        class Author
        {
            string item;
            public Author(string item)
            {
                this.item = item;
            }
            public void Show()
            {
                Console.WriteLine(item);
            }
        }
        class Content
        {
            string item;
            public Content(string item)
            {
                this.item = item;
            }
            public void Show()
            {
                Console.WriteLine(item);
            }
        }
        static void Task4()
        {
            var square = new Figure(new Point(0,0,"A"),new Point(0,3,"B"),new Point(3,3,"C"),new Point(3,0,"D"),new Point (10,20,"G"));
            Console.WriteLine(square.PerimiterCalculator());
        }
        class Point
        {
            public int x;
            public int y;
            public string name;
            public Point(int x, int y, string name)
            {
                this.x = x;
                this.y = y;
                this.name = name;
            }
            public int X
            {
                get { return x; }
            }
            public int Y
            {
                get { return y; }
            }
            public string Name
            {
                get { return name; }
            }
        }
        class Figure
        {
            Point[] points;
            public Figure(params Point[] mass)
            {
                points = mass;
            }
            double LengthSide(Point A, Point B)
            {
                return Math.Round(
                    Math.Sqrt(
                        Math.Pow(B.x-A.x,2)+ Math.Pow(B.y - A.y, 2)
                    )
                    ,2);
            }
            public double PerimiterCalculator()
            {
                var length = points.Length;
                var sideLengths=new double [length];
                for (int i = 0; i < length; i++)
                {
                    if (i == length - 1) sideLengths[i] = LengthSide(points[i],points[0]);
                    else
                    {
                        sideLengths[i] = LengthSide(points[i], points[i + 1]);
                    }
                }
                return sideLengths.Sum();
            }
        }
        static void Task5()
        {
            var taker = new string[5];
            var mass = new string[] { "name", "surname", "login", "data", "age" };
            Console.WriteLine("create youser");
            for (int i = 0; i < mass.Length; i++)
            {
                Console.WriteLine("write its " + mass[i]);
                taker[i] = Console.ReadLine();
            }
            var you = new User(taker);
            //you.data = 78;
            you.Show();
        }
        class User
        {
            public string name;
            public string surname;
            public string login;
            public readonly int data;
            public int age;
            public User(string[] data)
            {
                this.name = data[0];
                this.surname = data[1];
                this.login = data[2];
                this.data = int.Parse(data[3]);
                this.age = int.Parse(data[4]);
            }
            public void Show()
            {
                var taker = new dynamic[] { name, surname, login, age, data };
                foreach (var item in taker) Console.WriteLine(item);
            }
        }
        static void Test6()
        {
            Console.WriteLine("write what you want to convert");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("grn , rub , usd , eur");
            var toConvert = Console.ReadLine();
            Console.WriteLine("write value");
            var value = int.Parse(Console.ReadLine());
            Console.WriteLine("write in what do you want to convert : grn , rub , usd , eur ");
            var convertIn = Console.ReadLine();
            new Converter(toConvert, value, convertIn);
        }
        class Converter
        {
            public Converter(string toConvert, int number, string convertIn)
            {
                double convertedValue;
                double GetWellInGrywnas(string val)
                {
                    double output;
                    if (val == "grn") output = 1;
                    else if (val == "rub") output = 0.37;
                    else if (val == "usd") output = 26.68;
                    else output = 31.46;
                    return output;
                }
                if (toConvert == convertIn)
                {
                    Console.WriteLine("impossible to convert");
                    return;
                }
                convertedValue = number * (GetWellInGrywnas(toConvert) / GetWellInGrywnas(convertIn));
                Console.WriteLine($"{toConvert} {number} is {Math.Round(convertedValue, 2)} {convertIn}");
            }
        }
        static void Test7()
        {
            var Bob = new Employee("Bob", "Pylypenko");
            Bob.position = "programmer";
            Bob.experienceInYears = 20;
            Bob.Show();
        }
        class Employee
        {
            public string name;
            public string surname;
            public string position;
            public int experienceInYears;
            public int taxes;
            public Employee(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
            }
            public int GetSellary()
            {
                int defaultSelllary = 200;
                var mass = new dynamic[,] { { "programmer", 500 }, { "doctor", 300 }, { "teacher", 200 }, { "engineer", 340 } };
                for (int i = 0; i <= mass.GetUpperBound(0); i++)
                {
                    if (position == mass[i, 0]) defaultSelllary = mass[i, 1];
                }
                return 2 * (defaultSelllary * (1 + experienceInYears / 5)) - taxes;
            }
            public void Show()
            {
                var mass = new dynamic[,] { { "name", name }, { "surname", surname }, { "position", position }, { "experience", experienceInYears }, { "sellary", GetSellary() } };
                Console.WriteLine("you created a person");
                for (int i = 0; i <= mass.GetUpperBound(0); i++)
                {
                    Console.WriteLine(i);
                    Console.WriteLine($"its {mass[i, 0]} is {mass[i, 1]}");
                }
            }
        }
        static void Test8()
        {
            var milk = new Invoice(3433424,"Yarema","China",20,"milk");
            Console.WriteLine(milk.GetMoney());
        }
        class Invoice
        {
            public readonly int account;
            public readonly string customer;
            public readonly string provider;
            private string article;
            private int quanity;
            public Invoice(int account,string customer,string provider,int quanity,string article)
            {
                this.account = account;
                this.customer = customer;
                this.provider = provider;
                this.quanity = quanity;
                this.article = article;
            }
            public double GetMoney(bool withCommision=true)
            {
                double itemPrice=GetValue(provider,"provider")+GetValue(article, "article");
                itemPrice -= itemPrice * (withCommision ? 0.2 : 0);
                return Math.Round(quanity * itemPrice,2);
            }
            public int GetValue(string val,string type)
            {
                var articleMass = new dynamic[,] { { "computer", 5000 }, { "milk", 50 }, { "headphones", 900 }, { "sugar", 30 }, { "screwdriver", 80 } };
                var providerMass = new dynamic[,] { { "China", 500 }, { "USA", 300 }, { "Ukraine", 100 }, { "Russia", 340 }, { "Mexico", 180 } };
                var mass=(type=="article") ? articleMass : providerMass;
                int taker=0;
                for (int i = 0; i <= mass.GetUpperBound(0); i++)
                {
                    if (val == mass[i, 0]) taker=mass[i, 1];
                }
                return taker;
            }
        }
        static void Main()
        {
            //Task1();
            //Task2();
            //Task3();
            Task4();
            //Task5();
            //Test6();
            //Test7();
            //Test8();
            Console.ReadLine();
        }
    }
}