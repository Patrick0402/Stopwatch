﻿namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Segundos -> 10s = 10 segundos");
            Console.WriteLine("M = Minutos -> 1m = 1 minuto");
            Console.WriteLine("0 = Sair");
            Console.WriteLine("Quanto tempo deseja contar?");

            string data;
            char type;
            int time;
            int multiplier;

            while (true)
            {
                data = (Console.ReadLine() ?? string.Empty).ToLower().Replace(" ", "");

                if (string.IsNullOrEmpty(data) && data.Length <= 0)
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um valor válido.");
                    continue;
                }

                time = int.Parse(data.Substring(0, data.Length == 1 ? 1 : data.Length - 1));

                if (time < 0)
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um valor válido.");
                    continue;
                }
                else if (time == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Saindo...");
                    Thread.Sleep(2500);
                    Environment.Exit(0);
                }

                type = char.Parse(data.Substring(data.Length - 1, 1));

                if (type != 's' && type != 'm')
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um valor válido.");
                    continue;
                }
                else if (type == 's')
                {
                    multiplier = 1;
                }
                else
                {
                    multiplier = 60;
                }

                break;

            }

            PreStart(time, type, multiplier);
        }

        static void PreStart(int time, char type, int multiplier)
        {
            Console.Clear();
            Console.WriteLine($"Iniciando o cronômetro para {time}{(type == 's' ? " segundo(s)" : " minuto(s)")}...");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("Preparar... ");
            Thread.Sleep(750);
            Console.Write("Apontar... ");
            Thread.Sleep(750);
            Console.Write("Fogo!");
            Thread.Sleep(1000);

            Start(time * multiplier);
        }

        static void Start(int time)
        {
            int currentTime = 0;

            while (currentTime < time)
            {
                Console.Clear();
                Console.WriteLine(currentTime);

                if (currentTime <= time)
                {
                    Thread.Sleep(1000);
                }
                currentTime++;

            }

            Console.Clear();
            Console.WriteLine(currentTime + "!!!");
            Console.WriteLine("Stopwatch finalizado...");
            Console.WriteLine("Pressione 1 para retornar ao menu ou qualquer outra tecla para sair.");
            char key = Console.ReadKey(true).KeyChar;
            if (key == '1')
            {
                Menu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Saindo...");
                Thread.Sleep(2500);
                Environment.Exit(0);
            }
        }
    }

}