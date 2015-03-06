using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.CostumAttributes
{
    /// <summary>
    /// This Class represent GetFromDBAtributte
    /// </summary>
    [AttributeUsage(AttributeTargets.Property,
                    AllowMultiple = true)]
    public class GetFromDBAttribute : Attribute
    {
        private bool getFromDb = false;
        private Type databaseType = null;
        private string databaseName = null;

        /// <summary>
        /// Initializes a new instance of the GetFromDBAttribute class.
        /// </summary>
        public GetFromDBAttribute(bool getFromDb, Type databaseType = null, string databaseName = null)
        {
            this.getFromDb = getFromDb;
            this.databaseType = databaseType;
            this.databaseName = databaseName;
        }

        /// <summary>
        /// Gets a value indicating whether GetFromDB property. 
        /// </summary>
        public virtual bool GetFromDB
        {
            get { return this.getFromDb; }
        }

        /// <summary>
        /// Gets a value indicating whether it is a currency property. 
        /// </summary>
        public virtual Type GetDbType
        {
            get { return this.databaseType; }
        }

        /// <summary>
        /// Gets a value indicating the db name field. 
        /// </summary>
        public virtual string GetDbFieldName
        {
            get { return this.databaseName; }
        }
    }
}
