﻿using Communication.Interfaces;
using System.ComponentModel;
using System.IO.Ports;

namespace Communication.Bus.PhysicalPort
{
    /// <summary>
    /// 物理串口
    /// </summary>
    public class SerialPort : System.IO.Ports.SerialPort, IPhysicalPort, IDisposable
    {
        /// <summary>物理串口</summary>
        public SerialPort() : base() { }
        /// <summary>物理串口</summary>
        public SerialPort(IContainer container) : base(container) { }
        /// <summary>物理串口</summary>
        public SerialPort(string portName) : base(portName) { }
        /// <summary>物理串口</summary>
        public SerialPort(string portName, int baudRate) : base(portName, baudRate) { }
        /// <summary>物理串口</summary>
        public SerialPort(string portName, int baudRate, Parity parity) : base(portName, baudRate, parity) { }
        /// <summary>物理串口</summary>
        public SerialPort(string portName, int baudRate, Parity parity, int dataBits) : base(portName, baudRate, parity, dataBits) { }
        /// <summary>物理串口</summary>
        public SerialPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits) : base(portName, baudRate, parity, dataBits, stopBits) { }
        
        /// <inheritdoc/>
        public async Task OpenAsync()
        {
            base.Open();
            await Task.CompletedTask;
        }

        /// <inheritdoc/>
        public async Task CloseAsync()
        {
            base.Close();
            await Task.CompletedTask;
        }

        /// <inheritdoc/>
        public async Task<ReadDataResult> ReadDataAsync(int count, CancellationToken cancellationToken)
        {
            var data = new byte[count];
            int length = base.Read(data, 0, count);
            return await Task.FromResult(new ReadDataResult
            {
                Length = length,
                Data = data
            });
        }

        /// <inheritdoc/>
        public async Task SendDataAsync(byte[] data, CancellationToken cancellationToken)
        {
            base.Write(data, 0, data.Length);
            await Task.CompletedTask;
        }
    }
}
