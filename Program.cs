using System;
using System.IO;

//iniciando a funcao menu
Menu();

//metodo manu
static void Menu()
{
    //iniciais do menu
    Console.Clear();
    Console.WriteLine("o que voce deseja?");
    Console.WriteLine("1 - abrir arquivo");
    Console.WriteLine("2 - criar novo arquivo");
    Console.WriteLine("0 - sair");

    //criacao da variavel para o switch
    short option = short.Parse(Console.ReadLine());

    //criacao do switch
    switch (option)
    {
        case 0: System.Environment.Exit(0); break;
        case 1: Abrir(); break;
        case 2: Editar(); break;
        default: Menu(); break;
    }


}

//metodo abrir
static void Abrir()
{
    Console.Clear();
    Console.WriteLine("Qual o caminho do arquivo?");
    string path = Console.ReadLine();

    //sempre que for ler ou salvar um arquivo usa o using
    using (var file = new StreamReader(path))
    {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
    }
    Console.WriteLine("");
    Console.ReadLine();
    Menu();
}

//metodo editar
static void Editar()
{
    Console.Clear();
    Console.WriteLine("Aperte a tecla ESC para sair");
    Console.WriteLine("Digite seu texto:");
    Console.WriteLine("---------------------");

    //variavel que vai armazenar tudo q o usuario passar
    string text = "";

    //funcao que assim que o usuario apertar o ESC ela vai cancelar a aplicacao

    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine;
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    Salvar(text);
}

//metodo salvar
static void Salvar(string text)
{
    Console.Clear();
    Console.WriteLine("Qual o caminho para salvar?");

    //criar uma variavel que vai gravar o caminho do arquivo
    var path = Console.ReadLine();

    //funcao que usa para escrever um arquivo no caminho, ela faz parte do using System.IO
    using (var file = new StreamWriter(path))
    {
        file.Write(text);
    }
    Console.WriteLine($"Arquivo {path} salvo com sucesso");
    Console.ReadLine();
    Menu();
}



