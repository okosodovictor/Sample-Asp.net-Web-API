using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BEAssignment.Core.Interfaces.DataAccess;
using BEAssignment.Core.Interfaces.Managers;
using BEAssignment.Core.Managers;
using BEAssignment.Data;
using Ninject.Modules;
using Ninject.Web.Common;
using BEAssignment.Data.Repositories;

namespace BEAssignment.Api.Modules
{
    public class MainModule  : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<DataEntities>().InRequestScope();
            Bind<IInvoiceRepository>().To<InvoiceRepository>().InRequestScope();
            Bind<IInvoiceManager>().To<InvoiceManager>();
        }
    }
}