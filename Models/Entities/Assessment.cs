using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace mapun_api.Models.Entities
{
    public class Assessment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ASSESSMENT_ID { get; set; }

#nullable enable
        public string? ARP_NO { get; set; }
        public string? TCT_CLOA_NO { get; set; }

        public string? OCT_NO { get; set; }

        public string? TD_NO { get; set; }
        public Instant? DATE_FILLED { get; set; }
        public string? SURVEY_NO { get; set; }

        public string? ASSESSED_BOUNDARY_NORTH { get; set; }
        public string? ASSESSED_BOUNDARY_SOUTH { get; set; }

        public string? ASSESSED_BOUNDARY_WEST { get; set; }

        public string? ASSESSED_BOUNDARY_EAST { get; set; }


        public string? MEMORANDA { get; set; }


        public Instant? DATE_CREATED { get; set; }

        public Guid? CREATED_BY { get; set; }

        public Instant? DATE_UPDATED { get; set; }

        public Guid? UPDATED_BY { get; set; }
        public bool? IS_ACTIVE { get; set; }

        public Guid? PROPERTY_ID { get; set; }

        public Property? PROPERTY { get; set; }
    }
}