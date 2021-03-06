﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;

namespace QLDT.FormControls
{
    public class BaseUserControl : UserControl
    {
        public List<Control> FormControls = new List<Control>();

        public void Init<T>(T data = null) where T : class
        {
            FormControls = CRUD.GetAllChild(this);
            InitAction();
            if (data != null)
            {
                InitFormData(data);
            }
        }

        public void InitAction()
        {
            foreach (var control in FormControls)
            {
                if (control.Name == "btnSave")
                {
                    var featureName = this.Name.Replace("Uc", "");
                    if (Authorization.IsHavePermission(featureName, Define.PermissionEnum.Write.ToString()))
                    {
                        control.Click += new EventHandler(btnSave_Click);
                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
                else if (control.Name == "btnCancel")
                {
                    control.Click += new EventHandler(btnCancel_Click);
                }
                else if (control.GetType().Name == "ImageEdit" || control.GetType().Name == "PictureEdit")
                {
                    //control.DoubleClick += new EventHandler(FileHelper.ShowImagePopup);
                }

                var controlType = control.GetType();
                if (controlType.Name == "ComboBox")
                {
                    var combobox = control as ComboBox;
                    if (combobox != null)
                    {
                        combobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
                    }
                }
            }
        }

        public void InitFormData(object data)
        {
            if (data != null)
            {
                foreach (Control control in FormControls)
                {
                    var fieldName = CRUD.GetUIModelName(control.Name);
                    if (string.IsNullOrEmpty(fieldName)) continue;

                    var propertyName = "Text";
                    if (control is ComboBox)
                    {
                        propertyName = "SelectedValue";
                    }

                    var type = data.GetType();
                    var prop = type.GetProperty(fieldName);
                    if (prop != null) 
                    {
                        control.DataBindings.Add(new Binding(propertyName, data, fieldName));
                    }
                    //var modelData = CRUD.ReflectionGet(data, fieldName);
                    //if (modelData != null)
                    //{
                    //    CRUD.SetControlValue(control, modelData);
                    //}
                }
            }
        }

        public virtual bool SaveData()
        {
            return true;
        }

        public virtual void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                var parentForm = this.ParentForm;
                if (parentForm != null) parentForm.Close();
            }
        }

        public virtual void btnCancel_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm;
            if (parentForm != null) parentForm.Close();
        }
    }
}
