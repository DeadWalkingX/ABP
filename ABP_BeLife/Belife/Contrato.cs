using System;
using System.Collections.Generic;
using System.Text;

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
