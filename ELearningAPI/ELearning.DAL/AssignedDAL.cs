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
    public class AssignedDAL : IAssignedDAL
    {
        private readonly ELearningDBContext _db;

        public AssignedDAL(ELearningDBContext entityRef)
        {
            _db = entityRef;
        }

        public async Task<Assigned> CreateAsync(Assigned assigned)
        {
            var assignedVal = await _db.Assign.AddAsync(assigned);
            _db.SaveChanges();
            return assignedVal.Entity;
        }

        public async Task<Assigned> DeleteAsync(int id)
        {
            Assigned assignVal = await _db.Assign.FirstOrDefaultAsync(x => x.ID == id);
            var delUser = _db.Assign.Remove(assignVal);
            await _db.SaveChangesAsync();
            return delUser.Entity;
        }

        public async Task<List<Assigned>> DisplayAsync()
        {
            List<Assigned> assignedList = await _db.Assign.ToListAsync();
            await _db.SaveChangesAsync();
            return assignedList;
        }

        public async Task<Assigned> EditAsync(int id, Assigned assignVal)
        {

            Assigned updateAssign = _db.Assign.Where(x => x.ID == id).FirstOrDefault();
            updateAssign.ProjectId = assignVal.ProjectId;
            updateAssign.DocumentationId = assignVal.DocumentationId;
            updateAssign.AssignedTo = assignVal.AssignedTo;
            updateAssign.AssignedBy = assignVal.AssignedBy;
            await _db.SaveChangesAsync();
            return updateAssign;
        }

        public async Task<Assigned> EditAccessibleByStudentAsync(int id, Assigned assignVal)
        {
            Assigned updateAssign = _db.Assign.Where(x => x.ID == id).FirstOrDefault();
            updateAssign.UploadId = assignVal.UploadId;
            await _db.SaveChangesAsync();
            return updateAssign;
        }

        public async Task<List<Assigned>> SearchAsync(int id)
        {
            var assignVal = await _db.Assign.Where(u => u.ID == id).ToListAsync();
            return assignVal;
        }
    }
}
