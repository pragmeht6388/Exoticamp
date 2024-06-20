using Exoticamp.UI.AuthFilter;
using Exoticamp.UI.Models.Registration;
using Exoticamp.UI.Models.Users;
using Exoticamp.UI.Services.IRepositories;
using Exoticamp.UI.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    [AdminAuthFilter]
    [NoCache]
    public class AdminController : Controller
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IUsersRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        public AdminController(IUsersRepository userRepository, IRegistrationRepository registrationRepository, ILocationRepository locationRepository)
        {
            _userRepository = userRepository;
            _registrationRepository = registrationRepository;
            _locationRepository = locationRepository;
        }
        [HttpGet]
       
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return View(users);
        }

         
        [HttpGet]

        public async Task<IActionResult> GetAllVendors()
        {
             
            var users = await _userRepository.GetAllVendorsAsync();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> CreateVendor( )
        {
            ViewBag.Locations = await _locationRepository.GetAllLocations();
            return View( );
        }



         
        public async Task<IActionResult> CreateVendor(VendorRegistrationVM registrationVM)
        {
            if (ModelState.IsValid)
            {
                // Define base paths for the different file types
                var idCardBasePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/User/");
                var licenseBasePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/User/");
                var addressProofBasePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/User/");
                var othersBasePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/User/");

                // Ensure directories exist
                Directory.CreateDirectory(idCardBasePath);
                Directory.CreateDirectory(licenseBasePath);
                Directory.CreateDirectory(addressProofBasePath);
                Directory.CreateDirectory(othersBasePath);

                // Handle file uploads
                if (registrationVM.IDCardFile != null)
                {
                    var idCardFileName = Path.GetFileName(registrationVM.IDCardFile.FileName);
                    var idCardFilePath = Path.Combine(idCardBasePath, idCardFileName);
                    registrationVM.IDCard = "/Assets/Images/User/" + idCardFileName;
                    using (var idCardFileStream = new FileStream(idCardFilePath, FileMode.Create))
                    {
                        await registrationVM.IDCardFile.CopyToAsync(idCardFileStream);
                    }
                }

                if (registrationVM.LicenseFile != null)
                {
                    var licenseFileName = Path.GetFileName(registrationVM.LicenseFile.FileName);
                    var licenseFilePath = Path.Combine(licenseBasePath, licenseFileName);
                    registrationVM.License = "/Assets/Images/User/" + licenseFileName;
                    using (var licenseFileStream = new FileStream(licenseFilePath, FileMode.Create))
                    {
                        await registrationVM.LicenseFile.CopyToAsync(licenseFileStream);
                    }
                }

                if (registrationVM.AddressProofFile != null)
                {
                    var addressProofFileName = Path.GetFileName(registrationVM.AddressProofFile.FileName);
                    var addressProofFilePath = Path.Combine(addressProofBasePath, addressProofFileName);
                    registrationVM.AddressProof = "/Assets/Images/User/" + addressProofFileName;
                    using (var addressProofFileStream = new FileStream(addressProofFilePath, FileMode.Create))
                    {
                        await registrationVM.AddressProofFile.CopyToAsync(addressProofFileStream);
                    }
                }

                if (registrationVM.OthersFile != null)
                {
                    var othersFileName = Path.GetFileName(registrationVM.OthersFile.FileName);
                    var othersFilePath = Path.Combine(othersBasePath, othersFileName);
                    registrationVM.Others = "/Assets/Images/User/" + othersFileName;
                    using (var othersFileStream = new FileStream(othersFilePath, FileMode.Create))
                    {
                        await registrationVM.OthersFile.CopyToAsync(othersFileStream);
                    }
                }

                // Pass selected location ID
                registrationVM.LocationId = registrationVM.LocationId;

                var result = await _registrationRepository.CreateVendorRegistration(registrationVM);

                if (result.Message != null)
                {
                    TempData["Message"] = result.Message;
                    return View(registrationVM);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the User.");
                }

                return RedirectToAction("Login");
            }

            return View(registrationVM);
        }


        public async Task<IActionResult> IsDeleteUser(string Email)
        {
            var users = await _userRepository.IsDeleteAsync(Email);

            return RedirectToAction("GetAllUsers");
        }

        public async Task<IActionResult> IsDeleteVendor(string Email)
        {
            var users = await _userRepository.IsDeleteAsync(Email);

            return RedirectToAction("GetAllVendors");
        }


        #region ShowUserProfile
        [HttpGet]
        public async Task<IActionResult> ShowUser(string id)
        {
            // Retrieve user details based on the provided ID
            var userDetails = await _userRepository.GetUserByIdAsync(id);

            if (userDetails.data != null)
            {
                return View(userDetails.data);
            }
            else
            {
                // Handle case where user with specified ID is not found
                TempData["Message"] = $"User with ID '{id}' not found.";
                return RedirectToAction("GetAllUsers"); // Redirect to a list of users or handle as appropriate
            }
        }


        #endregion
        #region ShowVendorProfile
        [HttpGet]
        public async Task<IActionResult> ShowVendor(string id)
        {
            // Retrieve user details based on the provided ID
            var userDetails = await _userRepository.GetVendorByIdAsync(id);

            if (userDetails.data != null)
            {
                return View(userDetails.data);
            }
            else
            {
                // Handle case where user with specified ID is not found
                TempData["Message"] = $"User with ID '{id}' not found.";
                return RedirectToAction("GetAllVendors"); // Redirect to a list of users or handle as appropriate
            }
        }


        #endregion
        public async Task<IActionResult> IsLockedUsers(string Email)
        {
            var users = await _userRepository.IsLockedUsersAsync(Email);
           return RedirectToAction("GetAllUsers", "Admin");
            //return Json(new { success = true, message = "Vendor deleted successfully." });
        }

        public async Task<IActionResult> IsLockedVendor(string Email)
        {
            var users = await _userRepository.IsLockedUsersAsync(Email);
            return RedirectToAction("GetAllVendors", "Admin");
            //return Json(new { success = true, message = "Vendor deleted successfully." });
        }


    }
}
