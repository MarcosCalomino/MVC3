using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClienteController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Crear(int? id)//CON ESTE SIGNO DE PREGUNTA SE ESTÁ DICIENDO QUE SE ACEPTAN VALORES NULOS
        {
            Cliente cliente = new Cliente();
            if (id == null)
            {
                return View(cliente);
            }
            else
            {
                cliente = await _db.Cliente.FindAsync(id);
                return View(cliente);
            }
            
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]//SEGURIDAD PARA METODO POST
        public async Task<IActionResult> Crear(Cliente cliente)
        {
            if (ModelState.IsValid)//VERIFICA QUE EL MODELO QUE LLEGUE SEA VALIDO, OSEA NO TIENE NINGUN ERROR
            {
                if (cliente.Id==0)//SI Id=0 crea el registro
                {
                    await _db.Cliente.AddAsync(cliente);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Crear));
                }
                else
                {
                    _db.Cliente.Update(cliente);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Crear), new {id=0});
                }
             
            }
            return View(cliente);
        }


        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _db.Cliente.ToListAsync();
            return Json(new  { data = todos}); /*POR MEDIO DE JS ACOMODO LOS CLIENTES LA TABLE*/
        }
    }
}
