using CRM_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Portal.Interfaces
{
    public interface IUsers
    {
        public List<Users> GetAll();
    }
}
