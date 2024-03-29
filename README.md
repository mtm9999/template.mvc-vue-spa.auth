# Full Featured SPA Template

This project is for a dotnet template that installs an ASP.NET Core 2.0 MVC SPA using Vue as the client framework.
The project also implements a simple Authentication and Authorization system secured by [JWT](https://jwt.io/).

#### The application also uses the following client-side packages:

* [Axios](https://github.com/axios/axios) for promised based API calls
* [Element-UI](http://element.eleme.io/#/en-US) for page layout and controls
* [Vue](https://vuejs.org/) for the client side framework
* [Vue-Router](https://router.vuejs.org/en/) for the SPA page management
* [Vue-Awesome](https://github.com/Justineo/vue-awesome) for additional icons

#### Development includes the following features:

* ASP.NET Core support for webpack hot swappable modules
* Eslint for client code checks (NOTE: If you are having trouble running try `npm -g i eslint-cli`)
* JsHint config if your editor supports it

#### Publish template:

```
> package.bat
> nuget push jeffb.template.MvcVueSpa.Auth.<vers>.nupkg -ApiKey <key> -Source https://api.nuget.org/v3/index.json
```

#### Install template: \*\*

```
> dotnet new -i jeffb.template.MvcVueSpa.Auth
```

#### Uninstall template: \*\*

```
> dotnet new -u jeffb.template.MvcVueSpa.Auth
```

If there are problems reinstalling, run

```
> dotnet new --debug:reinit
```

## VSCode Configuration

Make sure the following extensions are installed:

* Beautify
* ESLint
* jshint
* npm
* npm intellisense
* prettier
* vetur
* vue.js Extension pack
