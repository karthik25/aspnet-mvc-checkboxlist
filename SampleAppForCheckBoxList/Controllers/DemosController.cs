using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleAppForCheckBoxList.Models;

namespace SampleAppForCheckBoxList.Controllers
{
    public class DemosController : Controller
    {
        public ActionResult Index()
        {
            return View(GetModel());
        }

        [HttpPost]
        public ActionResult Index(CheckBoxListViewModel model)
        {
            ViewData["Choices"] = string.Join(",", model.GetSelectedItems());
            return View(model);
        }

        public ActionResult MultipleCheckBoxLists()
        {
            List<CheckBoxListViewModel> models = new List<CheckBoxListViewModel> { GetModel(), GetSecondModel() };
            return View(models);
        }

        [HttpPost]
        public ActionResult MultipleCheckBoxLists(List<CheckBoxListViewModel> models)
        {
            ViewData["Choices1"] = string.Join(",", models.First().GetSelectedItems());
            ViewData["Choices2"] = string.Join(",", models.Last().GetSelectedItems());
            return View(models);
        }

        private CheckBoxListViewModel GetModel()
        {
            var model = new CheckBoxListViewModel();
            model.HeaderText = "Select Languages";
            model.Items = new List<CheckBoxListItem>{ new CheckBoxListItem { Text = "C#", Value = "CSharp", IsChecked = false },
                                                      new CheckBoxListItem { Text = "Ruby", Value = "Ruby", IsChecked = false },
                                                      new CheckBoxListItem { Text = "PHP", Value = "PHP", IsChecked = false },
                                                      new CheckBoxListItem { Text = "Java", Value = "Java", IsChecked = false },
                                                      new CheckBoxListItem { Text = "Scala", Value = "Scala", IsChecked = false }
            };

            return model;
        }

        private CheckBoxListViewModel GetSecondModel()
        {
            var model = new CheckBoxListViewModel();
            model.HeaderText = "Select Frameworks";
            model.Items = new List<CheckBoxListItem>{ new CheckBoxListItem { Text = "jQuery", Value = "jQuery", IsChecked = false },
                                                      new CheckBoxListItem { Text = "Prototype", Value = "Prototype", IsChecked = false },
                                                      new CheckBoxListItem { Text = "Mootools", Value = "Mootools", IsChecked = false },
                                                      new CheckBoxListItem { Text = "Dojo", Value = "Dojo", IsChecked = false },
                                                      new CheckBoxListItem { Text = "ExtJS", Value = "ExtJS", IsChecked = false }
            };

            return model;
        }
    }
}
