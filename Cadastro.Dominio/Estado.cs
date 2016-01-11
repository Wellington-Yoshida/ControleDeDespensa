using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Dominio
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
