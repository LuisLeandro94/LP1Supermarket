using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Supermercado
{
    [Serializable]

    public class Gerente : Funcionário
    {

        public Gerente() : base()
        {
            this.employeeList = new List<Funcionário>();
            this.gerenteList = new List<Gerente>();
            this.repositorList = new List<Repositor>();
        }

       

        public string g_userName { get; set; }

        public string g_password { get; set; }
        public string g_cargo { get; set; }

        public Gerente(string g_userName, string g_password)
        {
            this.g_userName = g_userName;
            this.g_password = g_password;
            this.g_cargo = "Gerente";
        }

        public override string ToString()
        {
            string result = "Nome" + "       " + "Password " + "    " + "Cargo" + "\n";
            foreach (Gerente g in this.gerenteList)
            {
                result += g.g_userName + " " + g.g_password + "     " + g.g_cargo + "   \n";
            }

            return result;
        }

        //Funcionário f = new Funcionário();


        public void MenuGerente()
        {
            int escolha = 0;
            while (escolha != 7)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|--------------------------------|");
                Console.WriteLine("|        MENU - GERENTE          |");
                Console.WriteLine("|--------------------------------|");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("|    1-Apagar Funcionários       |");
                Console.WriteLine("|    2-Vender Produtos           |");
                Console.WriteLine("|    0-Sair                      |");
                Console.WriteLine("|--------------------------------|");
                Console.ResetColor();

                escolha = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (escolha)
                {
                    case 1:
                        // ERRO AO APAGAR
                        Console.WriteLine("Apagar Funcionario");
                        string contactoAEliminarNome = Console.ReadLine();
                        bool resultado = removeFromContacs(contactoAEliminarNome);
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

                    case 2:
                        Console.WriteLine("Vender Produtos");
                        break;

                    case 3:
                        Console.WriteLine("Escolheu 3");
                        break;

                    case 0:
                        Funcionário f = new Funcionário();
                        f.LoginForm();

                        break;
                        
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }


       




    }
}
