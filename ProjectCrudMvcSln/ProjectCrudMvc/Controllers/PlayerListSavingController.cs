using ProjectCrudMvc.DAL;
using ProjectCrudMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectCrudMvc.Controllers
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class PlayerListSavingController : Controller
    {
        // GET: PlayerListSaving
        public ActionResult List()
        {
            using (var _context = new PlayerContext())
            {
                List<ExtraTableForPlayer> list = _context.bplPlayers.ToList();
                return View(list);
            }
        }
        public ActionResult Index()
        {
            using (var _context = new PlayerContext())
            {
                List<ExtraTableForPlayer> list = _context.bplPlayers.ToList();
                return View(list);
            }
             
        }
        public JsonResult insertPlayerList(List<ExtraTableForPlayer> playerList)
        {
            int insertRecord = 0;
            using (var _context = new PlayerContext())
            {
                _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [ExtraTableForPlayers]");
                if (playerList == null)
                {
                    playerList = new List<ExtraTableForPlayer>();
                }
                foreach (var item in playerList)
                {
                    _context.bplPlayers.Add(item);
                }
                insertRecord = _context.SaveChanges();
                return Json(insertRecord);
            }
        }
    }
}