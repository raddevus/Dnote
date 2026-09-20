1. Add a file naned `Directory.Build.props` into the same directory where the SLN file is (outermost directory of the repo)
2. Add the XML shown below & then add the license key between the open / closing tag (`AvaloniaUILicenseKey`).

```XML
 <Project>
   <PropertyGroup>
      <AvaloniaUILicenseKey> </AvaloniaUILicenseKey> 
   </PropertyGroup>
</Project>
```
