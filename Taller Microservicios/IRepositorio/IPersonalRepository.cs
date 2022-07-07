using Capa.Dominio;
using System.Collections.Generic;

namespace IRepositorio
{
    public interface IPersonalRepository
    {
        List<Personal> personalList();
        Personal personalId(int id);
        int insertPersonal(Personal personal);
        int updatePersonal(Personal personal);
        int deletePersonal(int id);
    }
}
