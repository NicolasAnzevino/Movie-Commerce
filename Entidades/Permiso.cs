using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Permiso
    {
        public int ID { get; set; }
        public string _codigo;

        public Permiso(int pID, string pCodigo)
        {
            ID = pID;
            _codigo = pCodigo;
        }
        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public abstract List<Permiso> RetornaPermisos();

        public abstract void AgregarPermiso(Permiso pPermiso);

    }

    public class PermisoSimple : Permiso
    {
        public PermisoSimple(int pID, string pCodigo) : base(pID, pCodigo)
        {
        }

        public override void AgregarPermiso(Permiso pPermiso)
        {
            throw new NotImplementedException();
        }

        public override List<Permiso> RetornaPermisos()
        {
            return new List<Permiso>() { this };
        }
    }
    public class PermisoCompuesto : Permiso
    {
        public List<Permiso> _l;

        public List<Permiso> _laux;
        public PermisoCompuesto(int pID, string pCodigo) : base(pID, pCodigo)
        {
            _l = new List<Permiso>();
        }
        public override void AgregarPermiso(Permiso Ppermiso)
        {
            _l.Add(Ppermiso);
        }
        public List<Permiso> Retornacomponentes()
        {
            return _l;
        }
        public override List<Permiso> RetornaPermisos()
        {

            _laux = new List<Permiso>();
            RecursivaRetornaPermisos(_l);
            return _laux;
        }
        private void RecursivaRetornaPermisos(List<Permiso> pLista)
        {
            foreach (Permiso p in pLista)
            {
                if (p is PermisoSimple)
                {
                    _laux.Add(p);
                }
                else
                {
                    RecursivaRetornaPermisos((p as PermisoCompuesto).Retornacomponentes());
                }
            }

        }

    }
}
