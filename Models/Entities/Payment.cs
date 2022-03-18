using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace mapun_api.Models.Entities
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PAYMENT_ID { get; set; }

#nullable enable

        public string? TRANSACTION_CODE { get; set; }

        public string? TITLE { get; set; }

        public string? REMARKS { get; set; }

        public string? PAYER_NAME_PROXY { get; set; }

        public long? AMOUNT_DUE { get; set; }

        public Instant? DUE_DATE { get; set; }


        public Instant? DATE_CREATED { get; set; }

        public Guid? CREATED_BY { get; set; }

        public Instant? DATE_UPDATED { get; set; }

        public Guid? UPDATED_BY { get; set; }

        public bool? IS_ACTIVE { get; set; }
        public Guid? PROPERTY_ID { get; set; }

        public Property? PROPERTY { get; set; }

        public Guid? PAYSTATUS_ID { get; set; }

        public PaymentStatus? PAYSTATUS { get; set; }

    }
}