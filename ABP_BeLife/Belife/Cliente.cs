using Belife.Entity;
using System;
using System.Linq;

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



        //Constructores

        //Constructor vacio
        public Cliente()
        {
            Init();
        }
        //Constructor con todos los parametros
        public Cliente(string _rut,string _nombres,string _apellidos,
            DateTime _fechaNacimiento,Sexo _sexo,EstadoCivil _estadoCivil)
        {
            Rut = _rut;
            Nombre = _nombres;
            Apellidos = _apellidos;
            FechaNacimiento = _fechaNacimiento;
            Sexo = _sexo;
            EstadoCivil = _estadoCivil;

        }

        private void Init()
        {
            this.Nombre = string.Empty;
            this.Rut = string.Empty;
            this.Apellidos = string.Empty;
            this.FechaNacimiento = DateTime.Now;
            this.Sexo = new Sexo();
            this.EstadoCivil = new EstadoCivil();

        }

        //se utiliza con registro cliente
        //todos los datos son obligatorios        
      
      public bool AgregaCliente()
        {
            bool agrega = false;
            BeLifeEntity bbdd = new BeLifeEntity();
            try
            {
                Entity.Cliente cli = new Entity.Cliente
                {
                    RutCliente = Rut,
                    Nombres = Nombre,
                    Apellidos = Apellidos,
                    FechaNacimiento = FechaNacimiento,
                    IdSexo = Sexo.ID,
                    IdEstadoCivil = EstadoCivil.ID
                };
                bbdd.Cliente.Add(cli);
                bbdd.SaveChanges();
                agrega = true;

            }
            catch (Exception)
            {

                throw;
            }
                       
            return agrega;
        }
        
        /// <summary>
        /// Metodo buscar cliente por RUT
        /// </summary>
        /// <param name="_rut"></param>
        /// <returns> Si es que el cliente fue o no encontrado</returns>
        public bool Read(string _rut)
        {
            bool exito = false;
            BeLifeEntity bbdd = new BeLifeEntity();

            //Consulta si hay algun cliente con el parametro _rut en la base de datos
            var query = from cli in bbdd.Cliente
                        where cli.RutCliente == _rut
                        select cli;
            //cuenta si la query tiene mas de 0 filas y agrega los datos al cliente
            if (query.Count() > 0)
            {
                Rut = query.First().RutCliente;
                Nombre = query.First().Nombres;
                Apellidos = query.First().Apellidos;
                FechaNacimiento = query.First().FechaNacimiento;
                Sexo = new Sexo(query.First().IdSexo);
                EstadoCivil = new EstadoCivil(query.First().IdEstadoCivil);
                exito = true;
            }

            return exito;
        }




        //se utiliza conregistro cliente
        
        public Boolean Update()
        {
            Boolean varRetorno = false;
            /*
             * verifica si existe el rut del cliente en la base de datos
             * El cliente debe ser mayor de 18, esto se debe verificar en la interfaz.
             * update resto de datos del cliente, si no existe notificar
             */
            BeLifeEntity bbdd = new BeLifeEntity();
            //se realiza la consulta a la db
            var query = from cli in bbdd.Cliente
                        where cli.RutCliente == Rut
                        select cli;
            //se pregunta si la consulta tiene alguna fila
            if (query.Count()>0)
            {
                //se cambia los valores del cliente en la db por los del cliente de interfaz
                query.First().Nombres = Nombre;
                query.First().Apellidos = Apellidos;
                query.First().FechaNacimiento = FechaNacimiento;
                query.First().IdSexo = Sexo.ID;
                query.First().IdEstadoCivil = EstadoCivil.ID;
                //se guardan los cambios
                bbdd.SaveChanges();
                varRetorno = true;
            }




            return varRetorno;
        }
        //se utiliza con registro cliente
        public Boolean Delete()
        {
            Boolean varRetorno = false;
            //verificar si rut existe en bd
            // no se puede eliminar un cliente que tenga contratos asociados, vigentes o no.
            BeLifeEntity bbdd = new BeLifeEntity();
            var query = from cli in bbdd.Cliente
                        where cli.RutCliente == Rut
                        select cli;
            if (query.Count() > 0)
            {
                bbdd.Cliente.Remove(query.First());
            }
            bbdd.SaveChanges();


            return varRetorno;
        }

        
        //se utiliza con listado clientes
        public ClienteCollection LeerTodo()
        {
            ClienteCollection clientes = new ClienteCollection();
            //al presionar el boton "ListarTodos" se debe ejecutar este metodo
            Cliente cliente;

            BeLifeEntity bbdd = new BeLifeEntity();
            try
            {
                foreach (Belife.Entity.Cliente cli in bbdd.Cliente.SqlQuery("select * from clientes"))
                {
                    cliente = new Cliente(
                        cli.RutCliente,
                        cli.Nombres,
                        cli.Apellidos,
                        cli.FechaNacimiento,
                        new Sexo(cli.IdSexo),
                        new EstadoCivil(cli.IdEstadoCivil));
                    clientes.Add(cliente);

                }
            }
            catch (Exception)
            {

                throw;
            }


            return clientes;
        }
        //se utiliza con listado clientes
        public ClienteCollection LeerPorSexo(Sexo sexo)
        {
            ClienteCollection clientes = new ClienteCollection();
            //al presionar el boton Buscar se ejecutara este metodo (si es que se a seleccionado un sexo)
            //verificar si se a seleccionado un estado civil para ejecutar el metodo "LeerPorEstadoCivil" aqui.

            Cliente cliente;

            BeLifeEntity bbdd = new BeLifeEntity();
            try
            {
                foreach (Belife.Entity.Cliente cli in bbdd.Cliente.SqlQuery("select * from clientes where IDSEXO ="+sexo.ID))
                {
                    cliente = new Cliente(
                        cli.RutCliente,
                        cli.Nombres,
                        cli.Apellidos,
                        cli.FechaNacimiento,
                        new Sexo(cli.IdSexo),
                        new EstadoCivil(cli.IdEstadoCivil));
                    clientes.Add(cliente);

                }
            }
            catch (Exception)
            {

                throw;
            }
            return clientes;
        }
        //se utiliza con listado clientes
        public ClienteCollection LeerPorEstadoCivil(EstadoCivil estadoCivil)
        {
            ClienteCollection clientes = new ClienteCollection();
            //al presionar el boton Buscar se ejecutara este metodo (si es que se a seleccionado un estadoCivil)
            //verificar si se a seleccionado un sexo para ejecutar el metodo "LeerPorSexo" aqui.
            Cliente cliente;

            BeLifeEntity bbdd = new BeLifeEntity();
            try
            {
                foreach (Belife.Entity.Cliente cli in bbdd.Cliente.SqlQuery("select * from clientes where IDESTADOCIVIL ="+estadoCivil.ID))
                {
                    cliente = new Cliente(
                        cli.RutCliente,
                        cli.Nombres,
                        cli.Apellidos,
                        cli.FechaNacimiento,
                        new Sexo(cli.IdSexo),
                        new EstadoCivil(cli.IdEstadoCivil));
                    clientes.Add(cliente);

                }
            }
            catch (Exception)
            {

                throw;
            }
            return clientes;
        }

        public int Edad()
        {
            return DateTime.Today.AddTicks(-this.FechaNacimiento.Ticks).Year - 1;
        }

    }
}
