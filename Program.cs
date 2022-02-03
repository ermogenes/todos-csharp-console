bool sair = false;
while (!sair)
{
    string opcao = UI.SelecionaOpcaoEmMenu();

    switch (opcao)
    {
        case "L": ListarTodasAsTarefas(); break;
        case "I": ListarTarefasPorId(); break;
        case "T": ListarTarefasPorTitulo(); break;
        case "N": IncluirNovaTarefa(); break;
        case "A": AlterarTituloDaTarefa(); break;
        case "C": ConcluirTarefa(); break;
        case "E": ExcluirTarefa(); break;

        case "S":
            sair = true;
            break;

        default:
            UI.ExibeErro("\nOpção não reconhecida.");
            break;
    }

    Console.Write("\nPressione uma tecla para continuar...");
    Console.ReadKey();
}

void ListarTodasAsTarefas() {
    UI.ExibeDestaque("\n-- Listar todas as Tarefas ---");
    // Continue daqui
}

void ListarTarefasPorTitulo()
{
    UI.ExibeDestaque("\n-- Listar Tarefas por Título ---");
    string titulo = UI.SelecionaTitulo();
    // Continue daqui
    Console.WriteLine(titulo);
}

void ListarTarefasPorId()
{
    UI.ExibeDestaque("\n-- Listar Tarefas por Id ---");
    int id = UI.SelecionaId();
    // Continue daqui
    Console.WriteLine(id);
}

void IncluirNovaTarefa()
{
    UI.ExibeDestaque("\n-- Incluir Nova Tarefa ---");
    string titulo = UI.SelecionaTitulo();
    // Continue daqui
    Console.WriteLine(titulo);
}

void AlterarTituloDaTarefa()
{
    UI.ExibeDestaque("\n-- Alterar Título da Tarefa ---");
    int id = UI.SelecionaId();
    string titulo = UI.SelecionaTitulo();
    // Continue daqui
    Console.WriteLine(id);
    Console.WriteLine(titulo);
}

void ConcluirTarefa()
{
    UI.ExibeDestaque("\n-- Concluir Tarefa ---");
    int id = UI.SelecionaId();
    // Continue daqui
    Console.WriteLine(id);
}

void ExcluirTarefa()
{
    UI.ExibeDestaque("\n-- Excluir Tarefa ---");
    int id = UI.SelecionaId();
    // Continue daqui
    Console.WriteLine(id);
}