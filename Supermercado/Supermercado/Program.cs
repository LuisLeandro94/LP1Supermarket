using System;

namespace Supermercado
{
    class Program
    {
        static void Main(string[] args)
        {
            Gerente g = new Gerente();
            Funcionário f = new Funcionário();
            f.employeeList.Add(new Funcionário("Luis", "Ribeiro","967852669" , "abc", "teste"));
            g.employeeList.Add(new Funcionário("Luis", "Ribeiro", "967852669", "abc", "teste"));
           
            f.gerenteList.Add(new Gerente("marco", "oliveira"));
            f.repositorList.Add(new Repositor("repositor", "123"));

            
         
            

            int escolha = 0;
           
            while (escolha != 7)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|------------------------------------|");   
                Console.WriteLine("|        SUPERMERCADO                |");
                Console.WriteLine("|------------------------------------|");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("|    1-LISTA DE FUNCIONÁRIOS (TESTE) |");
                Console.WriteLine("|    2-REGISTAR                      |");
                Console.WriteLine("|    3-LOGIN                         |");
                Console.WriteLine("|    4-LISTA DE GERENTES (TESTE)     |");
                Console.WriteLine("|    5-LIMPAR LISTA  FUNCIONARIOS - REMOVER   |");
                Console.WriteLine("|    6-SAIR                          |");
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
                        Console.WriteLine("fistName:\nlastName:\ntelefone:\nuserName:\npassWord:");
                        f.employeeList.Add(new Funcionário(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));
                        break;

                    case 3:    
                        f.LoginForm();
                        break;

                    case 4:
                        Console.WriteLine(g.ToString());
                        break;

                    case 5:
                        //    f.employeeList.Clear();
                        Console.WriteLine("Apagar Funcionario");
                        string contactoAEliminarNome = Console.ReadLine();
                        bool resultado = f.removeFromContacs(contactoAEliminarNome);
                        if (resultado)
                        {
                            Console.WriteLine("Eliminado com sucesso");
                        }
                        else
                        {
                            Console.WriteLine("Falhou");
                        }
                        Console.WriteLine("Clique Enter para voltar ao menu principal");
                       
                        break;

                    case 6:
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
