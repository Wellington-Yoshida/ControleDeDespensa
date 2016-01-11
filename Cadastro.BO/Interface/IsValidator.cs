using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.BO.Interface
{
    public interface IsValidator<T> where T : class
    {
        bool IsValidacao(T domain);
    }
}
