using Sports.Data;
using Sports.Models;
using Sports.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Sports.Services.Implementation
{
    public class TestService : ITestService, IDisposable
    {
        private readonly SportsContext _context;
        private bool _disposed;

        public TestService(SportsContext context)
        {
            _context = context;
        }

        public List<TestViewModel> GetAll()
        {
            var result = (from t in _context.Test
                          select new TestViewModel
                          {
                              Id = t.Id,
                              TestDate = t.TestDate,
                              TypeOfTest = t.TypeOfTest,
                              NoOfParticipants = _context.TestDetail.Count(td => td.TestId == t.Id)
                          }).ToList();
            return result;
        }

        public async Task<bool> Add(Test test)
        {
            try
            {
                _context.Test.Add(test);
               await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                //Write log here
                return false;
            }
            return true;
        }

        /// <summary>
        /// A method to dispose repository instance based in Idisposable
        /// </summary>
        /// <param name="disposing">Boolean for making disposing on or off</param>
        protected virtual void Dispose(bool disposing)
        {

            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }

        /// <summary>
        /// A method for Idisposable method 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
    }
}
