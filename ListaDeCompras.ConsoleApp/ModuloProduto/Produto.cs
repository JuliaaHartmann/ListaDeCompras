using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.ModuloProduto;

public class Produto : EntidadeBase
{
    public string Nome { get; set; }
    public string UnidadeMedida { get; set; }
    public decimal ValorAproximado { get; set; }
    public Categoria Categoria { get; set; }

    public Produto()
    {        
    }

    public Produto(string nome, string unidadeMedida, decimal valorAproximado, Categoria categoria)
    {
        Nome = nome;
        UnidadeMedida = unidadeMedida;
        ValorAproximado = valorAproximado;
        Categoria = categoria;
    }
    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        if (string.IsNullOrWhiteSpace(UnidadeMedida))
            erros.Add("O campo \"Unidade de Medida\" deve ser preenchido.");

        if (ValorAproximado == 0)
            erros.Add("O campo \"Preço Aproximado\" deve ser preenchido.");

        return erros;
    }
    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;
        
        Nome = produtoAtualizado.Nome;
        UnidadeMedida = produtoAtualizado.UnidadeMedida;
        ValorAproximado = produtoAtualizado.ValorAproximado;
        Categoria = produtoAtualizado.Categoria;
    }

}
