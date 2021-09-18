using ProjectCrudMvc.DAL;
using ProjectCrudMvc.Models;
using ProjectCrudMvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectCrudMvc.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult CreateRole()
        {
            using (var _context = new PlayerContext())
            {
                List<tblUser> userList = _context.users.ToList();
                ViewBag.Users = new SelectList(userList, "ID", "UserName");
                return View();
            }
        }
        [HttpPost]
        public ActionResult CreateRole(tblRole obj)
        {
            using (var _context = new PlayerContext())
            {
                _context.roles.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Index()
        {
            using (var _context = new PlayerContext())
            {
                var UserRoleList = (from user in _context.users join roles in _context.users on user.ID equals roles.ID select new { UserID = user.ID, RoleID = roles.ID, UserName = user.UserName, RoleName = roles.UserName }).ToList();
                List<ViewModelUser> list = new List<ViewModelUser>();
                foreach (var item in UserRoleList)
                {
                    ViewModelUser obj = new ViewModelUser();
                    obj.RoleID = item.RoleID;
                    obj.RoleName = item.RoleName;
                    obj.ID = item.UserID;
                    obj.UserName = item.UserName;
                    list.Add(obj);
                }
                return View(list);
            }
        }
        public ActionResult Edit(int id)
        {
            using (var _context = new PlayerContext())
            {
                tblRole role = _context.roles.Find(id);
                List<tblUser> userList = _context.users.ToList();
                ViewBag.Users = new SelectList(userList, "ID", "UserName");
                return View(role);
            }

        }
        [HttpPost]
        public ActionResult Edit(tblRole obj)
        {
            using (var _context = new PlayerContext())
            {
                bool IsExist = !_context.roles.Any(u => u.RoleName == obj.RoleName && u.UserID == obj.UserID);
                if (IsExist)
                {
                    tblRole roleObj = _context.roles.Find(obj.ID);
                    roleObj.RoleName = obj.RoleName;
                    roleObj.UserID = obj.UserID;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    tblRole role = _context.roles.Find(obj.ID);
                    List<tblUser> userList = _context.users.ToList();
                    ViewBag.Users = new SelectList(userList, "ID", "UserName");
                    ModelState.AddModelError("", "Role Already Exist");
                    return View();
                }

            }

        }
        public ActionResult Delete(int id)
        {
            using (var _context = new PlayerContext())
            {
                tblRole role = _context.roles.Find(id);
                role.TblUser = _context.users.Find(role.ID);
                return View(role);
            }

        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            using (var _context = new PlayerContext())
            {
                tblRole role = _context.roles.Find(id);
                if (role != null)
                {
                    _context.roles.Remove(role);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    role.TblUser = _context.users.Find(role.ID);
                    return View(role);
                }

            }

        }
        public ActionResult Details(int id)
        {
            using (var _context = new PlayerContext())
            {
                tblRole role = _context.roles.Find(id);
                List<tblUser> userList = _context.users.ToList();
                ViewBag.Users = new SelectList(userList, "ID", "UserName");
                return View(role);
            }

        }
    }
}