namespace SmartFlow.Modules
{
    //public class AccessPointModule : SmartFlowModule
    //{
    //    public AccessPointModule(SmartFlowContext context)
    //        : base(context)
    //    {
    //        Get["/access-points"] = _ =>
    //        {
    //            var model = this.Bind<AccessPointListViewModel>();
    //            model.Floors = context.Floors.Select(x => x.Name).Distinct().ToList();
    //            model.Floor = !string.IsNullOrEmpty(model.Floor) ? model.Floor : model.Floors.First();
    //            var accessPoints = context.AccessPointConfigs.Where(x => x.Name == model.Floor).OrderByDescending(x => x.IsActive).ThenBy(x => x.Name).ToList();
    //            model.AccessPointResults = accessPoints;
    //            model.AccessPoints =
    //                context.Floors
    //                    .Where(x => x.Name == model.Floor)
    //                    .ToList()
    //                    .Select(x => x.ApMac)
    //                    .Distinct()
    //                    .Where(x => !accessPoints.Any(y => y.ApMac == x && y.Name == model.Floor))
    //                    .ToList();

    //            return Negotiate.WithView("AccessPoints/List").WithModel(model);
    //        };

    //        Get["/access-points/config"] = _ =>
    //        {
    //            var model = this.Bind<AccessPointConfigViewModel>();
    //            var accessPointConfig = context.AccessPointConfigs.FirstOrDefault(x => x.Name == model.Floor && x.ApMac == model.AccessPoint);
    //            model.AccessPointConfig = accessPointConfig != null
    //                ? new AccessPointConfigDto
    //                {
    //                    Name = model.Floor,
    //                    ApMac = model.AccessPoint,
    //                    DisplayName = accessPointConfig.DisplayName,
    //                    X = accessPointConfig.X,
    //                    Y = accessPointConfig.Y,
    //                    IsActive = accessPointConfig.IsActive
    //                }
    //                : new AccessPointConfigDto
    //                {
    //                    Name = model.Floor,
    //                    ApMac = model.AccessPoint
    //                };

    //            return Negotiate.WithView("AccessPoints/Details").WithModel(model);
    //        };

    //        Post["/access-points/config"] = _ =>
    //        {
    //            var model = this.Bind<AccessPointConfigDto>();
    //            var result = this.Validate(model);

    //            if (result.IsValid)
    //            {
    //                var accessPointConfig = new AccessPointConfig
    //                {
    //                    ApMac = model.ApMac,
    //                    Name = model.Name,
    //                    DisplayName = model.DisplayName,
    //                    X = model.X,
    //                    Y = model.Y,
    //                    IsActive = model.IsActive
    //                };

    //                if (context.AccessPointConfigs.Any(x => x.Name == model.Name && x.ApMac == model.ApMac))
    //                {
    //                    context.AccessPointConfigs.Attach(accessPointConfig);
    //                    context.Entry(accessPointConfig).State = EntityState.Modified;
    //                }
    //                else
    //                {
    //                    context.AccessPointConfigs.Add(accessPointConfig);
    //                }

    //                return Response.AsRedirect("/smartflow/access-points");
    //            }

    //            model.Errors = result.Errors;
    //            return View["AccessPoints/Details", new AccessPointConfigViewModel
    //            {
    //                AccessPoint = model.ApMac,
    //                Floor = model.Name,
    //                AccessPointConfig = model
    //            }];
    //        };
    //    }
    //}
}