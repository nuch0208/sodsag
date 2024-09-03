using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sodsag.Data;
using sodsag.Models;


namespace sodsag.Controllers
{

    public class NurseRequestController : Controller
    {
        private readonly AppicationDbContext context;
        public NurseRequestController(AppicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string searchString)
        {
            Response.Headers.Add("Refresh","15");

            List<NurseRequest> NurseRequests;
            var nurserequest = context.NurseRequests.Include(x=>x.Patients).OrderByDescending(p => p.JobId).ToList();

            if(!String.IsNullOrEmpty(searchString))
            {
                nurserequest = nurserequest.Where(n => n.StartPoint.ToLower().Contains(searchString)).ToList();
            }
            
            return View(nurserequest);

        }

      [HttpGet]
      public IActionResult Create()
        {
            NurseRequest nurseRequest = new NurseRequest();
            nurseRequest.Patients.Add(new Patient() {Id = 1 });

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
            context.Add(nurseRequest);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
     }
}