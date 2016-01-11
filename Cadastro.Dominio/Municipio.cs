using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Dominio
{
    public class Municipio
    {
        public int MunicipioId { get; set; }
        public string Nome { get; set; }
        public Estado Estado { get; set; }
        public int EstadoId { get; set; }
    }
}
