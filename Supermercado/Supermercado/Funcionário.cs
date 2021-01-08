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

        public List<Funcionário> employeeList;

        public Funcionário()
        {
            active = true;
            entryTime = DateTime.Now;
        }

        #region Login
        public void LoginForm()
        {
            bool successfull = false;
            while(!successfull)
            {
                Console.WriteLine("Username:");
                var username = Console.ReadLine();
                Console.WriteLine("Password:");
                var password = Console.ReadLine();

                foreach (Funcionário funcionario in employeeList)
                {
                    if(username == funcionario.userName && password == funcionario.password)
                    {
                        Console.WriteLine("Login bem sucedido!");
                        Console.ReadLine();
                        successfull = true;
                        break;
                    }
                    if(!successfull)
                    {
                        Console.WriteLine("Username ou password inválido. Tente novamente.");
                    }
                }
            }
        }
        #endregion

        #region Criar Funcionario
        public void CreateEmployee()
        {
            string fileLocation = Directory.GetCurrentDirectory();
            string fileName = "listaDeFuncionarios.txt";

            //Validação

            if(File.Exists(fileName))
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

<<<<<<< Updated upstream
       #region Listar Funcionarios
=======
        #region Listar Funcionarios
>>>>>>> Stashed changes
        public void ListEmployee()
        {
            string fileName = "listaDeFuncionarios.txt";

            //Validação

            if(File.Exists(fileName))
            {
                FileStream fileStream = File.OpenRead(fileName);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                while(fileStream.Position > fileStream.Length)
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
