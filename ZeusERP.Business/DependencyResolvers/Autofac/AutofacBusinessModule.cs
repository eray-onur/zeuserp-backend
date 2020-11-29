using Autofac;

using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Business.Abstract;
using ZeusERP.Business.Concrete;
using ZeusERP.DataAccess.Abstract;
using ZeusERP.DataAccess.Concrete;

namespace ZeusERP.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<EfProductDao>().As<IProductDao>();
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfCategoryDao>().As<ICategoryDao>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
        }
    }
}
