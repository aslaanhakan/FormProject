using FormProject.Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Data.Abstract
{
    public interface IFormRepository:IGenericRepository<Form>
    {
        Task<List<Form>> GetAllFormFullDataAsync();
        void CreateFormAndField(Form form, Fields fields);
    }
}
