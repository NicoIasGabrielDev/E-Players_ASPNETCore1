using System.Collections.Generic;
using E_Players_ASPNETCore1.Models;

namespace E_Players_ASPNETCore1.Interfaces
{
    public interface IEquipe
    {
        //Criar
        void Criar(Equipe e);
        //Ler
       List<Equipe> ReadAll();
        //Alterar
        void Update(Equipe e);
        
        //Excluir
        void Delete(int idEquipe);
    }
}