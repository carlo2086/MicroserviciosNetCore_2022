using Capa.Dominio;
using IRepositorio;
using IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class PersonalService: IPersonalService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public PersonalService(IRepositoryWrapper repositoryWrapper)
        {
            this._repositoryWrapper = repositoryWrapper;
        }

        public int personalActualizar(Personal persona)
        {
            return this._repositoryWrapper.PersonalRepository.updatePersonal(persona);
        }

        public Personal personalId(int id)
        {
            return this._repositoryWrapper.PersonalRepository.personalId(id);
        }

        public int personalInsertar(Personal persona)
        {
            return this._repositoryWrapper.PersonalRepository.insertPersonal(persona);
        }

        public List<Personal> personalList()
        {
            return this._repositoryWrapper.PersonalRepository.personalList();
        }
    }
}
