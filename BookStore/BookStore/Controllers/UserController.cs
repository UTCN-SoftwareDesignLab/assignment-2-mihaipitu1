﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        private IAdminService adminService;
        public UserController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public ActionResult Index()
        {
            var users = adminService.GetUsers();
            return View(users);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user, string adminSelect)
        {
            if (adminSelect.Equals(Database.Constants.Roles.ADMIN) && adminSelect != null)
            {
                user.SetRole(GetRoleFromRights(Database.Constants.Roles.ADMIN));
            }
            else
            {
                if (adminSelect.Equals(Database.Constants.Roles.EMPLOYEE))
                {
                    user.SetRole(GetRoleFromRights(Database.Constants.Roles.EMPLOYEE));
                }
            }
            adminService.CreateUser(user);
            return RedirectToAction("Index", "User");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = adminService.GetUserById(id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                adminService.UpdateUser(user);
                return RedirectToAction("Index", "User");
            }

            return StatusCode(400);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = adminService.GetUserById(id);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
            if (ModelState.IsValid)
            {
                bool x = adminService.DeleteUser(user);
                return RedirectToAction("Index", "User");
            }
            return StatusCode(404);
        }

        private Role GetRoleFromRights(string role)
        {
            List<Right> rights = new List<Right>();
            if (role == Database.Constants.Roles.ADMIN)
            {
                foreach (var right in Database.Constants.Rights.ADMIN_RIGHTS)
                {
                    rights.Add(new Right(right));
                }
            }
            else
            {
                foreach (var right in Database.Constants.Rights.USER_RIGHTS)
                {
                    rights.Add(new Right(right));
                }
            }
            return new Role(role, rights);
        }
    }
}