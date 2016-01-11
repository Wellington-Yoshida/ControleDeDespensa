using Cadastro.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.BO.Interface
{
    public interface ILojaBo : IsValidator<Loja>
    {
        void Adicionar(Loja loja);

        void Editar(Loja loja);

        void Deletar(int Id);
    }
}
