using IRepositorio;
using Microsoft.Extensions.Configuration;

namespace Repositorio
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private IConfiguration _IConfiguration;
        private ILogErrorRepository _ILogErrorRepository;
        private IPersonalRepository _IPersonalRepository;

        public RepositoryWrapper(IConfiguration iConfiguration)
        {
            this._IConfiguration = iConfiguration;
        }

        public ILogErrorRepository LogErrorRepository
        {
            get { return _ILogErrorRepository ?? (_ILogErrorRepository = new LogErrorRepository(_IConfiguration)); }
        }
        public IPersonalRepository PersonalRepository
        {
            get { return _IPersonalRepository ?? (_IPersonalRepository = new PersonalRepository(_IConfiguration)); }
        }

    }
}
