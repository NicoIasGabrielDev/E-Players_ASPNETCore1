using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Players_ASPNETCore1.Models;
using Microsoft.AspNetCore.Http;

namespace E_Players_ASPNETCore1.Controllers
{
    public class NotíciasController : Controller
    {
        Notícias noticiasModel = new Notícias();
        public IActionResult Index()
        {
            ViewBag.Notícias = noticiasModel.ReadAll();
            return View();
        }
        public IActionResult Cadastrar(IFormCollection form)
        {
            Notícias novaNoticia = new Notícias();
            novaNoticia.IdNoticia = Int32.Parse(form ["IdNotícia"] );
            novaNoticia.Titulo = form["Título"];
            novaNoticia.Texto = form["Texto"];
            novaNoticia.Imagem = form["Imagem"];

            noticiasModel.Criar(novaNoticia);

            ViewBag.Noticias =noticiasModel.ReadAll();
            return LocalRedirect("~/Notícia");
        }
    }
}