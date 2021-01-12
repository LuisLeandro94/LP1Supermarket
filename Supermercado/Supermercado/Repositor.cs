using System;
namespace Supermercado
{
    public class Repositor : Funcionário
    {
        public Repositor() : base()
        {

        }

        public string r_userName { get; set; }
        public string r_password { get; set; }
        public string r_cargo { get; set; }

        public Repositor(string r_userName, string r_password)
        {
            this.r_userName = r_userName;
            this.r_password = r_password;
            this.r_cargo = "Repositor";
        }

        public void MenuRepostior()
        {
            int escolha = 0;
            while (escolha != 7)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|--------------------------------|");
                Console.WriteLine("|        MENU - REPOSITOR        |");
                Console.WriteLine("|--------------------------------|");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("|    1- Adicionar Produtos       |");
                Console.WriteLine("|    0-Sair                      |");
                Console.WriteLine("|--------------------------------|");
                Console.ResetColor();

                escolha = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("Adicionar Produtos");
                        break;

                    case 0:
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
        

