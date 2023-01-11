using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.NHibernate.Data.Config
{
 public static class NHibernateConfiguration
    {
        public static Configuration Configure()
        {
            NHibernateProfiler.Initialize();
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionStringName = "KitchenDbContext";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
                x.LogSqlInConsole = true;
            });

            cfg.AddAssembly("Kitchen.NHibernate.Data");
            //cfg.ClassMappings.Add(Food);
            //cfg.AddClass(typeof(Food));
            //cfg.AddFile("Food.hbm.xml");
            return cfg;
        }
    }
}
