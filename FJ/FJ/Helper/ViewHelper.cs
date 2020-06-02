using FJ.Enums;
using i18N;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FJ.Helper
{
    public static class ViewHelper
    {
        private static IDictionary<string,object> GetHtmlAttributes(object htmlAttributes)
        {
            IDictionary<string, object> attributes = null;
            if (htmlAttributes is Dictionary<string, object>)
                attributes = htmlAttributes as Dictionary<string, object>;
            else
                attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return attributes;
        }

        private static void SetAttributeRequired(TagBuilder tb)
        {
            tb.Attributes["required"] = string.Empty;
            tb.Attributes["data-required-error"] = "必填";
        }

        #region DropDownList
        public static MvcHtmlString FJDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectLists, bool required = false, bool multiple = false)
        {
            return FJDropDownListFor(htmlHelper, expression, selectLists, null, null, required, multiple);
        }

        public static MvcHtmlString FJDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectLists, object htmlAttributes, bool required = false, bool multiple = false)
        {
            return FJDropDownListFor(htmlHelper, expression, selectLists, null, htmlAttributes, required, multiple);
        }

        public static MvcHtmlString FJDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectLists, bool addOptionLabel, bool required = false, bool multiple = false)
        {
            string strOptionLabel = addOptionLabel ? "請選擇" : null;
            return FJDropDownListFor(htmlHelper, expression, selectLists, strOptionLabel, null, required, multiple);
        }

        public static MvcHtmlString FJDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectLists, string optionLabel, bool required = false, bool multiple = false)
        {
            return FJDropDownListFor(htmlHelper, expression, selectLists, optionLabel, null, required, multiple);
        }
        public static MvcHtmlString FJDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel,TProperty>> expression, IEnumerable<SelectListItem> selectLists, string optionLabel, object htmlAttributes, bool required = false, bool multiple = false)
        {
            MemberExpression member = expression.Body as MemberExpression;
            string strid = member.Member.Name;
            string strname = ExpressionHelper.GetExpressionText(expression);
            object objvalue = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model;
            string strvalue = objvalue != null ? objvalue.ToString() : null;

            return FJDropDownList(htmlHelper, strid, strname, strvalue, selectLists, optionLabel, htmlAttributes, required, multiple);
        }
        public static MvcHtmlString FJDropDownList(this HtmlHelper htmlHelper, string id, string name, string value, IEnumerable<SelectListItem> selectLists, string optionLabel, object htmlAttributes, bool required = false, bool multiple = false)
        {
            IDictionary<string, object> attributes = GetHtmlAttributes(htmlAttributes);

            TagBuilder tbdiv = new TagBuilder("div");
            tbdiv.AddCssClass("col-sm-3");

            TagBuilder tbselect = new TagBuilder("select");
            tbselect.GenerateId(id);
            tbselect.Attributes["name"] = name;
            
            if (required) SetAttributeRequired(tbselect);

            tbselect.MergeAttributes(attributes, true);
            tbselect.AddCssClass("form-control");

            if(multiple)
            {
                tbselect.AddCssClass("selectpicker");
                tbselect.Attributes["multiple"] = "multiple";
            }

            if(!string.IsNullOrWhiteSpace(optionLabel))
            {
                TagBuilder tboptionLabel = new TagBuilder("option");
                tboptionLabel.Attributes["values"] = string.Empty;
                tboptionLabel.SetInnerText(optionLabel);
                tbselect.InnerHtml += tboptionLabel.ToString();
            }

            if (selectLists != null)
            {
                foreach (SelectListItem item in selectLists)
                {
                    TagBuilder tboption = new TagBuilder("option");
                    tboption.Attributes["values"] = item.Value;
                    tboption.SetInnerText(item.Text);

                    if(value==item.Value)
                    {
                        tboption.Attributes["selected"] = "selected";
                    }

                    tbselect.InnerHtml += tboption.ToString();
                }
            }

            TagBuilder tbError = new TagBuilder("div");
            tbError.AddCssClass("help-block with-errors");

            tbdiv.InnerHtml += tbselect.ToString();
            tbdiv.InnerHtml += tbError.ToString();

            return MvcHtmlString.Create(tbdiv.ToString());
        }
        #endregion

        #region CheckBoxList
        public static MvcHtmlString FJCheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectLists, bool required = false, bool multiple = false)
        {
            return FJCheckBoxListFor(htmlHelper, expression, selectLists, null, null, required, multiple);
        }

        public static MvcHtmlString FJCheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectLists, object htmlAttributes, bool required = false, bool multiple = false)
        {
            return FJCheckBoxListFor(htmlHelper, expression, selectLists, null, htmlAttributes, required, multiple);
        }

        public static MvcHtmlString FJCheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectLists, bool addOptionLabel, bool required = false, bool multiple = false)
        {
            string strOptionLabel = addOptionLabel ? "請選擇" : null;
            return FJCheckBoxListFor(htmlHelper, expression, selectLists, strOptionLabel, null, required, multiple);
        }

        public static MvcHtmlString FJCheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectLists, string optionLabel, bool required = false, bool multiple = false)
        {
            return FJCheckBoxListFor(htmlHelper, expression, selectLists, optionLabel, null, required, multiple);
        }
        public static MvcHtmlString FJCheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectLists, string optionLabel, object htmlAttributes, bool required = false, bool multiple = false)
        {
            MemberExpression member = expression.Body as MemberExpression;
            string strid = member.Member.Name;
            string strname = ExpressionHelper.GetExpressionText(expression);
            object objvalue = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model;
            string strvalue = objvalue != null ? objvalue.ToString() : null;

            return FJCheckBoxList(htmlHelper, strid, strname, strvalue, selectLists, optionLabel, htmlAttributes, required, multiple);
        }
        public static MvcHtmlString FJCheckBoxList(this HtmlHelper htmlHelper, string id, string name, string value, IEnumerable<SelectListItem> selectLists, string optionLabel, object htmlAttributes, bool required = false, bool multiple = false)
        {
            IDictionary<string, object> attributes = GetHtmlAttributes(htmlAttributes);

            TagBuilder tbdiv = new TagBuilder("div");
            tbdiv.AddCssClass("col-sm-3");

            TagBuilder tbselect = new TagBuilder("select");
            tbselect.GenerateId(id);
            tbselect.Attributes["name"] = name;

            if (required) SetAttributeRequired(tbselect);

            tbselect.MergeAttributes(attributes, true);
            tbselect.AddCssClass("form-control");

            if (multiple)
            {
                tbselect.AddCssClass("selectpicker");
                tbselect.Attributes["multiple"] = "multiple";
            }

            if (string.IsNullOrWhiteSpace(optionLabel))
            {
                TagBuilder tboptionLabel = new TagBuilder("option");
                tboptionLabel.Attributes["values"] = string.Empty;
                tboptionLabel.SetInnerText(optionLabel);
                tbselect.InnerHtml += tboptionLabel.ToString();
            }

            if (selectLists != null)
            {
                foreach (SelectListItem item in selectLists)
                {
                    TagBuilder tboption = new TagBuilder("option");
                    tboption.Attributes["values"] = item.Value;
                    tboption.SetInnerText(item.Text);

                    if (value == item.Value)
                    {
                        tboption.Attributes["selected"] = "selected";
                    }

                    tbselect.InnerHtml += tboption.ToString();
                }
            }

            TagBuilder tbError = new TagBuilder("div");
            tbError.AddCssClass("help-block with-errors");

            tbdiv.InnerHtml += tbselect.ToString();
            tbdiv.InnerHtml += tbError.ToString();

            return MvcHtmlString.Create(tbdiv.ToString());
        }
        #endregion

        #region RadioBoxList

        #endregion

        #region TextBox

        #region DateTime

        public static MvcHtmlString AUOTextBoxDateTimeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool required = false)
        {
            return FJTextBoxDateTimeFor(htmlHelper, expression, DateTimeFormat.yyyyMMdd, null, required);
        }

        public static MvcHtmlString AUOTextBoxDateTimeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool required = false)
        {
            return FJTextBoxDateTimeFor(htmlHelper, expression, DateTimeFormat.yyyyMMdd, htmlAttributes, required);
        }

        public static MvcHtmlString FJTextBoxDateTimeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, DateTimeFormat dateTimeFormat, object htmlAttributes, bool required = false)
        {
            MemberExpression memberExpression = expression.Body as MemberExpression;
            string strId = memberExpression.Member.Name;
            string strName = ExpressionHelper.GetExpressionText(expression);
            object objValue = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model;

            DateTime? dteValue = null;
            if (objValue != null)
            {
                if (dateTimeFormat == DateTimeFormat.HHmmss) objValue = $"1911-01-01 {objValue.ToString()}";
                dteValue = Convert.ToDateTime(objValue);
            }

            return FJTextBoxDateTime(htmlHelper, strId, strName, dteValue, dateTimeFormat, htmlAttributes, required);
        }

        public static MvcHtmlString FJTextBoxDateTime(this HtmlHelper htmlHelper, string id, string name, DateTime? value, DateTimeFormat dateTimeFormat, object htmlAttributes, bool required = false)
        {
            IDictionary<string, object> attributes = GetHtmlAttributes(htmlAttributes);

            // div form-group
            TagBuilder tbdDivFormGroup = new TagBuilder("div");
            tbdDivFormGroup.AddCssClass("col-sm-3");

            // div input-group
            TagBuilder tbdDivInputGroup = new TagBuilder("div");
            tbdDivInputGroup.AddCssClass("input-group");

            #region input

            TagBuilder tbdInput = new TagBuilder("input");
            tbdInput.GenerateId(id);
            tbdInput.Attributes["name"] = name;
            tbdInput.Attributes["type"] = "text";

            // placeholder
            DateTime dtePlaceHolder = new DateTime(2019, 8, 1, 9, 0, 0);
            tbdInput.Attributes["placeholder"] = "ex:" + dtePlaceHolder.ToDateFormat(dateTimeFormat);

            // Required
            if (required) SetAttributeRequired(tbdInput);

            // Value
            if (value.HasValue) tbdInput.Attributes["value"] = value.Value.ToDateFormat(dateTimeFormat);

            // auto add Attribute data_daterange
            bool isAttrDateRange = attributes.Keys.Any(t => t == "startid" || t == "endid");
            if (isAttrDateRange) tbdInput.Attributes["data-daterange"] = string.Empty;

            tbdInput.MergeAttributes(attributes, true);
            tbdInput.AddCssClass("form-control");
            tbdInput.AddCssClass(Enum.GetName(typeof(DateTimeFormat), dateTimeFormat));

            #endregion

            #region icon

            TagBuilder tbdIcon = new TagBuilder("div");
            tbdIcon.AddCssClass("input-group-append");

            TagBuilder tbdIconButton = new TagBuilder("button");
            tbdIconButton.AddCssClass("btn btn-secondary");
            //tbdIconButton.Attributes["style"] = "padding-left:3px;padding-right:2px";
            tbdIconButton.Attributes["type"] = "button";
            tbdIconButton.Attributes["onclick"] = "$(this).parent().prev().focus().focus();";

            TagBuilder tbdglyphicon = new TagBuilder("span");
            tbdglyphicon.AddCssClass("fa fa-calendar");

            tbdIconButton.InnerHtml += tbdglyphicon.ToString();
            tbdIcon.InnerHtml += tbdIconButton.ToString();

            #endregion

            // error msg
            TagBuilder tbdError = new TagBuilder("div");
            tbdError.AddCssClass("help-block with-errors");

            // set InnerHtml
            tbdDivInputGroup.InnerHtml += tbdInput.ToString();
            tbdDivInputGroup.InnerHtml += tbdIcon.ToString();
            tbdDivFormGroup.InnerHtml += tbdDivInputGroup.ToString();
            tbdDivFormGroup.InnerHtml += tbdError.ToString();

            return MvcHtmlString.Create(tbdDivFormGroup.ToString());
        }

        #endregion

        #region Password
        public static MvcHtmlString FJPasswordTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool required = false)
        {
            return FJPasswordTextBoxFor(htmlHelper, expression, null, null, null, false, false, required);
        }
        public static MvcHtmlString FJPasswordTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool? autocomplete = false, bool required = false)
        {
            return FJPasswordTextBoxFor(htmlHelper, expression, null, null, null, autocomplete, false, required);
        }
        public static MvcHtmlString FJPasswordTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool? autocomplete = false, bool disabled = false, bool required = false)
        {
            return FJPasswordTextBoxFor(htmlHelper, expression, null, null, htmlAttributes, autocomplete, disabled, required);
        }
        public static MvcHtmlString FJPasswordTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool? autocomplete = false, bool disabled = false, bool required = false)
        {
            return FJPasswordTextBoxFor(htmlHelper, expression, null, null, null, autocomplete, disabled, required);
        }
        public static MvcHtmlString FJPasswordTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string placeholder, bool? autocomplete = false, bool disabled = false, bool required = false)
        {
            return FJPasswordTextBoxFor(htmlHelper, expression, placeholder, null, null, autocomplete, disabled, required);
        }
        public static MvcHtmlString FJPasswordTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string placeholder, int? maxlength, bool? autocomplete = false, bool disabled = false, bool required = false)
        {
            return FJPasswordTextBoxFor(htmlHelper, expression, placeholder, maxlength, null, autocomplete, disabled, required);
        }
        public static MvcHtmlString FJPasswordTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string placeholder, int? maxlength, object htmlAttributes, bool? autocomplete = false, bool disabled = false, bool required = false)
        {
            MemberExpression member = expression.Body as MemberExpression;
            string strid = member.Member.Name;
            string strname = ExpressionHelper.GetExpressionText(expression);
            object objvalue = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model;
            string strvalue = objvalue != null ? objvalue.ToString() : null;
            return FJPasswordTextBox(htmlHelper, strid, strname, strvalue, placeholder, maxlength, htmlAttributes, autocomplete, disabled, required);
        }

        public static MvcHtmlString FJPasswordTextBox(this HtmlHelper htmlHelper, string id, string name, string value, string placeholder, int? maxlength, object htmlAttributes, bool? autocomplete = false, bool disabled = false, bool required = false)
        {
            IDictionary<string, object> attributes = GetHtmlAttributes(htmlAttributes);

            TagBuilder tbdiv = new TagBuilder("div");
            //tbdiv.AddCssClass("col-lg-6");

            TagBuilder tbinput = new TagBuilder("input");
            tbinput.GenerateId(id);
            tbinput.Attributes["name"] = name;
            tbinput.Attributes["type"] = "password";

            if (required) SetAttributeRequired(tbinput);
            if (disabled) tbinput.Attributes["disabled"] = "disabled";
            if (autocomplete != null) if ((bool)autocomplete) tbinput.Attributes["autocomplete"] = "on";

            tbinput.MergeAttributes(attributes, true);
            tbinput.AddCssClass("form-control");
            tbinput.AddCssClass("form-control-user");

            if (!string.IsNullOrEmpty(value))
            {
                tbinput.Attributes["value"] = value;
            }

            if (placeholder != null) tbinput.Attributes["placeholder"] = placeholder;
            if (maxlength != null) tbinput.Attributes["maxlength"] = maxlength.ToString();

            TagBuilder tbError = new TagBuilder("div");
            tbError.AddCssClass("help-block with-errors");

            tbdiv.InnerHtml += tbinput.ToString();
            tbdiv.InnerHtml += tbError.ToString();

            return MvcHtmlString.Create(tbdiv.ToString());
        }
        #endregion

        #region TextBoxFor
        public static MvcHtmlString FJTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool required = false)
        {
            return FJTextBoxFor(htmlHelper, expression, null, null, null, false, false, required);
        }
        public static MvcHtmlString FJTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool? autocomplete = false, bool required = false)
        {
            return FJTextBoxFor(htmlHelper, expression, null, null, null, autocomplete, false, required);
        }
        public static MvcHtmlString FJTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool? autocomplete = false, bool disabled = false, bool required = false)
        {
            return FJTextBoxFor(htmlHelper, expression, null, null, htmlAttributes, autocomplete, disabled, required);
        }
        public static MvcHtmlString FJTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool? autocomplete = false, bool disabled = false, bool required = false)
        {
            return FJTextBoxFor(htmlHelper, expression, null, null, null, autocomplete, disabled, required);
        }
        public static MvcHtmlString FJTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string placeholder, bool? autocomplete = false, bool disabled = false, bool required = false)
        {
            return FJTextBoxFor(htmlHelper, expression, placeholder, null, null, autocomplete, disabled, required);
        }
        public static MvcHtmlString FJTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string placeholder, int? maxlength, bool? autocomplete = false, bool disabled = false, bool required = false)
        {
            return FJTextBoxFor(htmlHelper, expression, placeholder, maxlength, null, autocomplete, disabled, required);
        }
        public static MvcHtmlString FJTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string placeholder, int? maxlength, object htmlAttributes, bool? autocomplete = false, bool disabled = false, bool required = false)
        {
            MemberExpression member = expression.Body as MemberExpression;
            string strid = member.Member.Name;
            string strname = ExpressionHelper.GetExpressionText(expression);
            object objvalue = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model;
            string strvalue = objvalue != null ? objvalue.ToString() : null;
            return FJTextBox(htmlHelper, strid, strname, strvalue, placeholder, maxlength, htmlAttributes, autocomplete, disabled, required);
        }

        public static MvcHtmlString FJTextBox(this HtmlHelper htmlHelper, string id, string name, string value, string placeholder, int? maxlength, object htmlAttributes, bool? autocomplete = false, bool disabled = false, bool required = false)
        {
            IDictionary<string, object> attributes = GetHtmlAttributes(htmlAttributes);

            TagBuilder tbdiv = new TagBuilder("div");
            tbdiv.AddCssClass("col-sm-3");

            TagBuilder tbinput = new TagBuilder("input");
            tbinput.GenerateId(id);
            tbinput.Attributes["name"] = name;
            tbinput.Attributes["type"] = "text";

            if (required) SetAttributeRequired(tbinput);
            if (disabled) tbinput.Attributes["disabled"] = "disabled";
            if (autocomplete != null) if ((bool)autocomplete) tbinput.Attributes["autocomplete"] = "on";

            tbinput.MergeAttributes(attributes, true);
            tbinput.AddCssClass("form-control");

            if (!string.IsNullOrEmpty(value))
            {
                tbinput.Attributes["value"] = value;
            }

            if (placeholder != null) tbinput.Attributes["placeholder"] = placeholder;
            if (maxlength != null) tbinput.Attributes["maxlength"] = maxlength.ToString();

            TagBuilder tbError = new TagBuilder("div");
            tbError.AddCssClass("help-block with-errors");

            tbdiv.InnerHtml += tbinput.ToString();
            tbdiv.InnerHtml += tbError.ToString();

            return MvcHtmlString.Create(tbdiv.ToString());
        }
        #endregion

        #endregion

        #region Label
        public static MvcHtmlString FJLabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return FJLabelFor(htmlHelper, expression, null);
        }
        public static MvcHtmlString FJLabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            MemberExpression member = expression.Body as MemberExpression;
            string strid = member.Member.Name;
            string strname = ExpressionHelper.GetExpressionText(expression);
            object objvalue = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model;
            string strvalue = objvalue != null ? objvalue.ToString() : null;
            return FJLabel(htmlHelper, strvalue, htmlAttributes);
        }
        public static MvcHtmlString FJLabel(this HtmlHelper htmlHelper, string value)
        {
            return FJLabel(htmlHelper, value, null);
        }
        public static MvcHtmlString FJLabel(this HtmlHelper htmlHelper, string value, object htmlAttributes)
        {
            IDictionary<string, object> attributes = GetHtmlAttributes(htmlAttributes);

            TagBuilder tbdiv = new TagBuilder("div");
            tbdiv.AddCssClass("col-sm-2 col-form-label");
            tbdiv.AddCssClass("text-right"); 

            TagBuilder tblabel = new TagBuilder("label");
            //if (!string.IsNullOrEmpty(id))
            //{ 
            //    tblabel.GenerateId("lb_" + id); 
            //    tblabel.Attributes["for"] = id; 
            //}

            if(!string.IsNullOrEmpty(value))
            {
                tblabel.InnerHtml = value;
            }

            tblabel.MergeAttributes(attributes, true);

            tbdiv.InnerHtml += tblabel.ToString();

            return MvcHtmlString.Create(tbdiv.ToString());
        }
        #endregion

        #region Number
        public static MvcHtmlString FJNumberBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool required = false)
        {
            return FJNumberBoxFor(htmlHelper, expression, null, null, null, null, required);
        }
        public static MvcHtmlString FJNumberBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool required = false)
        {
            return FJNumberBoxFor(htmlHelper, expression, null, null, null, htmlAttributes, required);
        }
        public static MvcHtmlString FJNumberBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int? min, int? max, bool required = false)
        {
            return FJNumberBoxFor(htmlHelper, expression, min, max, null, null, required);
        }
        public static MvcHtmlString FJNumberBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int? min, int? max, object htmlAttributes, bool required = false)
        {
            return FJNumberBoxFor(htmlHelper, expression, min, max, null, htmlAttributes, required);
        }
        public static MvcHtmlString FJNumberBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int? min, int? max, double? step, bool required = false)
        {
            return FJNumberBoxFor(htmlHelper, expression, min, max, step, null, required);
        }
        public static MvcHtmlString FJNumberBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int? min, int? max, double? step, object htmlAttributes, bool required = false)
        {
            MemberExpression member = expression.Body as MemberExpression;
            string strid = member.Member.Name;
            string strname = ExpressionHelper.GetExpressionText(expression);
            object objvalue = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model;
            string strvalue = objvalue != null ? objvalue.ToString() : null;
            return FJNumberBox(htmlHelper, strid, strname, strvalue, min, max, step, htmlAttributes, required);
        }

        public static MvcHtmlString FJNumberBox(this HtmlHelper htmlHelper, string id, string name, string value, int? min, int? max, double? step, object htmlAttributes, bool required = false)
        {
            IDictionary<string, object> attributes = GetHtmlAttributes(htmlAttributes);

            TagBuilder tbdiv = new TagBuilder("div");
            tbdiv.AddCssClass("col-sm-2");

            TagBuilder tbinput = new TagBuilder("input");
            tbinput.GenerateId(id);
            tbinput.Attributes["name"] = name;
            tbinput.Attributes["type"] = "number";

            if (required) SetAttributeRequired(tbinput);

            tbinput.MergeAttributes(attributes, true);
            tbinput.AddCssClass("form-control");

            if (!string.IsNullOrEmpty(value) && int.TryParse(value, out int intvalue))
            {
                tbinput.Attributes["value"] = value;
            }

            if (min != null) tbinput.Attributes["min"] = min.ToString();
            if (max != null) tbinput.Attributes["max"] = max.ToString();
            if (step != null) tbinput.Attributes["step"] = step.ToString();

            TagBuilder tbError = new TagBuilder("div");
            tbError.AddCssClass("help-block with-errors");

            tbdiv.InnerHtml += tbinput.ToString();
            tbdiv.InnerHtml += tbError.ToString();

            return MvcHtmlString.Create(tbdiv.ToString());
        }
        #endregion

        #region Button
        public static MvcHtmlString FJButton(this HtmlHelper htmlHelper, string id, ButtonFormat buttonFormat, object htmlAttributes)
        {
            return FJButton(htmlHelper, id, null, buttonFormat, htmlAttributes);
        }
        public static MvcHtmlString FJButton(this HtmlHelper htmlHelper, string id, string value, object htmlAttributes)
        {
            return FJButton(htmlHelper, id, value, ButtonFormat.button, htmlAttributes);
        }
        public static MvcHtmlString FJButton(this HtmlHelper htmlHelper, string id, string value, ButtonFormat buttonFormat, object htmlAttributes)
        {
            IDictionary<string, object> attributes = GetHtmlAttributes(htmlAttributes);

            TagBuilder tbbutton = new TagBuilder("button");
            tbbutton.GenerateId(id);

            tbbutton.MergeAttributes(attributes, true);
            tbbutton.AddCssClass("btn");

            if (!string.IsNullOrEmpty(value))
            {
                tbbutton.SetInnerText(value);
            }
            else
            {
                switch (buttonFormat)
                {
                    case ButtonFormat.cancel:
                        tbbutton.SetInnerText(FJView.Cancel);
                        break;
                    case ButtonFormat.delete:
                        tbbutton.SetInnerText(FJView.Delete);
                        break;
                    case ButtonFormat.clear:
                        tbbutton.SetInnerText(FJView.Clear);
                        break;
                    case ButtonFormat.edit:
                        tbbutton.SetInnerText(FJView.Edit);
                        break;
                    case ButtonFormat.insert:
                        tbbutton.SetInnerText(FJView.Insert);
                        break;
                    case ButtonFormat.query:
                        tbbutton.SetInnerText(FJView.Query);
                        break;
                    case ButtonFormat.submit:
                        tbbutton.SetInnerText(FJView.Sumbit);
                        break;
                    default:
                        tbbutton.SetInnerText(value);
                        break;
                }
            }
            switch (buttonFormat)
            {
                case ButtonFormat.cancel:
                    tbbutton.AddCssClass("btn-danger");
                    break;
                case ButtonFormat.delete:
                    tbbutton.AddCssClass("btn-danger");
                    break;
                case ButtonFormat.clear:
                    tbbutton.AddCssClass("btn-warning");
                    tbbutton.Attributes["type"] = "reset";
                    break;
                case ButtonFormat.edit:
                    tbbutton.AddCssClass("btn-success");
                    break;
                case ButtonFormat.insert:
                    tbbutton.AddCssClass("btn-primary");
                    break;
                case ButtonFormat.query:
                    tbbutton.AddCssClass("btn-info");
                    break;
                case ButtonFormat.submit:
                    tbbutton.AddCssClass("btn-info");
                    tbbutton.Attributes["type"] = "submit";
                    break;
                default:
                    break;
            }
            
            return MvcHtmlString.Create(tbbutton.ToString());
        }
        #endregion

        #region BeginForm
        public static MvcForm FJBeginForm(this HtmlHelper htmlHelper, string Formid)
        {
            return FJBeginForm(htmlHelper, string.Empty, string.Empty, false, FormMethod.Post, true, new { id = Formid });
        }
        public static MvcForm FJBeginForm(this HtmlHelper htmlHelper, string actionName, string controllerName)
        {
            return FJBeginForm(htmlHelper, actionName, controllerName, false, FormMethod.Post, true, null);
        }

        public static MvcForm FJBeginForm(this HtmlHelper htmlHelper, string actionName, string controllerName, object htmlAttributes)
        {
            return FJBeginForm(htmlHelper, actionName, controllerName, false, FormMethod.Post, true, htmlAttributes);
        }

        public static MvcForm FJBeginForm(this HtmlHelper htmlHelper, string actionName, string controllerName, bool hasFile, object htmlAttributes)
        {
            return FJBeginForm(htmlHelper, actionName, controllerName, hasFile, FormMethod.Post, true, htmlAttributes);
        }
        public static MvcForm FJBeginForm(this HtmlHelper htmlHelper, string actionName, string controllerName, bool hasFile, FormMethod formMethod, bool hasFakeAjax, object htmlAttributes)
        {
            IDictionary<string, object> attributes = GetHtmlAttributes(htmlAttributes);

            if (hasFakeAjax) attributes.Add("target", "HiddenIframe");

            // 是否有檔案上傳
            if (hasFile) attributes.Add("enctype", "multipart/form-data");

            MvcForm mvcForm = htmlHelper.BeginForm(actionName, controllerName, formMethod, attributes);
            return mvcForm;
        }
        #endregion
    }
}