//
// --------------------------------------------------------------------------
//  Gurux Ltd
// 
//
//
// Filename:        $HeadURL: svn://utopia/projects/GXDeviceEditor/Development/AddIns/Modbus/Modbus.cs $
//
// Version:         $Revision: 4097 $,
//                  $Date: 2011-09-27 01:08:32 +0300 (Tue, 27 Sep 2011) $
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
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using System.ComponentModel;
using Gurux.Device;
using Gurux.Device.Editor;
using Gurux.Communication;

namespace Gurux.Modbus.AddIn
{    
	/// <summary>
	/// Implements modbus protocol addin component.
	/// </summary>
    [GXCommunicationAttribute(typeof(ModbusPacketHandler), typeof(ModBusPacketParser))]
	[Serializable]
    internal class GXModbus : GXProtocolAddIn
	{
		/// <summary>
		/// Initializes a new instance of the GXModbus class.
		/// </summary>
		public GXModbus()
			: base("Modbus", false, false, false)
		{
			base.WizardAvailable = VisibilityItems.Properties;
		}

        public override Type GetDeviceType()
        {
            return typeof(GXModbusDevice);
        }

		public override Type[] GetPropertyTypes(object parent)
        {
            return new Type[]{typeof(GXModbusProperty)};
        }        

        /// <summary>
        /// Returns available functionalities for the protocol.
        /// </summary>
        public override VisibilityItems ItemVisibility
        {
            get
            {
                return VisibilityItems.Categories;
            }
        }

        public override void ModifyWizardPages(object source, GXPropertyPageType type, System.Collections.Generic.List<Control> pages)
		{
            if (type == GXPropertyPageType.Property)
            {
                pages.Insert(1, new ModBusWizardPage1Dlg());
            }
		}        
    }
}