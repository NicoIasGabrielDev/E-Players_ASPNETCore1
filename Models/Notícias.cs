using System;
using System.Collections.Generic;
using System.IO;
using E_Players_ASPNETCore1.Interfaces;

namespace E_Players_ASPNETCore1.Models
{
    public class Notícias:EPlayersBase , INotícias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/notícias.csv";
        public Notícias(){
           CreateFolderAndFile(PATH);
        }
        private string PrepararLinha(Notícias n){
            return $"{n.IdNoticia};{n.Titulo};{n.Imagem}";
        }

        public void Criar(Notícias n)
        {
            string[] linha = { PrepararLinha(n) };
            File.AppendAllLines(PATH, linha);
        }

        public List<Notícias> ReadAll()
        {
            List<Notícias> noticias = new List<Notícias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas){
                string[] linha = item.Split(";");
                Notícias noticia = new Notícias();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Imagem = linha[2];

                noticias.Add(noticia);
            }
            return noticias;
        }

        public void Update(Notícias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add(PrepararLinha(n));
            RewriteCSV(PATH, linhas);
        }

        public void Delete(int idNotícia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(n => n.Split(";")[0] == idNotícia.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}