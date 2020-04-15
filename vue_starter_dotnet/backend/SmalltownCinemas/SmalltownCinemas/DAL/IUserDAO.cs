using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmalltownCinemas.DAL
{
    public interface IUserDAO
    {
        int GetEmailByUser(string email);
    }
}
