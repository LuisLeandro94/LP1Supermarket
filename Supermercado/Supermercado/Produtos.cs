using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Supermercado
{
    public class Produtos
    {
        public int id { get; set; }
        public string barcodeNumber { get; set; }
        public string productName { get; set; }
        public string unitPrice { get; set; }
        public double stock { get; set; }
        public int categoryId { get; set; }
        public int unitTypeID { get; set; }
        public bool active { get; set; }

        public List<Produtos> productList;

        public Produtos()
        {
            active = true;
        }

        #region Criar um Produto
        public void SaveProduct()
        {
            string fileLocation = Directory.GetCurrentDirectory();
            string fileName = "produtosEmStock.txt";

            //Validação

            if(File.Exists(fileName))
            {
                Console.WriteLine("Ficheiro antigo eliminado.");
                File.Delete(fileName);
            }

            FileStream fileStream = File.Create(fileName);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            foreach (Produtos productToBeSaved in productList)
            {
                binaryFormatter.Serialize(fileStream, productToBeSaved);
            }
            fileStream.Close();
        }
        #endregion

        #region Listar Produtos
        public void ListProduct()
        {
            string fileName = "produtosEmStock.txt";

            //Validação

            if(File.Exists(fileName))
            {
                FileStream fileStream = File.OpenRead(fileName);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                while (fileStream.Position > fileStream.Length)
                {
                    Produtos productToBeListed = binaryFormatter.Deserialize(fileStream) as Produtos;
                    productList.Add(productToBeListed);
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
