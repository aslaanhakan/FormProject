using FormProject.Data.Abstract;
using FormProject.Data.Concrate.EFCore.Context;
using FormProject.Entity.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Data.Concrate.EFCore
{
    public class EFCoreFormRepository : EfCoreGenericRepository<Form>, IFormRepository
    {
        public EFCoreFormRepository(FormProjectContext _appContext) : base(_appContext)
        {
        }
        FormProjectContext AppContext
        {
            get { return _dbContext as FormProjectContext; }
        }

        public void CreateFormAndField(Form form, Fields fields)
        {
            AppContext.Forms.Add(form);
            AppContext.SaveChanges();
            fields.FormId=form.Id;
            AppContext.Fields.Add(fields);
            AppContext.SaveChanges();

        }

        public async Task<List<Form>> GetAllFormFullDataAsync()
        {
            return await AppContext.Forms
                            .Include(x=>x.Fields)
                            .Include(x=>x.User)
                            .ToListAsync(); 
        }
    }
}
