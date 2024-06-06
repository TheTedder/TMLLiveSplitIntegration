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
    // Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
    public class LiveSplitIntegration : Mod
    {
        private static NamedPipeCommandClient Client;
        private static readonly object ClientLock = new();
        private static CancellationTokenSource connectSource;

        private static async Task Connect()
        {
            Client = new();
            await Client.ConnectAsync(connectSource.Token);
        }

        public override void Load()
        {
            connectSource = new();
            Task.Run(Connect);
        }

        public override void Unload()
        {
            connectSource.Cancel();
            connectSource.Dispose();
            Client?.Dispose();
        }

        internal static bool TrySendLsMsg(Action<NamedPipeCommandClient> msgAction)
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

        internal static bool TrySendLsMsg<T>(Func<NamedPipeCommandClient, T> msgAction, out T res)
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
