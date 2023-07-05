﻿using EmployeeManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Persistence.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserWithDetails(int id);
        Task<List<User>> GetUsersWithDetails();
    }
}
