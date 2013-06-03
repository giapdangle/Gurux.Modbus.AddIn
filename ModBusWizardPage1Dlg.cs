//
// --------------------------------------------------------------------------
//  Gurux Ltd
// 
//
//
// Filename:        $HeadURL: svn://utopia/projects/GXDeviceEditor/Development/AddIns/Modbus/ModBusWizardPage1Dlg.cs $
//
// Version:         $Revision: 4135 $,
//                  $Date: 2011-09-28 14:57:45 +0300 (Wed, 28 Sep 2011) $
//                  $Author: kurumi $
//
// Copyright (c) Gurux Ltd
//
//---------------------------------------------------------------------------
//
//  DESCRIPTION
//
// This file is a part of Gurux Device Framework.
//
// Gurux Device Framework is Open Source software; you can redistribute it
// and/or modify it under the terms of the GNU General Public License 
// as published by the Free Software Foundation; version 2 of the License.
// Gurux Device Framework is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of 
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details.
//
// This code is licensed under the GNU General Public License v2. 
// Full text may be retrieved at http://www.gnu.org/licenses/gpl-2.0.txt
//---------------------------------------------------------------------------


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Gurux.Device.Editor;
using Gurux.Device;
using Gurux.Common;


namespace Gurux.Modbus.AddIn
{
	/// <summary>
	/// A modbus specific custom wizard page. The page is used with the GXWizardDlg class.
	/// The page provides user interface for setting address, function and type.
	/// </summary>
	internal class ModBusWizardPage1Dlg : System.Windows.Forms.Form, IGXWizardPage
	{
		private System.ComponentModel.Container m_Components = null;
		private System.Windows.Forms.ComboBox typeCb;
		private System.Windows.Forms.Label typeLbl;
		private System.Windows.Forms.Label addressLbl;
		private System.Windows.Forms.TextBox addressTb;
		private System.Windows.Forms.Label functionLbl;
		private System.Windows.Forms.ComboBox functionCb;
		private GXModbusProperty m_Property = null;

        public ModBusWizardPage1Dlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;			
			UpdateResources();
			addressTb.Select();
            typeCb.Items.Add(typeof(bool).Name);
            typeCb.Items.Add(typeof(byte).Name);
            typeCb.Items.Add(typeof(UInt16).Name);
            typeCb.Items.Add(typeof(UInt32).Name);
            typeCb.Items.Add(typeof(Int16).Name);
            typeCb.Items.Add(typeof(Int32).Name);
		}

		private void UpdateResources()
		{
            addressLbl.Text = Gurux.Modbus.AddIn.Properties.Resources.AddressTxt;
            typeLbl.Text = Gurux.Modbus.AddIn.Properties.Resources.TypeTxt;
            functionLbl.Text = Gurux.Modbus.AddIn.Properties.Resources.FunctionTxt;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (m_Components != null)
				{
					m_Components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.typeCb = new System.Windows.Forms.ComboBox();
			this.typeLbl = new System.Windows.Forms.Label();
			this.addressLbl = new System.Windows.Forms.Label();
			this.addressTb = new System.Windows.Forms.TextBox();
			this.functionLbl = new System.Windows.Forms.Label();
			this.functionCb = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// TypeCb
			// 
			this.typeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeCb.Location = new System.Drawing.Point(96, 69);
			this.typeCb.Name = "TypeCb";
			this.typeCb.Size = new System.Drawing.Size(136, 21);
			this.typeCb.TabIndex = 2;
			// 
			// TypeLbl
			// 
			this.typeLbl.Location = new System.Drawing.Point(8, 69);
			this.typeLbl.Name = "TypeLbl";
			this.typeLbl.Size = new System.Drawing.Size(80, 16);
			this.typeLbl.TabIndex = 4;
			this.typeLbl.Text = "Type:";
			// 
			// AddressLbl
			// 
			this.addressLbl.Location = new System.Drawing.Point(8, 16);
			this.addressLbl.Name = "AddressLbl";
			this.addressLbl.Size = new System.Drawing.Size(80, 16);
			this.addressLbl.TabIndex = 6;
			this.addressLbl.Text = "Address:";
			// 
			// AddressTb
			// 
			this.addressTb.Location = new System.Drawing.Point(96, 16);
			this.addressTb.Name = "AddressTb";
			this.addressTb.Size = new System.Drawing.Size(136, 20);
			this.addressTb.TabIndex = 0;
			// 
			// FunctionLbl
			// 
			this.functionLbl.Location = new System.Drawing.Point(8, 42);
			this.functionLbl.Name = "FunctionLbl";
			this.functionLbl.Size = new System.Drawing.Size(80, 16);
			this.functionLbl.TabIndex = 8;
			this.functionLbl.Text = "Function:";
			// 
			// FunctionCb
			// 
			this.functionCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.functionCb.Location = new System.Drawing.Point(96, 42);
			this.functionCb.Name = "FunctionCb";
			this.functionCb.Size = new System.Drawing.Size(136, 21);
			this.functionCb.TabIndex = 1;
			this.functionCb.SelectedIndexChanged += new System.EventHandler(this.FunctionCb_SelectedIndexChanged);
			// 
			// ModBusWizardPage1Dlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 397);
			this.Controls.Add(this.functionCb);
			this.Controls.Add(this.functionLbl);
			this.Controls.Add(this.addressTb);
			this.Controls.Add(this.addressLbl);
			this.Controls.Add(this.typeCb);
			this.Controls.Add(this.typeLbl);
			this.Name = "ModBusWizardPage1Dlg";
			this.Text = "ModBusWizardPage1Dlg";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		#region IGXWizardPage Members

		public void Back()
		{
		}

		public void Next()
		{
			try
			{
				int.Parse(addressTb.Text);
			}
			catch
			{
				throw new Exception("Address is not in integer format");
			}
		}
       
		public string Description
		{
			get
			{
                return Gurux.Modbus.AddIn.Properties.Resources.WizardDescription1Txt;
			}
		}

		public string Caption
		{
			get
			{
                return Gurux.Modbus.AddIn.Properties.Resources.WizardCaption1Txt;
			}
		}

		public GXWizardButtons EnabledButtons
		{
			get
			{
				return GXWizardButtons.All;
			}
		}

		public void Finish()
		{
			try
			{
                if (!typeCb.Enabled)
                {
                    m_Property.AccessMode = Gurux.Device.AccessMode.Read;
                }
                else
                {
                    m_Property.AccessMode = Gurux.Device.AccessMode.ReadWrite;
                }
				m_Property.Address = (UInt16) long.Parse(addressTb.Text);
				m_Property.Function = (GXModbusProperty.GXFunctionType)Enum.Parse(typeof(GXModbusProperty.GXFunctionType), functionCb.SelectedItem.ToString(), true);
				if (typeCb.SelectedItem != null)
				{
                    m_Property.ValueType = Type.GetType("System." + typeCb.SelectedItem.ToString());
				}
			}
			catch (Exception Ex)
			{
				GXCommon.ShowError(this, Ex);
			}
		}

        public void Initialize()
		{
            m_Property = Target as GXModbusProperty;
            addressTb.Text = Convert.ToString(m_Property.Address);
            int selIndex;
            foreach (object str in Enum.GetValues(typeof(Gurux.Modbus.AddIn.GXModbusProperty.GXFunctionType)))
            {
                selIndex = functionCb.Items.Add(str);
                if (((Gurux.Modbus.AddIn.GXModbusProperty.GXFunctionType)str) == m_Property.Function)
                {
                    functionCb.SelectedIndex = selIndex;
                }
            }
            if (functionCb.SelectedIndex == -1)
            {
                functionCb.SelectedIndex = 0;
            }
            if (m_Property.ValueType != null)
            {
                typeCb.SelectedIndex = typeCb.FindStringExact(m_Property.ValueType.Name);
            }
        }

		public void Cancel()
		{
		}

		public bool IsShown()
		{
			return true;
		}

        public object Target
        {
            get;
            set;
        }

		#endregion

		// Hide type if there are no types to select.
		private void FunctionCb_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				GXModbusProperty.GXFunctionType func = (GXModbusProperty.GXFunctionType)Enum.Parse(typeof(GXModbusProperty.GXFunctionType), functionCb.SelectedItem.ToString(), true);
				bool hideType = func == GXModbusProperty.GXFunctionType.CoilOutputs || func == GXModbusProperty.GXFunctionType.DigitalInputs;
				typeCb.Enabled = typeLbl.Enabled = !hideType;
				if (hideType)
				{
                    typeCb.SelectedIndex = typeCb.FindStringExact(typeof(bool).Name);
				}
				else
				{
                    typeCb.SelectedIndex = typeCb.FindStringExact(typeof(UInt32).Name);
				}
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
		}
	}
}
