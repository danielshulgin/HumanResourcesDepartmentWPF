using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.EntityFramework.Services
{
    public class PositionService
    {
        private readonly HumanResourcesDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Position> _nonQueryDataService;

        public PositionService(HumanResourcesDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Position>(contextFactory);
        }

        public async Task<Position> Create(Position entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Position> Get(int id)
        {
            using (HumanResourcesDepartmentDBContext context = _contextFactory.CreateDbContext())
            {
                var entity = await context.Positions
                    .Include(p => p.Worker)
                    .Include(p => p.Department)
                    .Include(p => p.Profession)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Position>> GetAll()
        {
            using (HumanResourcesDepartmentDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Position> entities = await context.Positions
                    .Include(p => p.Worker)
                    .Include(p => p.Department)
                    .Include(p => p.Profession)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Position> Update(int id, Position entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
