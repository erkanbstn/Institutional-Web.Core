using Institutional.Core.Core.Models;
namespace Institutional.Core.Service.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
        Task<int> ContactCount();
    }
}
