﻿using Exoticamp.UI.Models.Users;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class UserController(IUsersRepository _usersRepository, ILocationRepository _locationRepository, IActivitiesRepository _activitiesRepository) : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Profile()
        {
            var UserId = HttpContext.Session.GetString("UserId");
            ViewBag.Locations = await _locationRepository.GetAllLocations();
            var userDetails = await _usersRepository.GetUserByIdAsync(UserId);
            ViewBag.Preferences = await _activitiesRepository.GetAllActivities();

            if (userDetails.data != null)
            {
                return View(userDetails.data);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UsersVM user)
        {
            user.Id = HttpContext.Session.GetString("UserId");
            var userId = await _usersRepository.UpdateProfile(user);
            if (userId == null)
            {
                return View(user);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
