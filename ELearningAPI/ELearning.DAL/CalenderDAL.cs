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

    public class CalenderDAL : IOperationDAL<Calender>
    {
        private readonly ELearningDBContext _db;

        public CalenderDAL(ELearningDBContext entityRef)
        {
            _db = entityRef;
        }
        public async Task<Calender> CreateAsync(Calender calender)
        {
            var eventVal = await _db.Calender.AddAsync(calender);
            _db.SaveChangesAsync();
            return eventVal.Entity;
        }

        public async Task<Calender> DeleteAsync(int id)
        {
            var eventVal = await _db.Calender.Where(x => x.ID == id).FirstOrDefaultAsync();
            _db.Calender.Remove(eventVal);
            _db.SaveChangesAsync();
            return eventVal;
        }

        public async Task<List<Calender>> DisplayAsync()
        {
            var eventList = await _db.Calender.ToListAsync();
            await _db.SaveChangesAsync();
            return eventList;
        }

        public async Task<Calender> EditAsync(int id,Calender eventVal)
        {
            Calender calender =  _db.Calender.Where(x => x.ID == id).FirstOrDefault();
            calender.EventStart = eventVal.EventStart;
            calender.EventEnd = eventVal.EventEnd;
            calender.Event = eventVal.Event;
            await _db.SaveChangesAsync();
            return calender;
        }

        public async Task<List<Calender>> SearchAsync(int id)
        {
            var eventVAl = await _db.Calender.Where(d => d.ID == id).ToListAsync();
            return eventVAl;
        }
    }
}
