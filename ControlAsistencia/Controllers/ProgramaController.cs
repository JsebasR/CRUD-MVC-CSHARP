using ControlAsistencia.Data;
using ControlAsistencia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ControlAsistencia.Controllers
{
    public class ProgramaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public string draw = "";
        public string start = "";
        public string length = "";
        public string stortColumn = "";
        public string stortColumnDir = "";
        public string searchValue = "";
        public int pageSize, skip, recordsTotal;

        public ProgramaController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: ProgramaController
        public ActionResult Index()
        {
            return View();
        }
        //
        //
        [HttpPost]
        public IActionResult Json()
        {
            List<Programa> lst = new List<Programa>();

            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue= Request.Form["search[value]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            using(_context)
            {
                IQueryable<Programa> query = (from p in _context.Programa
                                              select p).Where(e => e.Estado == true);

                if(searchValue != "")
                {
                    query = query.Where(p => p.Nombre.Contains(searchValue));
                }
                if(!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    query = query.OrderBy(sortColumn + " " + sortColumnDirection);
                }
                recordsTotal = query.Count();
                lst = query.Skip(skip).Take(pageSize).ToList();
            }
            return Json( new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = lst });

        }

        

        [HttpGet]
        public IActionResult LoadDataTable()
        {
            return Json(new { data = _context.Programa.ToList().Where(p => p.Estado == true) });
        }
        
       

        //
        // GET: ProgramaController/Details/5
        public ActionResult Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var programa = _context.Programa.FirstOrDefault(p => p.ProgramaId == id);

            if(programa == null)
            {
                return NotFound();
            }
            return View(programa);
        }

        // GET: ProgramaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgramaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ProgramaId,Nombre,Version,Codigo")]Programa programa)
        {
            if(ModelState.IsValid)
            {
                _context.Add(programa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
                return View(programa);
            
        }

        // GET: ProgramaController/Edit/5
        public IActionResult Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var programa = _context.Programa.Find(id);
            if(programa == null)
            {
                return NotFound();
            }
            return View(programa);
        }

        // POST: ProgramaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ProgramaId,Nombre,Version,Codigo")] Programa programa)
        {
           if(id != programa.ProgramaId)
            {
                return NotFound();
            }

           if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(programa);
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramaExists(programa.ProgramaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(programa);           
        }

        private bool ProgramaExists(int programaId)
        {
            return _context.Programa.Any(e => e.ProgramaId == programaId);
        }

        //// GET: ProgramaController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    if(id == null)
        //    {
        //        return NotFound();
        //    }
        //    var programa = _context.Programa.FirstOrDefault(p => p.ProgramaId == id);
        //    if(programa == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(programa);
        //}

        // POST: ProgramaController/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var programa = _context.Programa.Find(id);

        //    programa.Estado = false;
        //    _context.Update(programa);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _context.Programa.Find(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error Borrando el Programa de Formación" });
            }
            objFromDb.Estado = false;
            _context.Update(objFromDb);
            _context.SaveChanges();
            return Json(new { success = true, message = "Programa de Formación Borrado Correctamente" });

        }

    }
}
