using Sports.Data;
using Sports.Models;
using Sports.Services.Interface;
using System;
using System.Threading.Tasks;

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
