﻿using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel addRoleViewModel)
        {
            AppRole appRole = new AppRole()
            {
                Name = addRoleViewModel.RoleName
            };
            var result = await _roleManager.CreateAsync(appRole);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values =  _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
            {
                RoleName = values.Name,
                RoleID = values.Id
            };
            return View(updateRoleViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
            var values = _roleManager.Roles.FirstOrDefault(x=>x.Id == updateRoleViewModel.RoleID);
            values.Name = updateRoleViewModel.RoleName;
            await _roleManager.UpdateAsync(values);
            return RedirectToAction("Index");
        }
    }
}
