namespace SnapCot.Web.Infrastructure.Mapping
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using AutoMapper.QueryableExtensions;

    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            //Mapper.Map<Source, Destination>(source, destination);
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }
    }
}
