using infraestructure.Models;
using infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SubjectService
    {
        private SubjectRepository subjectRepository; 

        public SubjectService(string connectionString)
        {
            this.subjectRepository = new SubjectRepository(connectionString);
        }

        public string insert(SubjectModel subject)
        {
            return validateSubject(subject) ? subjectRepository.insert(subject) : throw new Exception("Error en la validacion");
        }

        public string modify(SubjectModel subject, int id)
        {
            return validateSubject(subject) ? subjectRepository.modify(subject, id) : throw new Exception("Error en la validacion");
        }

        public string delete(int id)
        {
            return subjectRepository.delete(id);
        }

        public SubjectModel getByid(int id)
        {
            return subjectRepository.getById(id);
        }

        public IEnumerable<SubjectModel> read()
        {
            return subjectRepository.read();
        }

        private bool validateSubject(SubjectModel subject)
        {
            if (subject.Name.Trim().Length > 2)
            {
                return false;
            }

            return true;
        }
    }
}
