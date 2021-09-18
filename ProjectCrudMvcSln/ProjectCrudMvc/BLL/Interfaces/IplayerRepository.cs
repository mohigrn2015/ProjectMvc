using ProjectCrudMvc.Models;
using ProjectCrudMvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCrudMvc.BLL.Interfaces
{
    interface IplayerRepository
    {
        List<PlayerListViewModel> GetPlayerList();
        List<CreatePlayerModel> GetCreatePlayers();
        void UpdatePlayer(Player obj);
        void SavePlayer(Player obj);
        void DeletePlayer(int id);
        Player GetPlayerById(int id);
        List<Grade> GetGrades();
        void SaveGrade(Grade obj);
        void UpdateGrade(Grade obj);
        Grade GetGradeById(int id);
        void DeleteGrade(int id);
    }
}
