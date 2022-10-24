using MCC71.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCC71.Repositories.Interface
{
    public interface IDivisionRepository
    {
        public List<Division> Get();
        public Division Get(int id);
        public int Insert(Division division);
        public int Update(Division division);
        public int Delete(int id);
    }
}
