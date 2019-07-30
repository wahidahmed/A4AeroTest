using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IBusinessEntitiesService
    {
        Task<int> Save(BusinessEntity entity);
        Task<IEnumerable<BusinessEntity>> GetAll();
        Task<BusinessEntity> GetById(int id);
        Task<bool> DeleteById(int id);

       string GetAutoCode();
    }
}
