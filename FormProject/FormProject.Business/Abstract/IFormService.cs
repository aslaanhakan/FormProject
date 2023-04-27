using FormProject.Data.Abstract;
using FormProject.Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Business.Abstract
{
    public interface IFormService
    {
        Task CreateAsync(Form form);
        Task<Form> GetByIdAsync(int id);
        Task<List<Form>> GetAllAsync();
        void Update(Form form);
        void Delete(Form form);
        public Task<List<Form>> GetAllFormFullDataAsync();
        void CreateFormAndField(Form form, Fields fields);


    }
}
