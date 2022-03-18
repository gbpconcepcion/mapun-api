using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace mapun_api.Models.Entities
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PROPERTY_ID { get; set; }

#nullable enable

        public string? PROPERTY_IDENTIFICATION_NUMBER { get; set; }

        public string? ARP_NO { get; set; }
        public string? TCT_CLOA_NO { get; set; }

        public string? OCT_NO { get; set; }

        public string? TD_NO { get; set; }
        public Instant? DATE_FILLED { get; set; }
        public string? LOT_NO { get; set; }

        public string? BLOCK_NO { get; set; }

        public string? BOUNDARY_NORTH { get; set; }
        public string? BOUNDARY_SOUTH { get; set; }

        public string? BOUNDARY_WEST { get; set; }

        public string? BOUNDARY_EAST { get; set; }



        public string? PROPERTY_NAME { get; set; }
        public long? PROPERTY_LONGITUDE { get; set; }
        public long? PROPERTY_LATITUDE { get; set; }

        public string? OWNER_NAME { get; set; }

        public string? OWNER_ADDRESS { get; set; }

        public string? OWNER_TIN { get; set; }

        public string? OWNER_TEL { get; set; }

        public string? ADMINISTRATOR_NAME { get; set; }

        public string? ADMINISTRATOR_ADDRESS { get; set; }

        public string? ADMINISTRATOR_TIN { get; set; }

        public string? ADMINISTRATOR_TEL { get; set; }

        public string? PROPERTY_STREET { get; set; }

        public string? PROPERTY_BARANGAY { get; set; }

        public string? PROPERTY_MUNICIPALITY { get; set; }

        public string? MEMORANDA { get; set; }

        public string? PROVINCE { get; set; }

        public string? EMAIL { get; set; }

        public Instant? DATE_CREATED { get; set; }

        public Guid? CREATED_BY { get; set; }

        public Instant? DATE_UPDATED { get; set; }

        public Guid? UPDATED_BY { get; set; }
        public bool? IS_ACTIVE { get; set; }

        public virtual ICollection<Payment>? PAYMENT_HISTORY { get; set; }

        public virtual ICollection<User>? ASSESSORS { get; set; }

        public virtual ICollection<PropertyLog>? HISTORY { get; set; }

        public virtual ICollection<Assessment>? ASSESSMENTS { get; set; }

        public Guid? PSTATUS_ID { get; set; }

        public PropertyStatus? PSTATUS { get; set; }

        public Guid? PEHANCEMENT_ID { get; set; }

        public PropertyEnhancement? ENHANCEMENT { get; set; }

        public Guid? BRATE_ID { get; set; }

        public BaseRate? BRATE { get; set; }

        public Guid? MRATE_ID { get; set; }

        public MiscRate? MRATE { get; set; }

        public Guid? ZONE_ID { get; set; }

        public Zone? ZONE { get; set; }
    }
}