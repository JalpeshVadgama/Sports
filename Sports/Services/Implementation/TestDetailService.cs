﻿using Sports.Data;
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

       

        public Task<bool> Update(TestDetail testDetail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int testDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<TestDetail> Get(int testDetailId)
        {
            throw new NotImplementedException();
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
