using AutoMapper;
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
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var leavetype = _repo.FindByID(id);
            var model = _mapper.Map<LeaveType, LeaveTypeVM>(leavetype);
            return View(model);
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
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var leavetype = _repo.FindByID(id);
            var model = _mapper.Map<LeaveType,LeaveTypeVM>(leavetype);
            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM Data)
        {
            try
            {   //Validation
                if (!ModelState.IsValid)
                {
                    return View(Data);
                }
                var model = _mapper.Map<LeaveTypeVM, LeaveType>(Data);
                var IsSuccess = _repo.Update(model);
                if (!IsSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(Data);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                if (!ModelState.IsValid)
                {
                    return View(Data);
                }
                return View();
            }
        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var leavetype = _repo.FindByID(id);
            var model = _mapper.Map<LeaveType, LeaveTypeVM>(leavetype);
            return View(model);
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LeaveType ToBeDeleted)
        {
            try
            {
                var delete = _repo.FindByID(id);
                if (delete == null)
                {
                    return NotFound();
                }
                //var model = _mapper.Map<LeaveType, LeaveTypeVM>(ToBeDeleted);
                var IsSuccess = _repo.Delete(delete);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
