This project is for a dotnet template that installs an ASP.NET Core 2.0 MVC SPA using Vue as the client framework.
The project also implements a simple Authentication and Authorization system secured by (JWT)[https://jwt.io/].

The application also uses the following client-side packages:

	- (Axios)[https://github.com/axios/axios] for promised based API calls
	- (Element-UI)[http://element.eleme.io/#/en-US] for page layout and controls
	- (Vue)[https://vuejs.org/] for the client side framework
	- (Vue-Router)[https://router.vuejs.org/en/] for the SPA page management
	- (Vue-Awesome)[https://github.com/Justineo/vue-awesome] for additional icons

** Publish template: **

	- publish.bat
	- nuget push jeffb.template.MvcVueSpa.Auth.<vers>.nupkg -ApiKey <key> -Source https://api.nuget.org/v3/index.json

** Install template: **

	- dotnet new -i jeffb.template.MvcVueSpa.Auth

** Uninstall template: **

	- dotnet new -u jeffb.template.MvcVueSpa.Auth
