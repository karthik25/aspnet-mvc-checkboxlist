using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Text.RegularExpressions;
using SampleAppForCheckBoxList.Models;

namespace SampleAppForCheckBoxList.Infrastructure
{
    public static class CustomHtmlHelpers
    {
        private static string chkId = "chkBox_{0}_{1}";
        private static string lblId = "lblLabel_{0}_{1}";
        private static string valID = "valValue_{0}_{1}";

        public static MvcHtmlString CheckBoxInput(this HtmlHelper html, string headerText, CheckBoxListItem item, int index)
        {
            string id = string.Format(chkId, Regex.Replace(headerText, @"\s+", ""), index);
            string hId = string.Format("hdnChk_{0}_{1}", Regex.Replace(headerText, @"\s+", ""), index);

            StringBuilder builder = new StringBuilder();
            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttribute("type", "checkbox");
            tagBuilder.MergeAttribute("id", id);
            tagBuilder.MergeAttribute("name", id);
            tagBuilder.MergeAttribute("class", "chkClickable");
            tagBuilder.MergeAttribute("value", item.IsChecked.ToString().ToLower());
            if (item.IsChecked)
                tagBuilder.MergeAttribute("checked", "checked");
            builder.AppendLine(tagBuilder.ToString());

            TagBuilder hdnTagBuilder1 = new TagBuilder("input");
            hdnTagBuilder1.MergeAttribute("type", "hidden");
            hdnTagBuilder1.MergeAttribute("id", hId);
            hdnTagBuilder1.MergeAttribute("name", hId);
            hdnTagBuilder1.MergeAttribute("class", "hdnStatus");
            hdnTagBuilder1.MergeAttribute("value", item.IsChecked.ToString().ToLower());
            builder.AppendLine(hdnTagBuilder1.ToString());

            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString CheckBoxInputLabel(this HtmlHelper html, string headerText, CheckBoxListItem item, int index)
        {
            string id = string.Format(chkId, Regex.Replace(headerText, @"\s+", ""), index);
            string lId = string.Format(lblId, Regex.Replace(headerText, @"\s+", ""), index);

            StringBuilder builder = new StringBuilder();

            TagBuilder tagBuilder = new TagBuilder("label");
            tagBuilder.MergeAttribute("for", id);
            tagBuilder.SetInnerText(item.Text);
            builder.AppendLine(tagBuilder.ToString());

            TagBuilder hdnTagBuilder = new TagBuilder("input");
            hdnTagBuilder.MergeAttribute("type", "hidden");
            hdnTagBuilder.MergeAttribute("id", lId);
            hdnTagBuilder.MergeAttribute("name", lId);
            hdnTagBuilder.MergeAttribute("value", item.Text);
            builder.AppendLine(hdnTagBuilder.ToString());

            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString CheckBoxValue(this HtmlHelper html, string headerText, CheckBoxListItem item, int index)
        {
            string vId = string.Format(valID, Regex.Replace(headerText, @"\s+", ""), index);

            StringBuilder builder = new StringBuilder();
            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttribute("type", "hidden");
            tagBuilder.MergeAttribute("id", vId);
            tagBuilder.MergeAttribute("name", vId);
            tagBuilder.MergeAttribute("value", item.Value);
            builder.AppendLine(tagBuilder.ToString());

            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString CheckBoxListHeader(this HtmlHelper html, string headerText)
        {
            string hdrId = string.Format("hdrTitle_{0}", Regex.Replace(headerText, @"\s+", ""));

            StringBuilder builder = new StringBuilder();
            TagBuilder lblBuilder = new TagBuilder("label");
            lblBuilder.SetInnerText(headerText);
            builder.AppendLine(lblBuilder.ToString());

            TagBuilder hdnHdr = new TagBuilder("input");
            hdnHdr.MergeAttribute("type", "hidden");
            hdnHdr.MergeAttribute("id", hdrId);
            hdnHdr.MergeAttribute("name", hdrId);
            hdnHdr.MergeAttribute("value", headerText);
            builder.AppendLine(hdnHdr.ToString());

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}
