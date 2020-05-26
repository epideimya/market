using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Data.EF
{
    class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        private string _connectionString
        {
            get
            {
                return "data source=localhost;initial catalog=kurajjMarket;Integrated Security=True;";
            }
        }

        public EFDBContext CreateDbContext(string[] args)
        {
            return new EFDBContext(_connectionString);
        }
    }
}//"(\/)Q_Q(\/)"
