//
// --------------------------------------------------------------------------
//  Gurux Ltd
// 
//
//
// Filename:        $HeadURL: svn://utopia/projects/GXDeviceEditor/Development/AddIns/Modbus/PropertyDlg.cs $
//
// Version:         $Revision: 870 $,
//                  $Date: 2009-09-29 17:21:48 +0300 (ti, 29 syys 2009) $
//                  $Author: airija $
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
using GuruxDeviceEditor;

namespace Modbus_RTU
{
	/// <summary>
	/// Summary description for PropertyDlg.
	/// </summary>
	public class PropertyDlg : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;		
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage CommonTab;
		private System.Windows.Forms.TabPage WriteTab;
		private System.Windows.Forms.TabPage ReadTab;
		private System.Windows.Forms.GroupBox GeneralGB;
		private System.Windows.Forms.Label NameLBL;
		private System.Windows.Forms.TextBox NameTB;
		private System.Windows.Forms.Label CategoryLBL;
		private System.Windows.Forms.Label TypeLBL;
		private System.Windows.Forms.TextBox UnitTB;
		private System.Windows.Forms.Label UnitLBL;
		private System.Windows.Forms.ComboBox CategoryDD;
		private System.Windows.Forms.ComboBox TypeDD;
		private System.Windows.Forms.GroupBox ReadResendingGB;
		private System.Windows.Forms.GroupBox ReadWaitTimeGB;
		private System.Windows.Forms.GroupBox ReadErrorStopGB;
		private System.Windows.Forms.RadioButton ReadSendDontWaitRB;
		private System.Windows.Forms.Label WaitMillisecondsLBL;
		private System.Windows.Forms.TextBox ReadWaitTB;
		private System.Windows.Forms.Label ReadWaitLBL;
		private System.Windows.Forms.Label ReadResendTimesTB;
		private System.Windows.Forms.TextBox ReadResendTB;
		private System.Windows.Forms.Label ReadResendLBL;
		private System.Windows.Forms.GroupBox WriteErrorStopGB;
		private System.Windows.Forms.GroupBox WriteWaitTimeGB;
		private System.Windows.Forms.GroupBox WriteResendingGB;
		private System.Windows.Forms.RadioButton WriteSendDontWaitRB;
		private System.Windows.Forms.Label WriteResendTimeTB;
		private System.Windows.Forms.TextBox WriteResendTB;
		private System.Windows.Forms.Label WriteResendLBL;
		private System.Windows.Forms.RadioButton ReadUseProtocolResendRB;
		private System.Windows.Forms.RadioButton ReadSendWaitRB;
		private System.Windows.Forms.RadioButton ReadResendWaitRB;
		private System.Windows.Forms.RadioButton ReadUseProtocolWaitRB;
		private System.Windows.Forms.RadioButton ReadUseSpecifiedRB;
		private System.Windows.Forms.RadioButton WriteUseSpecifiedRB;
		private System.Windows.Forms.RadioButton WriteUseProtocolWaitRB;
		private System.Windows.Forms.Label WriteWaitMillisecondsLBL;
		private System.Windows.Forms.TextBox WriteWaitTB;
		private System.Windows.Forms.Label WriteWaitLBL;
		private System.Windows.Forms.RadioButton WriteResendWaitRB;
		private System.Windows.Forms.RadioButton WriteSendWaitRB;
		private System.Windows.Forms.RadioButton WriteUseProtocolResendRB;
		private bool m_edit = false;
		private GXDevice m_GXDevice1 = null;
		private System.Windows.Forms.CheckBox ReadErrorStopCB;
		private System.Windows.Forms.CheckBox WriteErrorStopCB;
		private GXProperty m_GXProperty1 = null;
		private System.Windows.Forms.TabPage DescriptionTab;
		private System.Windows.Forms.TextBox DescriptionTB;
		GXWndState state = new GXWndState();
		private System.Windows.Forms.ComboBox AccessModeCB;
		private System.Windows.Forms.Label AccessModeLbl;
		private System.Windows.Forms.Label AccessTypeLbl;
		private System.Windows.Forms.ComboBox AccessTypeCB;
		private System.Windows.Forms.CheckBox HiddenCB;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox ExpirationReadTB;
		private System.Windows.Forms.RadioButton ExpirationReadRB;
		private System.Windows.Forms.RadioButton DeviceExpirationReadRB;
		private System.Windows.Forms.RadioButton NoExpirationReadRB;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ExpirationWriteTB;
		private System.Windows.Forms.RadioButton ExpirationWriteRB;
		private System.Windows.Forms.RadioButton DeviceExpirationWriteRB;
		private System.Windows.Forms.RadioButton NoExpirationWriteRB;
		private System.Windows.Forms.TextBox AddressTB;
		private System.Windows.Forms.Label AddressLbl;
		private System.Windows.Forms.ComboBox IOTB;
		private System.Windows.Forms.TabPage GraphTab;
		private System.Windows.Forms.GroupBox GraphGb;
		private System.Windows.Forms.CheckBox ShowGraphCb;
		private System.Windows.Forms.Label IOLBL;
		private System.Windows.Forms.RadioButton ReadOnceExpirationReadRB;
		private System.Windows.Forms.TabPage Common2Tab;
		private System.Windows.Forms.CheckBox HexCb;
		private System.Windows.Forms.GroupBox StaticValueGB;
		private System.Windows.Forms.GroupBox DefaultValueGB;
		private System.Windows.Forms.Button DefaultValueFormulaBtn;
		private System.Windows.Forms.CheckBox DefaultValueFormulaCB;
		private System.Windows.Forms.CheckBox DefaultValueCB;
		private System.Windows.Forms.TextBox DefaultValueTB;
		private System.Windows.Forms.GroupBox MinimumValueGB;
		private System.Windows.Forms.Button MinimumValueFormulaBtn;
		private System.Windows.Forms.TextBox MinimumTB;
		private System.Windows.Forms.CheckBox MinimumValueFormulaCB;
		private System.Windows.Forms.CheckBox MinimumValyeCB;
		private System.Windows.Forms.GroupBox MaximumValueGB;
		private System.Windows.Forms.TextBox MaximumTB;
		private System.Windows.Forms.Button MaximumValueFormulaBtn;
		private System.Windows.Forms.CheckBox MaximumValueFormulaCB;
		private System.Windows.Forms.CheckBox MaximumValueCB;
		private System.Windows.Forms.GroupBox ActualValueGB;
		private System.Windows.Forms.GroupBox UIFormulaGB;
		private System.Windows.Forms.Button UIFormulaBtn;
		private System.Windows.Forms.CheckBox UIFormulaCB;
		private System.Windows.Forms.TextBox UIValueFormulaTB;
		private System.Windows.Forms.GroupBox DeviceFormulaGB;
		private System.Windows.Forms.CheckBox DeviceFormulaCB;
		private System.Windows.Forms.Button DeviceFormulaBtn;
		private System.Windows.Forms.TextBox DeviceValueFormulaTB;
		private SortedList m_Types = new SortedList();

		public PropertyDlg(GXDevice GXDevice1, GXProperty GXProperty1, bool Edit)
		{
			m_GXProperty1 = GXProperty1;
			m_GXDevice1 = GXDevice1;
			m_edit = Edit;
			m_Types = CreateTypeTable();
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			PropertyDlgBase DlgBase = new PropertyDlgBase();
			DlgBase.SortTabOrder(GeneralGB);
			DlgBase.SortTabOrder(Common2Tab);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PropertyDlg));
			this.CancelBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.CommonTab = new System.Windows.Forms.TabPage();
			this.GeneralGB = new System.Windows.Forms.GroupBox();
			this.AddressTB = new System.Windows.Forms.TextBox();
			this.AddressLbl = new System.Windows.Forms.Label();
			this.IOTB = new System.Windows.Forms.ComboBox();
			this.IOLBL = new System.Windows.Forms.Label();
			this.AccessTypeCB = new System.Windows.Forms.ComboBox();
			this.AccessTypeLbl = new System.Windows.Forms.Label();
			this.AccessModeCB = new System.Windows.Forms.ComboBox();
			this.AccessModeLbl = new System.Windows.Forms.Label();
			this.HiddenCB = new System.Windows.Forms.CheckBox();
			this.TypeDD = new System.Windows.Forms.ComboBox();
			this.CategoryDD = new System.Windows.Forms.ComboBox();
			this.UnitTB = new System.Windows.Forms.TextBox();
			this.UnitLBL = new System.Windows.Forms.Label();
			this.TypeLBL = new System.Windows.Forms.Label();
			this.CategoryLBL = new System.Windows.Forms.Label();
			this.NameTB = new System.Windows.Forms.TextBox();
			this.NameLBL = new System.Windows.Forms.Label();
			this.ReadTab = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ReadOnceExpirationReadRB = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.ExpirationReadTB = new System.Windows.Forms.TextBox();
			this.ExpirationReadRB = new System.Windows.Forms.RadioButton();
			this.DeviceExpirationReadRB = new System.Windows.Forms.RadioButton();
			this.NoExpirationReadRB = new System.Windows.Forms.RadioButton();
			this.ReadErrorStopGB = new System.Windows.Forms.GroupBox();
			this.ReadErrorStopCB = new System.Windows.Forms.CheckBox();
			this.ReadWaitTimeGB = new System.Windows.Forms.GroupBox();
			this.ReadUseSpecifiedRB = new System.Windows.Forms.RadioButton();
			this.ReadUseProtocolWaitRB = new System.Windows.Forms.RadioButton();
			this.WaitMillisecondsLBL = new System.Windows.Forms.Label();
			this.ReadWaitTB = new System.Windows.Forms.TextBox();
			this.ReadWaitLBL = new System.Windows.Forms.Label();
			this.ReadResendingGB = new System.Windows.Forms.GroupBox();
			this.ReadResendTimesTB = new System.Windows.Forms.Label();
			this.ReadResendTB = new System.Windows.Forms.TextBox();
			this.ReadResendLBL = new System.Windows.Forms.Label();
			this.ReadResendWaitRB = new System.Windows.Forms.RadioButton();
			this.ReadSendWaitRB = new System.Windows.Forms.RadioButton();
			this.ReadSendDontWaitRB = new System.Windows.Forms.RadioButton();
			this.ReadUseProtocolResendRB = new System.Windows.Forms.RadioButton();
			this.WriteTab = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ExpirationWriteTB = new System.Windows.Forms.TextBox();
			this.ExpirationWriteRB = new System.Windows.Forms.RadioButton();
			this.DeviceExpirationWriteRB = new System.Windows.Forms.RadioButton();
			this.NoExpirationWriteRB = new System.Windows.Forms.RadioButton();
			this.WriteErrorStopGB = new System.Windows.Forms.GroupBox();
			this.WriteErrorStopCB = new System.Windows.Forms.CheckBox();
			this.WriteWaitTimeGB = new System.Windows.Forms.GroupBox();
			this.WriteUseSpecifiedRB = new System.Windows.Forms.RadioButton();
			this.WriteUseProtocolWaitRB = new System.Windows.Forms.RadioButton();
			this.WriteWaitMillisecondsLBL = new System.Windows.Forms.Label();
			this.WriteWaitTB = new System.Windows.Forms.TextBox();
			this.WriteWaitLBL = new System.Windows.Forms.Label();
			this.WriteResendingGB = new System.Windows.Forms.GroupBox();
			this.WriteResendTimeTB = new System.Windows.Forms.Label();
			this.WriteResendTB = new System.Windows.Forms.TextBox();
			this.WriteResendLBL = new System.Windows.Forms.Label();
			this.WriteResendWaitRB = new System.Windows.Forms.RadioButton();
			this.WriteSendWaitRB = new System.Windows.Forms.RadioButton();
			this.WriteSendDontWaitRB = new System.Windows.Forms.RadioButton();
			this.WriteUseProtocolResendRB = new System.Windows.Forms.RadioButton();
			this.DescriptionTab = new System.Windows.Forms.TabPage();
			this.DescriptionTB = new System.Windows.Forms.TextBox();
			this.GraphTab = new System.Windows.Forms.TabPage();
			this.GraphGb = new System.Windows.Forms.GroupBox();
			this.ShowGraphCb = new System.Windows.Forms.CheckBox();
			this.Common2Tab = new System.Windows.Forms.TabPage();
			this.HexCb = new System.Windows.Forms.CheckBox();
			this.StaticValueGB = new System.Windows.Forms.GroupBox();
			this.DefaultValueGB = new System.Windows.Forms.GroupBox();
			this.DefaultValueFormulaBtn = new System.Windows.Forms.Button();
			this.DefaultValueFormulaCB = new System.Windows.Forms.CheckBox();
			this.DefaultValueCB = new System.Windows.Forms.CheckBox();
			this.DefaultValueTB = new System.Windows.Forms.TextBox();
			this.MinimumValueGB = new System.Windows.Forms.GroupBox();
			this.MinimumValueFormulaBtn = new System.Windows.Forms.Button();
			this.MinimumTB = new System.Windows.Forms.TextBox();
			this.MinimumValueFormulaCB = new System.Windows.Forms.CheckBox();
			this.MinimumValyeCB = new System.Windows.Forms.CheckBox();
			this.MaximumValueGB = new System.Windows.Forms.GroupBox();
			this.MaximumTB = new System.Windows.Forms.TextBox();
			this.MaximumValueFormulaBtn = new System.Windows.Forms.Button();
			this.MaximumValueFormulaCB = new System.Windows.Forms.CheckBox();
			this.MaximumValueCB = new System.Windows.Forms.CheckBox();
			this.ActualValueGB = new System.Windows.Forms.GroupBox();
			this.UIFormulaGB = new System.Windows.Forms.GroupBox();
			this.UIFormulaBtn = new System.Windows.Forms.Button();
			this.UIFormulaCB = new System.Windows.Forms.CheckBox();
			this.UIValueFormulaTB = new System.Windows.Forms.TextBox();
			this.DeviceFormulaGB = new System.Windows.Forms.GroupBox();
			this.DeviceFormulaCB = new System.Windows.Forms.CheckBox();
			this.DeviceFormulaBtn = new System.Windows.Forms.Button();
			this.DeviceValueFormulaTB = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.CommonTab.SuspendLayout();
			this.GeneralGB.SuspendLayout();
			this.ReadTab.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.ReadErrorStopGB.SuspendLayout();
			this.ReadWaitTimeGB.SuspendLayout();
			this.ReadResendingGB.SuspendLayout();
			this.WriteTab.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.WriteErrorStopGB.SuspendLayout();
			this.WriteWaitTimeGB.SuspendLayout();
			this.WriteResendingGB.SuspendLayout();
			this.DescriptionTab.SuspendLayout();
			this.GraphTab.SuspendLayout();
			this.GraphGb.SuspendLayout();
			this.Common2Tab.SuspendLayout();
			this.StaticValueGB.SuspendLayout();
			this.DefaultValueGB.SuspendLayout();
			this.MinimumValueGB.SuspendLayout();
			this.MaximumValueGB.SuspendLayout();
			this.ActualValueGB.SuspendLayout();
			this.UIFormulaGB.SuspendLayout();
			this.DeviceFormulaGB.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBtn
			// 
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(328, 536);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(72, 24);
			this.CancelBtn.TabIndex = 21;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
			// 
			// OKBtn
			// 
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(240, 536);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(72, 24);
			this.OKBtn.TabIndex = 20;
			this.OKBtn.Text = "OK";
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.CommonTab);
			this.tabControl1.Controls.Add(this.Common2Tab);
			this.tabControl1.Controls.Add(this.ReadTab);
			this.tabControl1.Controls.Add(this.WriteTab);
			this.tabControl1.Controls.Add(this.DescriptionTab);
			this.tabControl1.Controls.Add(this.GraphTab);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(392, 520);
			this.tabControl1.TabIndex = 0;
			// 
			// CommonTab
			// 
			this.CommonTab.Controls.Add(this.GeneralGB);
			this.CommonTab.Location = new System.Drawing.Point(4, 22);
			this.CommonTab.Name = "CommonTab";
			this.CommonTab.Size = new System.Drawing.Size(384, 494);
			this.CommonTab.TabIndex = 0;
			this.CommonTab.Text = "Common";
			// 
			// GeneralGB
			// 
			this.GeneralGB.Controls.Add(this.AddressTB);
			this.GeneralGB.Controls.Add(this.AddressLbl);
			this.GeneralGB.Controls.Add(this.IOTB);
			this.GeneralGB.Controls.Add(this.IOLBL);
			this.GeneralGB.Controls.Add(this.AccessTypeCB);
			this.GeneralGB.Controls.Add(this.AccessTypeLbl);
			this.GeneralGB.Controls.Add(this.AccessModeCB);
			this.GeneralGB.Controls.Add(this.AccessModeLbl);
			this.GeneralGB.Controls.Add(this.HiddenCB);
			this.GeneralGB.Controls.Add(this.TypeDD);
			this.GeneralGB.Controls.Add(this.CategoryDD);
			this.GeneralGB.Controls.Add(this.UnitTB);
			this.GeneralGB.Controls.Add(this.UnitLBL);
			this.GeneralGB.Controls.Add(this.TypeLBL);
			this.GeneralGB.Controls.Add(this.CategoryLBL);
			this.GeneralGB.Controls.Add(this.NameTB);
			this.GeneralGB.Controls.Add(this.NameLBL);
			this.GeneralGB.Location = new System.Drawing.Point(8, 8);
			this.GeneralGB.Name = "GeneralGB";
			this.GeneralGB.Size = new System.Drawing.Size(360, 376);
			this.GeneralGB.TabIndex = 0;
			this.GeneralGB.TabStop = false;
			this.GeneralGB.Text = "General";
			this.GeneralGB.Enter += new System.EventHandler(this.GeneralGB_Enter);
			// 
			// AddressTB
			// 
			this.AddressTB.Location = new System.Drawing.Point(152, 88);
			this.AddressTB.Name = "AddressTB";
			this.AddressTB.Size = new System.Drawing.Size(160, 20);
			this.AddressTB.TabIndex = 3;
			this.AddressTB.Text = "";
			// 
			// AddressLbl
			// 
			this.AddressLbl.Location = new System.Drawing.Point(48, 88);
			this.AddressLbl.Name = "AddressLbl";
			this.AddressLbl.Size = new System.Drawing.Size(96, 24);
			this.AddressLbl.TabIndex = 20;
			this.AddressLbl.Text = "Address (Hex):";
			// 
			// IOTB
			// 
			this.IOTB.Cursor = System.Windows.Forms.Cursors.Default;
			this.IOTB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.IOTB.Location = new System.Drawing.Point(152, 64);
			this.IOTB.Name = "IOTB";
			this.IOTB.Size = new System.Drawing.Size(160, 21);
			this.IOTB.TabIndex = 2;
			this.IOTB.SelectedIndexChanged += new System.EventHandler(this.IOTB_SelectedIndexChanged);
			// 
			// IOLBL
			// 
			this.IOLBL.Location = new System.Drawing.Point(88, 64);
			this.IOLBL.Name = "IOLBL";
			this.IOLBL.Size = new System.Drawing.Size(56, 24);
			this.IOLBL.TabIndex = 19;
			this.IOLBL.Text = "I/O:";
			// 
			// AccessTypeCB
			// 
			this.AccessTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.AccessTypeCB.Location = new System.Drawing.Point(152, 184);
			this.AccessTypeCB.Name = "AccessTypeCB";
			this.AccessTypeCB.Size = new System.Drawing.Size(160, 21);
			this.AccessTypeCB.TabIndex = 8;
			// 
			// AccessTypeLbl
			// 
			this.AccessTypeLbl.Location = new System.Drawing.Point(48, 184);
			this.AccessTypeLbl.Name = "AccessTypeLbl";
			this.AccessTypeLbl.Size = new System.Drawing.Size(96, 24);
			this.AccessTypeLbl.TabIndex = 12;
			this.AccessTypeLbl.Text = "Access Type:";
			// 
			// AccessModeCB
			// 
			this.AccessModeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.AccessModeCB.Location = new System.Drawing.Point(152, 160);
			this.AccessModeCB.Name = "AccessModeCB";
			this.AccessModeCB.Size = new System.Drawing.Size(160, 21);
			this.AccessModeCB.TabIndex = 7;
			// 
			// AccessModeLbl
			// 
			this.AccessModeLbl.Location = new System.Drawing.Point(48, 160);
			this.AccessModeLbl.Name = "AccessModeLbl";
			this.AccessModeLbl.Size = new System.Drawing.Size(96, 24);
			this.AccessModeLbl.TabIndex = 10;
			this.AccessModeLbl.Text = "Access Mode:";
			// 
			// HiddenCB
			// 
			this.HiddenCB.Location = new System.Drawing.Point(152, 208);
			this.HiddenCB.Name = "HiddenCB";
			this.HiddenCB.Size = new System.Drawing.Size(64, 16);
			this.HiddenCB.TabIndex = 9;
			this.HiddenCB.Text = "Hidden";
			// 
			// TypeDD
			// 
			this.TypeDD.Cursor = System.Windows.Forms.Cursors.Default;
			this.TypeDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeDD.Location = new System.Drawing.Point(152, 112);
			this.TypeDD.Name = "TypeDD";
			this.TypeDD.Size = new System.Drawing.Size(160, 21);
			this.TypeDD.TabIndex = 4;
			this.TypeDD.SelectedIndexChanged += new System.EventHandler(this.TypeDD_SelectedIndexChanged);
			// 
			// CategoryDD
			// 
			this.CategoryDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CategoryDD.Location = new System.Drawing.Point(152, 40);
			this.CategoryDD.Name = "CategoryDD";
			this.CategoryDD.Size = new System.Drawing.Size(160, 21);
			this.CategoryDD.TabIndex = 1;
			// 
			// UnitTB
			// 
			this.UnitTB.Location = new System.Drawing.Point(152, 136);
			this.UnitTB.Name = "UnitTB";
			this.UnitTB.Size = new System.Drawing.Size(160, 20);
			this.UnitTB.TabIndex = 6;
			this.UnitTB.Text = "";
			// 
			// UnitLBL
			// 
			this.UnitLBL.Location = new System.Drawing.Point(88, 136);
			this.UnitLBL.Name = "UnitLBL";
			this.UnitLBL.Size = new System.Drawing.Size(56, 16);
			this.UnitLBL.TabIndex = 6;
			this.UnitLBL.Text = "Unit:";
			// 
			// TypeLBL
			// 
			this.TypeLBL.Location = new System.Drawing.Point(88, 112);
			this.TypeLBL.Name = "TypeLBL";
			this.TypeLBL.Size = new System.Drawing.Size(56, 24);
			this.TypeLBL.TabIndex = 4;
			this.TypeLBL.Text = "Type:";
			// 
			// CategoryLBL
			// 
			this.CategoryLBL.Location = new System.Drawing.Point(72, 40);
			this.CategoryLBL.Name = "CategoryLBL";
			this.CategoryLBL.Size = new System.Drawing.Size(72, 24);
			this.CategoryLBL.TabIndex = 2;
			this.CategoryLBL.Text = "Category:";
			// 
			// NameTB
			// 
			this.NameTB.Location = new System.Drawing.Point(152, 16);
			this.NameTB.Name = "NameTB";
			this.NameTB.Size = new System.Drawing.Size(160, 20);
			this.NameTB.TabIndex = 0;
			this.NameTB.Text = "";
			// 
			// NameLBL
			// 
			this.NameLBL.Location = new System.Drawing.Point(88, 16);
			this.NameLBL.Name = "NameLBL";
			this.NameLBL.Size = new System.Drawing.Size(56, 24);
			this.NameLBL.TabIndex = 0;
			this.NameLBL.Text = "Name:";
			// 
			// ReadTab
			// 
			this.ReadTab.Controls.Add(this.groupBox1);
			this.ReadTab.Controls.Add(this.ReadErrorStopGB);
			this.ReadTab.Controls.Add(this.ReadWaitTimeGB);
			this.ReadTab.Controls.Add(this.ReadResendingGB);
			this.ReadTab.Location = new System.Drawing.Point(4, 22);
			this.ReadTab.Name = "ReadTab";
			this.ReadTab.Size = new System.Drawing.Size(384, 414);
			this.ReadTab.TabIndex = 2;
			this.ReadTab.Text = "Reading";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ReadOnceExpirationReadRB);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.ExpirationReadTB);
			this.groupBox1.Controls.Add(this.ExpirationReadRB);
			this.groupBox1.Controls.Add(this.DeviceExpirationReadRB);
			this.groupBox1.Controls.Add(this.NoExpirationReadRB);
			this.groupBox1.Location = new System.Drawing.Point(8, 288);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(360, 112);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Expiration";
			// 
			// ReadOnceExpirationReadRB
			// 
			this.ReadOnceExpirationReadRB.Location = new System.Drawing.Point(80, 88);
			this.ReadOnceExpirationReadRB.Name = "ReadOnceExpirationReadRB";
			this.ReadOnceExpirationReadRB.Size = new System.Drawing.Size(200, 16);
			this.ReadOnceExpirationReadRB.TabIndex = 16;
			this.ReadOnceExpirationReadRB.Text = "Read Once";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(280, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 13;
			this.label1.Text = "ms.";
			// 
			// ExpirationReadTB
			// 
			this.ExpirationReadTB.Location = new System.Drawing.Point(208, 64);
			this.ExpirationReadTB.Name = "ExpirationReadTB";
			this.ExpirationReadTB.ReadOnly = true;
			this.ExpirationReadTB.Size = new System.Drawing.Size(64, 20);
			this.ExpirationReadTB.TabIndex = 13;
			this.ExpirationReadTB.Text = "";
			// 
			// ExpirationReadRB
			// 
			this.ExpirationReadRB.Location = new System.Drawing.Point(80, 64);
			this.ExpirationReadRB.Name = "ExpirationReadRB";
			this.ExpirationReadRB.Size = new System.Drawing.Size(112, 16);
			this.ExpirationReadRB.TabIndex = 12;
			this.ExpirationReadRB.Text = "Expiration Time";
			this.ExpirationReadRB.CheckedChanged += new System.EventHandler(this.ExpirationReadRB_CheckedChanged);
			// 
			// DeviceExpirationReadRB
			// 
			this.DeviceExpirationReadRB.Location = new System.Drawing.Point(80, 40);
			this.DeviceExpirationReadRB.Name = "DeviceExpirationReadRB";
			this.DeviceExpirationReadRB.Size = new System.Drawing.Size(200, 16);
			this.DeviceExpirationReadRB.TabIndex = 11;
			this.DeviceExpirationReadRB.Text = "Use Device Expiration";
			// 
			// NoExpirationReadRB
			// 
			this.NoExpirationReadRB.Location = new System.Drawing.Point(80, 16);
			this.NoExpirationReadRB.Name = "NoExpirationReadRB";
			this.NoExpirationReadRB.Size = new System.Drawing.Size(200, 16);
			this.NoExpirationReadRB.TabIndex = 10;
			this.NoExpirationReadRB.Text = "Don\'t use Expiration";
			// 
			// ReadErrorStopGB
			// 
			this.ReadErrorStopGB.Controls.Add(this.ReadErrorStopCB);
			this.ReadErrorStopGB.Location = new System.Drawing.Point(8, 240);
			this.ReadErrorStopGB.Name = "ReadErrorStopGB";
			this.ReadErrorStopGB.Size = new System.Drawing.Size(360, 48);
			this.ReadErrorStopGB.TabIndex = 2;
			this.ReadErrorStopGB.TabStop = false;
			this.ReadErrorStopGB.Text = "Error stop";
			// 
			// ReadErrorStopCB
			// 
			this.ReadErrorStopCB.Checked = true;
			this.ReadErrorStopCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ReadErrorStopCB.Location = new System.Drawing.Point(96, 16);
			this.ReadErrorStopCB.Name = "ReadErrorStopCB";
			this.ReadErrorStopCB.Size = new System.Drawing.Size(200, 24);
			this.ReadErrorStopCB.TabIndex = 8;
			this.ReadErrorStopCB.Text = "Stop progress on error.";
			// 
			// ReadWaitTimeGB
			// 
			this.ReadWaitTimeGB.Controls.Add(this.ReadUseSpecifiedRB);
			this.ReadWaitTimeGB.Controls.Add(this.ReadUseProtocolWaitRB);
			this.ReadWaitTimeGB.Controls.Add(this.WaitMillisecondsLBL);
			this.ReadWaitTimeGB.Controls.Add(this.ReadWaitTB);
			this.ReadWaitTimeGB.Controls.Add(this.ReadWaitLBL);
			this.ReadWaitTimeGB.Location = new System.Drawing.Point(8, 144);
			this.ReadWaitTimeGB.Name = "ReadWaitTimeGB";
			this.ReadWaitTimeGB.Size = new System.Drawing.Size(360, 96);
			this.ReadWaitTimeGB.TabIndex = 1;
			this.ReadWaitTimeGB.TabStop = false;
			this.ReadWaitTimeGB.Text = "Wait time";
			// 
			// ReadUseSpecifiedRB
			// 
			this.ReadUseSpecifiedRB.Location = new System.Drawing.Point(96, 40);
			this.ReadUseSpecifiedRB.Name = "ReadUseSpecifiedRB";
			this.ReadUseSpecifiedRB.Size = new System.Drawing.Size(200, 16);
			this.ReadUseSpecifiedRB.TabIndex = 6;
			this.ReadUseSpecifiedRB.Text = "Use specified value";
			this.ReadUseSpecifiedRB.CheckedChanged += new System.EventHandler(this.ReadUseSpecifiedRB_CheckedChanged);
			// 
			// ReadUseProtocolWaitRB
			// 
			this.ReadUseProtocolWaitRB.Checked = true;
			this.ReadUseProtocolWaitRB.Location = new System.Drawing.Point(96, 16);
			this.ReadUseProtocolWaitRB.Name = "ReadUseProtocolWaitRB";
			this.ReadUseProtocolWaitRB.Size = new System.Drawing.Size(200, 16);
			this.ReadUseProtocolWaitRB.TabIndex = 5;
			this.ReadUseProtocolWaitRB.TabStop = true;
			this.ReadUseProtocolWaitRB.Text = "Use protocol value";
			// 
			// WaitMillisecondsLBL
			// 
			this.WaitMillisecondsLBL.Location = new System.Drawing.Point(232, 64);
			this.WaitMillisecondsLBL.Name = "WaitMillisecondsLBL";
			this.WaitMillisecondsLBL.Size = new System.Drawing.Size(72, 16);
			this.WaitMillisecondsLBL.TabIndex = 7;
			this.WaitMillisecondsLBL.Text = "milliseconds";
			// 
			// ReadWaitTB
			// 
			this.ReadWaitTB.Location = new System.Drawing.Point(160, 64);
			this.ReadWaitTB.Name = "ReadWaitTB";
			this.ReadWaitTB.ReadOnly = true;
			this.ReadWaitTB.Size = new System.Drawing.Size(64, 20);
			this.ReadWaitTB.TabIndex = 7;
			this.ReadWaitTB.Text = "";
			// 
			// ReadWaitLBL
			// 
			this.ReadWaitLBL.Location = new System.Drawing.Point(120, 64);
			this.ReadWaitLBL.Name = "ReadWaitLBL";
			this.ReadWaitLBL.Size = new System.Drawing.Size(40, 16);
			this.ReadWaitLBL.TabIndex = 5;
			this.ReadWaitLBL.Text = "Wait";
			// 
			// ReadResendingGB
			// 
			this.ReadResendingGB.Controls.Add(this.ReadResendTimesTB);
			this.ReadResendingGB.Controls.Add(this.ReadResendTB);
			this.ReadResendingGB.Controls.Add(this.ReadResendLBL);
			this.ReadResendingGB.Controls.Add(this.ReadResendWaitRB);
			this.ReadResendingGB.Controls.Add(this.ReadSendWaitRB);
			this.ReadResendingGB.Controls.Add(this.ReadSendDontWaitRB);
			this.ReadResendingGB.Controls.Add(this.ReadUseProtocolResendRB);
			this.ReadResendingGB.Location = new System.Drawing.Point(8, 8);
			this.ReadResendingGB.Name = "ReadResendingGB";
			this.ReadResendingGB.Size = new System.Drawing.Size(360, 136);
			this.ReadResendingGB.TabIndex = 0;
			this.ReadResendingGB.TabStop = false;
			this.ReadResendingGB.Text = "Resending";
			// 
			// ReadResendTimesTB
			// 
			this.ReadResendTimesTB.Location = new System.Drawing.Point(240, 104);
			this.ReadResendTimesTB.Name = "ReadResendTimesTB";
			this.ReadResendTimesTB.Size = new System.Drawing.Size(56, 16);
			this.ReadResendTimesTB.TabIndex = 7;
			this.ReadResendTimesTB.Text = "times";
			// 
			// ReadResendTB
			// 
			this.ReadResendTB.Location = new System.Drawing.Point(168, 104);
			this.ReadResendTB.Name = "ReadResendTB";
			this.ReadResendTB.ReadOnly = true;
			this.ReadResendTB.Size = new System.Drawing.Size(64, 20);
			this.ReadResendTB.TabIndex = 4;
			this.ReadResendTB.Text = "";
			// 
			// ReadResendLBL
			// 
			this.ReadResendLBL.Location = new System.Drawing.Point(112, 104);
			this.ReadResendLBL.Name = "ReadResendLBL";
			this.ReadResendLBL.Size = new System.Drawing.Size(48, 16);
			this.ReadResendLBL.TabIndex = 5;
			this.ReadResendLBL.Text = "Resend";
			// 
			// ReadResendWaitRB
			// 
			this.ReadResendWaitRB.Location = new System.Drawing.Point(96, 88);
			this.ReadResendWaitRB.Name = "ReadResendWaitRB";
			this.ReadResendWaitRB.Size = new System.Drawing.Size(200, 16);
			this.ReadResendWaitRB.TabIndex = 3;
			this.ReadResendWaitRB.Text = "Send and wait for reply.";
			this.ReadResendWaitRB.CheckedChanged += new System.EventHandler(this.ReadResendWaitRB_CheckedChanged);
			// 
			// ReadSendWaitRB
			// 
			this.ReadSendWaitRB.Location = new System.Drawing.Point(96, 64);
			this.ReadSendWaitRB.Name = "ReadSendWaitRB";
			this.ReadSendWaitRB.Size = new System.Drawing.Size(200, 16);
			this.ReadSendWaitRB.TabIndex = 2;
			this.ReadSendWaitRB.Text = "Send once. Wait for reply.";
			// 
			// ReadSendDontWaitRB
			// 
			this.ReadSendDontWaitRB.Location = new System.Drawing.Point(96, 40);
			this.ReadSendDontWaitRB.Name = "ReadSendDontWaitRB";
			this.ReadSendDontWaitRB.Size = new System.Drawing.Size(200, 16);
			this.ReadSendDontWaitRB.TabIndex = 1;
			this.ReadSendDontWaitRB.Text = "Send once. Don\'t wait for reply.";
			// 
			// ReadUseProtocolResendRB
			// 
			this.ReadUseProtocolResendRB.Checked = true;
			this.ReadUseProtocolResendRB.Location = new System.Drawing.Point(96, 16);
			this.ReadUseProtocolResendRB.Name = "ReadUseProtocolResendRB";
			this.ReadUseProtocolResendRB.Size = new System.Drawing.Size(200, 16);
			this.ReadUseProtocolResendRB.TabIndex = 0;
			this.ReadUseProtocolResendRB.TabStop = true;
			this.ReadUseProtocolResendRB.Text = "Use protocol value.";
			// 
			// WriteTab
			// 
			this.WriteTab.Controls.Add(this.groupBox2);
			this.WriteTab.Controls.Add(this.WriteErrorStopGB);
			this.WriteTab.Controls.Add(this.WriteWaitTimeGB);
			this.WriteTab.Controls.Add(this.WriteResendingGB);
			this.WriteTab.Location = new System.Drawing.Point(4, 22);
			this.WriteTab.Name = "WriteTab";
			this.WriteTab.Size = new System.Drawing.Size(384, 414);
			this.WriteTab.TabIndex = 1;
			this.WriteTab.Text = "Writing";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.ExpirationWriteTB);
			this.groupBox2.Controls.Add(this.ExpirationWriteRB);
			this.groupBox2.Controls.Add(this.DeviceExpirationWriteRB);
			this.groupBox2.Controls.Add(this.NoExpirationWriteRB);
			this.groupBox2.Location = new System.Drawing.Point(8, 288);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(360, 96);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Expiration";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(280, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "ms.";
			// 
			// ExpirationWriteTB
			// 
			this.ExpirationWriteTB.Location = new System.Drawing.Point(208, 64);
			this.ExpirationWriteTB.Name = "ExpirationWriteTB";
			this.ExpirationWriteTB.ReadOnly = true;
			this.ExpirationWriteTB.Size = new System.Drawing.Size(64, 20);
			this.ExpirationWriteTB.TabIndex = 13;
			this.ExpirationWriteTB.Text = "";
			// 
			// ExpirationWriteRB
			// 
			this.ExpirationWriteRB.Location = new System.Drawing.Point(80, 64);
			this.ExpirationWriteRB.Name = "ExpirationWriteRB";
			this.ExpirationWriteRB.Size = new System.Drawing.Size(112, 16);
			this.ExpirationWriteRB.TabIndex = 12;
			this.ExpirationWriteRB.Text = "Expiration Time";
			this.ExpirationWriteRB.CheckedChanged += new System.EventHandler(this.ExpirationWriteRB_CheckedChanged);
			// 
			// DeviceExpirationWriteRB
			// 
			this.DeviceExpirationWriteRB.Location = new System.Drawing.Point(80, 40);
			this.DeviceExpirationWriteRB.Name = "DeviceExpirationWriteRB";
			this.DeviceExpirationWriteRB.Size = new System.Drawing.Size(200, 16);
			this.DeviceExpirationWriteRB.TabIndex = 11;
			this.DeviceExpirationWriteRB.Text = "Use Device Expiration";
			// 
			// NoExpirationWriteRB
			// 
			this.NoExpirationWriteRB.Location = new System.Drawing.Point(80, 16);
			this.NoExpirationWriteRB.Name = "NoExpirationWriteRB";
			this.NoExpirationWriteRB.Size = new System.Drawing.Size(200, 16);
			this.NoExpirationWriteRB.TabIndex = 9;
			this.NoExpirationWriteRB.Text = "Don\'t use Expiration";
			// 
			// WriteErrorStopGB
			// 
			this.WriteErrorStopGB.Controls.Add(this.WriteErrorStopCB);
			this.WriteErrorStopGB.Location = new System.Drawing.Point(8, 240);
			this.WriteErrorStopGB.Name = "WriteErrorStopGB";
			this.WriteErrorStopGB.Size = new System.Drawing.Size(360, 48);
			this.WriteErrorStopGB.TabIndex = 6;
			this.WriteErrorStopGB.TabStop = false;
			this.WriteErrorStopGB.Text = "Error stop";
			// 
			// WriteErrorStopCB
			// 
			this.WriteErrorStopCB.Checked = true;
			this.WriteErrorStopCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.WriteErrorStopCB.Location = new System.Drawing.Point(96, 16);
			this.WriteErrorStopCB.Name = "WriteErrorStopCB";
			this.WriteErrorStopCB.Size = new System.Drawing.Size(200, 24);
			this.WriteErrorStopCB.TabIndex = 7;
			this.WriteErrorStopCB.Text = "Stop progress on error.";
			// 
			// WriteWaitTimeGB
			// 
			this.WriteWaitTimeGB.Controls.Add(this.WriteUseSpecifiedRB);
			this.WriteWaitTimeGB.Controls.Add(this.WriteUseProtocolWaitRB);
			this.WriteWaitTimeGB.Controls.Add(this.WriteWaitMillisecondsLBL);
			this.WriteWaitTimeGB.Controls.Add(this.WriteWaitTB);
			this.WriteWaitTimeGB.Controls.Add(this.WriteWaitLBL);
			this.WriteWaitTimeGB.Location = new System.Drawing.Point(8, 144);
			this.WriteWaitTimeGB.Name = "WriteWaitTimeGB";
			this.WriteWaitTimeGB.Size = new System.Drawing.Size(360, 96);
			this.WriteWaitTimeGB.TabIndex = 5;
			this.WriteWaitTimeGB.TabStop = false;
			this.WriteWaitTimeGB.Text = "Wait time";
			// 
			// WriteUseSpecifiedRB
			// 
			this.WriteUseSpecifiedRB.Location = new System.Drawing.Point(96, 40);
			this.WriteUseSpecifiedRB.Name = "WriteUseSpecifiedRB";
			this.WriteUseSpecifiedRB.Size = new System.Drawing.Size(200, 16);
			this.WriteUseSpecifiedRB.TabIndex = 6;
			this.WriteUseSpecifiedRB.Text = "Use specified value";
			this.WriteUseSpecifiedRB.CheckedChanged += new System.EventHandler(this.WriteUseSpecifiedRB_CheckedChanged);
			// 
			// WriteUseProtocolWaitRB
			// 
			this.WriteUseProtocolWaitRB.Checked = true;
			this.WriteUseProtocolWaitRB.Location = new System.Drawing.Point(96, 16);
			this.WriteUseProtocolWaitRB.Name = "WriteUseProtocolWaitRB";
			this.WriteUseProtocolWaitRB.Size = new System.Drawing.Size(200, 16);
			this.WriteUseProtocolWaitRB.TabIndex = 5;
			this.WriteUseProtocolWaitRB.TabStop = true;
			this.WriteUseProtocolWaitRB.Text = "Use protocol value";
			// 
			// WriteWaitMillisecondsLBL
			// 
			this.WriteWaitMillisecondsLBL.Location = new System.Drawing.Point(232, 64);
			this.WriteWaitMillisecondsLBL.Name = "WriteWaitMillisecondsLBL";
			this.WriteWaitMillisecondsLBL.Size = new System.Drawing.Size(72, 16);
			this.WriteWaitMillisecondsLBL.TabIndex = 7;
			this.WriteWaitMillisecondsLBL.Text = "milliseconds";
			// 
			// WriteWaitTB
			// 
			this.WriteWaitTB.Location = new System.Drawing.Point(160, 64);
			this.WriteWaitTB.Name = "WriteWaitTB";
			this.WriteWaitTB.ReadOnly = true;
			this.WriteWaitTB.Size = new System.Drawing.Size(64, 20);
			this.WriteWaitTB.TabIndex = 6;
			this.WriteWaitTB.Text = "";
			// 
			// WriteWaitLBL
			// 
			this.WriteWaitLBL.Location = new System.Drawing.Point(120, 64);
			this.WriteWaitLBL.Name = "WriteWaitLBL";
			this.WriteWaitLBL.Size = new System.Drawing.Size(40, 16);
			this.WriteWaitLBL.TabIndex = 5;
			this.WriteWaitLBL.Text = "Wait";
			// 
			// WriteResendingGB
			// 
			this.WriteResendingGB.Controls.Add(this.WriteResendTimeTB);
			this.WriteResendingGB.Controls.Add(this.WriteResendTB);
			this.WriteResendingGB.Controls.Add(this.WriteResendLBL);
			this.WriteResendingGB.Controls.Add(this.WriteResendWaitRB);
			this.WriteResendingGB.Controls.Add(this.WriteSendWaitRB);
			this.WriteResendingGB.Controls.Add(this.WriteSendDontWaitRB);
			this.WriteResendingGB.Controls.Add(this.WriteUseProtocolResendRB);
			this.WriteResendingGB.Location = new System.Drawing.Point(8, 8);
			this.WriteResendingGB.Name = "WriteResendingGB";
			this.WriteResendingGB.Size = new System.Drawing.Size(360, 136);
			this.WriteResendingGB.TabIndex = 4;
			this.WriteResendingGB.TabStop = false;
			this.WriteResendingGB.Text = "Resending";
			// 
			// WriteResendTimeTB
			// 
			this.WriteResendTimeTB.Location = new System.Drawing.Point(240, 104);
			this.WriteResendTimeTB.Name = "WriteResendTimeTB";
			this.WriteResendTimeTB.Size = new System.Drawing.Size(56, 16);
			this.WriteResendTimeTB.TabIndex = 7;
			this.WriteResendTimeTB.Text = "times";
			// 
			// WriteResendTB
			// 
			this.WriteResendTB.Location = new System.Drawing.Point(168, 104);
			this.WriteResendTB.Name = "WriteResendTB";
			this.WriteResendTB.ReadOnly = true;
			this.WriteResendTB.Size = new System.Drawing.Size(64, 20);
			this.WriteResendTB.TabIndex = 4;
			this.WriteResendTB.Text = "";
			// 
			// WriteResendLBL
			// 
			this.WriteResendLBL.Location = new System.Drawing.Point(112, 104);
			this.WriteResendLBL.Name = "WriteResendLBL";
			this.WriteResendLBL.Size = new System.Drawing.Size(48, 16);
			this.WriteResendLBL.TabIndex = 5;
			this.WriteResendLBL.Text = "Resend";
			// 
			// WriteResendWaitRB
			// 
			this.WriteResendWaitRB.Location = new System.Drawing.Point(96, 88);
			this.WriteResendWaitRB.Name = "WriteResendWaitRB";
			this.WriteResendWaitRB.Size = new System.Drawing.Size(200, 16);
			this.WriteResendWaitRB.TabIndex = 3;
			this.WriteResendWaitRB.Text = "Send and wait for reply.";
			this.WriteResendWaitRB.CheckedChanged += new System.EventHandler(this.WriteResendWaitRB_CheckedChanged);
			// 
			// WriteSendWaitRB
			// 
			this.WriteSendWaitRB.Location = new System.Drawing.Point(96, 64);
			this.WriteSendWaitRB.Name = "WriteSendWaitRB";
			this.WriteSendWaitRB.Size = new System.Drawing.Size(200, 16);
			this.WriteSendWaitRB.TabIndex = 2;
			this.WriteSendWaitRB.Text = "Send once. Wait for reply.";
			// 
			// WriteSendDontWaitRB
			// 
			this.WriteSendDontWaitRB.Location = new System.Drawing.Point(96, 40);
			this.WriteSendDontWaitRB.Name = "WriteSendDontWaitRB";
			this.WriteSendDontWaitRB.Size = new System.Drawing.Size(200, 16);
			this.WriteSendDontWaitRB.TabIndex = 1;
			this.WriteSendDontWaitRB.Text = "Send once. Don\'t wait for reply.";
			// 
			// WriteUseProtocolResendRB
			// 
			this.WriteUseProtocolResendRB.Checked = true;
			this.WriteUseProtocolResendRB.Location = new System.Drawing.Point(96, 16);
			this.WriteUseProtocolResendRB.Name = "WriteUseProtocolResendRB";
			this.WriteUseProtocolResendRB.Size = new System.Drawing.Size(200, 16);
			this.WriteUseProtocolResendRB.TabIndex = 0;
			this.WriteUseProtocolResendRB.TabStop = true;
			this.WriteUseProtocolResendRB.Text = "Use protocol value.";
			// 
			// DescriptionTab
			// 
			this.DescriptionTab.Controls.Add(this.DescriptionTB);
			this.DescriptionTab.Location = new System.Drawing.Point(4, 22);
			this.DescriptionTab.Name = "DescriptionTab";
			this.DescriptionTab.Size = new System.Drawing.Size(384, 414);
			this.DescriptionTab.TabIndex = 3;
			this.DescriptionTab.Text = "Description";
			// 
			// DescriptionTB
			// 
			this.DescriptionTB.AcceptsReturn = true;
			this.DescriptionTB.AcceptsTab = true;
			this.DescriptionTB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DescriptionTB.Location = new System.Drawing.Point(0, 0);
			this.DescriptionTB.Multiline = true;
			this.DescriptionTB.Name = "DescriptionTB";
			this.DescriptionTB.Size = new System.Drawing.Size(384, 414);
			this.DescriptionTB.TabIndex = 0;
			this.DescriptionTB.Text = "";
			// 
			// GraphTab
			// 
			this.GraphTab.Controls.Add(this.GraphGb);
			this.GraphTab.Location = new System.Drawing.Point(4, 22);
			this.GraphTab.Name = "GraphTab";
			this.GraphTab.Size = new System.Drawing.Size(384, 414);
			this.GraphTab.TabIndex = 5;
			this.GraphTab.Text = "Graph";
			// 
			// GraphGb
			// 
			this.GraphGb.Controls.Add(this.ShowGraphCb);
			this.GraphGb.Location = new System.Drawing.Point(8, 8);
			this.GraphGb.Name = "GraphGb";
			this.GraphGb.Size = new System.Drawing.Size(360, 80);
			this.GraphGb.TabIndex = 0;
			this.GraphGb.TabStop = false;
			this.GraphGb.Text = "General";
			// 
			// ShowGraphCb
			// 
			this.ShowGraphCb.Location = new System.Drawing.Point(8, 16);
			this.ShowGraphCb.Name = "ShowGraphCb";
			this.ShowGraphCb.Size = new System.Drawing.Size(88, 24);
			this.ShowGraphCb.TabIndex = 0;
			this.ShowGraphCb.Text = "Allow Graph";
			// 
			// Common2Tab
			// 
			this.Common2Tab.Controls.Add(this.StaticValueGB);
			this.Common2Tab.Controls.Add(this.ActualValueGB);
			this.Common2Tab.Location = new System.Drawing.Point(4, 22);
			this.Common2Tab.Name = "Common2Tab";
			this.Common2Tab.Size = new System.Drawing.Size(384, 494);
			this.Common2Tab.TabIndex = 6;
			this.Common2Tab.Text = "Common2";
			// 
			// HexCb
			// 
			this.HexCb.Location = new System.Drawing.Point(8, 16);
			this.HexCb.Name = "HexCb";
			this.HexCb.Size = new System.Drawing.Size(112, 16);
			this.HexCb.TabIndex = 29;
			this.HexCb.Text = "View as Hex";
			this.HexCb.CheckedChanged += new System.EventHandler(this.HexCb_CheckedChanged);
			// 
			// StaticValueGB
			// 
			this.StaticValueGB.Controls.Add(this.DefaultValueGB);
			this.StaticValueGB.Controls.Add(this.MinimumValueGB);
			this.StaticValueGB.Controls.Add(this.MaximumValueGB);
			this.StaticValueGB.Controls.Add(this.HexCb);
			this.StaticValueGB.Location = new System.Drawing.Point(8, 8);
			this.StaticValueGB.Name = "StaticValueGB";
			this.StaticValueGB.Size = new System.Drawing.Size(368, 288);
			this.StaticValueGB.TabIndex = 30;
			this.StaticValueGB.TabStop = false;
			// 
			// DefaultValueGB
			// 
			this.DefaultValueGB.Controls.Add(this.DefaultValueFormulaBtn);
			this.DefaultValueGB.Controls.Add(this.DefaultValueFormulaCB);
			this.DefaultValueGB.Controls.Add(this.DefaultValueCB);
			this.DefaultValueGB.Controls.Add(this.DefaultValueTB);
			this.DefaultValueGB.Location = new System.Drawing.Point(16, 40);
			this.DefaultValueGB.Name = "DefaultValueGB";
			this.DefaultValueGB.Size = new System.Drawing.Size(344, 72);
			this.DefaultValueGB.TabIndex = 0;
			this.DefaultValueGB.TabStop = false;
			this.DefaultValueGB.Text = "Default Value";
			// 
			// DefaultValueFormulaBtn
			// 
			this.DefaultValueFormulaBtn.Enabled = false;
			this.DefaultValueFormulaBtn.Image = ((System.Drawing.Image)(resources.GetObject("DefaultValueFormulaBtn.Image")));
			this.DefaultValueFormulaBtn.Location = new System.Drawing.Point(120, 16);
			this.DefaultValueFormulaBtn.Name = "DefaultValueFormulaBtn";
			this.DefaultValueFormulaBtn.Size = new System.Drawing.Size(24, 24);
			this.DefaultValueFormulaBtn.TabIndex = 3;
			this.DefaultValueFormulaBtn.Click += new System.EventHandler(this.DefaultValueFormulaBtn_Click);
			// 
			// DefaultValueFormulaCB
			// 
			this.DefaultValueFormulaCB.Enabled = false;
			this.DefaultValueFormulaCB.Location = new System.Drawing.Point(8, 48);
			this.DefaultValueFormulaCB.Name = "DefaultValueFormulaCB";
			this.DefaultValueFormulaCB.Size = new System.Drawing.Size(120, 16);
			this.DefaultValueFormulaCB.TabIndex = 22;
			this.DefaultValueFormulaCB.Text = "Contains Formula";
			this.DefaultValueFormulaCB.CheckedChanged += new System.EventHandler(this.DefaultValueFormulaCB_CheckedChanged);
			// 
			// DefaultValueCB
			// 
			this.DefaultValueCB.Location = new System.Drawing.Point(8, 24);
			this.DefaultValueCB.Name = "DefaultValueCB";
			this.DefaultValueCB.Size = new System.Drawing.Size(112, 16);
			this.DefaultValueCB.TabIndex = 9;
			this.DefaultValueCB.Text = "Enabled";
			this.DefaultValueCB.CheckedChanged += new System.EventHandler(this.DefaultValueCB_CheckedChanged);
			// 
			// DefaultValueTB
			// 
			this.DefaultValueTB.AcceptsReturn = true;
			this.DefaultValueTB.Location = new System.Drawing.Point(152, 16);
			this.DefaultValueTB.Multiline = true;
			this.DefaultValueTB.Name = "DefaultValueTB";
			this.DefaultValueTB.ReadOnly = true;
			this.DefaultValueTB.Size = new System.Drawing.Size(184, 48);
			this.DefaultValueTB.TabIndex = 0;
			this.DefaultValueTB.Text = "";
			// 
			// MinimumValueGB
			// 
			this.MinimumValueGB.Controls.Add(this.MinimumValueFormulaBtn);
			this.MinimumValueGB.Controls.Add(this.MinimumTB);
			this.MinimumValueGB.Controls.Add(this.MinimumValueFormulaCB);
			this.MinimumValueGB.Controls.Add(this.MinimumValyeCB);
			this.MinimumValueGB.Location = new System.Drawing.Point(16, 120);
			this.MinimumValueGB.Name = "MinimumValueGB";
			this.MinimumValueGB.Size = new System.Drawing.Size(344, 72);
			this.MinimumValueGB.TabIndex = 1;
			this.MinimumValueGB.TabStop = false;
			this.MinimumValueGB.Text = "Minimum Value";
			// 
			// MinimumValueFormulaBtn
			// 
			this.MinimumValueFormulaBtn.Enabled = false;
			this.MinimumValueFormulaBtn.Image = ((System.Drawing.Image)(resources.GetObject("MinimumValueFormulaBtn.Image")));
			this.MinimumValueFormulaBtn.Location = new System.Drawing.Point(120, 16);
			this.MinimumValueFormulaBtn.Name = "MinimumValueFormulaBtn";
			this.MinimumValueFormulaBtn.Size = new System.Drawing.Size(24, 24);
			this.MinimumValueFormulaBtn.TabIndex = 2;
			this.MinimumValueFormulaBtn.Click += new System.EventHandler(this.MinimumValueFormulaBtn_Click);
			// 
			// MinimumTB
			// 
			this.MinimumTB.AcceptsReturn = true;
			this.MinimumTB.Location = new System.Drawing.Point(152, 16);
			this.MinimumTB.Multiline = true;
			this.MinimumTB.Name = "MinimumTB";
			this.MinimumTB.ReadOnly = true;
			this.MinimumTB.Size = new System.Drawing.Size(184, 48);
			this.MinimumTB.TabIndex = 10;
			this.MinimumTB.Text = "";
			// 
			// MinimumValueFormulaCB
			// 
			this.MinimumValueFormulaCB.Enabled = false;
			this.MinimumValueFormulaCB.Location = new System.Drawing.Point(8, 40);
			this.MinimumValueFormulaCB.Name = "MinimumValueFormulaCB";
			this.MinimumValueFormulaCB.Size = new System.Drawing.Size(120, 24);
			this.MinimumValueFormulaCB.TabIndex = 23;
			this.MinimumValueFormulaCB.Text = "Contains Formula";
			this.MinimumValueFormulaCB.CheckedChanged += new System.EventHandler(this.MinimumValueFormulaCB_CheckedChanged);
			// 
			// MinimumValyeCB
			// 
			this.MinimumValyeCB.Location = new System.Drawing.Point(8, 24);
			this.MinimumValyeCB.Name = "MinimumValyeCB";
			this.MinimumValyeCB.Size = new System.Drawing.Size(112, 16);
			this.MinimumValyeCB.TabIndex = 14;
			this.MinimumValyeCB.Text = "Enabled";
			this.MinimumValyeCB.CheckedChanged += new System.EventHandler(this.MinimumValyeCB_CheckedChanged);
			// 
			// MaximumValueGB
			// 
			this.MaximumValueGB.Controls.Add(this.MaximumTB);
			this.MaximumValueGB.Controls.Add(this.MaximumValueFormulaBtn);
			this.MaximumValueGB.Controls.Add(this.MaximumValueFormulaCB);
			this.MaximumValueGB.Controls.Add(this.MaximumValueCB);
			this.MaximumValueGB.Location = new System.Drawing.Point(16, 200);
			this.MaximumValueGB.Name = "MaximumValueGB";
			this.MaximumValueGB.Size = new System.Drawing.Size(344, 72);
			this.MaximumValueGB.TabIndex = 2;
			this.MaximumValueGB.TabStop = false;
			this.MaximumValueGB.Text = "Maximum Value";
			// 
			// MaximumTB
			// 
			this.MaximumTB.AcceptsReturn = true;
			this.MaximumTB.Location = new System.Drawing.Point(152, 16);
			this.MaximumTB.Multiline = true;
			this.MaximumTB.Name = "MaximumTB";
			this.MaximumTB.ReadOnly = true;
			this.MaximumTB.Size = new System.Drawing.Size(184, 48);
			this.MaximumTB.TabIndex = 11;
			this.MaximumTB.Text = "";
			// 
			// MaximumValueFormulaBtn
			// 
			this.MaximumValueFormulaBtn.Enabled = false;
			this.MaximumValueFormulaBtn.Image = ((System.Drawing.Image)(resources.GetObject("MaximumValueFormulaBtn.Image")));
			this.MaximumValueFormulaBtn.Location = new System.Drawing.Point(120, 16);
			this.MaximumValueFormulaBtn.Name = "MaximumValueFormulaBtn";
			this.MaximumValueFormulaBtn.Size = new System.Drawing.Size(24, 24);
			this.MaximumValueFormulaBtn.TabIndex = 1;
			this.MaximumValueFormulaBtn.Click += new System.EventHandler(this.MaximumValueFormulaBtn_Click);
			// 
			// MaximumValueFormulaCB
			// 
			this.MaximumValueFormulaCB.Enabled = false;
			this.MaximumValueFormulaCB.Location = new System.Drawing.Point(8, 48);
			this.MaximumValueFormulaCB.Name = "MaximumValueFormulaCB";
			this.MaximumValueFormulaCB.Size = new System.Drawing.Size(120, 16);
			this.MaximumValueFormulaCB.TabIndex = 24;
			this.MaximumValueFormulaCB.Text = "Contains Formula";
			this.MaximumValueFormulaCB.CheckedChanged += new System.EventHandler(this.MaximumValueFormulaCB_CheckedChanged);
			// 
			// MaximumValueCB
			// 
			this.MaximumValueCB.Location = new System.Drawing.Point(8, 24);
			this.MaximumValueCB.Name = "MaximumValueCB";
			this.MaximumValueCB.Size = new System.Drawing.Size(112, 16);
			this.MaximumValueCB.TabIndex = 15;
			this.MaximumValueCB.Text = "Enabled";
			this.MaximumValueCB.CheckedChanged += new System.EventHandler(this.MaximumValueCB_CheckedChanged);
			// 
			// ActualValueGB
			// 
			this.ActualValueGB.Controls.Add(this.UIFormulaGB);
			this.ActualValueGB.Controls.Add(this.DeviceFormulaGB);
			this.ActualValueGB.Location = new System.Drawing.Point(8, 296);
			this.ActualValueGB.Name = "ActualValueGB";
			this.ActualValueGB.Size = new System.Drawing.Size(368, 184);
			this.ActualValueGB.TabIndex = 31;
			this.ActualValueGB.TabStop = false;
			// 
			// UIFormulaGB
			// 
			this.UIFormulaGB.Controls.Add(this.UIFormulaBtn);
			this.UIFormulaGB.Controls.Add(this.UIFormulaCB);
			this.UIFormulaGB.Controls.Add(this.UIValueFormulaTB);
			this.UIFormulaGB.Location = new System.Drawing.Point(16, 16);
			this.UIFormulaGB.Name = "UIFormulaGB";
			this.UIFormulaGB.Size = new System.Drawing.Size(344, 72);
			this.UIFormulaGB.TabIndex = 3;
			this.UIFormulaGB.TabStop = false;
			this.UIFormulaGB.Text = "UI Value Formula";
			// 
			// UIFormulaBtn
			// 
			this.UIFormulaBtn.Enabled = false;
			this.UIFormulaBtn.Image = ((System.Drawing.Image)(resources.GetObject("UIFormulaBtn.Image")));
			this.UIFormulaBtn.Location = new System.Drawing.Point(120, 16);
			this.UIFormulaBtn.Name = "UIFormulaBtn";
			this.UIFormulaBtn.Size = new System.Drawing.Size(24, 24);
			this.UIFormulaBtn.TabIndex = 2;
			this.UIFormulaBtn.Click += new System.EventHandler(this.UIFormulaBtn_Click);
			// 
			// UIFormulaCB
			// 
			this.UIFormulaCB.Location = new System.Drawing.Point(8, 24);
			this.UIFormulaCB.Name = "UIFormulaCB";
			this.UIFormulaCB.Size = new System.Drawing.Size(96, 16);
			this.UIFormulaCB.TabIndex = 25;
			this.UIFormulaCB.Text = "Enabled";
			this.UIFormulaCB.CheckedChanged += new System.EventHandler(this.UIFormulaCB_CheckedChanged);
			// 
			// UIValueFormulaTB
			// 
			this.UIValueFormulaTB.AcceptsReturn = true;
			this.UIValueFormulaTB.Location = new System.Drawing.Point(152, 16);
			this.UIValueFormulaTB.Multiline = true;
			this.UIValueFormulaTB.Name = "UIValueFormulaTB";
			this.UIValueFormulaTB.ReadOnly = true;
			this.UIValueFormulaTB.Size = new System.Drawing.Size(184, 48);
			this.UIValueFormulaTB.TabIndex = 12;
			this.UIValueFormulaTB.Text = "";
			// 
			// DeviceFormulaGB
			// 
			this.DeviceFormulaGB.Controls.Add(this.DeviceFormulaCB);
			this.DeviceFormulaGB.Controls.Add(this.DeviceFormulaBtn);
			this.DeviceFormulaGB.Controls.Add(this.DeviceValueFormulaTB);
			this.DeviceFormulaGB.Location = new System.Drawing.Point(16, 96);
			this.DeviceFormulaGB.Name = "DeviceFormulaGB";
			this.DeviceFormulaGB.Size = new System.Drawing.Size(344, 72);
			this.DeviceFormulaGB.TabIndex = 4;
			this.DeviceFormulaGB.TabStop = false;
			this.DeviceFormulaGB.Text = "Device Value Formula";
			// 
			// DeviceFormulaCB
			// 
			this.DeviceFormulaCB.Location = new System.Drawing.Point(8, 24);
			this.DeviceFormulaCB.Name = "DeviceFormulaCB";
			this.DeviceFormulaCB.Size = new System.Drawing.Size(96, 16);
			this.DeviceFormulaCB.TabIndex = 26;
			this.DeviceFormulaCB.Text = "Enabled";
			this.DeviceFormulaCB.CheckedChanged += new System.EventHandler(this.DeviceFormulaCB_CheckedChanged);
			// 
			// DeviceFormulaBtn
			// 
			this.DeviceFormulaBtn.Enabled = false;
			this.DeviceFormulaBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeviceFormulaBtn.Image")));
			this.DeviceFormulaBtn.Location = new System.Drawing.Point(120, 16);
			this.DeviceFormulaBtn.Name = "DeviceFormulaBtn";
			this.DeviceFormulaBtn.Size = new System.Drawing.Size(24, 24);
			this.DeviceFormulaBtn.TabIndex = 1;
			this.DeviceFormulaBtn.Click += new System.EventHandler(this.DeviceFormulaBtn_Click);
			// 
			// DeviceValueFormulaTB
			// 
			this.DeviceValueFormulaTB.AcceptsReturn = true;
			this.DeviceValueFormulaTB.Location = new System.Drawing.Point(152, 16);
			this.DeviceValueFormulaTB.Multiline = true;
			this.DeviceValueFormulaTB.Name = "DeviceValueFormulaTB";
			this.DeviceValueFormulaTB.ReadOnly = true;
			this.DeviceValueFormulaTB.Size = new System.Drawing.Size(184, 48);
			this.DeviceValueFormulaTB.TabIndex = 13;
			this.DeviceValueFormulaTB.Text = "";
			// 
			// PropertyDlg
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(410, 567);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PropertyDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PropertyDlg";
			this.Load += new System.EventHandler(this.PropertyDlg_Load);
			this.tabControl1.ResumeLayout(false);
			this.CommonTab.ResumeLayout(false);
			this.GeneralGB.ResumeLayout(false);
			this.ReadTab.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ReadErrorStopGB.ResumeLayout(false);
			this.ReadWaitTimeGB.ResumeLayout(false);
			this.ReadResendingGB.ResumeLayout(false);
			this.WriteTab.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.WriteErrorStopGB.ResumeLayout(false);
			this.WriteWaitTimeGB.ResumeLayout(false);
			this.WriteResendingGB.ResumeLayout(false);
			this.DescriptionTab.ResumeLayout(false);
			this.GraphTab.ResumeLayout(false);
			this.GraphGb.ResumeLayout(false);
			this.Common2Tab.ResumeLayout(false);
			this.StaticValueGB.ResumeLayout(false);
			this.DefaultValueGB.ResumeLayout(false);
			this.MinimumValueGB.ResumeLayout(false);
			this.MaximumValueGB.ResumeLayout(false);
			this.ActualValueGB.ResumeLayout(false);
			this.UIFormulaGB.ResumeLayout(false);
			this.DeviceFormulaGB.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void PropertyDlg_Load(object sender, System.EventArgs e)
		{
			//Fill TypeDD
			foreach (string VariantType in m_Types.Keys)
			{
				TypeDD.Items.Add(VariantType);
			}
			IOTB_SelectedIndexChanged(null, null);

			DefaultValueCB.Checked = (m_GXProperty1.DefaultValue != null);
			if (m_GXProperty1.DefaultValue != null && m_GXProperty1.DefaultValue.ToString().StartsWith("=EVAL"))
			{
				DefaultValueTB.Text = m_GXProperty1.DefaultValue.ToString().Remove(0, 5);
				DefaultValueFormulaCB.Checked = true;
			}
			else
			{
				DefaultValueTB.Text = m_GXProperty1.DefaultValue.ToString();
			}
			MinimumValyeCB.Checked = (m_GXProperty1.Minimum != null);
			if (m_GXProperty1.Minimum != null && m_GXProperty1.Minimum.ToString().StartsWith("=EVAL"))
			{
				MinimumTB.Text = m_GXProperty1.Minimum.ToString().Remove(0, 5);
				MinimumValueFormulaCB.Checked = true;
			}
			else
			{
				MinimumTB.Text = m_GXProperty1.Minimum.ToString();
			}
			MaximumValueCB.Checked = m_GXProperty1.Maximum != null;
			if (m_GXProperty1.Maximum != null && m_GXProperty1.Maximum.ToString().StartsWith("=EVAL"))
			{
				MaximumTB.Text = m_GXProperty1.Maximum.ToString().Remove(0, 5);
				MaximumValueFormulaCB.Checked = true;
			}
			else
			{
				MaximumTB.Text = m_GXProperty1.Maximum.ToString();
			}

			if (m_GXProperty1.UIValueFormula.StartsWith("=EVAL"))
			{
				UIValueFormulaTB.Text = m_GXProperty1.UIValueFormula.Remove(0, 5);
				UIFormulaCB.Checked = true;
			}
			if (m_GXProperty1.DeviceValueFormula.StartsWith("=EVAL"))
			{
				DeviceValueFormulaTB.Text = m_GXProperty1.DeviceValueFormula.Remove(0, 5);
				DeviceFormulaCB.Checked = true;
			}

			//Show available categories.
			CategoryDD.Items.Add("Default");
			foreach (GXCategory cat1 in m_GXDevice1.Categories)
			{
				string cat = cat1.Name;
				if (!CategoryDD.Items.Contains(cat))
				{
					CategoryDD.Items.Add(cat);
				}
			}
			//Add I/Os
			IOTB.Items.Add("Coil outputs (0x00000)");
			IOTB.Items.Add("Digital Inputs (0x10000)");
			IOTB.Items.Add("Analogue Inputs (0x30000)");
			IOTB.Items.Add("Holding registers (0x40000)");
			IOTB.Items.Add("Extended registers (0x60000)");
			IOTB.SelectedIndex = 0;

			CategoryDD.Text = m_GXProperty1.Category.Name;
			if (m_GXProperty1.Table != null)
			{
				CategoryDD.Enabled = false;
			}
			//Set default buttons.
			this.CancelButton = CancelBtn;
			this.AcceptButton = OKBtn;

			//Add Access Modes.
			AccessModeCB.Items.Add("Read/Write");
			AccessModeCB.Items.Add("Read");
			AccessModeCB.Items.Add("Write");
			AccessModeCB.Items.Add("Not Accessible");
			AccessModeCB.SelectedIndex = 0;


			//Add Access Types.
			AccessTypeCB.Items.Add("Mandatory");
			AccessTypeCB.Items.Add("Optional");
			AccessTypeCB.Items.Add("Obsolete");
			AccessTypeCB.Items.Add("Deprecated");
			AccessTypeCB.SelectedIndex = 0;

			if (!m_edit)
			{
				TypeDD.SelectedItem = "Boolean";
				this.Text = "Add new Property";
				//No expiration in default 
				NoExpirationReadRB.Checked = true;				
				NoExpirationWriteRB.Checked = true;				
				return;
			}
			this.Text = "Edit selected Property";
			DescriptionTB.Text = m_GXProperty1.Description;
			//Retreave data.
			NameTB.Text = m_GXProperty1.Name;
			//ShowGraphCb.Checked = Convert.ToBoolean(m_GXProperty1.UseGraph);
			
			foreach (TypeItem SelectedItem in m_Types.Values)
			{
				if (m_GXProperty1.ReadSize == SelectedItem.ReadSize &&
					m_GXProperty1.WriteSize == SelectedItem.WriteSize &&
					m_GXProperty1.Type == SelectedItem.GXType)
				{
					TypeDD.SelectedItem = SelectedItem.Name;
					break;
				}
			}
			if (TypeDD.SelectedItem == null)
			{
				MessageBox.Show("Unknown Type, please select one");
			}

			if (m_GXProperty1.Parameters.Find("Function", null) != null)
			{
				GXParameter Function = (GXParameter) m_GXProperty1.Parameters.Find("Function", null);
				IOTB.SelectedIndex = Convert.ToInt32(Function.Value);
			}

			if (m_GXProperty1.Parameters.Find("Address", null) != null)
			{
				GXParameter Address = (GXParameter) m_GXProperty1.Parameters.Find("Address", null);
				try
				{
					string s = Address.Value;
					AddressTB.Text = Convert.ToString(Convert.ToInt32(s, 10), 16);
				}
				catch
				{
					MessageBox.Show("Address decimal to hex conversion failed");
					AddressTB.Text = Address.Value;
				}
			}

			string[] types = Enum.GetNames(typeof(GXProperty.VARTYPE));
			UnitTB.Text = m_GXProperty1.Unit;
			//Get read settings.			
			ReadUseProtocolResendRB.Checked = (m_GXProperty1.Read.RetryCount == -2);
			ReadSendDontWaitRB.Checked = (m_GXProperty1.Read.RetryCount == -1);
			ReadSendWaitRB.Checked = (m_GXProperty1.Read.RetryCount == 0);
			ReadResendWaitRB.Checked = (m_GXProperty1.Read.RetryCount > 0);
			ReadResendTB.ReadOnly = !ReadResendWaitRB.Checked;
			if (ReadResendWaitRB.Checked)
			{
				ReadResendTB.Text = m_GXProperty1.Read.RetryCount.ToString();
			}
			//Get read wait times.
			ReadUseProtocolWaitRB.Checked = (m_GXProperty1.Read.TimeOut == -2);
			ReadUseSpecifiedRB.Checked = (m_GXProperty1.Read.TimeOut > -2);
			ReadWaitTB.ReadOnly = !ReadUseSpecifiedRB.Checked;
			if (ReadUseSpecifiedRB.Checked)
			{
				ReadWaitTB.Text = m_GXProperty1.Read.TimeOut.ToString();
			}
			//Get read error stop.
			ReadErrorStopCB.Checked = m_GXProperty1.Read.ErrorStop;

			//Get write settings.			
			WriteUseProtocolResendRB.Checked = (m_GXProperty1.Write.RetryCount == -2);
			WriteSendDontWaitRB.Checked = (m_GXProperty1.Write.RetryCount == -1);
			WriteSendWaitRB.Checked = (m_GXProperty1.Write.RetryCount == 0);
			WriteResendWaitRB.Checked = (m_GXProperty1.Write.RetryCount > 0);
			WriteResendTB.ReadOnly = !WriteResendWaitRB.Checked;
			if (WriteResendWaitRB.Checked)
			{
				WriteResendTB.Text = m_GXProperty1.Write.RetryCount.ToString();
			}
			//Get write wait times.
			WriteUseProtocolWaitRB.Checked = (m_GXProperty1.Write.TimeOut == -2);
			WriteUseSpecifiedRB.Checked = (m_GXProperty1.Write.TimeOut > -2);
			WriteWaitTB.ReadOnly = !WriteUseSpecifiedRB.Checked;
			if (WriteUseSpecifiedRB.Checked)
			{
				WriteWaitTB.Text = m_GXProperty1.Write.TimeOut.ToString();
			} 
			//Get write error stop.
			WriteErrorStopCB.Checked = m_GXProperty1.Write.ErrorStop;
			
			//Get Access Modes.
			AccessModeCB.SelectedIndex = (int) m_GXProperty1.AccessMode;

			//Get Access Types.
			AccessTypeCB.SelectedIndex = (int) m_GXProperty1.AccessType;

			//Get Hidden and Automatic notify
            HiddenCB.Checked = m_GXProperty1.Hidden;			
			
			//No expiration
			NoExpirationReadRB.Checked = m_GXProperty1.ExpirationRead == 0;
			//Device expiration
			DeviceExpirationReadRB.Checked = m_GXProperty1.ExpirationRead == -1;
			//Own expiration
			ExpirationReadRB.Checked = m_GXProperty1.ExpirationRead > 0;
			ExpirationReadTB.ReadOnly = !ExpirationReadRB.Checked;
			if (ExpirationReadRB.Checked)
			{
				ExpirationReadTB.Text = m_GXProperty1.ExpirationRead.ToString();
			}

			//No expiration
			NoExpirationWriteRB.Checked = m_GXProperty1.ExpirationWrite == 0;
			//Device expiration
			DeviceExpirationWriteRB.Checked = m_GXProperty1.ExpirationWrite == -1;
			//Read Once expiration
			ReadOnceExpirationReadRB.Checked = m_GXProperty1.ExpirationRead == -2;
			//Own expiration
			ExpirationWriteRB.Checked = m_GXProperty1.ExpirationWrite > 0;
			ExpirationWriteTB.ReadOnly = !ExpirationWriteRB.Checked;
			if (ExpirationWriteRB.Checked)
			{
				ExpirationWriteTB.Text = m_GXProperty1.ExpirationWrite.ToString();
			}

		}

		/// <summary>
		/// Close window. Don't do nothing. User has reject changes...
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CancelBtn_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Save setting to the GXDevice1 parameter.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OKBtn_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (HexCb.Enabled)
				{
					HexCb.Checked = false;
					if (HexCb.Checked)
					{
						return;
					}
				}
				GuruxScriptParserLib.GXScriptParser parser = new GuruxScriptParserLib.GXScriptParser();
				parser.CreateEngine(GuruxScriptParserLib.GX_SCRIPT_LANGUAGE.GX_SCRIPT_VB);
				if (DefaultValueFormulaCB.Checked)
				{
					try
					{
						parser.Eval(DefaultValueTB.Text, null, null);
					}
					catch
					{
						throw new Exception("Error in default value formula.");
					}
				}
				else
				{
					PropertyDlgBase DlgBase = new PropertyDlgBase();
					if (TypeDD.SelectedIndex > -1)
					{
						TypeItem SelectedType = (TypeItem) m_Types[TypeDD.SelectedItem];
						DlgBase.PresetValueChecker(DefaultValueTB.Text, MinimumTB.Text, MaximumTB.Text, SelectedType.GXType, 
							MinimumValueFormulaCB.Checked, MaximumValueFormulaCB.Checked, MinimumValyeCB.Checked, MaximumValueCB.Checked);
					}
				}
				if (MinimumValueFormulaCB.Checked)
				{
					try
					{
						parser.Eval(MinimumTB.Text, null, null);
					}
					catch
					{
						throw new Exception("Error in minimum value formula.");
					}
				}
				if (MaximumValueFormulaCB.Checked)
				{
					try
					{
						parser.Eval(MaximumTB.Text, null, null);
					}
					catch
					{
						throw new Exception("Error in maximum value formula.");
					}
				}
				//Retreave data.
				string name = NameTB.Text.Trim();
				if (name == "" || name.IndexOf(';') != -1)
				{
					NameTB.Focus();
					throw new Exception("Property name can't be empty and can't contain ';'.");
				}
				//Check input strings.
				if (!ReadResendTB.ReadOnly)
				{
					ReadResendTB.Focus();
					Convert.ToUInt32(ReadResendTB.Text);
				}
				if (!ReadWaitTB.ReadOnly)
				{
					ReadWaitTB.Focus();
					Convert.ToUInt32(ReadWaitTB.Text);
				}
				if (!ExpirationReadTB.ReadOnly)
				{
					ExpirationReadTB.Focus();
					Convert.ToUInt32(ExpirationReadTB.Text);
				}				
				if (!WriteResendTB.ReadOnly)
				{
					WriteResendTB.Focus();
					Convert.ToUInt32(WriteResendTB.Text);
				}
				if (!WriteWaitTB.ReadOnly)
				{
					WriteWaitTB.Focus();
					Convert.ToUInt32(WriteWaitTB.Text);
				}
				if (!ExpirationWriteTB.ReadOnly)
				{
					ExpirationWriteTB.Focus();
					Convert.ToUInt32(ExpirationWriteTB.Text);
				}

				//Formulas
				if (!DeviceFormulaCB.Checked)
				{
					DeviceValueFormulaTB.Text = "";
					m_GXProperty1.DeviceValueFormula = DeviceValueFormulaTB.Text;
				}
				else
				{
					m_GXProperty1.DeviceValueFormula = "=EVAL" + DeviceValueFormulaTB.Text;
				}
				if (!UIFormulaCB.Checked)
				{
					UIValueFormulaTB.Text = "";
					m_GXProperty1.UIValueFormula = UIValueFormulaTB.Text;
				}
				else
				{
					m_GXProperty1.UIValueFormula = "=EVAL" + UIValueFormulaTB.Text;
				}
				//Store Default Value
				if (!DefaultValueCB.Checked)
				{
					DefaultValueTB.Text = "";
				}
				if (DefaultValueFormulaCB.Checked)
				{
					DefaultValueTB.Text = "=EVAL" + DefaultValueTB.Text;
				}
				m_GXProperty1.DefaultValue = DefaultValueTB.Text;
				//Store Minimum Value
				if (!MinimumValyeCB.Checked)
				{
					MinimumTB.Text = "";
				}
				if (MinimumValueFormulaCB.Checked)
				{
					MinimumTB.Text = "=EVAL" + MinimumTB.Text;
				}
				m_GXProperty1.Minimum = MinimumTB.Text;
				//Store Maximum Value	
				if (!MaximumValueCB.Checked)
				{
					MaximumTB.Text = "";
				}
				if (MaximumValueFormulaCB.Checked)
				{
					MaximumTB.Text = "=EVAL" + MaximumTB.Text;
				}
				m_GXProperty1.Maximum = MaximumTB.Text;
				/*
				object prop = null;
				if ((prop = m_GXDevice1.Properties.Find(name, m_GXProperty1)) != null)
				{
					throw new Exception("Property with same name already exists.");
				}
				*/
				m_GXProperty1.Name = name;

				GXParameter Function = (GXParameter) m_GXProperty1.Parameters.Find("Function", null);
				if (Function != null)
				{
					m_GXProperty1.Parameters.Remove(Function);
				}
				Function = new GXParameter();
				Function.Name = "Function";
				Function.Value = IOTB.SelectedIndex.ToString();
				m_GXProperty1.Parameters.Add(Function);

				GXParameter Address = (GXParameter) m_GXProperty1.Parameters.Find("Address", null);
				if (Address != null)
				{
					m_GXProperty1.Parameters.Remove(Address);
				}
				if (AddressTB.Text != "" && this.DialogResult != DialogResult.None)
				{
					try
					{
						string s = AddressTB.Text;
						AddressTB.Text = Convert.ToInt32(s, 16).ToString();
					}
					catch
					{
						throw new Exception("Address hex to decimal conversion failed");
					}
					Address = new GXParameter();
					Address.Name = "Address";
					Address.Value = AddressTB.Text;
					m_GXProperty1.Parameters.Add(Address);
				}
				else
				{
					if (this.DialogResult != DialogResult.None)
					{
						throw new Exception("Address must be defined.");
					}
				}

				if (NoExpirationReadRB.Checked)
				{
					m_GXProperty1.ExpirationRead = 0;
				}
				else if (DeviceExpirationReadRB.Checked)
				{
					m_GXProperty1.ExpirationRead = -1;
				}
				else if (ReadOnceExpirationReadRB.Checked)
				{
					m_GXProperty1.ExpirationRead = -2;
				}
				else
				{
					m_GXProperty1.ExpirationRead = Convert.ToInt32(ExpirationReadTB.Text);
				}

				//No expiration
				if (NoExpirationWriteRB.Checked)
				{
					m_GXProperty1.ExpirationWrite = 0;
				}
				else if (DeviceExpirationWriteRB.Checked)
				{
					m_GXProperty1.ExpirationWrite = -1;
				}
				else
				{
					m_GXProperty1.ExpirationWrite = Convert.ToInt32(ExpirationWriteTB.Text);
				}

				m_GXProperty1.Category = (GXCategory) m_GXDevice1.Categories.Find(CategoryDD.Text);
				if (TypeDD.SelectedIndex > -1)
				{
					TypeItem SelectedType = (TypeItem) m_Types[TypeDD.SelectedItem];
					m_GXProperty1.Type = SelectedType.GXType;
					m_GXProperty1.ReadSize = SelectedType.ReadSize;
					m_GXProperty1.WriteSize = SelectedType.WriteSize;
				}
				else
				{
					throw new Exception("Type not specified, please select one");
				}

				//m_GXProperty1.UseGraph = Convert.ToInt32(ShowGraphCb.Checked);
				m_GXProperty1.Unit = UnitTB.Text;
				//Set read all settings.
				m_GXProperty1.Description = DescriptionTB.Text;

				//Get read settings.			
				if (ReadUseProtocolResendRB.Checked)
				{
					m_GXProperty1.Read.RetryCount = -2;
				}
				else if(ReadSendDontWaitRB.Checked)
				{
					m_GXProperty1.Read.RetryCount = -1;
				}
				else if (ReadSendWaitRB.Checked)
				{
					m_GXProperty1.Read.RetryCount = 0;
				}
				else
				{
					m_GXProperty1.Read.RetryCount = Convert.ToInt32(ReadResendTB.Text);
				}

				//Get read wait times.
				if (ReadUseProtocolWaitRB.Checked)
				{
					m_GXProperty1.Read.TimeOut = -2;
				}
				else if(ReadUseSpecifiedRB.Checked)
				{
					m_GXProperty1.Read.TimeOut = Convert.ToInt32(ReadWaitTB.Text);
				}

				//Get read error stop.
				m_GXProperty1.Read.ErrorStop = ReadErrorStopCB.Checked;

				//Get write settings.			
				if (WriteUseProtocolResendRB.Checked)
				{
					m_GXProperty1.Write.RetryCount = -2;
				}
				else if (WriteSendDontWaitRB.Checked)
				{
					m_GXProperty1.Write.RetryCount = -1;
				}
				else if (WriteSendWaitRB.Checked)
				{
					m_GXProperty1.Write.RetryCount = 0;
				}
				else
				{
					m_GXProperty1.Write.RetryCount = Convert.ToInt32(WriteResendTB.Text);
				}
				//Get write wait times.
				if (WriteUseProtocolWaitRB.Checked)
				{
					m_GXProperty1.Write.TimeOut = -2;
				}
				else if (WriteUseSpecifiedRB.Checked)				
				{
					m_GXProperty1.Write.TimeOut = Convert.ToInt32(WriteWaitTB.Text);
				}
				if (!m_edit)
				{
					GXMessageGroup GXMsgGrpRead = new GXMessageGroup();
					GXMsgGrpRead.Name = "Default";
					GXMsgGrpRead.LoopCnt = "1";
					m_GXProperty1.Read.Messages.Add(GXMsgGrpRead);

					GXMessageGroup GXMsgGrpWrite = new GXMessageGroup();
					GXMsgGrpWrite.Name = "Default";
					GXMsgGrpWrite.LoopCnt = "1";
					m_GXProperty1.Write.Messages.Add(GXMsgGrpWrite);				
				}

				//Get write error stop.
				m_GXProperty1.Write.ErrorStop = WriteErrorStopCB.Checked;
				//Get hidden and auto notify
				m_GXProperty1.Hidden = HiddenCB.Checked;
				m_GXProperty1.AccessType = (GXProperty.ACCESS_TYPE)AccessTypeCB.SelectedIndex;
				m_GXProperty1.AccessMode = (GXProperty.ACCESS_MODE)AccessModeCB.SelectedIndex;
			}
			catch(Exception Ex)
			{
				this.DialogResult = DialogResult.None;
				GuruxCommon.GXCommon.ShowError(Ex);				
			}
		}

		private void ReadResendWaitRB_CheckedChanged(object sender, System.EventArgs e)
		{
			ReadResendTB.ReadOnly = !ReadResendWaitRB.Checked;
		}

		private void ReadUseSpecifiedRB_CheckedChanged(object sender, System.EventArgs e)
		{
			ReadWaitTB.ReadOnly = !ReadUseSpecifiedRB.Checked;
		}

		private void WriteResendWaitRB_CheckedChanged(object sender, System.EventArgs e)
		{
			WriteResendTB.ReadOnly = !WriteResendWaitRB.Checked;		
		}

		private void WriteUseSpecifiedRB_CheckedChanged(object sender, System.EventArgs e)
		{
			WriteWaitTB.ReadOnly = !WriteUseSpecifiedRB.Checked;
		}

		private void ExpirationReadRB_CheckedChanged(object sender, System.EventArgs e)
		{
			ExpirationReadTB.ReadOnly = !ExpirationReadRB.Checked;
		
		}

		private void ExpirationWriteRB_CheckedChanged(object sender, System.EventArgs e)
		{
			ExpirationWriteTB.ReadOnly = !ExpirationWriteRB.Checked;
		}

		private void DefaultValueCB_CheckedChanged(object sender, System.EventArgs e)
		{
			DefaultValueTB.ReadOnly = !DefaultValueCB.Checked;
			DefaultValueFormulaCB.Enabled = DefaultValueCB.Checked;
			if (!DefaultValueCB.Checked && DefaultValueFormulaCB.Checked)
			{
				DefaultValueFormulaCB.Checked = false;
				DefaultValueCB_CheckedChanged(null, null);
			}
		}

		private void MinimumValyeCB_CheckedChanged(object sender, System.EventArgs e)
		{
			MinimumTB.ReadOnly = !MinimumValyeCB.Checked;
			MinimumValueFormulaCB.Enabled = MinimumValyeCB.Checked;
			if (!MinimumValyeCB.Checked && MinimumValueFormulaCB.Checked)
			{
				MinimumValueFormulaCB.Checked = false;
				MinimumValyeCB_CheckedChanged(null, null);
			}
		}

		private void MaximumValueCB_CheckedChanged(object sender, System.EventArgs e)
		{
			MaximumTB.ReadOnly = !MaximumValueCB.Checked;
			MaximumValueFormulaCB.Enabled = MaximumValueCB.Checked;
			if (!MaximumValueCB.Checked && MaximumValueFormulaCB.Checked)
			{
				MaximumValueFormulaCB.Checked = false;
				MaximumValueCB_CheckedChanged(null, null);
			}
		}

		private void DeviceFormulaBtn_Click(object sender, System.EventArgs e)
		{
			GuruxDeviceEditor.MacroDlg FormulaDlg = new GuruxDeviceEditor.MacroDlg(ref DeviceValueFormulaTB);
			FormulaDlg.ShowDialog();
		}

		private void UIFormulaBtn_Click(object sender, System.EventArgs e)
		{
			GuruxDeviceEditor.MacroDlg FormulaDlg = new GuruxDeviceEditor.MacroDlg(ref UIValueFormulaTB);
			FormulaDlg.ShowDialog();
		}

		private void MaximumValueFormulaBtn_Click(object sender, System.EventArgs e)
		{
			GuruxDeviceEditor.MacroDlg FormulaDlg = new GuruxDeviceEditor.MacroDlg(ref MaximumTB);
			FormulaDlg.ShowDialog();
		}

		private void MinimumValueFormulaBtn_Click(object sender, System.EventArgs e)
		{
			GuruxDeviceEditor.MacroDlg FormulaDlg = new GuruxDeviceEditor.MacroDlg(ref MinimumTB);
			FormulaDlg.ShowDialog();
		}

		private void DefaultValueFormulaBtn_Click(object sender, System.EventArgs e)
		{
			GuruxDeviceEditor.MacroDlg FormulaDlg = new GuruxDeviceEditor.MacroDlg(ref DefaultValueTB);
			FormulaDlg.ShowDialog();
		}

		private void MaximumValueFormulaCB_CheckedChanged(object sender, System.EventArgs e)
		{
			MaximumValueFormulaBtn.Enabled = MaximumValueFormulaCB.Checked;
			MaximumTB.ReadOnly = MaximumValueFormulaCB.Checked;
			if (MaximumValueFormulaCB.Checked)
			{
				MaximumTB.BackColor = Color.White;
				MaximumTB.ForeColor = Color.Gray;
			}
			else
			{
				MaximumTB.BackColor = Color.Empty;
				MaximumTB.ForeColor = Color.Empty;
			}
		}

		private void MinimumValueFormulaCB_CheckedChanged(object sender, System.EventArgs e)
		{
			MinimumValueFormulaBtn.Enabled = MinimumValueFormulaCB.Checked;
			MinimumTB.ReadOnly = MinimumValueFormulaCB.Checked;
			if (MinimumValueFormulaCB.Checked)
			{
				MinimumTB.BackColor = Color.White;
				MinimumTB.ForeColor = Color.Gray;
			}
			else
			{
				MinimumTB.BackColor = Color.Empty;
				MinimumTB.ForeColor = Color.Empty;
			}
		}

		private void DefaultValueFormulaCB_CheckedChanged(object sender, System.EventArgs e)
		{
			DefaultValueFormulaBtn.Enabled = DefaultValueFormulaCB.Checked;
			DefaultValueTB.ReadOnly = DefaultValueFormulaCB.Checked;
			if (DefaultValueFormulaCB.Checked)
			{
				DefaultValueTB.BackColor = Color.White;
				DefaultValueTB.ForeColor = Color.Gray;
			}
			else
			{
				DefaultValueTB.BackColor = Color.Empty;
				DefaultValueTB.ForeColor = Color.Empty;
			}
		}

		private void DeviceFormulaCB_CheckedChanged(object sender, System.EventArgs e)
		{
			DeviceFormulaBtn.Enabled = DeviceFormulaCB.Checked;
			if (DeviceFormulaCB.Checked)
			{
				DeviceValueFormulaTB.BackColor = Color.White;
				DeviceValueFormulaTB.ForeColor = Color.Gray;
			}
			else
			{
				DeviceValueFormulaTB.BackColor = Color.Empty;
				DeviceValueFormulaTB.ForeColor = Color.Empty;
			}
		}

		private void UIFormulaCB_CheckedChanged(object sender, System.EventArgs e)
		{
			UIFormulaBtn.Enabled = UIFormulaCB.Checked;
			if (UIFormulaCB.Checked)
			{
				UIValueFormulaTB.BackColor = Color.White;
				UIValueFormulaTB.ForeColor = Color.Gray;
			}
			else
			{
				UIValueFormulaTB.BackColor = Color.Empty;
				UIValueFormulaTB.ForeColor = Color.Empty;
			}
		}

		private void GeneralGB_Enter(object sender, System.EventArgs e)
		{
		
		}
		private SortedList CreateTypeTable()
		{
			SortedList TypeTable = new SortedList();
			TypeItem VariantType = null;
			
			VariantType = new TypeItem();
			VariantType.Name = "Unknown";
			VariantType.GXType = GXProperty.VARTYPE.None;
			VariantType.ReadSize = 0;
			VariantType.WriteSize = 0;
			TypeTable.Add(VariantType.Name, VariantType);
			VariantType = new TypeItem();
			VariantType.Name = "Signed Integer";
			VariantType.GXType = GXProperty.VARTYPE.SignedInteger;
			VariantType.ReadSize = 4;
			VariantType.WriteSize = 4;
			TypeTable.Add(VariantType.Name, VariantType);
			VariantType = new TypeItem();
			VariantType.Name = "Signed Integer16";
			VariantType.GXType = GXProperty.VARTYPE.SignedInteger;
			VariantType.ReadSize = 2;
			VariantType.WriteSize = 2;
			TypeTable.Add(VariantType.Name, VariantType);
			VariantType = new TypeItem();
			VariantType.Name = "Unsigned Integer";
			VariantType.GXType = GXProperty.VARTYPE.UnsignedInteger;
			VariantType.ReadSize = 4;
			VariantType.WriteSize = 4;
			TypeTable.Add(VariantType.Name, VariantType);
			VariantType = new TypeItem();
			VariantType.Name = "Unsigned Integer16";
			VariantType.GXType = GXProperty.VARTYPE.UnsignedInteger;
			VariantType.ReadSize = 2;
			VariantType.WriteSize = 2;
			TypeTable.Add(VariantType.Name, VariantType);
			VariantType = new TypeItem();
			VariantType.Name = "Hex String";
			VariantType.GXType = GXProperty.VARTYPE.HexString;
			VariantType.ReadSize = 0;
			VariantType.WriteSize = 0;
			TypeTable.Add(VariantType.Name, VariantType);
			VariantType = new TypeItem();
			VariantType.Name = "Byte";
			VariantType.GXType = GXProperty.VARTYPE.SignedInteger;
			VariantType.ReadSize = 1;
			VariantType.WriteSize = 1;
			TypeTable.Add(VariantType.Name, VariantType);
			VariantType = new TypeItem();
			VariantType.Name = "Byte Array";
			VariantType.GXType = GXProperty.VARTYPE.ByteArray;
			VariantType.ReadSize = 0;
			VariantType.WriteSize = 0;
			TypeTable.Add(VariantType.Name, VariantType);
			VariantType = new TypeItem();
			VariantType.Name = "Boolean";
			VariantType.GXType = GXProperty.VARTYPE.Boolean;
			VariantType.ReadSize = 1;
			VariantType.WriteSize = 1;
			TypeTable.Add(VariantType.Name, VariantType);

			return TypeTable;
		}

		private void IOTB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (IOTB.SelectedIndex < 2)
			{
				TypeDD.SelectedItem = "Boolean";
				TypeDD.Enabled = false;
			}
			else
			{
				TypeDD.SelectedItem = "Unsigned Integer16";
				TypeDD.Enabled = false;
			}
		}

		private void HexCb_CheckedChanged(object sender, System.EventArgs e)
		{
			string min = MinimumTB.Text;
			string max = MaximumTB.Text;
			string defval = DefaultValueTB.Text;

			if (HexCb.Checked)
			{
				//To hex form
				try
				{
					try
					{
						if (min != "" && MinimumTB.ReadOnly == false)
						{
							MinimumTB.Text = Convert.ToString(Convert.ToInt64(min), 16);
						}
					}
					catch
					{
						throw new Exception("Minimum value conversion failed!\r\nValues were not converted.");
					}
					try
					{
						if (max != "" && MaximumTB.ReadOnly == false)
						{
							MaximumTB.Text = Convert.ToString(Convert.ToInt64(max), 16);
						}
					}
					catch
					{
						throw new Exception("Maximum value conversion failed!\r\nValues were not converted.");
					}
					try
					{
						if (defval != "" && DefaultValueTB.ReadOnly == false)
						{
							DefaultValueTB.Text = Convert.ToString(Convert.ToInt64(defval), 16);
						}
					}
					catch
					{
						throw new Exception("Default value conversion failed!\r\nValues were not converted.");
					}
				}
				catch(Exception ex)
				{
					MinimumTB.Text = min;
					MaximumTB.Text = max;
					DefaultValueTB.Text = defval;
					this.HexCb.CheckedChanged -= new System.EventHandler(this.HexCb_CheckedChanged);
					HexCb.Checked = false;
					this.HexCb.CheckedChanged += new System.EventHandler(this.HexCb_CheckedChanged);
					GuruxCommon.GXCommon.ShowError(ex);				
				}
			}
			else
			{
				//To decimal form
				try
				{
					try
					{
						if (min != "" && MinimumTB.ReadOnly == false)
						{
							MinimumTB.Text = Convert.ToInt64(min, 16).ToString();
						}
					}
					catch
					{
						throw new Exception("Minimum value conversion failed!\r\nValues were not converted.");
					}
					try
					{
						if (max != "" && MaximumTB.ReadOnly == false)
						{
							MaximumTB.Text = Convert.ToInt64(max, 16).ToString();
						}
					}
					catch
					{
						throw new Exception("Maximum value conversion failed!\r\nValues were not converted.");
					}
					try
					{
						if (defval != "" && DefaultValueTB.ReadOnly == false)
						{
							DefaultValueTB.Text = Convert.ToInt64(defval, 16).ToString();
						}
					}
					catch
					{
						throw new Exception("Default value conversion failed!\r\nValues were not converted.");
					}
				}
				catch(Exception ex)
				{
					MinimumTB.Text = min;
					MaximumTB.Text = max;
					DefaultValueTB.Text = defval;
					this.HexCb.CheckedChanged -= new System.EventHandler(this.HexCb_CheckedChanged);
					HexCb.Checked = true;
					this.HexCb.CheckedChanged += new System.EventHandler(this.HexCb_CheckedChanged);
					GuruxCommon.GXCommon.ShowError(ex);				
					this.DialogResult = DialogResult.None;
				}
			}
		}

		private void TypeDD_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (((TypeItem) m_Types[TypeDD.SelectedItem]).GXType == GXProperty.VARTYPE.SignedInteger ||
				((TypeItem) m_Types[TypeDD.SelectedItem]).GXType == GXProperty.VARTYPE.UnsignedInteger)
			{
				HexCb.Enabled = true;
			}
			else
			{
				HexCb.Enabled = false;
				this.HexCb.CheckedChanged -= new System.EventHandler(this.HexCb_CheckedChanged);
				HexCb.Checked = false;
				this.HexCb.CheckedChanged += new System.EventHandler(this.HexCb_CheckedChanged);
			}
		}

		public class TypeItem
		{
			public string Name;
			public GXProperty.VARTYPE GXType;
			public int ReadSize;
			public int WriteSize;
		}
	}
}
