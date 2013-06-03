using System;
using System.Collections.Generic;
using System.Text;
using Gurux.Communication;

namespace Gurux.Modbus.AddIn
{
    public class ModBusPacketParser : Gurux.Communication.IGXPacketParser
    {
        UInt16 PacketID = 1;
        #region IGXPacketParser Members

        public void AfterSend(GXPacket packet)
        {
        }

        public void BeforeSend(object sender, Gurux.Communication.GXPacket packet)
        {
            GXClient client = sender as GXClient;
            if (client.MediaType == "Net")
            {
                if (++PacketID == UInt16.MaxValue)
                {
                    PacketID = 1;
                }
                //The Unit Identifier
                packet.InsertData((byte)((GXModbusDevice)client.Owner).Address, 0, 0, 0);
                //Count data size and update it to the packet before send.
                int PackSize = packet.GetSize(PacketParts.Data);
                packet.InsertData((UInt16)PackSize, 0, 0, 0);
                //Protocol ID. (Always 0x0)
                packet.InsertData((UInt16)0, 0, 0, 0); 
                //PacketID
                packet.InsertData(PacketID, 0, 0, 0); 
            }
        }

        /// <summary>
        /// Count Checksum for ASCII.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CountChecksum(object sender, Gurux.Communication.GXChecksumEventArgs e)
        {
            byte[] data = e.Packet.ExtractPacket();
            int crc = 0;
            int value;            
            for (int pos = 1; pos != data.Length - 2; pos += 2)
            {
                value = Convert.ToInt32(ASCIIEncoding.ASCII.GetString(data, pos, 2), 16);
                crc = (crc + value) & 0xFF;
            }
            e.Checksum = ModbusPacketHandler.GetValue((byte)-crc, true); 
        }

        /// <summary>
        /// Check are Device ID's same.
        /// </summary>
        /// <param name="send"></param>
        /// <param name="received"></param>
        /// <returns></returns>
        public void IsReplyPacket(object sender, Gurux.Communication.GXReplyPacketEventArgs e)
        {      
            //Get address from data            
            GXClient client = sender as GXClient;
            if (client.MediaType == "Net")
            {
                object SendPackID = e.Send.ExtractData(typeof(System.UInt16), 0, 1);
                object ReceivePackID = e.Received.ExtractData(typeof(System.UInt16), 0, 1);
                e.Accept = SendPackID.Equals(ReceivePackID);
                //Remove all data until function code so parsed data looks same as using serial port connection.
                if (e.Accept)
                {
                    e.Received.RemoveData(0, 7);
                }
            }
            else
            {
                object SendSlaveAdd, ReceiveSlaveAdd;
                byte SendFunc, ReceiveFunc;
                SendSlaveAdd = e.Send.Bop;
                ReceiveSlaveAdd = e.Received.Bop;
                //Get function from data
                SendFunc = (byte) e.Send.ExtractData(typeof(System.Byte), 0, 1);
                ReceiveFunc = (byte) e.Received.ExtractData(typeof(System.Byte), 0, 1);
                //If meter notifies error.
                if ((ReceiveFunc & 0x80) != 0 && (ReceiveFunc & 0x7F) == SendFunc)
                {
                    throw new Exception("Unexpected response received.");
                }
                //Are Slave Address and functions same...
                e.Accept = SendSlaveAdd.Equals(ReceiveSlaveAdd) && SendFunc.Equals(ReceiveFunc);
            }
        }

        /// <summary>
        /// We do not accept any notifications that Modbus device sends. Notification is 
        /// in our case old packet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AcceptNotify(object sender, Gurux.Communication.GXReplyPacketEventArgs e)
        {
            e.Accept = false;
        }

        public void Load(object sender)
        {
            
        }

        /// <inheritdoc cref="IGXPacketParser.Connect"/>
        public void Connect(object sender)
        {
        }

        /// <inheritdoc cref="IGXPacketParser.Disconnect"/>
        public void Disconnect(object sender)
        {

        }


        public void ParsePacketFromData(object sender, GXParsePacketEventArgs e)
        {            
        }
        
        public void ReceiveData(object sender, GXReceiveDataEventArgs e)
        {            
        }

        public void Received(object sender, GXReceivedPacketEventArgs e)
        {
        }

        public void Unload(object sender)
        {
		}

		public void InitializeMedia(object sender, Gurux.Common.IGXMedia media)
		{		
		}

		public void VerifyPacket(object sender, GXVerifyPacketEventArgs e)
		{		
		}

		#endregion
	}
}
