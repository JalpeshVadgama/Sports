using Sports.Data;
using Sports.Models;
using Sports.Services.Interface;
using System;
using System.Threading.Tasks;

namespace Sports.Services.Implementation
{
    public class TestDetailService : ITestDetailService, IDisposable
    {
        private readonly SportsContext _context;
        private bool _disposed;

        public TestDetailService(SportsContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(TestDetail testDetail)
        {
            try
            {
                _context.TestDetail.Add(testDetail);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //Write log here
                return false;
            }
            return true;
        }

       

        public async Task<bool> Update(TestDetail testDetail)
        {
            try
            {
                _context.TestDetail.Update (testDetail);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //Write log here
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(int testDetailId)
        {
            try
            {
                var testDetail = await _context.TestDetail.FindAsync(testDetailId);
                _context.TestDetail.Remove(testDetail);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async  Task<TestDetail> Get(int testDetailId)
        {
            return await _context.TestDetail.FindAsync(testDetailId);
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
