using System;
using System.Collections.Generic;
using System.Text;

namespace Belife
{
    public class Plan
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int PrimaBase { get; set; }
        public int PolizaActual { get; set; }

        public Plan()
        {
            Init();
        }

        private void Init()
        {
            this.ID = 0;
            this.Nombre = string.Empty;
            this.PrimaBase = 0;
            this.PolizaActual = 0;
        }


        public void Leer()
        {

        }
        public void LeerTodo()
        {

        }

    }
}
