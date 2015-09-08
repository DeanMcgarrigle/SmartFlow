using System;
using Nancy;
using Nancy.Json;
using Nancy.ModelBinding;
using SmartFlow.DataAccess;
using SmartFlow.DataAccess.Queries;
using SmartFlow.ViewModels;

namespace SmartFlow.Modules
{
    public class DashboardModule : SmartFlowModule
    {
        public DashboardModule(SmartFlowContext context)
            : base(context)
        {
            JsonSettings.MaxJsonLength = Int32.MaxValue;
            Get["/dashboard"] = _ =>
            {
                var model = this.Bind<ReportListViewModel>();

                var fromDate = DateTime.Parse(model.FromDate);
                var toDate = DateTime.Parse(model.ToDate);
                var query = new DashboardQuery(context, fromDate, toDate);
                model.Floors.AddRange(query.Floors);

                return
                    Negotiate.WithModel(model)
                    ;
            };
        }
    }
}