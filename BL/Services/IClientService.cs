using DataAccessLayer.Entities;

namespace BL.Services
{
    public interface IClientService
    {
        bool RentABook(Book book, Client client);
        bool ReturnABook(Book book, Client client);
    }
}
