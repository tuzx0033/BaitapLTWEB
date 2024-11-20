using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using StudentRegistrationApp.Models;


namespace StudentRegistrationApp.Controllers
{
    public class StudentController : Controller
    {
        // Danh sách giả lập để lưu trữ sinh viên đã đăng ký
        private static List<Student> registeredStudents = new List<Student>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowKQ(Student student)
        {
            // Thêm sinh viên đăng ký vào danh sách
            registeredStudents.Add(student);

            // Tính số lượng sinh viên đã đăng ký chuyên ngành giống sinh viên này
            var studentCount = registeredStudents.Count(s => s.Major == student.Major);

            // Truyền thông tin sinh viên và số lượng sinh viên cùng chuyên ngành vào View
            ViewBag.StudentCount = studentCount;

            return View(student);
        }
    }
}
