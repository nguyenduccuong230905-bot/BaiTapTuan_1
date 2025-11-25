using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bai2_01
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Tạo danh sách ít nhất 5 học sinh
            List<Student> students = new List<Student>()
            {
                new Student(){ Id = 1, Name = "An", Age = 16 },
                new Student(){ Id = 2, Name = "Binh", Age = 18 },
                new Student(){ Id = 3, Name = "Anh Khoa", Age = 15 },
                new Student(){ Id = 4, Name = "Cuong", Age = 20 },
                new Student(){ Id = 5, Name = "A My", Age = 17 }
            };

            // a. In toàn bộ danh sách
            Console.WriteLine("a. Toàn bộ danh sách học sinh:");
            foreach (var s in students)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");
            Console.WriteLine();

            // b. Học sinh có tuổi từ 15 đến 18
            Console.WriteLine("b. Học sinh có tuổi từ 15 đến 18:");
            var age15to18 = students.Where(s => s.Age >= 15 && s.Age <= 18);
            foreach (var s in age15to18)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");
            Console.WriteLine();

            // c. Học sinh có tên bắt đầu bằng chữ A
            Console.WriteLine("c. Học sinh có tên bắt đầu bằng chữ A:");
            var startWithA = students.Where(s => s.Name.StartsWith("A"));
            foreach (var s in startWithA)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");
            Console.WriteLine();

            // d. Tổng tuổi các học sinh
            Console.WriteLine("d. Tổng tuổi của tất cả học sinh:");
            int totalAge = students.Sum(s => s.Age);
            Console.WriteLine("Tổng tuổi = " + totalAge);
            Console.WriteLine();

            // e. Học sinh có tuổi lớn nhất
            Console.WriteLine("e. Học sinh có tuổi lớn nhất:");
            int maxAge = students.Max(s => s.Age);
            var oldest = students.Where(s => s.Age == maxAge);
            foreach (var s in oldest)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");
            Console.WriteLine();

            // f. Sắp xếp theo tuổi tăng dần
            Console.WriteLine("f. Danh sách sau khi sắp xếp theo tuổi tăng dần:");
            var sorted = students.OrderBy(s => s.Age);
            foreach (var s in sorted)
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");
        }
    }
}

