namespace SmartFlow.Modules
{
    //public class FloorModule : SmartFlowModule
    //{
    //    public FloorModule(SmartFlowContext context)
    //        : base(context)
    //    {
    //        Get["/floors"] = _ =>
    //        {
    //            var floors = context.FloorConfigs.ToList();
    //            var model = this.Bind<FloorListViewModel>();
    //            model.FloorResults = floors;
    //            model.Floors = context.Floors.Select(x => x.Name).Distinct().ToList().Where(x => !floors.Select(y => y.Name).Contains(x)).ToList();

    //            return Negotiate.WithView("Floor/List").WithModel(model);
    //        };

    //        Get["/floors/config"] = _ =>
    //        {
    //            var model = this.Bind<FloorConfigViewModel>();
    //            var floorConfig = context.FloorConfigs.FirstOrDefault(x => x.Name == model.Floor);
    //            model.FloorConfig = floorConfig != null ? new FloorConfigDto { Name = model.Floor, X = floorConfig.X, Y = floorConfig.Y } : new FloorConfigDto { Name = model.Floor };
    //            model.ImagePath = string.Format(@"/images/{0}.png", model.Floor);

    //            return Negotiate.WithView("Floor/Details").WithModel(model);
    //        };

    //        Post["/floors/config"] = _ =>
    //        {
    //            var model = this.Bind<FloorConfigDto>();
    //            var result = this.Validate(model);

    //            if (result.IsValid)
    //            {
    //                var floorConfig = new FloorConfig { Name = model.Name, X = model.X, Y = model.Y };
    //                if (context.FloorConfigs.Any(x => x.Name == model.Name))
    //                {
    //                    context.FloorConfigs.Attach(floorConfig);
    //                    context.Entry(floorConfig).State = EntityState.Modified;
    //                }
    //                else
    //                {
    //                    context.FloorConfigs.Add(floorConfig);
    //                }

    //                return Response.AsRedirect("/smartflow/floors");
    //            }

    //            model.Errors = result.Errors;
    //            return View["Floor/Details", new FloorConfigViewModel
    //            {
    //                ImagePath = string.Format(@"/images/{0}.png", model.Name),
    //                Floor = model.Name,
    //                FloorConfig = model
    //            }];
    //        };
    //    }
    //}
}