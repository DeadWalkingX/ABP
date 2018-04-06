using System;
using System.Collections.Generic;
using System.Text;

namespace Belife
{   
    
    public class Cliente
    {

        //Propiedades
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public eeSexo Sexo { get; set; }
        public eeEstadoCivil EstadoCivil { get; set; }



        //Constructor
        public Cliente()
        {
            Init();
        }

        private void Init()
        {
            this.Nombre = string.Empty;
            this.Rut = string.Empty;
            this.Apellidos = string.Empty;
            this.FechaNacimiento = DateTime.Now;
            this.Sexo = (eeSexo)0;
            this.EstadoCivil = (eeEstadoCivil)0;
        }

        public void Create()
        {

        }
        public void Read()
        {

        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
        public void LeerTodo()
        {

        }
        public void LeerPorSexo()
        {

        }
        public void LeerPorEstadoCivil()
        {

        }

    }
}
