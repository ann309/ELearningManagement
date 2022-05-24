using ELearning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Interface
{
    public interface IChatBLL
    {
        public Task<Chat> CreateAsync(Chat chat);
        public Task<List<Chat>> DisplayAsync();
        public Task<Chat> DeleteAsync(int id);

        public Task<List<Chat>> MyChatsAsync(string userName);
    }
}
