using System.Text.Json;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloListaCompras;
using ListaDeCompras.ConsoleApp.Utilidades;

string caminhoDownloads = "C:\\Users\\julia\\Downloads";
string caminhoArquivo = caminhoDownloads + "\\categoria.json";

Categoria categoria = new Categoria("Café", CorCategoria.Vermelha);
Categoria categoria2 = new Categoria("Padaria", CorCategoria.Branca);

List<Categoria> categorias = [categoria, categoria2];

JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
opcoesJson.WriteIndented = true;
opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

string jsonString = JsonSerializer.Serialize(categorias, opcoesJson);

File.WriteAllText(caminhoArquivo, jsonString);

return;

TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{
    ITelaOpcoes? telaSelecionada = telaPrincipal.ApresentarMenuOpcoesPrincipal();

    if (telaSelecionada == null)
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoSubMenu = telaSelecionada.ObterOpcaoMenu();

        if (opcaoSubMenu == "S")
        {
            Console.Clear();
            break;
        }

        if (telaSelecionada is ITelaCrud telaCrud)
        {
            if (opcaoSubMenu == "1")
                telaCrud.Cadastrar();

            else if (opcaoSubMenu == "2")
                telaCrud.Editar();

            else if (opcaoSubMenu == "3")
                telaCrud.Excluir();

            else if (opcaoSubMenu == "4")
                telaCrud.VisualizarTodos(deveExibirCabecalho: true);

            if (telaCrud is TelaListaCompras telaListaCompras)
            {
                if (opcaoSubMenu == "5")
                    telaListaCompras.AdicionarItem();
                
                else if (opcaoSubMenu == "6")
                    telaListaCompras.RemoverItem();
                
                else if (opcaoSubMenu == "7")
                    telaListaCompras.VisualizarItens();
            }
        }
    }
}