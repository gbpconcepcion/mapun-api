using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace mapun_api.Models.Entities
{
    public class Zone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ZONE_ID { get; set; }

#nullable enable

        public string? ZONE_NAME { get; set; }
        public string? ZONE_DESCRIPTION { get; set; }
        public string? ZONE_AREA { get; set; }

        public string? ZONE_AREACODE { get; set; }

        public long? ZONE_LATITUDE { get; set; }

        public long? ZONE_LONGITUDE { get; set; }

        public Instant? DATE_CREATED { get; set; }

        public Guid? CREATED_BY { get; set; }

        public Instant? DATE_UPDATED { get; set; }

        public Guid? UPDATED_BY { get; set; }
        public bool? IS_ACTIVE { get; set; }

        public virtual ICollection<Property>? PROPERTIES { get; set; }

        public Guid? ZRATE_ID { get; set; }

        public ZoneRate? ZRATE { get; set; }

    }
}