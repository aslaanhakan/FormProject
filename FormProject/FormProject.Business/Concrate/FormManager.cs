using FormProject.Business.Abstract;
using FormProject.Data.Abstract;
using FormProject.Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Business.Concrate
{
    public class FormManager:IFormService
    {
        private readonly IFormRepository _formRepository;

        public FormManager(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }
        public Task<List<Form>> GetAllFormFullDataAsync()
        {
            return _formRepository.GetAllFormFullDataAsync();
        }


        public async Task CreateAsync(Form form)
        {
           await _formRepository.CreateAsync(form);
        }

        public void Delete(Form form)
        {
            throw new NotImplementedException();
        }

        public Task<List<Form>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Form> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Form form)
        {
            throw new NotImplementedException();
        }

        public void CreateFormAndField(Form form, Fields fields)
        {
            _formRepository.CreateFormAndField(form,fields);
        }
    }
}
