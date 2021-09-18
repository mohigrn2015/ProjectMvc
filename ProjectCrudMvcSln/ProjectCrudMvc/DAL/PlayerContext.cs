using ProjectCrudMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ProjectCrudMvc.DAL
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(): base("PlayerContext")
        {
            
        }
        public DbSet<Player> players { get; set; }
        public DbSet<Grade> grades { get; set; }
        public DbSet<tblRole> roles { get; set; }
        public DbSet<tblUser> users { get; set; } 
        public DbSet<ExtraTableForPlayer> bplPlayers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    } 
}