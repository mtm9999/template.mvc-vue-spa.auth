MD publish
MD publish\content
PUSHD content
RD /S /Q .vs
RD /S /Q bin
RD /S /Q node_modules
RD /S /Q obj
RD /S /Q wwwroot
POPD
xcopy .\content .\publish\content /s /e /y
copy *.nuspec publish
nuget.exe pack .\publish\jeffb.MvcVueSpa.Auth.nuspec

move /Y *.nupkg ..
RD /S /Q publish
CD ..
