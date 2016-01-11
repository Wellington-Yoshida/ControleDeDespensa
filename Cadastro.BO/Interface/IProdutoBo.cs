using Cadastro.BO.Interface;
using Cadastro.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.BO
{
    public interface IProdutoBo : IsValidator<Produto>
    {
        void Adicionar(Produto produto);

        void Editar(Produto produto);

        void Deletar(int Id);
    }
}
