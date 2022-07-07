using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorio
{
    public interface IRepositoryWrapper
    {
        ILogErrorRepository LogErrorRepository { get; }
        IPersonalRepository PersonalRepository { get; }
    }
}
