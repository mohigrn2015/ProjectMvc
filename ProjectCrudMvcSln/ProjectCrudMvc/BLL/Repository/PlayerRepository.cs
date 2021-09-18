using ProjectCrudMvc.BLL.Interfaces;
using ProjectCrudMvc.DAL;
using ProjectCrudMvc.Models;
using ProjectCrudMvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCrudMvc.BLL.Repository
{
    public class PlayerRepository : IplayerRepository
    {
        PlayerContext db = new PlayerContext();

        public void DeleteGrade(int id)
        {
            Grade delGrade= GetGradeById(id);
            db.grades.Remove(delGrade);
            db.SaveChanges();
        }

        public void DeletePlayer(int id)
        {
            Player delPlayer = GetPlayerById(id);
            db.players.Remove(delPlayer);
            db.SaveChanges();
        }

        public List<CreatePlayerModel> GetCreatePlayers()
        {
            List<CreatePlayerModel> createPlayerModels = new List<CreatePlayerModel>();
            createPlayerModels = db.players.Select(p => new CreatePlayerModel { 
            Name=p.Name,
            DoB=p.DoB,
            Team=p.Team,
            Email=p.Email,
            Phone=p.Phone,
            Salary=p.Salary,
            ImageName=p.ImageName,
            ImageUrl=p.ImageUrl,
            GradeID=p.Grade.GradeID
            }).ToList();
            return createPlayerModels;
        }

        public Grade GetGradeById(int id)
        {
            Grade grade=db.grades.SingleOrDefault(g=>g.GradeID==id);
            return grade;
        }

        public List<Grade> GetGrades()
        {
            List<Grade> gradeList = db.grades.ToList();
            return gradeList;
        }

        public Player GetPlayerById(int id)
        {
            Player player = db.players.SingleOrDefault(p => p.PlayerID == id);
            return player;
        }

        public List<PlayerListViewModel> GetPlayerList()
        {
            List<PlayerListViewModel> list = db.players.Select(p => new PlayerListViewModel { 
            PlayerID = p.PlayerID, 
            Name= p.Name, 
            DoB = p.DoB,
            Team = p.Team, 
            Email = p.Email, 
            Phone= p.Phone,
            Salary = p.Salary, 
            ImageName = p.ImageName,
            ImageUrl = p.ImageUrl,
            GradeID= p.GradeID,
            GradeName = p.Grade.GradeName,
            }).ToList();
            return list;
        }

        public void SaveGrade(Grade obj)
        {
            db.grades.Add(obj);
            db.SaveChanges();
        }

        public void SavePlayer(Player obj)
        {
            db.players.Add(obj);
            db.SaveChanges();
        }

        public void UpdateGrade(Grade obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdatePlayer(Player obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}