using System.Collections;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.ModuloProduto;

public class TelaProduto : TelaBase<Produto>, ITelaOpcoes, ITelaCrud
{
    private RepositorioCategoria repositorioCategoria;
    public TelaProduto(RepositorioProduto repositorio, RepositorioCategoria repositorioCategoria) : base("Produto", repositorio)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Produtos");

        List<Produto> produtos = repositorio.SelecionarTodos();

        if (produtos.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Não existe nenhum registro de produto.");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -10} | {4, -10}",
            "Id", "Nome", "Categoria", "Unidade", "Preço"
        );

        foreach (Produto p in produtos)
        {
            Console.WriteLine(
               "{0, -7} | {1, -20} | {2, -10} | {3, -10} | {4, -10}",
                 p.Id, p.Nome, p.Categoria.Nome, p.UnidadeMedida, p.ValorAproximado
        );

            Console.Write("{0, -7} | ", p.Id);
            Console.Write("{0, -20} | ", p.Nome);

            string corCategoria = p.Categoria.Cor;

            if (corCategoria == "Vermelho")
                Console.ForegroundColor = ConsoleColor.Red;

            else if (corCategoria == "Verde")
                Console.ForegroundColor = ConsoleColor.Green;

            else if (corCategoria == "Azul")
                Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("{0, -10} | ", p.Categoria.Nome);
            Console.ResetColor();

            Console.Write("{0, -10} | ", p.UnidadeMedida);
            Console.Write("{0, -10} | ", p.ValorAproximado);
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Produto ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine() ?? string.Empty;

        // string? idCategoria = SelecionarCategorias();

        // if (idCategoria == null)
        // {
        //     Console.ForegroundColor = ConsoleColor.Yellow;
        //     Console.Write("Não existe nenhum registro.");
        //     Console.ResetColor();
        //     Console.WriteLine("---------------------------------");
        //     Console.Write("Digite ENTER para continuar...");
        //     Console.ReadLine();
        //     return;????????
        // }
        // Console.Write("Digite o ID da categoria do produto: ");

        // Categoria? categoriaSelecionada = (Categoria?)repositorioCategoria.SelecionarPorId(idCategoria);

        // if (categoriaSelecionada == null)
        //     throw new NullReferenceException("Não foi possível obter o registro selecionado {Caixa}.");

        // return new Revista(titulo, numeroEdicao, anoPublicacao, caixaSelecionada);

        Console.Write("Digite a unidade de medida do produto (kg, unidade, litro, caixa): ");
        string unidadeMedida = Console.ReadLine() ?? string.Empty; // Pode ser assim?

        Console.Write("Digite o valor do produto: ");
        decimal valorAproximado = Convert.ToDecimal(Console.ReadLine()); // Pode ser assim?


    }

    private string? SelecionarCategorias()
    {
        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        if (categorias.Count == 0)
        {
            return null;
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Nome", "Cor"
        );

        foreach (Categoria c in categorias)
        {
            string corSelecionada = c.Cor;

            if (corSelecionada == "Vermelho")
                Console.ForegroundColor = ConsoleColor.Red;

            else if (corSelecionada == "Verde")
                Console.ForegroundColor = ConsoleColor.Green;

            else if (corSelecionada == "Azul")
                Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10}",
                c.Id, c.Nome, c.Cor
            );
        }

        Console.ResetColor();

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o ID da categoria:  ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        return idSelecionado;
    }
}
