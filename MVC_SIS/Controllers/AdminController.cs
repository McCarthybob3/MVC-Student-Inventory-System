using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if (ModelState.IsValid)
            {
                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors");
            }
            else
            {
               return AddMajor();
            }

}

[HttpGet]
        public ActionResult EditMajor(int id)
        {

            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            if (ModelState.IsValid)
            {
                MajorRepository.Edit(major);
                return RedirectToAction("Majors");
            }
            else
            {
                return EditMajor(major.MajorId);
            }
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
           
                return View(new State());
         

            
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            if (ModelState.IsValid)
            {
                StateRepository.Add(state);
            return RedirectToAction("States");
        }
            else
            {
                return AddState();
    }
}

        [HttpGet]
        public ActionResult DeleteState(string id)
        {
            var model = StateRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            StateRepository.Delete(state.StateName);
            return RedirectToAction("States");
        }
        [HttpGet]
        public ActionResult EditState(string id)
        {
            var model = StateRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditState(State State)
        {
            if (ModelState.IsValid)
            {
                StateRepository.Edit(State);
                return RedirectToAction("States");
            }
            else
            {
                return EditState(State.StateAbbreviation);
            }
        }

        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseRepository.Add(course.CourseName);
            return RedirectToAction("Courses");
            }
            else
            {


                return AddCourse();
            }

        }


        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            var model = CourseRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
      
                var model = CourseRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseRepository.Edit(course);
                return RedirectToAction("Courses");
            }
            else
            {
                return EditCourse(course.CourseId);
            }
           
        }
    }
}