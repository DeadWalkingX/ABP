using System;

using System.Collections.Generic;
using System.Text;

namespace Belife
{
    public class Sexo

    {
        public int ID { get; set; }
        public string Descripcion { get; set; }





        public Sexo()
        {
            Init();
        }

        public Sexo(int id)
        {
            switch (id)
            {
                case 0:
                    Descripcion = "Masculino";
                    break;
                case 1:
                    Descripcion = "Femenino";
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
