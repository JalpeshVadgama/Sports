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
        public bool Delete(int testId)
        {
            try
            {
                var testDetails = (from td in _context.TestDetail where td.TestId == testId select td).ToList();
                _context.TestDetail.RemoveRange(testDetails);

                var test = _context.Test.Find(testId);
                _context.Test.Remove(test);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public DetailTestViewModel GetDetailsOfTest(int testId)
        {
            var detailsOfTest = (from t in _context.Test
                                 where t.Id == testId
                                 select new DetailTestViewModel
                                 {
                                     Id = t.Id,
                                     TestDate = t.TestDate,
                                     TypeOfTest = t.TypeOfTest,
                                     TestDetails = (from td in _context.TestDetail
                                                    join
                                                    u in _context.Users on td.UserId equals u.Id
                                                    where td.TestId == testId
                                                    select new TestDetailViewModel
                                                    {
                                                        TestDetailId = td.Id,
                                                        Distnace = td.Distnace,
                                                        User = u.UserName,
                                                        FitnessRanking = GetFitnessReanking(td.Distnace)
                                                    }).ToList()
                                 }).FirstOrDefault();
            return detailsOfTest;
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
            catch (Exception)
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

        private string GetFitnessReanking(double distance)
        {
        
                if (distance <= 1000)
                {
                  return  "Below Average";
                }
                else if (distance > 1000 && distance <= 2000)
                {
                   return "Average";
                }
                else if (distance > 2000 && distance <= 3500)
                {
                    return "Good";
                }
                else if (distance > 3000)
                {
                    return "Very Good";
                }
            return string.Empty;
        }

       
    }
}
