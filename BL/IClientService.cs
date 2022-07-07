using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IClientService
    {
        bool RentABook(Book book, Client client);
        bool ReturnABook(Book book, Client client);
    }
}
