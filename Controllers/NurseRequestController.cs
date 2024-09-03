using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sodsag.Data;
using sodsag.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace sodsag.Controllers
{

    public class NurseRequestController : Controller
    {
        private readonly AppicationDbContext _context;
        public NurseRequestController(AppicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var nurserequest = _context.Patients.Include(x=>x.NurseRequest).ToList();
            return View(nurserequest);

        }

      [HttpGet]
      public IActionResult Create()
        {
            NurseRequest nurseRequest = new NurseRequest();
            nurseRequest.Patients.Add(new Patient() {Id = 1 });
            // nurseRequest.Patients.Add(new Patient() {Id = 2 });
            // nurseRequest.Patients.Add(new Patient() {Id = 3 });
            return View(nurseRequest);
        }

        [HttpPost]
        public IActionResult Create(NurseRequest nurseRequest)
        {
            foreach(Patient patient in nurseRequest.Patients)
            {
                if (patient.Qn == null || patient.Qn.Length == 0)
                    nurseRequest.Patients.Remove(patient);
            }
            _context.Add(nurseRequest);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
         public IActionResult Edit(int id, NurseRequestDto nurseRequestDto) 
         {
            var nurseRequest = _context.NurseRequests.Find(id); 
            if(nurseRequest == null) 
            {
                return RedirectToAction("Index", "NurseRequest");
            }
            if (ModelState.IsValid)
            {
                ViewData["NurseRequestId"] = nurseRequest.JobId;   
                return View(nurseRequestDto); 
            }

            _context.SaveChanges(); 

            return RedirectToAction("Index", "NurseRequest");
         }
     }
}