﻿using AutoMapper;
using Leave_Management.Contracts;
using Leave_Management.Data;
using Leave_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Leave_Management.Controllers
{
    public class LeaveTypesController : Controller
    {   //interface leaveTypes
        private readonly ILeaveTypeReposiory _repo;
        private readonly IMapper _mapper;
        //dependency Injection
        public LeaveTypesController(ILeaveTypeReposiory repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: LeaveTypesController
        public ActionResult Index()
        {
            var leavetype = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LeaveType>,List<LeaveTypeVM>>(leavetype); 
            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM Data)
        {
            try
            {
                //Validation
                if(!ModelState.IsValid) { 
                    return View(Data);
                }
                var model = _mapper.Map <LeaveTypeVM,LeaveType>(Data);
                model.DateCreated= DateTime.Now; 

                var IsSuccess = _repo.Create(model);
                if (!IsSuccess)
                {
                    ModelState.AddModelError("","Something went wrong");
                    return View(Data);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(Data);
            }
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            //var NewData = new LeaveType.Get
            return View();
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
