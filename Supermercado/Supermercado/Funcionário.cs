using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Supermercado
{
    [Serializable]

    public class Funcionário
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public DateTime birthDate { get; set; }
        public decimal salary { get; set; }
        public DateTime entryTime { get; set; }
        public int authorityId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool active { get; set; }
        public string cargo { get; set; }


        static public List<Funcionário> employeeList = new List<Funcionário>();
        static public List<Gerente> gerentList = new List<Gerente>();
        static public List<Repositor> repositorList = new List<Repositor>();
        //public List<Gerente> gerenteList;
        //public List<Repositor> repositorList;
        public Funcionário()
        {

            active = true;
            entryTime = DateTime.Now;
        }

        public Funcionário(string firstName, string lastName, string phoneNumber, string address, DateTime birthDate, DateTime entryTime, decimal salary, string userName, string password, bool active, string cargo)
        {
            //this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.birthDate = birthDate;
            this.salary = salary;
            this.entryTime = entryTime;
            //this.authorityId = authorityId;
            this.userName = userName;
            this.password = password;
            this.active = active;
            this.cargo = "Funcionario";
        }

        public override string ToString()
        {
            string result = "";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|           LISTA DE FUNCIONARIOS         |");
            Console.WriteLine("|-----------------------------------------|");
            Console.ResetColor();
            foreach (Funcionário f in employeeList)
            {
                Console.WriteLine("Name");
                Console.WriteLine(f.firstName + " " + f.lastName);
                Console.WriteLine("\nPhoneNumber");
                Console.WriteLine(f.phoneNumber);
                Console.WriteLine("\nAddress");
                Console.WriteLine(f.address);
                Console.WriteLine("\nBirthDate");
                Console.WriteLine(f.birthDate.ToString("dd/MM/yyyy"));
                Console.WriteLine("\nSalary");
                Console.WriteLine(f.salary);
                Console.WriteLine("\nEntryTime");
                Console.WriteLine(f.entryTime);
                Console.WriteLine("\nUserName");
                Console.WriteLine(f.userName);
                Console.WriteLine("\nPassword");
                Console.WriteLine(f.password);
                Console.WriteLine("\nCargo");
                Console.WriteLine(f.cargo);
                Console.WriteLine("\nActive");
                Console.WriteLine(f.active);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("|-----------------------------------------|");
                Console.ResetColor();

                Console.WriteLine();
                result += "";

            }
            return result;
        }

        #region Listar Funcionarios
        public void ListEmployee()
        {
            string fileName = "listaDeFuncionarios.txt";

            //Validação

            if (File.Exists(fileName))
            {
                FileStream fileStream = File.OpenRead(fileName);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                while (fileStream.Position > fileStream.Length)
                {
                    Funcionário employeeToBeListed = binaryFormatter.Deserialize(fileStream) as Funcionário;
                    //employeeList.Add(employeeToBeListed);
                }
                fileStream.Close();
            }
            else
            {
                Console.WriteLine("Este ficheiro não existe para leitura!");
            }
        }



        #endregion

        #region Criar Funcionario
        public void CreateEmployee()
        {
            string fileLocation = Directory.GetCurrentDirectory();
            string fileName = "listaDeFuncionarios.txt";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|                REGISTAR                 |");
            Console.WriteLine("|-----------------------------------------|");
            Console.ResetColor();
            Console.WriteLine("FirstName:");
            var firstName = Console.ReadLine();
            Console.WriteLine("\nLastName:");
            var lastName = Console.ReadLine();
            Console.WriteLine("\nPhoneNumber");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("\nAddress");
            var address = Console.ReadLine();
            Console.WriteLine("\nData de Aniversário");
            DateTime birthDate = Convert.ToDateTime(Console.ReadLine());
            //string data = Console.ReadLine("dd/MM/yyyy");
           
            //DateTime dateAndTime = DateTime.Now;
            //Console.WriteLine(dateAndTime.ToString("dd/MM/yyyy"));
            Console.WriteLine("\nSalary");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("\nUserName:");
            var username = Console.ReadLine();
            Console.WriteLine("\nPassword:");
            var password = Console.ReadLine();

            employeeList.Add(new Funcionário(firstName, lastName, phoneNumber, address, birthDate, entryTime, salary, username, password, active, cargo));

            Console.WriteLine("Registado com sucesso!");

            //Validação

            if (File.Exists(fileName))
            {
                Console.WriteLine("Ficheiro antigo eliminado.");
                File.Delete(fileName);
            }

            FileStream fileStream = File.Create(fileName);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            foreach (Funcionário employeeToCreate in employeeList)
            {
                binaryFormatter.Serialize(fileStream, employeeToCreate);
            }
            fileStream.Close();

        }




        #endregion

        #region Login
        public virtual void LoginForm()
        {
            bool successfull = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|                   LOGIN                 |");
            Console.WriteLine("|-----------------------------------------|");
            Console.ResetColor();
            Console.WriteLine("1- Funcionário ");
            Console.WriteLine("2- Gerente ");
            Console.WriteLine("3- Repositor ");
            int escolha = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (escolha)
            {
                case 1:

                    do
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("|---------------------------------------|");
                        Console.WriteLine("|          LOGIN - FUNCIONARIO          |");
                        Console.WriteLine("|---------------------------------------|");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Username:");
                        var username = Console.ReadLine();
                        Console.Write("Password:");
                        var password = Console.ReadLine();
                        Console.WriteLine("|-----------------------------------------|");
                        Console.ResetColor();
                        foreach (Funcionário funcionario in employeeList)
                        {
                            if (username == funcionario.userName && password == funcionario.password && escolha == 1)
                            {
                                Console.WriteLine("Login bem sucedido!");
                                successfull = true;
                                Console.Clear();
                                Console.WriteLine("FUNCIONARIO");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Username ou Password incorretos.");
                                Console.Clear();

                            }
                        }

                    } while (successfull == false);
                    break;

                case 2:
                    do
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("|-----------------------------------------|");
                        Console.WriteLine("|             LOGIN - GERENTE             |");
                        Console.WriteLine("|-----------------------------------------|");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Username:");
                        var username = Console.ReadLine();
                        Console.Write("Password:");
                        var password = Console.ReadLine();
                        Console.WriteLine("|-----------------------------------------|");
                        Console.ResetColor();
                        foreach (Gerente gerente in gerentList)
                        {
                            if (username == gerente.userName && password == gerente.password && escolha == 2)
                            {
                                Console.WriteLine("Login bem sucedido!");
                                successfull = true;
                                Console.Clear();
                                Gerente gr = new Gerente();
                                gr.MenuGerente();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Username ou Password incorretos.");
                                Console.Clear();
                            }
                        }

                    } while (successfull == false);
                    break;

                case 3:
                    do
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("|-----------------------------------------|");
                        Console.WriteLine("|             LOGIN - REPOSITOR           |");
                        Console.WriteLine("|-----------------------------------------|");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Username:");
                        var username = Console.ReadLine();
                        Console.Write("Password:");
                        var password = Console.ReadLine();
                        Console.WriteLine("|-----------------------------------------|");
                        Console.ResetColor();
                        foreach (Repositor repositor in repositorList)
                        {
                            if (username == repositor.userName && password == repositor.password && escolha == 3)
                            {
                                Console.WriteLine("Login bem sucedido!");
                                successfull = true;
                                Console.Clear();
                                Repositor rep = new Repositor();
                                rep.MenuRepostior();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Username ou Password incorretos.");
                                Console.Clear();
                            }
                        }

                    } while (successfull == false);
                    break;


                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }

    }
    #endregion


}




