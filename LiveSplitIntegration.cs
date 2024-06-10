using LiveSplitInterop.Clients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace LiveSplitIntegration
{
    public class LiveSplitIntegration : Mod
    {
        /// <summary>
        /// The client that communicates with LiveSplit.
        /// </summary>
        private NamedPipeCommandClient Client;
        
        /// <summary>
        /// A lock to prevent multiple threads from using <see cref="Client"/> simultaneously.
        /// </summary>
        private object ClientLock;

        /// <summary>
        /// A <see cref="CancellationTokenSource"/> used to stop pending connections when unloading the mod.
        /// </summary>
        private CancellationTokenSource connectSource;

        /// <summary>
        /// Connect to LiveSplit asynchronously. Cancel <see cref="connectSource"/> to stop the operation.
        /// </summary>
        private async Task Connect()
        {
            Client = new();
            await Client.ConnectAsync(connectSource.Token);
        }

        public override void Load()
        {
            ClientLock = new();
            connectSource = new();
            Task.Run(Connect);
        }

        public override void Unload()
        {
            connectSource.Cancel();
            connectSource.Dispose();
            Client?.Dispose();
        }

        /// <summary>
        /// Attempt to send one or more messages to LiveSplit.
        /// </summary>
        /// <param name="msgAction">
        /// The action to perform with the LiveSplit client.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/> indicating whether or not <paramref name="msgAction"/> completed successfully.
        /// </returns>
        internal bool TrySendLsMsg(Action<NamedPipeCommandClient> msgAction)
        {
            lock (ClientLock)
            {
                if (!Client?.IsConnected ?? false)
                {
                    return false;
                }

                try
                {
                    msgAction(Client);
                    return true;
                }
                catch (IOException)
                {
                    //TODO: log
                }
                catch (ObjectDisposedException)
                {
                    return false;
                }

                if (!connectSource.IsCancellationRequested)
                {
                    Client.Dispose();
                    Task.Run(Connect);
                }

                return false;
            }
        }

        /// <summary>
        /// Attempt to send one or more messages to LiveSplit, at least one of which returns a value.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data returned.
        /// </typeparam>
        /// <param name="res">
        /// The returned data. In case of failure, this value will be invalid.
        /// </param>
        /// <inheritdoc cref="TrySendLsMsg(Action{NamedPipeCommandClient})"/>
        internal bool TrySendLsMsg<T>(Func<NamedPipeCommandClient, T> msgAction, out T res)
        {
            lock (ClientLock)
            {
                if (!Client?.IsConnected ?? false)
                {
                    res = default;
                    return false;
                }

                try
                {
                    res = msgAction(Client);
                    return true;
                }
                catch (IOException)
                {
                    //TODO: log
                }
                catch (ObjectDisposedException)
                {
                    res = default;
                    return false;
                }

                if (!connectSource.IsCancellationRequested)
                {
                    Client.Dispose();
                    Task.Run(Connect);
                }

                res = default;
                return false;
            }
        }
    }
}
