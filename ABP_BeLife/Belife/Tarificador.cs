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

        /// <summary>
        /// Calcula la prima anual del cliente
        /// </summary>
        /// <param name="PrimaBase"> Prima base obtenida desde plan </param>
        /// <returns>Prima anual del cliente</returns>
        public double CalcularPrima(int PrimaBase)
        {
            double prima = 0;
            //Pregunta por el rango de edad del cliente para asignar valor de prima
            if (this.Cliente.Edad() < 26)
            {
                prima += 3.6;
            }else if(this.Cliente.Edad() < 46){
                prima += 2.4;
            }
            else
            {
                prima += 6;
            }
            //pregunta por el sexo del cliente para asignar valor de prima// 0 hombre -  1 mujer
            if (this.Cliente.Sexo.ID == 0)
            {
                prima+=2.4;
            }
            else
            {
                prima += 1.2;
            }
            //pregunta por el estado civil del cliente para asignar valor de prima
            //0 Soltero, 1 Casado, 2 Viudo, 3 Divorciado
            if(this.Cliente.EstadoCivil.ID == 0)
            {
                prima += 4.8;
            }else if(this.Cliente.EstadoCivil.ID == 1)
            {
                prima += 2.4;
            }
            else
            {
                prima += 3.6;
            }
            return prima;
        }
    }
}
