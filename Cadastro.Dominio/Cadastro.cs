using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Dominio
{
    public abstract class Cadastro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Campo Obrigatorio!")]

        public string Nome { get; set; }
    }
}
