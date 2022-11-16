using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWeb.DataAccess;
using TestWeb.Models;

namespace TestWeb.Controllers
{
    public class TeacherController : Controller
    {

            public IActionResult Index()
            {
                TeacherDA teacherDA = new TeacherDA();
                List<Teacher> teachers = teacherDA.GetTeachers();

                return View(teachers);
            }

            public IActionResult Create()
            {
                Teacher teacher = new Teacher();
                return View(teacher);
            }
            [HttpPost]
            public IActionResult Create(Teacher teacher)
            {
                TeacherDA teacherDA = new TeacherDA();
                var response = teacherDA.CreateTeacher(teacher);

                return Redirect("Index");
            }

            public IActionResult Edit(int ID)
            {
                TeacherDA teacherDA = new TeacherDA();
                Teacher teacher = teacherDA.GetTeacher(ID);

                return View(teacher);
            }

            [HttpPost]
            public IActionResult Edit(Teacher teacher)
            {
                TeacherDA teacherDA = new TeacherDA();
                var response = teacherDA.UpdateTeacher(teacher);

                return Redirect("../Index");
            }

        public IActionResult Details(int ID)
        {
            TeacherDA teacherDA = new TeacherDA();
            Teacher teacher = teacherDA.GetTeacher(ID);

            return View(teacher);
        }

        public IActionResult Delete(int ID)
            {
                TeacherDA teacherDA = new TeacherDA();
                bool response = teacherDA.DeleteTeacher(ID);

                return Redirect("../Index");
            }
        }
    }

