using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleAppForCheckBoxList.Infrastructure
{
    public static class ModelBindingContextHelpers
    {
        public static string GetValue(this ModelBindingContext bindingContext, string keyName)
        {
            string[] keyValues = (string[])bindingContext.ValueProvider.GetValue(keyName).RawValue;
            return keyValues.First();
        }
    }
}
