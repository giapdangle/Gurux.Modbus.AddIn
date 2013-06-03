using System;
using System.Collections.Generic;
using System.Text;
using Gurux.Device;
using Gurux.Device.Editor;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Gurux.Modbus.AddIn
{
    /// <summary>
    /// Extends GXProperty class with the modbus specific properties.
    /// </summary>
    [GXReadMessage("ModbusRead", "ModbusReadReply")]
    [GXWriteMessage("ModbusWrite", "ModbusWriteReply", Index=1)]
    [GXWriteMessage("ModbusFailedWrite", "ModbusFailedWriteReply", Index=2)]
    [DataContract(Namespace = "http://www.gurux.org")]
    public class GXModbusProperty : GXProperty
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public GXModbusProperty()
        {            
        }

        /// <summary>
        /// Defines modbus function types.
        /// </summary>
        public enum GXFunctionType
        {
            /// <summary>
            /// Discrete Output Coils. Read/write.
            /// </summary>
            CoilOutputs = 1,
            /// <summary>
            /// Discrete Input Contacts. Read.
            /// </summary>
            DigitalInputs = 2,
            /// <summary>
            /// Analog Input Registers. Read.
            /// </summary>
            AnalogueInputs = 4,
            /// <summary>
            /// Analog Output Holding Registers. Read/write.
            /// </summary>
            HoldingRegisters = 3,
            /// <summary>
            /// Extended registers
            /// </summary>
            ExtendedRegisters = 0x14
        }

        /// <summary>
        /// Register type where read/writes are made.
        /// </summary>
        [System.ComponentModel.Category("Design"), System.ComponentModel.Description("Register type where read/writes are made.")]
        [ValueAccess(ValueAccessType.Show, ValueAccessType.None)]
        [ReadOnly(false), DataMember(IsRequired = true)]
        public GXFunctionType Function
        {
            get;
            set;
        }

        /// <summary>
        /// Register address.
        /// </summary>
        [System.ComponentModel.Category("Design"), System.ComponentModel.Description("Register address.")]
        [DataMember(IsRequired = true)]
        [ReadOnly(false), ValueAccess(ValueAccessType.Show, ValueAccessType.None)]
        public UInt16 Address
        {
            get;
            set;
        }       
    }
}
