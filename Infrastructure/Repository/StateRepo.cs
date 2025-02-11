using Domain.Model;
using Domain.RepositoryInterface;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class StateRepo : IStateRepo
    {
        private readonly ApplicationDbContext _employee;
        //private readonly ApiResponse _response;
        public StateRepo(ApplicationDbContext context)
        {
            _employee = context;
        }

        public Task<bool> AddStateAsync(State State)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletedAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditStateAsync(State State)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<State>> GetStateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<State> GetStateByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
