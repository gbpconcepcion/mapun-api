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

        public IQueryable<User> GetUsers([Service] AppDbContext context)
        {
            return context.USERS;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]

        public IQueryable<mapunRole> GetRoles([Service] AppDbContext context)
        {
            return context.ROLES;
        }


    }


}