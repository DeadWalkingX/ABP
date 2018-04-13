using Belife.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belife
{
    public class Contrato
    {
        public int NumContrato { get; set; }
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
        public void Read()
        {

        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
        public void LeerTodos()
        {

        }
        public void LeerNumContrato()
        {

        }
        public void LeerRut()
        {

        }
        public void LeerPoliza()
        {

        }
    }
}
