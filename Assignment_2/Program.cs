using System;
using System.Linq;
using System.Text;
using Assignement_2.DdContext;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Assignement_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ItiDbContext dbContext = new ItiDbContext();
        }
    }
}