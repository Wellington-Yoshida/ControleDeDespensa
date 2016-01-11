using Cadastro.BO.Interface;
using Cadastro.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.BO
{
    public interface ICadastroBo : IsValidator<Compra>
    {
        void Adicionar(Compra compra);

        void Editar(Compra compra);

        void Deletar(int Id);

        
       
    }
}
