using Library.Models.CostumAttributes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This Class represent Taxes
    /// </summary>
    public class Taxes
    {
        /// <summary>
        /// Gets or sets the Effective Date.
        /// </summary>
        [GetFromDBAttribute(true, databaseType: typeof(DateTime))]
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// Gets or sets the tax Entity Id.
        /// </summary>
        [DisplayName("Tax Entity")]
        [GetFromDBAttribute(true, databaseName: "taxEntityId")]
        public int TaxEntityId { get; set; }

        /// <summary>
        /// Gets or sets the asOfDate.
        /// </summary>
        public DateTime ParticipantEffectiveDate { get; set; }

        /// <summary>
        /// Gets or sets the Tax Entity Name.
        /// </summary>
        [DisplayName("Tax Entity Name")]
        [GetFromDBAttribute(true, databaseName: "description")]
        public string TaxEntityName { get; set; }

        /// <summary>
        /// Gets or sets the Tax Entity Code.
        /// </summary>
        [DisplayName("Tax Entity Code")]
        [GetFromDBAttribute(true)]
        public string TaxEntityCode { get; set; }

        /// <summary>
        /// Gets or sets the Tax rate.
        /// </summary>
        [DisplayName("Tax Rate")]
        [GetFromDBAttribute(true)]
        public decimal TaxRate { get; set; }
    }
}       