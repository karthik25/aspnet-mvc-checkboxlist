using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleAppForCheckBoxList.Models;
using System.Text.RegularExpressions;

namespace SampleAppForCheckBoxList.Infrastructure
{
    public class CheckBoxListValuesModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            List<CheckBoxListValues> models = new List<CheckBoxListValues>();

            string[] formKeys = controllerContext.HttpContext.Request.Form.AllKeys.ToArray();

            List<string> rootItems = formKeys.Where(s => s.StartsWith("hdrTitle")).ToList();

            foreach (var item in rootItems)
            {
                string hdrValue = item.Split('_')[1];
                string[] valValues = formKeys.Where(s => s.StartsWith("valValue_" + hdrValue)).ToArray();
                string[] hdnValues = formKeys.Where(s => s.StartsWith("hdnChk_" + hdrValue)).ToArray();

                CheckBoxListValues model = new CheckBoxListValues();
                model.HeaderText = Regex.Replace(hdrValue, "([a-z])([A-Z])", "$1 $2");
                model.SelectedValues = new List<string>();

                for (int index = 0; index < hdnValues.Count(); index++)
                    if (bool.Parse(bindingContext.GetValue(hdnValues[index])))
                        model.SelectedValues.Add(bindingContext.GetValue(valValues[index]));

                models.Add(model);
            }

            if (rootItems.Count == 1)
                return models.First();
            else
                return models;
        }
    }
}