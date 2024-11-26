using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NeptunoDataBd.Models; 
using NeptunoDataBd.DAO;

namespace NeptunoDataBd.Controllers
{
    public class ClientesController : Controller
    {
        ClientesDao clientesDao = new ClientesDao();
        // GET: Clientes
        public ActionResult ListadoClientes()
        {
            var listado = clientesDao.ListarClientes();
            return View(listado);
        }
    }
}