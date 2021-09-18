using ProjectCrudMvc.BLL.Repository;
using ProjectCrudMvc.DAL;
using ProjectCrudMvc.Models;
using ProjectCrudMvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectCrudMvc.Controllers
{
    [Authorize(Roles ="SuperAdmin, Admin")]
    public class PlayerController : Controller
    {
        // GET: Player
        PlayerRepository repoObj = new PlayerRepository();        
        public ActionResult Index()
        {
            List<PlayerListViewModel> list = repoObj.GetPlayerList();
            return View(list);
        }
        
        public ActionResult Create()
        {
            CreatePlayerModel crObj = new CreatePlayerModel();
            crObj.gradeList = repoObj.GetGrades();
            return View(crObj);
        }
        public ActionResult AddOrEdit(CreatePlayerModel viewObj)
        {
            var result = false;
            string fileName = Path.GetFileNameWithoutExtension(viewObj.ImageFile.FileName);
            string extension = Path.GetExtension(viewObj.ImageFile.FileName);
            string fileWithExtension = fileName + extension;
            Player playerObj = new Player();
            playerObj.Name = viewObj.Name;
            playerObj.DoB = viewObj.DoB;
            playerObj.Team = viewObj.Team;
            playerObj.Email = viewObj.Email;
            playerObj.Phone = viewObj.Phone;
            playerObj.Salary = viewObj.Salary;
            playerObj.GradeID = viewObj.GradeID;
            playerObj.ImageName = fileWithExtension;
            playerObj.ImageUrl = "~/Images/" + fileName + extension;
            string fileServerPath = Path.Combine(Server.MapPath("~/Images/" + fileName + extension));
            viewObj.ImageFile.SaveAs(fileServerPath);

            if (ModelState.IsValid)
            {
                if (viewObj.PlayerID == 0)
                {
                    repoObj.SavePlayer(playerObj);
                    result = true;
                }
                else
                {
                    playerObj.PlayerID = viewObj.PlayerID;
                    repoObj.UpdatePlayer(playerObj);
                    result = true;
                }
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (viewObj.PlayerID == 0)
                {
                    CreatePlayerModel crObj = new CreatePlayerModel();
                    crObj.gradeList = repoObj.GetGrades();
                    return View("Create",crObj);
                }
                else
                {
                    CreatePlayerModel crObj = new CreatePlayerModel();
                    crObj.gradeList = repoObj.GetGrades();
                    return View("Edit", crObj);
                }
            }

        }
        public ActionResult Edit(int id)
        {
            Player playerObj = repoObj.GetPlayerById(id);
            CreatePlayerModel viewObj = new CreatePlayerModel();
            viewObj.PlayerID = playerObj.PlayerID;
            viewObj.Name = playerObj.Name;
            viewObj.DoB = playerObj.DoB;
            viewObj.Team = playerObj.Team;
            viewObj.Email = playerObj.Email;
            viewObj.Phone = playerObj.Phone;
            viewObj.ImageName = playerObj.ImageName;
            viewObj.Salary = playerObj.Salary;
            viewObj.GradeID = playerObj.GradeID;
            viewObj.gradeList = repoObj.GetGrades();
            viewObj.ImageUrl = playerObj.ImageUrl;
            return View(viewObj);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Player playerObj = repoObj.GetPlayerById(id);
            CreatePlayerModel viewObj = new CreatePlayerModel();
            viewObj.PlayerID = playerObj.PlayerID;
            viewObj.Name = playerObj.Name;
            viewObj.DoB = playerObj.DoB;
            viewObj.Team = playerObj.Team;
            viewObj.Email = playerObj.Email;
            viewObj.Phone = playerObj.Phone;
            viewObj.Salary = playerObj.Salary;
            viewObj.GradeID = playerObj.GradeID;
            viewObj.ImageUrl = playerObj.ImageUrl;
            return View(viewObj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Player playerObj = repoObj.GetPlayerById(id);
            if(playerObj != null)
            {
                repoObj.DeletePlayer(playerObj.PlayerID);
                return RedirectToAction("Index");
            }
            return View(playerObj);
        }
        public ActionResult Details(int PlayerID)
        {
            Player playerObj = repoObj.GetPlayerById(PlayerID);
            PlayerListViewModel viewObj = new PlayerListViewModel();
            viewObj.PlayerID = playerObj.PlayerID;
            viewObj.Name = playerObj.Name;
            viewObj.DoB = playerObj.DoB;
            viewObj.Team = playerObj.Team;
            viewObj.Email = playerObj.Email;
            viewObj.Phone = playerObj.Phone;
            viewObj.Salary = playerObj.Salary;
            viewObj.GradeID = playerObj.GradeID;
            viewObj.GradeName = playerObj.Grade.GradeName;
            viewObj.ImageUrl = playerObj.ImageUrl;
            return PartialView("_PlayerList", viewObj);
        }
    }

}