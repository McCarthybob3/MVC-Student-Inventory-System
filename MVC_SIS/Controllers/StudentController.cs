using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {

            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {

            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
                // here we would save the appointment to a database
              
            }
            else
            {
                

               return Add();
            }
           
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = StudentRepository.Get(id);
            var viewModel = new StudentVM();
            viewModel.Student = model;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Delete(StudentVM studentVM)
        {
         
            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            StudentRepository.Delete(studentVM.Student.StudentId);

            return RedirectToAction("List");
          
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var viewModel = new StudentVM();

            viewModel.SetStateItems(StateRepository.GetAll());
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.Student = StudentRepository.Get(id);
            viewModel.Student.Address = StudentRepository.Get(id).Address;
            foreach (var course in StudentRepository.Get(id).Courses)
               viewModel.SelectedCourseIds.Add(CourseRepository.Get(course.CourseId).CourseId);
            return View(viewModel);
          

        }

        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));
                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);

                StudentRepository.Edit(studentVM.Student);
                return RedirectToAction("List");
            }
            else
            {
                return Edit(studentVM.Student.StudentId);
            }
        }


    }
}