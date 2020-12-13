﻿using HumanResourcesDepartment.Domain.Models;
using HumanResourcesDepartment.Domain.Sercices;
using HumanResourcesDepartment.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.EntityFramework.Services
{
    public class EmployeeDataService : IDataService<Employee>
    {
        private readonly HumanResourcesDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Employee> _nonQueryDataService;

        public EmployeeDataService(HumanResourcesDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Employee>(contextFactory);
        }

        public async Task<Employee> Create(Employee entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Employee> Get(int id)
        {
            using (HumanResourcesDepartmentDBContext context = _contextFactory.CreateDbContext())
            {
                Employee entity = await context.Employees
                    .Include(e => e.Address)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            using (HumanResourcesDepartmentDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Employee> entities = await context.Employees
                    .Include(d => d.Address)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Employee> Update(int id, Employee entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}