using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A4AeroTest.Areas.BusinessEntities.Models;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace A4AeroTest.Areas.BusinessEntities.Controllers
{
    [Area("BusinessEntities")]
    public class BusinessEntitiesController : Controller
    {
        private readonly IBusinessEntitiesService businessEntitiesService;
        public BusinessEntitiesController(IBusinessEntitiesService businessEntitiesService)
        {
            this.businessEntitiesService = businessEntitiesService;
        }
        public IActionResult Index(int? id)
        {
            if (id > 0)
            {
                ViewBag.id = id;
            }
            else
            {
                ViewBag.id = 0;
            }
           
            return View();
        }


        public async Task<IActionResult> List()
        {

            var result= await businessEntitiesService.GetAll();
            return View(result);
        }

        public async Task<IActionResult> GetAll()
        {
           

            var result = await businessEntitiesService.GetAll();
            return Json(result);
        }

        public async Task<IActionResult> GetById(int id)
        {


            var result = await businessEntitiesService.GetById(id);
            return Json(result);
        }

        public async Task<IActionResult> Delete(int id)
        {
          await  businessEntitiesService.DeleteById(id);
          return Json(true);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(BusinessEntitiesViewModel model)
        {
            int returnId = 0;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                BusinessEntity entity = new BusinessEntity
                {
                    Id=model.Id,
                    Code=model.Code,
                    Name=model.Name,
                    Email=model.Email,
                    Street=model.Street,
                    City=model.City,
                    State=model.State,
                    Mobile=model.Mobile,
                    Phone=model.Phone,
                    Status=1,
                    Balance=100,
                    LoginUrl="",
                   SMTPPort=1,
                   CreatedOnUtc=DateTime.UtcNow,
                   UpdatedOnUtc=DateTime.UtcNow,
                   Deleted=false

                };
               returnId= await businessEntitiesService.Save(entity);
            }
            return RedirectToAction(nameof(List));
        }
        public IActionResult GetAutoCode()
        {
            
            return Json(businessEntitiesService.GetAutoCode());
        }
    }
}