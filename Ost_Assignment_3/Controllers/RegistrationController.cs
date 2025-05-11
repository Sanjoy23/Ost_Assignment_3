using Ost_Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ost_Assignment_3.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(string txtFirstName, string txtLastName, string txtUserName,
            string txtPassword, string txtConfirmPassword, string txtRole, string txtGender)
        {
            BaseMember member = new BaseMember();
            int roleId = int.Parse(txtRole);
            string isUserExist = member.FindMemberByUserName(txtUserName);
            if (isUserExist == null)
            {
                member.UserRegistraion(txtFirstName, txtLastName, txtUserName, txtPassword, txtGender, roleId);

                Session["Message"] = "Registration Compeleted successfully. Redirecting to User List Page.";
                Session["IsSuccess"] = true;
                return View();
            }
            Session["Message"] = "User is already exist.";
            Session["IsSuccess"] = false;
            return View();
        }

        public ActionResult RegisteredUser()
        {
            BaseMember baseMember = new BaseMember();
            List<BaseMember> userList = baseMember.getAllUsers();
            ViewBag.UserList = userList;

            return View();
        }

    }
}