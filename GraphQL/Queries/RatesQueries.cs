using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using HotChocolate.Data;
using mapun_api.Data;
using mapun_api.Models.Entities;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using mapun_api.Models;

namespace mapun_api.GQL.Query
{
    public partial class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]

        public IQueryable<BaseRate> GetBRates([Service] AppDbContext context)
        {
            return context.BRATES;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]

        public IQueryable<MiscRate> GetMRates([Service] AppDbContext context)
        {
            return context.MRATES;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]

        public IQueryable<EnhancementRate> GetERates([Service] AppDbContext context)
        {
            return context.ERATES;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]

        public IQueryable<ZoneRate> GetZRates([Service] AppDbContext context)
        {
            return context.ZRATES;
        }


    }


}