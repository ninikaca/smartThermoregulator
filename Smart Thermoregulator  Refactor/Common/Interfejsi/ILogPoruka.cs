using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfejsi
{
    public interface ILogPoruka
    {
        string GetInfoMessage(); // info poruka
        string GetWarnMessage(); // warn poruka
        string GetErrorMessage(); // error poruka
    }
}
