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

        public IQueryable<Property> GetProperties([Service] AppDbContext context)
        {
            return context.PROPERTIES;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]

        public IQueryable<PropertyEnhancement> GetPEnhancments([Service] AppDbContext context)
        {
            return context.PENHANCEMENTS;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]

        public IQueryable<PropertyLog> GetPLogs([Service] AppDbContext context)
        {
            return context.PLOGS;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]

        public IQueryable<PropertyStatus> GetPropertyStatuses([Service] AppDbContext context)
        {
            return context.PSTATUSES;
        }


    }


}