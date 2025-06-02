// ----------------------------
// General Testing Instructions
// ----------------------------
// This console project is used to test individual sample files from the research_samples_repo class library.
//
// Some sample files may contain compiler errors. To avoid build failures, only include
// the specific file(s) you want to test in the project build.
//
// Setup steps:
// 1. Edit the .csproj file for this console project.
// 2. Add <EnableDefaultCompileItems>false</EnableDefaultCompileItems> in a <PropertyGroup>.
// 3. Explicitly include only the required files in the <ItemGroup>, for example:
//
//    <ItemGroup>
//        <Compile Include="folder\YourSampleFile.cs" />
//    </ItemGroup>
//
// 4. In the Main method below, call the static entry point of the sample you want to test.
//    For example: SampleFile.Main(args);
//
// To test a different file:
// - Update the <ItemGroup> to include only that file
// - Update the Main method below to call its entry point
//


using research_samples_repo.Self_Authored;

namespace TestingPlatformForSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            sample_3.Main(args); // Replace this with the class you want to test
        }
    }
}
