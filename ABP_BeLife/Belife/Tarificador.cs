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
        /// Se calcula la "prima" del cliente a partir de la edad,sexo y estado civil 
        /// </summary>
        /// <param name="ValorBase"> Valor base del plan para obtener el valor total de la prima </param>
        /// <returns> valor de la prima </returns>
        public double CalcularPrima(double ValorBase)
        {
            double prima = 0;
            //Revisa entre que rangos esta la edad del cliente
            if (CalcularEdadCliente()<26)
            {
                prima += 3.6;
            }else if(CalcularEdadCliente()<46){
                prima += 2.4;
            }
            else
            {
                prima += 6;
            }

            //Revisa el sexo del cliente 1="Masculino" 2="Femenino"
            if(Cliente.Sexo.ID == 1)
            {
                prima += 2.4;
            }else if(Cliente.Sexo.ID == 2){
                prima += 1.2;
            }
            else
            {
                //Nose que dejar en el else.. si se les ocurre borren esto :D
                prima += 0;
            }

            //Revisa el Estado Civil del Cliente 1="Soltero",2="Casado",3="Divorciado",4="Viudo"
            if(Cliente.EstadoCivil.ID == 1)
            {
                prima += 4.8;
            }else if (Cliente.EstadoCivil.ID == 2)
            {
                prima += 2.4;
            }else if (Cliente.EstadoCivil.ID == 3 || Cliente.EstadoCivil.ID==4)
            {
                prima += 3.6;
            }
            else
            {
                //Nose que dejar en el else.. si se les ocurre borren esto :D
                prima += 0;
            }


            return prima+ValorBase;
        }
        //Retorna la edad del Cliente
        private int CalcularEdadCliente()
        {
            
            return DateTime.Today.AddTicks(-this.Cliente.FechaNacimiento.Ticks).Year-1;

        }
    }
}
