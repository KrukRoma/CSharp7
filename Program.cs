namespace CSharp7
{
    class Square
    {
        public int A { get; set; }

        public Square() : this(0) { }

        public Square(int a)
        {
            A = a;
        }

        public override string ToString()
        {
            return $"A : {A}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Square square &&
                   A == square.A;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(A);
        }

        public static Square operator ++(Square s)
        {
            s.A++;
            return s;
        }

        public static Square operator --(Square s)
        {
            s.A--;
            return s;
        }

        public static Square operator +(Square s1, Square s2)
        {
            Square res = new Square
            {
                A = s1.A + s2.A
            };
            return res;
        }

        public static Square operator -(Square s1, Square s2)
        {
            Square res = new Square
            {
                A = s1.A - s2.A
            };
            return res;
        }

        public static Square operator *(Square s1, Square s2)
        {
            Square res = new Square
            {
                A = s1.A * s2.A
            };
            return res;
        }

        public static bool operator ==(Square s1, Square s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(Square s1, Square s2)
        {
            return !(s1 == s2);
        }

        public static bool operator <(Square s1, Square s2)
        {
            return s1.A < s2.A;
        }

        public static bool operator >(Square s1, Square s2)
        {
            return s1.A > s2.A;
        }

        public static bool operator <=(Square s1, Square s2)
        {
            return s1.A <= s2.A;
        }

        public static bool operator >=(Square s1, Square s2)
        {
            return s1.A >= s2.A;
        }

        public static bool operator true(Square s)
        {
            return s.A > 0;
        }

        public static bool operator false(Square s)
        {
            return s.A <= 0;
        }

        public static implicit operator Rectangle(Square s)
        {
            return new Rectangle(s.A, s.A);
        }

        public static implicit operator int(Square s)
        {
            return s.A;
        }
    }

    class Rectangle
    {
        public int A { get; set; }
        public int B { get; set; }

        public Rectangle() : this(0, 0) { }

        public Rectangle(int a, int b)
        {
            A = a;
            B = b;
        }

        public override string ToString()
        {
            return $"A : {A}, B : {B}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Rectangle rectangle &&
                   A == rectangle.A &&
                   B == rectangle.B;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A, B);
        }

        public static Rectangle operator ++(Rectangle r)
        {
            r.A++;
            r.B++;
            return r;
        }

        public static Rectangle operator --(Rectangle r)
        {
            r.A--;
            r.B--;
            return r;
        }

        public static Rectangle operator +(Rectangle r1, Rectangle r2)
        {
            Rectangle res = new Rectangle
            {
                A = r1.A + r2.A,
                B = r1.B + r2.B
            };
            return res;
        }

        public static Rectangle operator -(Rectangle r1, Rectangle r2)
        {
            Rectangle res = new Rectangle
            {
                A = r1.A - r2.A,
                B = r1.B - r2.B
            };
            return res;
        }

        public static Rectangle operator *(Rectangle r1, Rectangle r2)
        {
            Rectangle res = new Rectangle
            {
                A = r1.A * r2.A,
                B = r1.B * r2.B
            };
            return res;
        }

        public static bool operator ==(Rectangle r1, Rectangle r2)
        {
            return r1.Equals(r2);
        }

        public static bool operator !=(Rectangle r1, Rectangle r2)
        {
            return !(r1 == r2);
        }

        public static bool operator <(Rectangle r1, Rectangle r2)
        {
            return r1.A < r2.A && r1.B < r2.B;
        }

        public static bool operator >(Rectangle r1, Rectangle r2)
        {
            return r1.A > r2.A && r1.B > r2.B;
        }

        public static bool operator <=(Rectangle r1, Rectangle r2)
        {
            return r1.A <= r2.A && r1.B <= r2.B;
        }

        public static bool operator >=(Rectangle r1, Rectangle r2)
        {
            return r1.A >= r2.A && r1.B >= r2.B;
        }

        public static bool operator true(Rectangle r)
        {
            return r.A > 0 && r.B > 0;
        }

        public static bool operator false(Rectangle r)
        {
            return r.A <= 0 || r.B <= 0;
        }

        public static explicit operator Square(Rectangle r)
        {
            int minSide = Math.Min(r.A, r.B);
            return new Square(minSide);
        }

        public static explicit operator int(Rectangle r)
        {
            return r.A + r.B;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Square s1 = new Square(3);
            Square s2 = new Square(4);

            Rectangle r1 = new Rectangle(3, 5);
            Rectangle r2 = new Rectangle(2, 6);

            Console.WriteLine($"Square s1: {s1}");
            Console.WriteLine($"Square s2: {s2}");
            Console.WriteLine($"Rectangle r1: {r1}");
            Console.WriteLine($"Rectangle r2: {r2}");

            s1++;
            s2--;

            Console.WriteLine($"s1 after increment: {s1}");
            Console.WriteLine($"s2 after decrement: {s2}");

            Square s3 = s1 + s2;
            Console.WriteLine($"s1 + s2 = {s3}");

            Square s4 = s1 - s2;
            Console.WriteLine($"s1 - s2 = {s4}");

            Rectangle r3 = r1 + r2;
            Console.WriteLine($"r1 + r2 = {r3}");

            Rectangle r4 = r1 - r2;
            Console.WriteLine($"r1 - r2 = {r4}");

            Console.WriteLine($"s1 == s2: {s1 == s2}");
            Console.WriteLine($"r1 != r2: {r1 != r2}");

            if (s1)
            {
                Console.WriteLine("s1 is true");
            }
            else
            {
                Console.WriteLine("s1 is false");
            }

            if (r1)
            {
                Console.WriteLine("r1 is true");
            }
            else
            {
                Console.WriteLine("r1 is false");
            }

            Rectangle r5 = s1;
            Console.WriteLine($"Implicit conversion of s1 to Rectangle: {r5}");

            Square s5 = (Square)r1;
            Console.WriteLine($"Explicit conversion of r1 to Square: {s5}");

            int sideLength = s1;
            Console.WriteLine($"Implicit conversion of s1 to int: {sideLength}");

            int perimeter = (int)r1;
            Console.WriteLine($"Explicit conversion of r1 to int: {perimeter}");
        }
    }
}

