using Newtonsoft.Json;
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
    [Authorize(Roles ="Admin, SuperAdmin")]
    public class AjaxCrudController : Controller
    {
        PlayerContext db = new PlayerContext();
        public ActionResult Index()
        {
            //List<Grade> gradeList = db.grades.ToList();
            //ViewBag.ListOfGrade = new SelectList(gradeList, "GradeID", "GradeName");    gradeList
            return View();
        }
        public JsonResult GetPlayerList()
        {
            var playerList = db.bplPlayers.Where(p => p.ID > 0).Select(p => new ExtraPlayerCreate
            {
                ID = p.ID,
                Name = p.Name,
                Team=p.Team,               
                HireInBPL=p.HireInBPL,
                SigningMoney=p.SigningMoney               
            }).ToList();
            return Json(playerList, JsonRequestBehavior.AllowGet);
        }  
        public ActionResult SavePlayer()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult SavePlayer(ExtraPlayerCreate obj) 
        {
            var result = false;
            try
            {
                ExtraTableForPlayer plObj;
                if (obj.ID==0)
                {
                    plObj = new ExtraTableForPlayer();
                    plObj.Name = obj.Name;
                    plObj.Team = obj.Team;
                    plObj.HireInBPL = obj.HireInBPL;
                    plObj.SigningMoney = obj.SigningMoney;                    
                    db.bplPlayers.Add(plObj);
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    plObj = db.bplPlayers.SingleOrDefault(p=>p.ID== obj.ID);
                    plObj.Name = obj.Name;
                    plObj.Team = obj.Team;
                    plObj.HireInBPL = obj.HireInBPL;
                    plObj.SigningMoney = obj.SigningMoney;
                    db.SaveChanges();
                    result = true;
                }
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        public JsonResult GetPlayersById(int PlayerID)
        {
            ExtraTableForPlayer obj = db.bplPlayers.Where(p => p.ID == PlayerID).SingleOrDefault();
            string value = "";
            value = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling=ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetplayerDetails(int PlayerId)
        {
            ExtraTableForPlayer obj = db.bplPlayers.Where(p => p.ID == PlayerId).SingleOrDefault();
            ExtraPlayerCreate vObj = new ExtraPlayerCreate();
            vObj.ID = obj.ID;
            vObj.Name = obj.Name;
            vObj.Team = obj.Team;
            vObj.HireInBPL = obj.HireInBPL;
            vObj.SigningMoney = obj.SigningMoney;           
            return PartialView("_PlayerList", vObj);
        } 
        public JsonResult deleteRecord(int Id)
        {
            bool result = false;
            ExtraTableForPlayer obj = db.bplPlayers.Where(p => p.ID == Id).SingleOrDefault();
            if(obj != null)
            {
                db.bplPlayers.Remove(obj);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
            //string value = "";
            //value = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});
            //return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}