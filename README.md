# TML LiveSplit Integration
This is a mod for Terraria that allows for integration with [LiveSplit](https://livesplit.org). This is achieved through use of the [LiveSplitInterop](https://www.nuget.org/packages/LiveSplitInterop) library. To use the mod, subscribe to it on the [Steam Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=3266597236). Alternatively, use the in-game mod browser to install it. Go to the in-game configuration menu ("LiveSplit Config") and select whether you want the timer to start automatically or not and which bosses or boss groups should trigger a split upon defeat.
## How to Build
Unfortunately, TML's build system is a bit wack, so you'll have to jump through some hoops to get this mod to compile correctly.
### Prerequisites
To compile this mod, you need:
* [Terraria](https://www.terraria.org/)
* [tModLoader](https://tmodloader.net/)
* [msbuild](https://visualstudio.microsoft.com/) (or the [dotnet SDK](https://dotnet.microsoft.com/en-us/))

If you are using Visual Studio, make sure you have the .NET desktop development workload installed. You should have the ".NET 8.0 Runtime", "C# and Visual Basic", "MSBuild", "NuGet package manager", and "NuGet targets and build tasks" component installed. You have to own Terraria on Steam if you intend to fork this project and then publish your version to the Steam Workshop.
### Build Process
1. Clone the repository into your mod sources folder. Yes, it has to be in this folder for this to work. Make sure the files in the repository are themselves inside of a folder and not direct children of the ModSources folder.
	* On **Windows**, this folder is located at the following location, relative to your Documents folder: `My Games\Terraria\tModLoader\ModSources\`.
	* On **Linux**, this folder is located at `$XDG_DATA_HOME/Terraria/tModLoader/ModSources/`.
	* On **macOS**, this folder is located at `$HOME/Library/Application Support/Terraria/tModLoader/ModSources/`.
2. Restore NuGet packages and copy dependencies to `/lib`. After completing this step, all dependencies should be downloaded and copied to `/lib`. You only need to do this step once unless you add more nuget dependencies or update your existing ones.
	* If you are using **Visual Studio**, this is accomplished by opening the Developer Command Prompt (in the Tools > Command Line menu) and running the following command: `call setup_msbuild.cmd`.
	* If you are using the **dotnet CLI**, run either `setup_dotnet.cmd` or `setup.sh` depending on your operating system.
3. Launch tModLoader, navigate to the Workshop menu and click "Develop Mods." You should see LiveSplitIntegration listed, as well as any other mods you are developing. Click the "Build" or the "Build + Reload" button depending on your needs. If you get a message about a missing dependency, step 2 failed.
## Acknowledgments
Thanks to EvenOrOdds for commissioning this project.
