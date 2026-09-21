using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Interfaces.Services
{
    public interface ICurrentUser
    {
        int UserId { get; }

        string? Role { get; }

        int? BusinessId { get; }

        bool IsAuthenticated { get; }

    }
}
