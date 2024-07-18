using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_De_Implementação
{
    public interface IEmprestavel
    {
         bool Disponivel();
        bool Emprestado();
        bool Bloqueado();
        bool Atrasado();
        string ToString();

    }
}


