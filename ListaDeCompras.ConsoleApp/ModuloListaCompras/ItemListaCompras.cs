using System.Security.Cryptography;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.ModuloListaCompras;

public class ItemListaCompras
{
    public string Id { get; set; }
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
    public decimal Valor
    {
        get
        {
            return Produto.ValorAproximado * Quantidade;
        }
    }

    public ItemListaCompras()
    {        
    }

    public ItemListaCompras(Produto produto, int quantidade)
    {
        Id = Convert
                .ToHexString(RandomNumberGenerator.GetBytes(4))
                .ToLower()
                .Substring(0, 7);

        Produto = produto;
        Quantidade = quantidade;
    }
}