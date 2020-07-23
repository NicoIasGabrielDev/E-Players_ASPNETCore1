using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Players_ASPNETCore1.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

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


            // Upload Início
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Notícias");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novaNoticia.Imagem   = file.FileName;
            }
            else
            {
                novaNoticia.Imagem   = "padrao.png";
            }
            // Upload Final

            noticiasModel.Criar(novaNoticia);

            ViewBag.Noticias =noticiasModel.ReadAll();
            return RedirectToAction("Index");
        }

        [Route("[controller]/{id}")]
        public IActionResult Excluir(int id){
            noticiasModel.Delete(id);
            ViewBag.Equipes = noticiasModel.ReadAll();
            return RedirectToAction("Index");

        }
    }
}