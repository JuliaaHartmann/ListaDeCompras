using System;
using System.Dynamic;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.ModuloProduto;

public class Produto : EntidadeBase
{
    public string Nome { get; private set; }
    public string UnidadeMedida { get; private set; }
    public decimal ValorAproximado { get; private set; }
    public Categoria Categoria { get; private set; }

    public Produto(string nome, string unidadeMedida, decimal valorAproximado, Categoria categoria)
    {
        Nome = nome;
        UnidadeMedida = unidadeMedida;
        ValorAproximado = valorAproximado;
        Categoria = categoria;
    }
    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Nome.Length < 2 || Nome.Length > 100)
            erros += "O campo \"Nome\" deve conter entre 2 e 100 caracteres;";

        if (string.IsNullOrWhiteSpace(UnidadeMedida))
            erros += "O campo \"Unidade de Medida\" deve ser preenchido;";

        if (ValorAproximado <= 0)
            erros += "O campo \"Valor Aproximado\" deve ser maior que zero;";

        if (Categoria == null)
            erros += "O campo \"Categoria\" é obrigatório;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}
