using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFV.WebAPI.Gateway.Data
{
    public static class UnitOfWorkExtension
    {
        public static AppDbContext DbContext(this IUnitOfWork unitOfWork)
        {
            return (AppDbContext)unitOfWork.Context;
        }
    }
}
