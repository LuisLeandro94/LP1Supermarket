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


        //ATENCAO - TESTE
        public string cargo { get; set; }

        public List<Funcionário> employeeList;
        public List<Gerente> gerenteList;
        public Funcionário()
        {
            this.employeeList = new List<Funcionário>();
            this.gerenteList = new List<Gerente>();
            active = true;
            entryTime = DateTime.Now;
        }

        public Funcionário(string firstName, string lastName ,string userName, string password)
        {
           // this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
           // this.phoneNumber = phoneNumber;
            //this.address = address;
            //this.birthDate = birthDate;
            //this.salary = salary;
            //this.entryTime = entryTime;
            //this.authorityId = authorityId;
            this.userName = userName;
            this.password = password;
            //this.active = active;
            this.cargo = "Funcionario";
        }

        public override string ToString()
        {
            string result = "Nome" + "       " + "UserName " + "    " + "PassWord" + "\n";
            foreach (Funcionário f in  this.employeeList)
            {
                result += f.firstName + " " + f.lastName + "     " + f.userName + "     " + f.password + " \n";
            }

            return result;
        }


        #region Login
        public virtual void LoginForm()
        {
            bool successfull = false;
          
            do
            {
              
                Console.WriteLine("--------LOGIN--------");
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Password:");
                string password = Console.ReadLine();

               //AQUI ESTÁ ALGUM ERRO...METO OS DADOS DIREITOS E DA ERRO, TENHO DE CORRIGIR
                foreach (Gerente gerente in gerenteList)
                {


                    if (username == gerente.g_userName && password == gerente.g_password)
                    {
                        Console.WriteLine("Login bem sucedido!");
                        successfull = true;
                        Console.Clear();
                        //SE QUISERES VER ISTO, COPIA PARA O LOGIN DO FUNCIONARIO 
                        Gerente gr = new Gerente();
                        gr.MenuGerente();


                        break;
                    }
                    else
                    {
                        Console.WriteLine("Username ou Password estão errrados.\n");
                    }
                }
                
                foreach (Funcionário funcionario in employeeList)
                {
                
                    
                    if (username == funcionario.userName  &&  password == funcionario.password)
                    {
                        Console.WriteLine("Login bem sucedido!");
                        successfull = true;
                        Console.Clear();
                        


                        break;
                    }
                    else
                    {
                        Console.WriteLine("Username ou Password estão errrados.\n");
                    }
                }

               



            } while (successfull==false);
           
          
        }
        #endregion

        #region Criar Funcionario
        public void CreateEmployee()
        {
            string fileLocation = Directory.GetCurrentDirectory();
            //string fileName = "listaDeFuncionarios.txt";

            Console.WriteLine("nome:");
            var username = Console.ReadLine();
            Console.WriteLine("passe:");
            var password = Console.ReadLine();

           

            Console.WriteLine("Sucesso");

            //Validação
            /*
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
       }*/

            #endregion

            #region Listar Funcionarios
            //public void ListEmployee()
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
                        employeeList.Add(employeeToBeListed);
                    }
                    fileStream.Close();
                }
                else
                {
                    Console.WriteLine("Este ficheiro não existe para leitura!");
                }
            }
            #endregion
        }
    }
}
