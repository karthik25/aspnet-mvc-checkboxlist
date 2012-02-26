using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using SampleAppForCheckBoxList.Models;

namespace SampleAppForCheckBoxList.Infrastructure
{
    public class CheckBoxListViewModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            List<CheckBoxListViewModel> models = new List<CheckBoxListViewModel>();

            string[] formKeys = controllerContext.HttpContext.Request.Form.AllKeys.ToArray();

            List<string> rootItems = formKeys.Where(s => s.StartsWith("hdrTitle")).ToList();

            foreach (var item in rootItems)
            {
                string hdrValue = item.Split('_')[1];
                string[] txtValues = formKeys.Where(s => s.StartsWith("lblLabel_" + hdrValue)).ToArray();
                string[] valValues = formKeys.Where(s => s.StartsWith("valValue_" + hdrValue)).ToArray();
                string[] hdnValues = formKeys.Where(s => s.StartsWith("hdnChk_" + hdrValue)).ToArray();

                CheckBoxListViewModel model = new CheckBoxListViewModel();
                model.HeaderText = Regex.Replace(hdrValue, "([a-z])([A-Z])", "$1 $2");
                model.Items = new List<CheckBoxListItem>();
                for (int index = 0; index < txtValues.Count(); index++)
                {
                    CheckBoxListItem _item = new CheckBoxListItem();
                    _item.Text = ((string[])bindingContext.ValueProvider.GetValue(txtValues[index]).RawValue).First();
                    _item.Value = ((string[])bindingContext.ValueProvider.GetValue(valValues[index]).RawValue).First();
                    _item.IsChecked = bool.Parse(((string[])bindingContext.ValueProvider.GetValue(hdnValues[index]).RawValue).First());

                    model.Items.Add(_item);
                }

                models.Add(model);
            }

            if (rootItems.Count == 1)
                return models.First();
            else
                return models;
        }
    }
}
