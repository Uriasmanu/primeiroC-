// Screen Sound
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
Dictionary<string, List<int>> BandasRegistradas = new Dictionary<string, List<int>>
{
    {"Ira", new List<int> { 10, 10, 10, 10, 10 } },
};


void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarLista();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: MediaDaBanda();
            break;
        case -1: Console.WriteLine("Tchau tchau :)");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarBanda()
{
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");

     string nomeDaBanda = Console.ReadLine()!;
    BandasRegistradas.Add(nomeDaBanda, new List<int> { });

    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Console.Clear();
    Thread.Sleep(2000);
    ExibirOpcoesDoMenu();
}

void MostrarLista()
{
    Console.WriteLine("Lista de bandas");
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");

    foreach (string banda in BandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarBanda()
{
    //Qual banda
    //Ela existe na lista
    //se não, voltar ao inicio

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;

    // dicionario, contem a key (nome digitado)?
    if(BandasRegistradas.ContainsKey(nomeBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        BandasRegistradas[nomeBanda].Add(nota); // o colchetes serve para acessar o index da banda
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void MediaDaBanda()
{
    //limpa
    Console.Clear ();

    //titulo
    ExibirTituloDaOpcao("Media de notas");

    //qual banda
    Console.WriteLine("Escolha uma banda");
    string nomeBanda = Console.ReadLine()!;


    // esta presente
    if (BandasRegistradas.ContainsKey(nomeBanda))
    {
        //calculo da media
        List<int> notas = BandasRegistradas[nomeBanda];
        double media = notas.Average();
        Console.WriteLine($"\nA média das notas da banda {nomeBanda} é: {media}");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    }


ExibirLogo();
ExibirOpcoesDoMenu();

