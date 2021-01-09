using System;

namespace Supermercado
{
    class Program
    {
        static void Main(string[] args)
        {
            Funcionário f = new Funcionário();
            f.employeeList.Add(new Funcionário("Luis", "Ribeiro", "abc", "teste"));

            Gerente g = new Gerente();
            g.gerenteList.Add(new Gerente("marco", "oliveira"));
            g.gerenteList.Add(new Gerente("a", "b"));

            int escolha = 0;
           
            while (escolha != 7)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|------------------------------------|");   
                Console.WriteLine("|        SUPERMERCADO                |");
                Console.WriteLine("|------------------------------------|");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("|    1-LISTA DE FUNCIOANRIOS (TESTE) |");
                Console.WriteLine("|    2-REGISTAR                      |");
                Console.WriteLine("|    3-LOGIN                         |");
                Console.WriteLine("|    4-LISTA DE GERENTES (TESTE)     |");
                Console.WriteLine("|    5-Apagar                        |");
                Console.WriteLine("|    6-Limpar Lista                  |");
                Console.WriteLine("|    7-Sair                          |");
                Console.WriteLine("|------------------------------------|");
                Console.ResetColor();

                escolha = int.Parse(Console.ReadLine());
                Console.Clear();


                switch (escolha)
                {
                    case 1:
                        Console.WriteLine(f.ToString());
                        break;

                    case 2:
                        Console.WriteLine("fistName:\nlastName:\nuserName:\npassWord:");
                        f.employeeList.Add(new Funcionário(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));
                        break;

                    case 3:
                       
                        f.LoginForm();
                        break;

                    case 4:
                        Console.WriteLine(g.ToString());
                        break;

                    case 5:

                    break;

                    case 6:
                                          
                    break;
                    case 7:
                    
                    Console.WriteLine("Escolheu sair");
                    
                    break;
                    default:
                    Console.WriteLine("Opção Inválida");
                    break;
                }
                Console.ReadKey();
                Console.Clear();
            }

            //Quando sair
            Console.WriteLine("@SuperMercado)");
           
    }
}
}
