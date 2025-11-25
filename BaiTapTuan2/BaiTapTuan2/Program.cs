using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTuan2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Student> studentList = new List<Student>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Xuất danh sách sinh viên");
                Console.WriteLine("3. SV khoa CNTT");
                Console.WriteLine("4. SV có điểm TB >= 5");
                Console.WriteLine("5. Sắp xếp theo điểm TB tăng dần");
                Console.WriteLine("6. SV điểm TB >=5 và khoa CNTT");
                Console.WriteLine("7. SV có điểm TB cao nhất và thuộc khoa CNTT");
                Console.WriteLine("8. Số lượng xếp loại trong danh sách");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(studentList); break;
                    case "2": DisplayStudentList(studentList); break;
                    case "3": DisplayStudentsByFaculty(studentList, "CNTT"); break;
                    case "4": DisplayStudentsWithHighAverageScore(studentList, 5); break;
                    case "5": SortStudentsByAverageScore(studentList); break;
                    case "6": DisplayStudentsByFacultyAndScore(studentList, "CNTT", 5); break;
                    case "7": DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT"); break;
                    case "8": CountStudentRank(studentList); break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Tùy chọn không hợp lệ."); break;
                }

                Console.WriteLine();
            }
        }

        // case 1
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        // case 2
        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách sinh viên ===");
            foreach (var student in studentList)
                student.Show();
        }

        // case 3
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"=== SV khoa {faculty} ===");
            var students = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));
            DisplayStudentList(students.ToList());
        }

        // case 4
        static void DisplayStudentsWithHighAverageScore(List<Student> studentList, float minDTB)
        {
            Console.WriteLine($"=== SV có điểm TB >= {minDTB} ===");
            var students = studentList.Where(s => s.AverageScore >= minDTB);
            DisplayStudentList(students.ToList());
        }

        // case 5
        static void SortStudentsByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("=== Sắp xếp theo điểm TB tăng dần ===");
            var sorted = studentList.OrderBy(s => s.AverageScore).ToList();
            DisplayStudentList(sorted);
        }

        // case 6
        static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minDTB)
        {
            Console.WriteLine($"=== SV khoa {faculty} và điểm >= {minDTB} ===");
            var students = studentList.Where(s =>
                         s.AverageScore >= minDTB &&
                         s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudentList(students);
        }

        // case 7
        static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"=== SV khoa {faculty} có điểm TB cao nhất ===");

            var students = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));

            if (!students.Any())
            {
                Console.WriteLine("Không có sinh viên nào thuộc khoa này.");
                return;
            }

            float maxScore = students.Max(s => s.AverageScore);

            var result = students.Where(s => s.AverageScore == maxScore);

            DisplayStudentList(result.ToList());
        }

        // case 8
        static void CountStudentRank(List<Student> studentList)
        {
            Console.WriteLine("=== Số lượng xếp loại ===");

            var ranks = studentList.GroupBy(s =>
            {
                if (s.AverageScore >= 9) return "Xuất sắc";
                if (s.AverageScore >= 8) return "Giỏi";
                if (s.AverageScore >= 7) return "Khá";
                if (s.AverageScore >= 5) return "Trung bình";
                if (s.AverageScore >= 4) return "Yếu";
                return "Kém";
            });

            foreach (var group in ranks)
                Console.WriteLine($"{group.Key}: {group.Count()} SV");
        }
    }
}
