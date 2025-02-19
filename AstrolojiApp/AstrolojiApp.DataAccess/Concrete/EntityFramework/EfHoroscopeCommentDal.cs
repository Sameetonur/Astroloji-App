using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AstrolojiApp.DataAccess.Concrete.EntityFramework;
using AstrolojiApp.Entities.Concrete;

namespace AstrolojiApp.DataAccess.Concrete.EntityFramework
{
    public class EfHoroscopeCommentDal : IHoroscopeCommentDal
    {
        public async Task UpdateAsync(HoroscopeComment entity)
        {
            using (var context = new AstrolojiAppContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
} 