Dynamic Settings
================
Dynamic Settings is a .NET library that allows you to load application settings from a variety of sources including environment variables, ConfigurationManager, text files, YAML files, and Redis.

Install
=======
Binaries are available on Nuget at https://www.nuget.org/DynamicSettings

To install, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

	PM> Install-Package DynamicSettings

Usage
=====
You can set up your DI container to cascade through the different types of settings as follows. This example uses Autofac, but others will be similar.
	
	var builder = new ContainerBuilder();
	builder.Register(c => new AppSettings(new EnvironmentVariableSettings("MYAPP_"), new FileSettings(".", "*.key"), new YamlSettings("Config.yaml"), new ConfigurationManagerSettings())).SingleInstance();

When a setting is accessed through the AppSettings class, this will first look in the EnvironmentVariableSettings, if the setting isn't there, it will then look in FileSettings, then YamlSettings, etc.

Inject an instance of AppSettings and access your configuration settings through it.

	public class MyClass
    {
    	private dynamic _appSettings

        public MyClass(AppSettings settings)
        {
            _appSettings = settings;
        }

        public GetMySetting()
        {
            var setting = _appSettings.MySetting

            return setting;
        }
    }

