using System;
namespace Supermercado
{
    [Serializable]

    public class Funcionário
    {
        public string name { get; set; }
        public int idNumber { get; set; }
        public string salary { get; set; }

        public Funcionário()
        {
        }
    }
}
