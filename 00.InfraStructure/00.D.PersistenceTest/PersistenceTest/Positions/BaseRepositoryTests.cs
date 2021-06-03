using System;
using System.Collections.Generic;
using System.Text;
using Persistence.UnitOfWorks;

namespace PersistenceTest.Positions
{
    public class BaseRepositoryTests
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        public BaseRepositoryTests(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
