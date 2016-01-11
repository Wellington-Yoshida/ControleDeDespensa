using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Dominio
{
    public class Loja : Cadastro
    {        
        public Loja()
        {
            this.Compras = new List<Compra>();
        }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }



        public virtual ICollection<Compra> Compras { get; set; }
    }
}
