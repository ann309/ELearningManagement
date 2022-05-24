using ELearning.DAL.Interface;
using ELearning.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL
{
    public class ChatDAL : IChatDAL
    {
        private readonly ELearningDBContext _db;
        public ChatDAL(ELearningDBContext db)
        {
            _db = db;
        }
        public async Task<Chat> CreateAsync(Chat chat)
        {
            var newChat =await  _db.Chats.AddAsync(chat);
            await _db.SaveChangesAsync();
            return newChat.Entity;
        }

        public async Task<Chat> DeleteAsync(int id)
        {
            Chat chat = await _db.Chats.FirstOrDefaultAsync(c => c.ID == id);
            var delChat = _db.Chats.Remove(chat);
            await _db.SaveChangesAsync();
            return delChat.Entity;
        }

        public async Task<List<Chat>> DisplayAsync()
        {
            var chatList = await _db.Chats.ToListAsync();
            return chatList;
        }

        public async Task<List<Chat>> MyChatsAsync(string userName)
        {
            var chatList = await _db.Chats.Where(c => c.RecieverName== userName || c.UserName==userName).ToListAsync();
            return chatList;
        }
    }
}
