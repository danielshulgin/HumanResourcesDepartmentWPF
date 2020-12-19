using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.EntityFramework.Services
{
    public class PositionService : IDataService<Position>
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
            using (HumanResourcesDepartmentDBContext context = _contextFactory.CreateDbContext())
            {
                var department = await context.Departments.FirstOrDefaultAsync((e) => e.Id == entity.Department.Id);
                var employee = await context.Employees.FirstOrDefaultAsync((e) => e.Id == entity.Employee.Id);
                var profession = await context.Professions.FirstOrDefaultAsync((e) => e.Id == entity.Profession.Id);
                var createdResult = await context.Set<Position>().AddAsync(new Position(entity.Name, employee, profession, department, entity.Salary));
                await context.SaveChangesAsync();
                return createdResult.Entity;
            }
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
                    .Include(p => p.Employee)
                    .ThenInclude(e => e.Address)
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
                    .Include(p => p.Employee)
                    .ThenInclude(e => e.Address)
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
