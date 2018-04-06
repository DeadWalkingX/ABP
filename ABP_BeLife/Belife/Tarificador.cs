using System;
using System.Collections.Generic;
using System.Text;

namespace Belife
{
    public class Tarificador
    {
        public Cliente Cliente { get; set; }


        public Tarificador()
        {
            Init();
        }

        private void Init()
        {
            this.Cliente = new Cliente();

        }


        private double CalcularPrima()
        {
            double prima = 0;

            return prima;
        }
    }
}
