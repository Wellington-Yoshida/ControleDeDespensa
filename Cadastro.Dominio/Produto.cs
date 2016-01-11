using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Dominio
{
    public class Produto : Cadastro
    {
        private DateTime _dataValidade;
        [Display(Name = "Data de Validade")]
	    [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]
        public DateTime DataValidade 
        {
            get { return _dataValidade; } 
            set
            {
                if (value > DateTime.Now)
                {
                    _dataValidade = value;
                }
                else
                {
                    _dataValidade = DateTime.Now;
                }
            }
        }
        
                 
        public string Marca { get; set; }

        
        
        private int _quatidadeDoItem;
        [Display(Name = "Quantidade do Item")]
        public int QuantidadeDoItem 
        { 
            get
            { return this._quatidadeDoItem; }
            
            set
            {
                if (value > 0)
                {
                    _quatidadeDoItem = value;
                }
                else
                {
                    _quatidadeDoItem = 0;
                }
            }
        }

        public int CompraId { get; set; }
        public Compra Compra { get; set; } // Criando relação com a classe Compra de 1 para muitos.

        
        
    }
}
