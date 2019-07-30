using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Service.Services
{
    public class BusinessEntitiesService : IBusinessEntitiesService
    {
        private readonly AppDbContext _context;

        public BusinessEntitiesService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteById(int id)
        {
            _context.BusinessEntities.Remove(_context.BusinessEntities.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BusinessEntity>> GetAll()
        {
            return await _context.BusinessEntities.AsNoTracking().ToListAsync();
        }

        public async Task<BusinessEntity> GetById(int id)
        {
            return await _context.BusinessEntities.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(BusinessEntity entity)
        {
            if (entity.Id != 0)
                _context.BusinessEntities.Update(entity);
            else
                _context.BusinessEntities.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public  string GetAutoCode()
        {
            string code = "hWe";
            var result = _context.BusinessEntities.ToList();
           
            if (result.Count() > 0)
            {
                int getid = result.Max(x=>x.Id);
               code = code + getid;
            }
            else
            {
                code = code + 0;
            }
            return  code;
        }

    }
}
