using DataAccessLayer.Entities;

namespace BL.Services.ClientServices
{
    public interface IClientService
    {
        bool RentABook(Book book, User client);
        bool ReturnABook(Book book, User client);
    }
}
