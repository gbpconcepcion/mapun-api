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

        public IQueryable<Payment> GetPayments([Service] AppDbContext context)
        {
            return context.PAYMENTS;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]

        public IQueryable<PaymentStatus> GetPayStatuses([Service] AppDbContext context)
        {
            return context.PAYSTATUSES;
        }


    }


}