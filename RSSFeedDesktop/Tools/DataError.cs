using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace RSSFeedDesktop.Tools
{
    public abstract class DataError : IDataErrorInfo
    {
        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                var prop = GetType().GetProperty(columnName);
                var validationMap = prop
                    .GetCustomAttributes(typeof(ValidationAttribute), true)
                    .Cast<ValidationAttribute>();

                foreach (var v in validationMap)
                {
                    try
                    {
                        v.Validate(prop.GetValue(this, null), columnName);
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                return null;
            }
        }
    }
}
