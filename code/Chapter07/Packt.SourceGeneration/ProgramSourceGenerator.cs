// To use [Generator], IIncrementalGenerator, and so on.
using Microsoft.CodeAnalysis; 

namespace Packt.Shared;

[Generator]
public class ProgramSourceGenerator : IIncrementalGenerator
{
  public void Initialize(IncrementalGeneratorInitializationContext initContext)
  {
    // Create a pipeline that gets the compilation
    IncrementalValueProvider<Compilation> compilationProvider = initContext.CompilationProvider;

    // Register the source output
    initContext.RegisterSourceOutput(compilationProvider, (context, compilation) =>
    {
      IMethodSymbol? mainMethod = compilation.GetEntryPoint(context.CancellationToken);
      
      string sourceCode = $@"// Source-generated class.
#nullable enable

using System.Globalization; // To use CultureInfo.

partial class {mainMethod?.ContainingType.Name}
{{
  private static CultureInfo? _computerCulture = null;

  public static void ConfigureConsole(
    string culture = ""en-US"",
    bool useComputerCulture = false,
    bool showCulture = true)
  {{
    // Store the original computer culture so we can reset it later.
    if (_computerCulture is null)
    {{
      _computerCulture = CultureInfo.CurrentCulture;
    }}

    // Enable special characters like Euro currency symbol.
    OutputEncoding = System.Text.Encoding.UTF8;

    if (useComputerCulture)
    {{
      CultureInfo.CurrentCulture = _computerCulture;
    }}
    else
    {{
      CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
    }}

    if (showCulture)
    {{
      WriteLine($""Current culture: {{CultureInfo.CurrentCulture.DisplayName}}."");
    }}
  }}
}}
";

      string fileName = $"{mainMethod?.ContainingType.Name}.Methods.g.cs";
      context.AddSource(fileName, sourceCode);
    });
  }
}
