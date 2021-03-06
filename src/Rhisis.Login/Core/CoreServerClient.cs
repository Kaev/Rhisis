﻿using Microsoft.Extensions.Logging;
using Rhisis.Network.Core;
using Sylver.HandlerInvoker;
using Sylver.Network.Data;
using Sylver.Network.Server;
using System;
using System.Net.Sockets;

namespace Rhisis.Login.Core
{
    public class CoreServerClient : NetServerClient, ICoreServerClient
    {
        private ILogger<CoreServerClient> _logger;
        private IHandlerInvoker _handlerInvoker;

        /// <summary>
        /// Gets or sets the server informations.
        /// </summary>
        public ServerInfo ServerInfo { get; internal set; }

        /// <summary>
        /// Creates a new <see cref="CoreServerClient"/> instance.
        /// </summary>
        /// <param name="socketConnection"></param>
        public CoreServerClient(Socket socketConnection) 
            : base(socketConnection)
        {
        }

        /// <summary>
        /// Initialize the <see cref="CoreServerClient"/>.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="handlerInvoker">Handler Invoker.</param>
        public void Initialize(ILogger<CoreServerClient> logger, IHandlerInvoker handlerInvoker)
        {
            this._logger = logger;
            this._handlerInvoker = handlerInvoker;
        }

        /// <inheritdoc />
        public override void HandleMessage(INetPacketStream packet)
        {
            uint packetHeaderNumber = 0;

            if (this.Socket == null)
            {
                this._logger.LogTrace("Skip to handle core packet from null socket. Reason: socket is not connected.");
                return;
            }

            try
            {
                packetHeaderNumber = packet.Read<uint>();
                this._handlerInvoker.Invoke((CorePacketType)packetHeaderNumber, this, packet);
            }
            catch (ArgumentException)
            {
                if (Enum.IsDefined(typeof(CorePacketType), packetHeaderNumber))
                {
                    this._logger.LogWarning("Received an unimplemented Core packet {0} (0x{1}) from {2}.",
                        Enum.GetName(typeof(CorePacketType), packetHeaderNumber),
                        packetHeaderNumber.ToString("X2"),
                        this.Socket.RemoteEndPoint);
                }
                else
                {
                    this._logger.LogWarning($"Received an unknown Core packet 0x{packetHeaderNumber.ToString("X2")} from {this.Socket.RemoteEndPoint}.");
                }
            }
            catch (Exception exception)
            {
                this._logger.LogError(exception, $"An error occured while handling a CoreServer packet.");
                this._logger.LogDebug(exception.InnerException?.StackTrace);
            }
        }
    }
}
