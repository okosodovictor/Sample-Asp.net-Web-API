using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace BEAssignment.Test
{
    [TestClass]
    public class TestBindings
    {
        [TestMethod]
        public void TestBinding()
        {
            //Create Kernel and Load Assembly Application.Web
            var kernel = new StandardKernel();
            kernel.Load(new Assembly[] { Assembly.Load("BEAssignment.Api") });
            var query = from types in Assembly.Load("BEAssignment.Core").GetExportedTypes()
                        where types.IsInterface
                        where types.Namespace.StartsWith("BEAssignmentSolution.Core.Interface")
                        select types;
            foreach (var i in query.ToList())
            {
                kernel.Get(i);
            }
        }
    }
}
