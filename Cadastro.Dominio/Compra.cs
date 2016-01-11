using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Dominio
{
   
    public class Compra : Cadastro
    {
        public Compra()
        {
            this.Produtos = new List<Produto>();
        }

        private DateTime _dataCompra;
        [Display(Name = "Data da Compra")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataCompra 
        {
            get { return _dataCompra; }
            set
            {
                if (value <= DateTime.Now)
                {
                    _dataCompra = value;
                }
                else
                {
                    _dataCompra = DateTime.Now;
                }
            }
        }
                
        public Produto Produto { get; set; }

        public int LojaId { get; set; } 
        public Loja Loja { get; set; }


        
        private int _quatidade;
        [Display(Name = "Quantidade de Itens Comprados")]
        public int Quantidade 
        {
            get { return _quatidade; }
            set
            {
                if (value < 0)
                {
                    _quatidade = 0;
                }
                else
                {
                    _quatidade = value;
                }
            }
        }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
