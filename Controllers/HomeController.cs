﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountOperations.Models;
using System.Data.SqlClient;

namespace AccountOperations.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult MasterDataMaint()
        {
            ViewBag.Message = "Master Data Maintenance.";
            List<MenuFields> MenuFieldsList = GetMenuFields("Master Data Maintenance", "Master Data");
            List<Projects> ProjectsList = GetProjects();
            return View(MenuFieldsList);
        }

        public List<MenuFields> GetMenuFields(String menuName, String fieldName)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["accountOpsConn"].ConnectionString;
            List<MenuFields> MenuFieldsList = new List<MenuFields>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = String.Format(DBQueries.GetMasterMenuLov,menuName, fieldName);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MenuFields temp = new MenuFields();

                        temp.menuName = reader.GetString(reader.GetOrdinal("MENU_NM"));
                        temp.fieldName = reader.GetString(reader.GetOrdinal("FIELD_NM"));
                        temp.seqNumber = reader.GetInt32(reader.GetOrdinal("LOV_SEQ_NBR"));
                        temp.lovDesc = reader.GetString(reader.GetOrdinal("LOV_DESC"));
                        temp.lastUpdatedBy = reader.GetInt32(reader.GetOrdinal("LAST_UPD_BY"));
                        temp.lastUpdatedTime = reader.GetDateTime(reader.GetOrdinal("LAST_UPD_TS"));

                        MenuFieldsList.Add(temp);

                    };
                }
            }
            return MenuFieldsList;
        }

        public List<Projects> GetProjects()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["accountOpsConn"].ConnectionString;
            List<Projects> ProjectsList = new List<Projects>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = DBQueries.GetProjects;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Projects temp = new Projects();
                        temp.projectId = reader.GetInt32(reader.GetOrdinal("PROJ_ID"));
                        temp.projectName = reader.GetString(reader.GetOrdinal("PROJ_NM"));
                        temp.projectDesc = reader.GetString(reader.GetOrdinal("PROJ_DESC"));
                        temp.projectBeginDate = reader.GetDateTime(reader.GetOrdinal("PROJ_BEG_DT"));
                        temp.projectEndDate = reader.GetDateTime(reader.GetOrdinal("PROJ_END_DT"));
                        temp.lastUpdatedBy = reader.GetInt32(reader.GetOrdinal("LAST_UPD_BY"));
                        temp.lastUpdatedTime = reader.GetDateTime(reader.GetOrdinal("LAST_UPD_TS"));

                        ProjectsList.Add(temp);

                    };
                                    }
            }
            return ProjectsList;
        }
    }
}