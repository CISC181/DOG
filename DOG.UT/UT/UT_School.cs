using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;
using DOG.EF.Data;
using DOG.EF.Models;





namespace DOG.UT.UT
{
    [TestClass]
    public class UT_EF_Acct
    {

        static IConfiguration Configuration = InitConfiguration();

        static Microsoft.Extensions.DependencyInjection.IServiceCollection services;
        static DbContextOptionsBuilder<DOGOracleContext> _optionsBuilder = new DbContextOptionsBuilder<DOGOracleContext>();
        static DOGOracleContext _context;

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }

        [ClassInitialize()]
        public static void InitTestSuite(TestContext testContext)
        {
            _optionsBuilder.UseOracle(Configuration.GetConnectionString("DOGConnection"));
            _context = new DOGOracleContext(_optionsBuilder.Options);
        }

        [TestMethod]
        public void AddAcct()
        {
            School _school = new School
            {
                SchoolId = 4,
                SchoolName = "Test"
            };
            _context.Schools.Add(_school);
            _context.SaveChanges();
        }

        [TestMethod]
        public void GetAccts()
        {
            var lstSchools = _context.Schools.ToList();
            Assert.IsTrue(lstSchools.Count() > 0);
        }

        [TestMethod]
        public void DeleteAcct()
        {
            School _School = _context.Schools.Where(w => w.SchoolName == "Test").FirstOrDefault();
            if (_School != null)
            {
                _context.Schools.Remove(_School);
                _context.SaveChanges();
            }
        }
    }
}