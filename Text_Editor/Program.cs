using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Selecione a ação desejada:");
            Console.WriteLine("1 - Abrir um arquivo");
            Console.WriteLine("2 - Criar um novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Editor(); break;
                default: Menu(); break;
            }
        }

        static void Open()
        {

            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editor()
        {
            Console.Clear();
            Console.WriteLine("Digite o seu texto abaixo (pressione ESC para sair):");
            Console.WriteLine("----------------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Save(text);
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Onde deseja salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo salvo com sucesso em {path}");
            Console.ReadLine();
            Menu();
        }
    }
}
