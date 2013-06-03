using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Gurux.Device;
using System.Runtime.Serialization;
using Gurux.Device.Editor;
using Gurux.Communication.Common;

namespace Gurux.Modbus.AddIn
{
    /// <summary>
    /// Extends GXDevice class with the modbus specific properties.
    /// </summary>
    [DataContract(Namespace = "http://www.gurux.org")]
    public class GXModbusDevice : GXDevice
    {
        /// <summary>
        /// Initializes a new instance of the GXModbusDevice class.
        /// </summary>
        public GXModbusDevice()
        {
            this.GXClient.ByteOrder = Gurux.Communication.ByteOrder.BigEndian;
            Address = 1;
            this.WaitTime = 1000;            
            AllowedMediaTypes.Add(new GXMediaType("Serial", ""));
            AllowedMediaTypes.Add(new GXMediaType("Net", ""));
            //TODO: AllowedMediaTypes.Add(new GXMediaType("Terminal", ""));            
        }

        /// <summary>
        /// Address
        /// </summary>
        [Category("Design"), System.ComponentModel.Description("Device address.")]
        [ValueAccess(ValueAccessType.None, ValueAccessType.Edit)]
        [DefaultValue(1), DataMember(IsRequired = false)]
        public int Address
        {
            get;
            set;
        }

        public override void Validate(bool designMode, GXTaskCollection tasks)
        {
            if (!designMode && Address == 0)
            {
                tasks.Add(new GXTask(this, "Address", "Address is invalid."));
            }
        }

        /// <summary>
        /// Is mode ASCII or RTU.
        /// </summary>
        /// <remarks>
        /// RTU is default.
        /// </remarks>
        public bool Ascii
        {
            get;
            set;
        }

        /// <summary>
        /// Set media spesific settings.
        /// </summary>
        /// <param name="media"></param>
        public override void UpdateCommunicationSettings(object media)
        {          
            this.GXClient.ByteOrder = Gurux.Communication.ByteOrder.BigEndian;
            this.GXClient.ChecksumSettings.Position = -1;
            this.GXClient.Eop = null;
            if (this.GXClient.MediaType == "Net")
            {
                if (Ascii)
                {
                    this.GXClient.ChecksumSettings.Position = -3;
                    this.GXClient.Bop = ":" + ModbusPacketHandler.GetValue((byte)Address, true);
                    this.GXClient.Eop = "\r\n";
                    this.GXClient.ChecksumSettings.Type = Gurux.Communication.ChecksumType.Own;
                    this.GXClient.ChecksumSettings.Size = 16;
                }
                else //Do not use BOP or EOP.
                {
                    this.GXClient.Bop = null;
                    this.GXClient.ChecksumSettings.Type = Gurux.Communication.ChecksumType.None;
                }
            }
            else
            {                
                if (Ascii)
                {
                    this.GXClient.ChecksumSettings.Position = -3;
                    this.GXClient.Bop = ":" + ModbusPacketHandler.GetValue((byte)Address, true);
                    this.GXClient.Eop = "\r\n";
                    this.GXClient.ChecksumSettings.Type = Gurux.Communication.ChecksumType.Own;
                    this.GXClient.ChecksumSettings.Size = 16;
                }
                else //Use BOP but don't EOP
                {                    
                    this.GXClient.Bop = (byte)Address;
                    this.GXClient.ChecksumSettings.Type = Gurux.Communication.ChecksumType.Ibm16;
                }                
            }            
        }
    }
}
