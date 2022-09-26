public string RootDirectory => MakeAbsolute(Directory("./")).ToString();

public string ArtifactsDirectory => $"{RootDirectory}/Artifacts";

public string BundleAndroidPath => $"{ArtifactsDirectory}/Android/Cappuccino.App.Android.apk";
public string BundleiOSPath => $"{ArtifactsDirectory}/iOS/Cappuccino.App.iOS.ipa";

public string RootAndroidDirectory => $"{RootDirectory}/Cappuccino.App.Android";
public string RootiOSDirectory => $"{RootDirectory}/Cappuccino.App.iOS";

public string ProjectCorePath => $"{RootDirectory}/Cappuccino.Core.Network/Cappuccino.Core.Network.csproj";
public string ProjectCoreTestsPath => $"{RootDirectory}/Cappuccino.Core.Network.Tests/Cappuccino.Core.Network.Tests.csproj";
public string ProjectAndroidPath => $"{RootAndroidDirectory}/Cappuccino.App.Android.csproj";
public string ProjectiOSPath => $"{RootiOSDirectory}/Cappuccino.App.iOS.csproj";

public string NuSpecCorePath => $"{RootDirectory}/Cappuccino.Core.Network/Nuget/Cappuccino.Core.Network.nuspec";
public string NugetCorePath => $"{ArtifactsDirectory}/Cappuccino.Core.Network.*.nupkg";

public string TestsResultPath => $"{ArtifactsDirectory}/Cappuccino.Core.Network.Tests.trx";


public DotNetPublishSettings DotNetPublishSettings(string output) {
    var settings = new DotNetMSBuildSettings();
    settings.WithProperty("SignAssembly", sign);
    settings.WithProperty("AssemblyOriginatorKeyFile", $"{RootDirectory}/key.snk");

    return new DotNetPublishSettings {  
        MSBuildSettings = settings,
        OutputDirectory = output,
        Configuration = configuration,
        Verbosity = DotNetVerbosity.Minimal
    };
} 