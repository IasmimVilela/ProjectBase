using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TaskB3.Domain.Enums
{
    public enum Status
    {
        Aguardando = 1,
        Pronto = 2,
        EmExecução = 3,
        Concluida = 4,
        Erro = 5,
        Cancelado = 6,
        Suspensa = 7,
        Indeterminada = 8,
        Bloqueada = 9
    }
}
