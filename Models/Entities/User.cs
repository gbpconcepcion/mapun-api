using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace mapun_api.Models.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid USER_ID { get; set; }

#nullable enable

        public string? FIRSTNAME { get; set; }
        public string? MIDDLENAME { get; set; }
        public string? LASTNAME { get; set; }

        public string? USERNAME { get; set; }

        public string? EMAIL { get; set; }

        public Instant? DATE_CREATED { get; set; }

        public Guid? CREATED_BY { get; set; }

        public Instant? DATE_UPDATED { get; set; }

        public Guid? UPDATED_BY { get; set; }
        public bool? IS_ACTIVE { get; set; }

        public Guid? ROLE_ID { get; set; }

        public mapunRole? ROLE { get; set; }

        public virtual ICollection<Property>? PROPERTIES { get; set; }

        public virtual ICollection<PropertyLog>? HISTORY { get; set; }

    }
}