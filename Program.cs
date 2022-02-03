using todos.db;

bool sair = false;
while (!sair)
{
    string opcao = UI.SelecionaOpcaoEmMenu();

    switch (opcao)
    {
        case "L": ListarTodasAsTarefas(); break;
        case "P": ListarTarefasPendentes(); break;
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

void ListarTodasAsTarefas()
{
    UI.ExibeDestaque("\n-- Listar todas as Tarefas ---");

    using (var _db = new todosContext())
    {
        var tarefas = _db.Todo.ToList<Todo>();

        foreach (var tarefa in tarefas)
        {
            Console.WriteLine($"[ {(tarefa.Done ? "X" : " ")} ] #{tarefa.Id}: {tarefa.Title}");
        }
    }
}

void ListarTarefasPendentes()
{
    UI.ExibeDestaque("\n-- Listar Tarefas Pendentes ---");

    using (var _db = new todosContext())
    {
        var tarefas = _db.Todo
            .Where(t => !t.Done)
            .OrderByDescending(t => t.Id)
            .ToList<Todo>();

        foreach (var tarefa in tarefas)
        {
            Console.WriteLine($"[ {(tarefa.Done ? "X" : " ")} ] #{tarefa.Id}: {tarefa.Title}");
        }
    }
}

void ListarTarefasPorTitulo()
{
    UI.ExibeDestaque("\n-- Listar Tarefas por Título ---");
    string titulo = UI.SelecionaTitulo();

    using (var _db = new todosContext())
    {
        var tarefas = _db.Todo
            .Where(t => t.Title.Contains(titulo))
            .OrderBy(t => t.Title)
            .ToList<Todo>();

        Console.WriteLine($"{tarefas.Count()} tarefa(s) encontrada(s).");

        foreach (var tarefa in tarefas)
        {
            Console.WriteLine($"[ {(tarefa.Done ? "X" : " ")} ] #{tarefa.Id}: {tarefa.Title}");
        }
    }
}

void ListarTarefasPorId()
{
    UI.ExibeDestaque("\n-- Listar Tarefas por Id ---");
    int id = UI.SelecionaId();

    using (var _db = new todosContext())
    {
        var tarefa = _db.Todo.Find(id);

        if (tarefa == null)
        {
            Console.WriteLine($"Tarefa não encontrada.");
            return;
        }

        Console.WriteLine($"[ {(tarefa.Done ? "X" : " ")} ] #{tarefa.Id}: {tarefa.Title}");
    }
}

void IncluirNovaTarefa()
{
    UI.ExibeDestaque("\n-- Incluir Nova Tarefa ---");
    string titulo = UI.SelecionaTitulo();

    if (String.IsNullOrEmpty(titulo))
    {
        UI.ExibeErro("Não é possivel incluir tarefa sem título.");
        return;
    }

    using (var _db = new todosContext())
    {
        var tarefa = new Todo
        {
            Title = titulo
        };

        _db.Add(tarefa);
        _db.SaveChanges();

        Console.WriteLine($"[ {(tarefa.Done ? "X" : " ")} ] #{tarefa.Id}: {tarefa.Title}");
    }
}

void AlterarTituloDaTarefa()
{
    UI.ExibeDestaque("\n-- Alterar Título da Tarefa ---");
    int id = UI.SelecionaId();
    string titulo = UI.SelecionaTitulo();

    if (String.IsNullOrEmpty(titulo))
    {
        UI.ExibeErro("Não é permitido deixar uma tarefa sem título.");
        return;
    }

    using (var _db = new todosContext())
    {
        var tarefa = _db.Todo.Find(id);

        if (tarefa == null)
        {
            Console.WriteLine($"Tarefa não encontrada.");
            return;
        }

        tarefa.Title = titulo;
        _db.SaveChanges();

        Console.WriteLine($"[ {(tarefa.Done ? "X" : " ")} ] #{tarefa.Id}: {tarefa.Title}");
    }
}

void ConcluirTarefa()
{
    UI.ExibeDestaque("\n-- Concluir Tarefa ---");
    int id = UI.SelecionaId();

    using (var _db = new todosContext())
    {
        var tarefa = _db.Todo.Find(id);

        if (tarefa == null)
        {
            Console.WriteLine($"Tarefa não encontrada.");
            return;
        }

        if (tarefa.Done)
        {
            UI.ExibeErro($"Tarefa já finalizada.");
            return;
        }

        tarefa.Done = true;
        _db.SaveChanges();

        Console.WriteLine($"[ {(tarefa.Done ? "X" : " ")} ] #{tarefa.Id}: {tarefa.Title}");
    }
}

void ExcluirTarefa()
{
    UI.ExibeDestaque("\n-- Excluir Tarefa ---");
    int id = UI.SelecionaId();

    using (var _db = new todosContext())
    {
        var tarefa = _db.Todo.Find(id);

        if (tarefa == null)
        {
            Console.WriteLine($"Tarefa não encontrada.");
            return;
        }

        Console.WriteLine($"[ {(tarefa.Done ? "X" : " ")} ] #{tarefa.Id}: {tarefa.Title}");

        _db.Todo.Remove(tarefa);
        _db.SaveChanges();

        Console.WriteLine($"Tarefa excluída.");
    }
}
