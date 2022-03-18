using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace mapun_api.Models.Entities
{
    public class BaseRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BRATE_ID { get; set; }

#nullable enable

        public string? TITLE { get; set; }

        public string? REMARKS { get; set; }
        public string? DESCRIPTION { get; set; }

        public long? RATE { get; set; }

        public Instant? DATE_CREATED { get; set; }

        public Guid? CREATED_BY { get; set; }

        public Instant? DATE_UPDATED { get; set; }

        public Guid? UPDATED_BY { get; set; }
        public bool? IS_ACTIVE { get; set; }

        public virtual ICollection<Property>? AFFECTED_PROPERTIES { get; set; }

    }
}