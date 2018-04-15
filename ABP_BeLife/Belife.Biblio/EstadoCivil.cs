using System;
using System.Collections.Generic;
using System.Text;

namespace Belife
{
    public class EstadoCivil
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }


       

        public EstadoCivil()
        {
            Init();
        }
        public EstadoCivil(int id)
        {
            switch (id)
            {
                case 0:
                    Descripcion = "Soltero";
                    break;
                case 1:
                    Descripcion = "Casado";
                    break;
                case 2:
                    Descripcion = "Divorciado";
                    break;
                case 3:
                    Descripcion = "Viudo";
                    break;
                default:
                    break;
            }
        }

        private void Init()
        {
            this.ID = 0;
            this.Descripcion = string.Empty;
        }
       public void Read()
        {

        }

        public void ReadAll()
        {

        }


    }
}
