PUSHD content
RD /S /Q .vs
RD /S /Q bin
RD /S /Q node_modules
RD /S /Q obj
RD /S /Q wwwroot
POPD
CD ..
.\mvc-vue-spa\nuget.exe pack .\template.mvc-vue-spa.auth\jeffb.MvcVueSpa.Auth.nuspec
