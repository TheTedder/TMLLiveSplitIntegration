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
        private NamedPipeCommandClient Client;
        private object ClientLock;
        private CancellationTokenSource connectSource;

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
