using Belife.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Belife
{
    public class Contrato
    {
        public long NumContrato { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Termino { get; set; }
        public Cliente Titular { get; set; }
        public Plan PlanAsociado { get; set; }
        public int Poliza { get; set; }
        public DateTime IniVigencia { get; set; }
        public DateTime FinVigencia { get; set; }
        public Boolean EstaVigente { get; set; }
        public Boolean ConDeclaracionDeSalud { get; set; }
        public int PrimaAnual { get; set; }
        public int PrimaMensual { get; set; }
        public string Obsevaciones { get; set; }
        
        
        public Contrato()
        {
            Init();
        }

        private void Init()
        {
            throw new NotImplementedException();
        }

        public bool Create(Contrato contrato)
        {
            bool exito = false;

            try
            {
                using (BeLifeEntity bbdd = new BeLifeEntity())
                {
                    Entity.Contrato cont = new Entity.Contrato();
                    cont.Numero = ""+contrato.NumContrato;
                    cont.RutCliente = contrato.Titular.Rut;
                    cont.FechaCreacion = contrato.Creacion;
                    cont.CodigoPlan = ""+contrato.PlanAsociado.ID;
                    cont.FechaInicioVigencia = contrato.IniVigencia;
                    cont.FechaFinVigencia = contrato.FinVigencia;
                    cont.Vigente = contrato.EstaVigente;
                    cont.DeclaracionSalud = contrato.ConDeclaracionDeSalud;
                    cont.PrimaAnual = contrato.PrimaAnual;
                    cont.PrimaMensual = contrato.PrimaMensual;
                    cont.Observaciones = contrato.Obsevaciones;

                    bbdd.Contrato.Add(cont);
                    bbdd.SaveChanges();
                    exito = true;
                    
                }

            }
            catch (Exception)
            {

                throw;
            }

            return exito;
        }
        public bool Read()
        {
            bool exito = false;
            BeLifeEntity bbdd = new BeLifeEntity();
            var query = from con in bbdd.Contrato
                        where con.Numero == NumContrato.ToString()
                        select con;
            if(query.Count() > 0)
            {
                Creacion = query.First().FechaCreacion;
                //faltaran metodos para asignar cliente y plan
                IniVigencia = query.First().FechaInicioVigencia;
                FinVigencia = query.First().FechaFinVigencia;
                EstaVigente = query.First().Vigente;
                ConDeclaracionDeSalud = query.First().DeclaracionSalud;
                PrimaAnual = (int)query.First().PrimaAnual;
                PrimaMensual = (int)query.First().PrimaMensual;
                Obsevaciones = query.First().Observaciones;
                exito = true;
            }

            return exito;
        }
        public bool Update()
        {
            bool exito = false;
            BeLifeEntity bbdd = new BeLifeEntity();
            var query = from con in bbdd.Contrato
                        where con.Numero == NumContrato.ToString()
                        select con;
            if (query.Count() > 0)
            {
                query.First().FechaCreacion = Creacion;
                query.First().RutCliente = Titular.Rut;
                query.First().CodigoPlan = PlanAsociado.ID+"";
                query.First().FechaInicioVigencia = IniVigencia;
                query.First().FechaFinVigencia = FinVigencia;
                query.First().Vigente = EstaVigente;
                query.First().DeclaracionSalud = ConDeclaracionDeSalud;
                query.First().PrimaAnual = PrimaAnual;
                query.First().PrimaMensual = PrimaMensual;
                query.First().Observaciones = Obsevaciones;
                bbdd.SaveChanges();
                exito = true;

            }
            return exito;
        }
        public bool Delete()
        {
            bool exito = false;
            BeLifeEntity bbdd = new BeLifeEntity();
            var query = from con in bbdd.Contrato
                        where con.Numero == NumContrato.ToString()
                        select con;
            if (query.Count() > 0)
            {
                bbdd.Contrato.Remove(query.First());
                bbdd.SaveChanges();
            }


            return exito;
        }
        public ContratoCollection LeerTodos()
        {
            ContratoCollection coll = new ContratoCollection();
            BeLifeEntity bbdd = new BeLifeEntity();
            var query = from con in bbdd.Contrato                       
                        select con;
            foreach (Entity.Contrato con in query)
            {
                Contrato contrato = new Contrato();
                contrato.NumContrato = Convert.ToInt64(con.Numero);
                contrato.Creacion = con.FechaCreacion;
                //faltan metodos para los dos casos
                //contrato.Titular = con.RutCliente;
                //contrato.PlanAsociado = con.CodigoPlan;
                contrato.Poliza = 0;//hay que cambiar esto
                contrato.IniVigencia = con.FechaInicioVigencia;
                contrato.FinVigencia = con.FechaFinVigencia;
                contrato.EstaVigente = con.Vigente;
                contrato.ConDeclaracionDeSalud = con.DeclaracionSalud;
                contrato.PrimaAnual = Convert.ToInt32(con.PrimaAnual);
                contrato.PrimaMensual = Convert.ToInt32(con.PrimaMensual);
                contrato.Obsevaciones = con.Observaciones;
                coll.Add(contrato);
            }
            return coll;

        }
        public ContratoCollection LeerNumContrato()
        {
            ContratoCollection coll = new ContratoCollection();
            BeLifeEntity bbdd = new BeLifeEntity();
            var query = from con in bbdd.Contrato                       
                        select con;
            foreach (Entity.Contrato con in query)
            {
                Contrato contrato = new Contrato();
                contrato.NumContrato = Convert.ToInt64(con.Numero);
                contrato.Creacion = con.FechaCreacion;
                //faltan metodos para los dos casos
                //contrato.Titular = con.RutCliente;
                //contrato.PlanAsociado = con.CodigoPlan;
                contrato.Poliza = 0;//hay que cambiar esto
                contrato.IniVigencia = con.FechaInicioVigencia;
                contrato.FinVigencia = con.FechaFinVigencia;
                contrato.EstaVigente = con.Vigente;
                contrato.ConDeclaracionDeSalud = con.DeclaracionSalud;
                contrato.PrimaAnual = Convert.ToInt32(con.PrimaAnual);
                contrato.PrimaMensual = Convert.ToInt32(con.PrimaMensual);
                contrato.Obsevaciones = con.Observaciones;
                coll.Add(contrato);
            }
            return coll;

        }
        public ContratoCollection LeerRut(string _rut)
        {
            ContratoCollection coll = new ContratoCollection();
            BeLifeEntity bbdd = new BeLifeEntity();
            var query = from con in bbdd.Contrato
                        where con.RutCliente == _rut
                        select con;
            foreach (Entity.Contrato con in query)
            {
                Contrato contrato = new Contrato();
                contrato.NumContrato = Convert.ToInt64(con.Numero);
                contrato.Creacion = con.FechaCreacion;
                //faltan metodos para los dos casos
                //contrato.Titular = con.RutCliente;
                //contrato.PlanAsociado = con.CodigoPlan;
                contrato.Poliza = con.;//hay que cambiar esto
                contrato.IniVigencia = con.FechaInicioVigencia;
                contrato.FinVigencia = con.FechaFinVigencia;
                contrato.EstaVigente = con.Vigente;
                contrato.ConDeclaracionDeSalud = con.DeclaracionSalud;
                contrato.PrimaAnual = Convert.ToInt32(con.PrimaAnual);
                contrato.PrimaMensual = Convert.ToInt32(con.PrimaMensual);
                contrato.Obsevaciones = con.Observaciones;
                coll.Add(contrato);
            }
            return coll;
        }
        public void LeerPoliza(int _poliza)
        {
            ContratoCollection coll = new ContratoCollection();
            BeLifeEntity bbdd = new BeLifeEntity();
            var query = from con in bbdd.Contrato
                        //Aca falta meter la poliza pero Contrato
                        // No tiene atributo poliza
                        //HAY QUE ARREGLARLO    
                        select con;
            foreach (Entity.Contrato con in query)
            {
                Contrato contrato = new Contrato();
                contrato.NumContrato = Convert.ToInt64(con.Numero);
                contrato.Creacion = con.FechaCreacion;
                //faltan metodos para los dos casos
                //contrato.Titular = con.RutCliente;
                //contrato.PlanAsociado = con.CodigoPlan;
                contrato.Poliza = 0;//hay que cambiar esto
                contrato.IniVigencia = con.FechaInicioVigencia;
                contrato.FinVigencia = con.FechaFinVigencia;
                contrato.EstaVigente = con.Vigente;
                contrato.ConDeclaracionDeSalud = con.DeclaracionSalud;
                contrato.PrimaAnual = Convert.ToInt32(con.PrimaAnual);
                contrato.PrimaMensual = Convert.ToInt32(con.PrimaMensual);
                contrato.Obsevaciones = con.Observaciones;
                coll.Add(contrato);
            }
            return coll;
        }
    }
}
