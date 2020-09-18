using sql_crup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sql_crup.DbContext
{
    public interface IContext
    {
        public List<Persons> Get();
        public Persons GetById(int id);
        public void Insert(Persons New);
        public void Delete(int? Id);
        public void Update(Persons Up, int Id);
    }
}
