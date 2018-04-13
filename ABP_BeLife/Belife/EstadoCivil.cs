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
