using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using AstrolojiApp.Business.Abstract;
using AstrolojiApp.Shared.Dtos;

namespace AstrolojiApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
    private readonly IContactService  _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: ContactController
        public async Task<ActionResult> Index()
        {
            var contact = await _contactService.GetContacAsync();
            return View(contact);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            
            var updateDto = new ContactUpdateDto
            {
                Id = contact.Id,
                Address = contact.Address,
                PhoneNumber = contact.PhoneNumber,
                Icon = contact.Icon,
                Map = contact.Map
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ContactUpdateDto  contactUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var contact = await _contactService.UpdateAsync(contactUpdateDto);
                
            return RedirectToAction("Index", "Contact");
            }
             return View(contactUpdateDto);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ContactCreateDto());
        }

        [HttpPost]

        public async Task<IActionResult> Add(ContactCreateDto  contactCreateDto)
        {   
            if (ModelState.IsValid)
            {
                var contact = await _contactService.CreateAsync(contactCreateDto);

                return RedirectToAction("Index", "Contact");
            }
            return View(contactCreateDto);
            
        }

        [HttpGet]
        public  async Task<IActionResult> Delete(int id)
        {
             await _contactService.DeleteAsync(id);

            return RedirectToAction("Index", "Contact");
        }

    }
}
