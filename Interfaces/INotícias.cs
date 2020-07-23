using System.Collections.Generic;
using E_Players_ASPNETCore1.Models;

namespace E_Players_ASPNETCore1.Interfaces
{
    public interface INotícias
    {
        //Criar
        void Criar(Notícias n);
        //Ler
        List<Notícias> ReadAll();
        //Alterar
        void Update(Notícias n);
        
        //Excluir
        void Delete(int idNotícia);
    }
}