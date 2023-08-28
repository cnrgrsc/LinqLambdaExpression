using BenchmarkDotNet.Attributes;
using Example2.NorthwindDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    public class BenchmarkLinqLamda
    {
        NorthwindContext ctx = new NorthwindContextFactory().CreateDbContext(new string[0]);

        [Benchmark]
        public void ProductsWhereQuery()
        {
            var londonEmployeLINQ = from employe in ctx.Employees
                                    where employe.City == "London"
                                    select employe;
        }
    }
}
