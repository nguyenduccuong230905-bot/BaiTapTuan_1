using System;
using System.Text;

class PTBac1
{
    protected double a, b;
    public PTBac1(double a, double b) { this.a = a; this.b = b; }

    public virtual void Giai()
    {
        if (a == 0)
            Console.WriteLine(b == 0 ? "Vô số nghiệm" : "Vô nghiệm");
        else
            Console.WriteLine("Nghiệm x = " + (-b / a));
    }
}

class PTBac2 : PTBac1
{
    private double c;

    public PTBac2(double a, double b, double c) : base(a, b)
    {
        this.c = c;
    }

    public override void Giai()
    {
        if (a == 0)
        {
            new PTBac1(b, c).Giai();
            return;
        }
        double delta = b * b - 4 * a * c;
        if (delta < 0)
            Console.WriteLine("Phương trình vô nghiệm");
        else if (delta == 0)
            Console.WriteLine("Phương trình có nghiệm kép x = " + (-b / (2 * a)));
        else
        {
            double x1 = (-b + Math.Sqrt(delta)) / (2 * a),
                   x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine($"x1 = {x1}, x2 = {x2}");
        }
    }
}

class Program
{
    static double ReadDouble(string prompt)
    {
        double value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (double.TryParse(input, out value)) return value;
            Console.WriteLine("Chỉ nhập số thôi.");
        }
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        double a = ReadDouble("Nhập a: ");
        double b = ReadDouble("Nhập b: ");
        double c = ReadDouble("Nhập c: ");

        PTBac2 pt = new PTBac2(a, b, c);
        pt.Giai();
        Console.ReadKey();
    }
}