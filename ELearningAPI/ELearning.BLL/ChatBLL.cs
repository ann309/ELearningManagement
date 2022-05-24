using ELearning.BLL.Interface;
using ELearning.DAL.Interface;
using ELearning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL
{
    public class ChatBLL : IChatBLL
    {

        private readonly IChatDAL _chatDAL;

        public ChatBLL(IChatDAL chatDAL)
        {
            _chatDAL = chatDAL;
        }
        public async Task<Chat> CreateAsync(Chat chat)
        {
            var result = await _chatDAL.CreateAsync(chat);
            if (result != null) return result;
            else return null;
        }

        public async Task<Chat> DeleteAsync(int id)
        {
            var result = await _chatDAL.DeleteAsync(id);
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Chat>> DisplayAsync()
        {
            var result = await _chatDAL.DisplayAsync();
            if (result != null) return result;
            else return null;
        }

        public async Task<List<Chat>> MyChatsAsync(string userName)
        {
            var result = await _chatDAL.MyChatsAsync(userName);
            if (result != null) return result;
            else return null;
        }
    }
}
