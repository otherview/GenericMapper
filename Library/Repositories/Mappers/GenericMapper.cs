using Library.Models.CostumAttributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositories.Mappers
{
    /// <summary>
    /// This class implements a GenericMapper any given class.
    /// </summary>
    /// /// <typeparam name="T">The first generic type parameter.</typeparam>
    internal class GenericMapper<T>
    {
        /// <summary>
        /// This class implements a MappedValue for the GenericMapper class.
        /// </summary>
        internal class MappedValue
        {
            public MappedValue(string propertyDBName, Type propertyDBType)
            {
                this.PropertyDBName = propertyDBName;
                this.PropertyDBType = propertyDBType;
            }

            public string PropertyDBName { get; set; }

            public Type PropertyDBType { get; set; }
        }

        private Dictionary<string, MappedValue> classProperties = new Dictionary<string, MappedValue>();
        
        public GenericMapper()
        {
            var result = (T)Activator.CreateInstance(typeof(T), new object[] { });

            bool getFromDB = false;
            Type propertyDBType = null;
            string propertyDBName = null;

            foreach (PropertyInfo iteratedProperty in result.GetType().GetProperties())
            {
                // Get the GetFromDBAttribute from the property 
                getFromDB = false;
                try
                {
                    getFromDB = ((GetFromDBAttribute)iteratedProperty.GetCustomAttributes(typeof(GetFromDBAttribute), true).First()).GetFromDB;
                }
                catch (Exception)
                {
                    continue;
                }

                // Get the Convertion DB type from the property if specified
                propertyDBType = null;
                propertyDBType = ((GetFromDBAttribute)iteratedProperty.GetCustomAttributes(typeof(GetFromDBAttribute), true).First()).GetDbType;
                if (propertyDBType == null)
                {
                    propertyDBType = iteratedProperty.PropertyType;
                }

                // Get the DB field Name if specified
                propertyDBName = null;
                propertyDBName = ((GetFromDBAttribute)iteratedProperty.GetCustomAttributes(typeof(GetFromDBAttribute), true).First()).GetDbFieldName;
                if (propertyDBName == null)
                {
                    propertyDBName = iteratedProperty.Name.ToString();
                }

                // Saves the Database propertyName and the Database property Type into an Dictionary
                this.classProperties.Add(iteratedProperty.Name.ToString(), new MappedValue(propertyDBName, propertyDBType));
            }
        }

        public T MapRow<T>(IDataRecord row)
        {
            var result = (T)Activator.CreateInstance(typeof(T), new object[] { });
       
            if (row.FieldCount == 0 || !this.classProperties.Any())
            {
                return result;
            }

            foreach (string propertyName in this.classProperties.Keys)
            {
                // Get the value from the reader and convert it to the instanced class property
                result.GetType().GetProperty(propertyName).SetValue(result, Convert.ChangeType(MapperUtilities.GetValue(row, this.classProperties[propertyName].PropertyDBName), this.classProperties[propertyName].PropertyDBType));
            }
            return result;
        }
    }
}
