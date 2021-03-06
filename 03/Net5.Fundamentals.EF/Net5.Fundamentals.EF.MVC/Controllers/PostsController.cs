using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Net5.Fundamentals.EF.CodeFirst.Data.Contexts;
using Net5.Fundamentals.EF.CodeFirst.Data.Entities;

namespace Net5.Fundamentals.EF.MVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly Net5FundamentalsEFDatabaseContext _context;

        public PostsController(Net5FundamentalsEFDatabaseContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var net5FundamentalsEFDatabaseContext = _context.Posts.Include(p => p.UsuarioIdActualizacionNavigation).Include(p => p.UsuarioIdCreacionNavigation).Include(p => p.UsuarioIdPropietarioNavigation);
            return View(await net5FundamentalsEFDatabaseContext.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.UsuarioIdActualizacionNavigation)
                .Include(p => p.UsuarioIdCreacionNavigation)
                .Include(p => p.UsuarioIdPropietarioNavigation)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["UsuarioIdActualizacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno");
            ViewData["UsuarioIdCreacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno");
            ViewData["UsuarioIdPropietario"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Titulo,Contenido,UsuarioIdPropietario,UsuarioIdCreacion,FechaCreacion,UsuarioIdActualizacion,FechaActualizacion")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioIdActualizacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdActualizacion);
            ViewData["UsuarioIdCreacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdCreacion);
            ViewData["UsuarioIdPropietario"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdPropietario);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["UsuarioIdActualizacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdActualizacion);
            ViewData["UsuarioIdCreacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdCreacion);
            ViewData["UsuarioIdPropietario"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdPropietario);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Titulo,Contenido,UsuarioIdPropietario,UsuarioIdCreacion,FechaCreacion,UsuarioIdActualizacion,FechaActualizacion")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
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
            ViewData["UsuarioIdActualizacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdActualizacion);
            ViewData["UsuarioIdCreacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdCreacion);
            ViewData["UsuarioIdPropietario"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdPropietario);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.UsuarioIdActualizacionNavigation)
                .Include(p => p.UsuarioIdCreacionNavigation)
                .Include(p => p.UsuarioIdPropietarioNavigation)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
