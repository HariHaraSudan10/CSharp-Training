using Assignment1___MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Assignment1___MVC.Repositories
{
    public interface IContactRepositories
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(long id);
        Task CreateAsync(Contact contact);
        Task UpdateAsync(Contact contact);
        Task DeleteAsync(long id);
    }
}