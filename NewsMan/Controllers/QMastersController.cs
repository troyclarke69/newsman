using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsMan.Data.Data;
using NewsMan.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NewsMan.ViewModels
{
    public class QMastersController : Controller
    {
        private readonly NewsManDbContext _context;

        public QMastersController(NewsManDbContext context)
        {
            _context = context;
        }

        // GET: QMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.QMaster.ToListAsync());
        }

        // GET: QMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMaster = await _context.QMaster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qMaster == null)
            {
                return NotFound();
            }

            return View(qMaster);
        }

        // GET: QMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Level,Order,Question")] QMaster qMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qMaster);
        }

        // GET: QMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMaster = await _context.QMaster.FindAsync(id);
            if (qMaster == null)
            {
                return NotFound();
            }
            return View(qMaster);
        }

        // POST: QMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Level,Order,Question")] QMaster qMaster)
        {
            if (id != qMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QMasterExists(qMaster.Id))
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
            return View(qMaster);
        }

        // GET: QMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qMaster = await _context.QMaster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qMaster == null)
            {
                return NotFound();
            }

            return View(qMaster);
        }

        // POST: QMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qMaster = await _context.QMaster.FindAsync(id);
            _context.QMaster.Remove(qMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QMasterExists(int id)
        {
            return _context.QMaster.Any(e => e.Id == id);
        }
    }
}
