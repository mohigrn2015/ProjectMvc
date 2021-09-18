using ProjectCrudMvc.BLL.Repository;
using ProjectCrudMvc.Models;
using ProjectCrudMvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectCrudMvc.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class GradeController : Controller
    {
        PlayerRepository repoObj = new PlayerRepository();
        public ActionResult GradeList()
        {
            List<Grade> gradeList = repoObj.GetGrades();
            return View(gradeList);
        }
        [HttpGet]
        public ActionResult AddGrade()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddGrade(CreateGradeViewModel viewobj)
        {
            Grade gradeObj = new Grade();
            gradeObj.GradeName = viewobj.GradeName;
            repoObj.SaveGrade(gradeObj);
            RedirectToAction("GradeList");
            return RedirectToAction("GradeList");
        }
        [HttpGet]
        public ActionResult EditGrade(int id)
        {
            Grade gradeObj = repoObj.GetGradeById(id);
            CreateGradeViewModel viewObj = new CreateGradeViewModel();
            viewObj.GradeName = gradeObj.GradeName;
            return View(gradeObj);
        }
        [HttpPost]
        public ActionResult EditGrade(CreateGradeViewModel viewObj)
        {
            Grade gradeObj = new Grade();
            gradeObj.GradeName = viewObj.GradeName;
            gradeObj.GradeID = viewObj.GradeID;
            repoObj.UpdateGrade(gradeObj);
            return RedirectToAction("GradeList");
        }
        public ActionResult DeleteGrate(int id)
        {
            Grade gradeobj = repoObj.GetGradeById(id);
            if (gradeobj != null)
            {
                repoObj.DeleteGrade(gradeobj.GradeID);
                return RedirectToAction("GradeList");
            }
            return View(gradeobj);
        }
    }
}