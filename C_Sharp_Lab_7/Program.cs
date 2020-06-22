using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace C_Sharp_Lab_7
{
    class Person
    {
        public string fam; // записать 1 раз Read, Write-once
        public string status = "alive"; // только читать Read-only
        public double salary; // недоступна для чтения Write-only
        public int age; //чтение запись Read, Write
        private string health = "100%";//скрыто и не записывается Not Read, Not Write
        public int Age
        {
            set { age = value; }
            get { return (age); }
        }
        public string Fam
        {
            set { if (fam == "") fam = value; }
            get { return (fam); }
        }
        public string Status
        {
            private set { status = value; }
            get { return (status); }
        }
        public double Salary
        {
            set { salary = value; }
            private get { return (salary); }
        }
        /* public string Health
         {
             private set { health = value; }
             private get { return (health); }
         }*/
        public void Check_health()
        {
            Console.WriteLine("Здоровье {0}",health);
        }


    }

    class Rational
    {
        public int m;//числитель
        public int n;//знаменатель
        public static readonly Rational Zero, One;
        private Rational(int a, int b, string t)
        {
            m = a; n = b;
        }
        static Rational()

        {

            Console.WriteLine("static constructor Rational");

            Zero = new Rational(0, 1, "private");

            One = new Rational(1, 1, "private");

        }

        public override string ToString()
        {
            return "" + m + "/" + n;
        }

        public static bool operator ==(Rational r1, Rational r2)

        {

            return ((r1.m == r2.m) && (r1.n == r2.n));

        }

        public static bool operator !=(Rational r1, Rational r2)

        {

            return ((r1.m != r2.m) || (r1.n != r2.n));

        }
        public static bool operator <(Rational r1, double r2)

        {

            return ((double)r1.m / (double)r1.n < r2);

        }

        public static bool operator >(Rational r1, double r2)

        {

            return ((double)r1.m / (double)r1.n > r2);

        }

        public void TestRationalConst()

        {

            Rational r1 = new Rational(2, 8), r2 = new Rational(2, 5);

            Rational r3 = new Rational(4, 10), r4 = new Rational(3, 7);

            Rational r5 = Rational.Zero, r6 = Rational.Zero;

            if ((r1 != Rational.Zero) && (r2 == r3)) r5 =

             (r3 + Rational.One) * r4;

            r6 = Rational.One + Rational.One;

            r1.PrintRational("r1: (2,8)");

            r2.PrintRational("r2: (2,5)");

            r3.PrintRational("r3: (4,10)");

            r4.PrintRational("r4: (3,7)");

            r5.PrintRational("r5: ((r3 +1)*r4)");

            r6.PrintRational("r6: (1+1)");
            Console.WriteLine("r1==r2?{0}", r1 == r2);
            Console.WriteLine("r1!=r2?{0}", r1 != r2);
            Console.WriteLine("r1>r2?{0}", r1 > 10);
            Console.WriteLine("r1<r2?{0}", r1 < 10);

        }
        public Rational(int a, int b)

        {

            if (b == 0) { m = 0; n = 1; }
            else

            {
                if (b < 0) { b = -b; a = -a; }
                int d = GCD(a, b);
                m = a / d; n = b / d;
            }

        }
        public Rational()

        {


        }
        // Перегрузка операторов
        public static Rational operator +(Rational a, Rational b)
        {
            int m1, n1;
            
            if (a.n != b.n)
            {
                m1 = a.m * b.n + b.m * a.n;
                n1 = a.n * b.n;
                
            }
            else
            {
                m1 = a.m+b.m;
                n1 = a.n;
            }

            Rational n = new Rational(m1,n1);
            return n;
        }
        public static Rational operator -(Rational a, Rational b)
        {
            int m1, n1;

            if (a.n != b.n)
            {
                m1 = a.m * b.n - b.m * a.n;
                n1 = a.n * b.n;

            }
            else
            {
                m1 = a.m - b.m;
                n1 = a.n;
            }

            Rational n = new Rational(m1, n1);
            return n;
        }
        public static Rational operator *(Rational a, Rational b)
        {
            int m1, n1;

            m1 = a.m * b.m;
            n1 = a.n * b.n;          
          
            Rational n = new Rational(m1, n1);
            return n;
        }
        public static Rational operator /(Rational a, Rational b)
        {
            int m1, n1;

            m1 = a.m * b.n;
            n1 = a.n * b.m;

            Rational n = new Rational(m1, n1);
            return n;
        }


        public static int GCD(int n, int m)
        {
            n = Math.Abs(n);
            while (n != 0)
            {
                var t = n;
                n = m % n;
                m = t;
            }
            return m;
        }
        public void PrintRational(string name)

        {

            Console.WriteLine(" {0} = {1}/{2}", name, m, n);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person f1 = new Person();
            Console.WriteLine("Введите возвраст");
            f1.age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Возвраст: {0}", f1.age);
            Console.WriteLine("Введите фамилию");
            f1.fam = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Фамилия: {0}", f1.fam);
            //Console.WriteLine("Введите статус");
            //f1.status = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Статус: {0}", f1.status);
            Console.WriteLine("Введите зарплату");
            f1.salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Зарплата: {0}", f1.salary);
            f1.Check_health();
            //Console.WriteLine("Введите здоровье");
            //f1.health = Convert.ToString(Console.ReadLine());
            //Console.WriteLine("Здоровье: {0}", f1.health);

            //второе задание
            Rational t1 = new Rational(25, 100);
            Rational t2 = new Rational(15, 25);
            Rational t3 = new Rational();
            t1.PrintRational("GCD");
            t2.PrintRational("GCD");
            t3 = t1 + t2;
            t3.PrintRational("+");
            t3 = t1 - t2;
            t3.PrintRational("-");
            t3 = t1 * t2;
            t3.PrintRational("*");
            t3 = t1 / t2;
            t3.PrintRational("/");
            t3.TestRationalConst();
        }
    }
}