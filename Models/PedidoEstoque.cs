//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgroCoops.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PedidoEstoque
    {
        public int IDPedido { get; set; }
        public int IDProduto { get; set; }
        public int IDCooperativa { get; set; }
        public int IDPessoa { get; set; }
        public int Quantidade { get; set; }
        public string ObservacaoProduto { get; set; }
    
        public virtual Cooperativa Cooperativa { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
