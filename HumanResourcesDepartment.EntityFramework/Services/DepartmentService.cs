using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Domain.Sercices
{
    public class DepartmentService
    {
        private readonly HumanResourcesDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Department> _nonQueryDataService;

        public DepartmentService(HumanResourcesDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Department>(contextFactory);
        }

        public async Task<Department> Create(Department entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Department> Get(int id)
        {
            using (HumanResourcesDepartmentDBContext context = _contextFactory.CreateDbContext())
            {
                Department entity = await context.Departments
                    .Include(d => d.Address)
                    .Include(d => d.Positions)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            using (HumanResourcesDepartmentDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Department> entities = await context.Departments
                    .Include(d => d.Address)
                    .Include(d => d.Positions)
                    .ThenInclude(p => p.Worker)
                    .Include(d => d.Positions)
                    .ThenInclude(p => p.Profession)
                    .ToListAsync();
                return entities;
            }
        }



        public async Task<Department> Update(int id, Department entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
