using Belife.Entity;
using System;

namespace Belife
{

    public class Cliente
    {

        //Propiedades
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }



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
            this.Sexo = new Sexo(); ;
            this.EstadoCivil = new EstadoCivil(); ;
        }

        public void Create()
        {

        }
        public bool AgregaCliente(Cliente cliente)
        {
            bool agrega = false;
            using (BeLifeEntity bbdd = new BeLifeEntity())
            {
                Entity.Cliente cli = new Entity.Cliente
                {
                    RutCliente = cliente.Rut,
                    Nombres = cliente.Nombre,
                    Apellidos = cliente.Apellidos,
                    FechaNacimiento = cliente.FechaNacimiento,
                    IdSexo = cliente.Sexo.ID,
                    IdEstadoCivil = cliente.EstadoCivil.ID
                };
                bbdd.Cliente.Add(cli);
                bbdd.SaveChanges();
                agrega = true;
            }
            return agrega;
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

        public int Edad()
        {
            return DateTime.Today.AddTicks(-this.FechaNacimiento.Ticks).Year - 1;
        }

    }
}
