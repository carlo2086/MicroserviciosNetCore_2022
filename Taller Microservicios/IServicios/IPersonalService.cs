using Capa.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios
{
    public interface IPersonalService
    {
        List<Personal> personalList();
        Personal personalId(int id);
        int personalActualizar(Personal persona);
        int personalInsertar(Personal persona);
    }
}
