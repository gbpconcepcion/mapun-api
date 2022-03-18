using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;
using HotChocolate.Types;

namespace mapun_api.Models.Entities
{
    public enum ResponseCode
    {
        Ok = 200,
        Updated = 202,
        Error = 500
    }



    public class Response
    {
        public int ResponseCode { get; set; }
        public string ResponseLabel { get; set; }
        public string ResponseMessage { get; set; }

        [GraphQLType(typeof(AnyType))]
        public object ResponseObject { get; set; }
    }
}