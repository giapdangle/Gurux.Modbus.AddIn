using System;
using System.Collections.Generic;
using System.Text;
using Gurux.Device;
using Gurux.Communication;
using Gurux.Communication.Common;

namespace Gurux.Modbus.AddIn
{
    public class ModbusPacketHandler : Gurux.Device.IGXPacketHandler
    {
        #region IGXPacketHandler Members
        bool WriteFailed;
        public object Parent
        {
            get;
            set;
        }

        /// <inheritdoc cref="IGXPacketHandler.Connect"/>
        public void Connect(object sender)
        {
        }

        /// <inheritdoc cref="IGXPacketHandler.Disconnect"/>
        public void Disconnect(object sender)
        {

        }

        public object DeviceValueToUIValue(Gurux.Device.GXProperty sender, object value)
        {
            GXModbusProperty prop = sender as GXModbusProperty;
            return Convert.ChangeType(value, prop.ValueType);
        }
       
        public object UIValueToDeviceValue(Gurux.Device.GXProperty sender, object value)
        {
            return value;
        }

        object GetWriteData(GXProperty prop, byte functionCode)
        {
            if (functionCode == 5)
            {
                return Convert.ToBoolean(prop.GetValue(true)) ? 0xFF00 : 0x0;
            }
            if (functionCode == 6)
            {
                return prop.GetValue(false);
            }
            throw new Exception("Write failed. Invalid Function code. " + functionCode.ToString());
        }        
        
        /// <summary>
        /// Converts value to ASCII protocol.
        /// </summary>
        /// <param name="value">Converted data.</param>        
        static string ToAscii(byte[] value)
        {
            StringBuilder ascii = new StringBuilder(value.Length * 2);
            foreach (byte b in value)
            {
                int idHigh = b >> 4;
                int idLow = b & 0x0F;
                ascii.Append(Convert.ToString(idHigh, 16).ToUpper() + Convert.ToString(idLow, 16).ToUpper());
            }
            return ascii.ToString();
        }
        static internal object GetValue(object value, bool useAscii)
        {
            if (useAscii)
            {
                return ToAscii(GXConverter.GetBytes(value, true));
            }
            return value;
        }

        public void ExecuteSendCommand(object sender, string command, Gurux.Communication.GXPacket packet)
        {
            GXModbusProperty prop = sender as GXModbusProperty;
            bool ascii = (prop.Device as GXModbusDevice).Ascii;
            UInt16 address = prop.Address;
            byte functionCode = (byte)prop.Function;
            if (command == "ModbusRead")
            {
                packet.AppendData(GetValue(functionCode, ascii));
                packet.AppendData(GetValue(address, ascii));
                packet.AppendData(GetValue((UInt16)1, ascii));
            }
            else if (command == "ModbusWrite")
            {
                switch (functionCode)
                {
                    case 1:
                        functionCode = 5;
                        break;
                    case 3:
                        functionCode = 6;
                        break;
                }
                WriteFailed = false;
                packet.AppendData(GetValue(functionCode, ascii));
                packet.AppendData(GetValue(address, ascii));
                object value = GetWriteData(prop, functionCode);
                packet.AppendData(GetValue(value, ascii));
            }
            //Read value type if write failed.
            else if (command == "ModbusFailedWrite")
            {
                if (WriteFailed)
                {
                    packet.AppendData(GetValue(functionCode, ascii));
                    packet.AppendData(GetValue(address, ascii));
                    packet.AppendData(GetValue((UInt16)1, ascii));
                }
            }
        }

        public void ExecuteParseCommand(object sender, string command, Gurux.Communication.GXPacket[] packets)
        {
            GXProperty prop = sender as GXProperty;
            bool ascii = (prop.Device as GXModbusDevice).Ascii;
            object value = null;
            byte functionCode;
            if (ascii)
            {
                functionCode = Convert.ToByte(packets[0].ExtractData(typeof(string), 0, 2).ToString(), 16);
            }
            else
            {
                functionCode = (byte)packets[0].ExtractData(typeof(System.Byte), 0, 1);
            }
            if (command == "ModbusReadReply" || command == "ModbusFailedWriteReply")
            {
                byte len;
                if (ascii)
                {
                    len = Convert.ToByte(packets[0].ExtractData(typeof(string), 2, 2).ToString(), 16);
                }
                else
                {
                    len = (byte)packets[0].ExtractData(typeof(System.Byte), 1, 1);
                }
                bool unsigned = prop.ValueType == typeof(byte) || prop.ValueType == typeof(UInt16) || 
                    prop.ValueType == typeof(UInt32) || prop.ValueType == typeof(UInt64);
                Type type = prop.ValueType;                
                if (type != typeof(bool) && type != typeof(string) && type != typeof(byte[]))
                {
                    if (len > 4)
                    {
                        if (unsigned)
                        {
                            type = typeof(UInt64);
                        }
                        else
                        {
                            type = typeof(Int64);
                        }
                    }
                    if (len > 2)
                    {
                        if (unsigned)
                        {
                            type = typeof(UInt32);
                        }
                        else
                        {
                            type = typeof(Int32);
                        }
                    }
                    if (len == 2)
                    {
                        if (unsigned)
                        {
                            type = typeof(UInt16);
                        }
                        else
                        {
                            type = typeof(Int16);
                        }
                    }
                    if (len == 1)
                    {
                        if (unsigned)
                        {
                            type = typeof(byte);
                        }
                        else
                        {
                            type = typeof(sbyte);
                        }
                    }
                }                              
                if (command == "ModbusFailedWriteReply")
                {
                    if (len == System.Runtime.InteropServices.Marshal.SizeOf(prop.ValueType))
                    {
                        throw new Exception("Failed to set value.");
                    }
                    else
                    {
                        throw new Exception("Failed to set value." + Environment.NewLine + "Value type is invalid. Currect type is " + prop.ValueType.Name + " and device expected " + type.Name + ".");
                    }
                }
                else
                {
                    if (ascii)
                    {
                        value = packets[0].ExtractData(typeof(string), 4, 2 * len);
                        if (unsigned)
                        {
                            value = Convert.ToUInt64(value.ToString(), 16);
                        }
                        else
                        {
                            value = Convert.ToInt64(value.ToString(), 16);
                        }
                        value = Convert.ChangeType(value, type);
                    }
                    else
                    {
                        value = packets[0].ExtractData(type, 2, 1);
                    }
                    prop.ReadTime = DateTime.Now;
                    prop.SetValue(value, false, Gurux.Device.PropertyStates.ValueChangedByDevice);
                }
            }
            else if (command == "ModbusWriteReply")
            {
                UInt16 address = (UInt16)packets[0].ExtractData(typeof(UInt16), 1, 1);
                if (packets[0].GetSize(PacketParts.Data) - 3 < System.Runtime.InteropServices.Marshal.SizeOf(prop.ValueType))
                {
                    WriteFailed = true;
                }
                else
                {
                    value = packets[0].ExtractData(prop.ValueType, 3, 1);
                    prop.WriteTime = DateTime.Now;
                    if (!value.Equals(prop.GetValue(false)))
                    {
                        WriteFailed = true;
                    }
                    else
                    {
                        prop.NotifyPropertyChange(PropertyStates.ValueChangedByDevice);
                    }
                }
            }            
        }

        public bool IsTransactionComplete(object sender, string command, Gurux.Communication.GXPacket packet)
        {
            return true;
        }

        #endregion
    }
}