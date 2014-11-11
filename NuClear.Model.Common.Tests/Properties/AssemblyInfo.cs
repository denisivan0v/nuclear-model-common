using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[assembly: AssemblyCompany("2GIS")]
[assembly: AssemblyProduct("2GIS Model Common Tests(NuClear project)")]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]

[assembly: NeutralResourcesLanguage("en")]

[assembly: AssemblyVersion("0.0.0.0")]
[assembly: AssemblyFileVersion("0.0.0.0")]
[assembly: AssemblyInformationalVersion("0.0.0")]
[assembly: SatelliteContractVersion("0.0.0.0")]


#if DEBUG

[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyDescription("This is Debug version of assembly")]

#else

[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("This is Release version of assembly")]

#endif