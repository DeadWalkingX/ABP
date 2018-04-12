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
            this.Sexo = new Sexo();
            this.EstadoCivil = new EstadoCivil();
        }

        //se utiliza con registro cliente
        //todos los datos son obligatorios
        public Boolean Create(Cliente cliente)
        {
            Boolean varRetorno = false;

            /*
             * El cliente debe ser mayor de 18, esto se debe verificar en la interfaz.
             * se envian los datos del cliente resivido a la bd
             * en un try catch enviar información de retorno si datos son incorrectos
             */

            return varRetorno;
        }




        //se utiliza conregistro cliente
        public Boolean Update(Cliente cliente)
        {
            Boolean varRetorno = false;
            /*
             * verifica si existe el rut del cliente en la base de datos
             * El cliente debe ser mayor de 18, esto se debe verificar en la interfaz.
             * update resto de datos del cliente, si no existe notificar
             */
            return varRetorno;
        }
        //se utiliza con registro cliente
        public Boolean Delete(string rut)
        {
            Boolean varRetorno = false;
            //verificar si rut existe en bd
            // no se puede eliminar un cliente que tenga contratos asociados, vigentes o no.
            return varRetorno;
        }

        //se utiliza con listado clientes, registro cliente y ListadoContratos
        public ClienteCollection Read(string rut)
        {
            ClienteCollection clientes = new ClienteCollection();
            /*
             *se verifica si el cliente existe en la bd.
             * si existe se cargan los datos.
             * de lo contrario se notifica (try catch).
             */
            return clientes;
        }
        //se utiliza con listado clientes
        public ClienteCollection LeerTodo()
        {
            ClienteCollection clientes = new ClienteCollection();
            //al presionar el boton "ListarTodos" se debe ejecutar este metodo
            return clientes;
        }
        //se utiliza con listado clientes
        public ClienteCollection LeerPorSexo(Sexo sexo)
        {
            ClienteCollection clientes = new ClienteCollection();
            //al presionar el boton Buscar se ejecutara este metodo (si es que se a seleccionado un sexo)
            //verificar si se a seleccionado un estado civil para ejecutar el metodo "LeerPorEstadoCivil" aqui.
            return clientes;
        }
        //se utiliza con listado clientes
        public ClienteCollection LeerPorEstadoCivil(EstadoCivil estadoCivil)
        {
            ClienteCollection clientes = new ClienteCollection();
            //al presionar el boton Buscar se ejecutara este metodo (si es que se a seleccionado un estadoCivil)
            //verificar si se a seleccionado un sexo para ejecutar el metodo "LeerPorSexo" aqui.
            return clientes;
        }

    }
}
