## Repro steps

```fsharp
dotnet tool restore
dotnet build
dotnet fsdocs build 
```

## Error

```
API docs:
  generating model for 1 assemblies in API docs...
  loading 1 assemblies...
isNetCoreApp = true
  registering entities for assembly Lib...
  reading XML doc for /Users/sergey/github/fsdocs-generic-params/src/Lib/bin/Debug/netstandard2.0/Lib.dll...
  reading assembly data for /Users/sergey/github/fsdocs-generic-params/src/Lib/bin/Debug/netstandard2.0/Lib.dll...
Error : 
System.Xml.XmlException: '<', hexadecimal value 0x3C, is an invalid attribute character. Line 10, position 86.
   at System.Xml.XmlTextReaderImpl.Throw(Exception e)
   at System.Xml.XmlTextReaderImpl.Throw(String res, String[] args)
   at System.Xml.XmlTextReaderImpl.ParseAttributeValueSlow(Int32 curPos, Char quoteChar, NodeData attr)
   at System.Xml.XmlTextReaderImpl.ParseAttributes()
   at System.Xml.XmlTextReaderImpl.ParseElement()
   at System.Xml.XmlTextReaderImpl.ParseElementContent()
   at System.Xml.XmlTextReaderImpl.Read()
   at System.Xml.Linq.XContainer.ReadContentFrom(XmlReader r)
   at System.Xml.Linq.XContainer.ReadContentFrom(XmlReader r, LoadOptions o)
   at System.Xml.Linq.XDocument.Load(XmlReader reader, LoadOptions options)
   at System.Xml.Linq.XDocument.Load(String uri, LoadOptions options)
   at FSharp.Formatting.ApiDocs.SymbolReader.readAssembly(FSharpAssembly assembly, Boolean publicOnly, String xmlFile, FSharpList`1 substitutions, FSharpOption`1 sourceFolderRepo, FSharpFunc`2 urlRangeHighlight, Boolean mdcomments, CrossReferenceResolver urlMap, String codeFormatCompilerArgs, Boolean warn) in /home/runner/work/FSharp.Formatting/FSharp.Formatting/src/FSharp.Formatting.ApiDocs/GenerateModel.fs:line 2028
   at <StartupCode$FSharp-Formatting-ApiDocs>.$GenerateModel.assemblies@2180-1.Invoke(Tuple`2 tupledArg) in /home/runner/work/FSharp.Formatting/FSharp.Formatting/src/FSharp.Formatting.ApiDocs/GenerateModel.fs:line 2226
   at Microsoft.FSharp.Primitives.Basics.List.choose[T,TResult](FSharpFunc`2 f, FSharpList`1 xs) in D:\workspace\_work\1\s\src\fsharp\FSharp.Core\local.fs:line 189
   at FSharp.Formatting.ApiDocs.ApiDocModel.Generate(FSharpList`1 projects, String collectionName, FSharpOption`1 libDirs, FSharpOption`1 otherFlags, Boolean qualify, FSharpOption`1 urlRangeHighlight, String root, FSharpList`1 substitutions, Boolean strict, ApiDocFileExtensions extensions) in /home/runner/work/FSharp.Formatting/FSharp.Formatting/src/FSharp.Formatting.ApiDocs/GenerateModel.fs:line 2180
   at FSharp.Formatting.ApiDocs.ApiDocs.GenerateHtmlPhased[b](FSharpList`1 inputs, String output, String collectionName, FSharpList`1 substitutions, FSharpOption`1 template, FSharpOption`1 root, FSharpOption`1 qualify, FSharpOption`1 libDirs, FSharpOption`1 otherFlags, FSharpOption`1 urlRangeHighlight, FSharpOption`1 strict) in /home/runner/work/FSharp.Formatting/FSharp.Formatting/src/FSharp.Formatting.ApiDocs/ApiDocs.fs:line 62
   at <StartupCode$fsdocs>.$BuildCommand.runGeneratePhase1@615-1.Invoke(Unit unitVar0) in /home/runner/work/FSharp.Formatting/FSharp.Formatting/src/FSharp.Formatting.CommandTool/BuildCommand.fs:line 646
   at <StartupCode$fsdocs>.$BuildCommand.protect@388(CoreBuildOptions this, String phase, FSharpFunc`2 f) in /home/runner/work/FSharp.Formatting/FSharp.Formatting/src/FSharp.Formatting.CommandTool/BuildCommand.fs:line 390
```

## Source of error

XML comments

```fsharp
    interface IEnumerable<byte> with
        /// Gets an enumerator for the bytes stored in the byte string.
        member this.GetEnumerator() = this.GetEnumerator()

    interface IEnumerable with
        /// Gets an enumerator for the bytes stored in the byte string.
        member this.GetEnumerator() = this.GetEnumerator() :> IEnumerator
```