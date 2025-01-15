using Domain.Model;
using Domain.RepositoryInterface;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AuthRepo : IAuthRepo
    {
        private readonly ApplicationDbContext _employee;
        //private readonly ApiResponse _response;
        public AuthRepo(ApplicationDbContext context)
        {
            _employee = context;
        }
        public async Task<bool> DeletedAsync(string Id)
        {
            var remo = await _employee.AspNetUsers.Where(ep => ep.Id == Id).SingleOrDefaultAsync();
            _employee.AspNetUsers.Remove(remo);
            await _employee.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AspNetUsers>> GetUserAsync()
        {
            return await _employee.AspNetUsers.ToListAsync();
        }

        public async Task<AspNetUsers> GetUserByIdAsync(string Id)
        {
            return await _employee.AspNetUsers.Where(u=>u.Id==Id).SingleOrDefaultAsync();
        }
        public async Task<AspNetUsers> LoginAsync(AspNetUsers user)
        {
            return await _employee.AspNetUsers.Where(u=>u.UserName==user.UserName && u.Password == user.Password).SingleOrDefaultAsync();
        }
        public async Task<AspNetUsers> ResistrationAsync(AspNetUsers user)
        {
            AspNetUsers userobject = new AspNetUsers();
            var Id = Guid.NewGuid();
            var datestore = DateTime.Now;
            userobject.Id = Id.ToString();
            userobject.UserName = user.UserName;
            userobject.Name = user.Name;
            userobject.Email = user.Email;
            userobject.Phone = user.Phone;
            userobject.Password = user.Password;
            userobject.Roles = user.Roles;
            userobject.Images = user.Images;
            userobject.ExpiredateTime = datestore;
            await _employee.AspNetUsers.AddAsync(userobject);
            await _employee.SaveChangesAsync();
            return user;
        }
        public async void SaveChangesAsync()
        {
            await _employee.SaveChangesAsync();
        }
        public async Task<AspNetUsers> UpdateAsync(AspNetUsers user)
        {
            _employee.AspNetUsers.Update(user);
            await _employee.SaveChangesAsync();
            return user;
        }
    }
}
