﻿Namespace Application

    ''' <summary>
    ''' Configures the services for dependency injection.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="ServiceConfigurator"/> class provides methods to configure and register services
    ''' for dependency injection. It creates a new instance of the <see cref="ServiceCollection"/> class,
    ''' registers various services and their corresponding implementations, and builds an <see cref="IServiceProvider"/>
    ''' which can be used to resolve services at runtime.
    ''' </remarks>
    Friend Class ServiceConfigurator

        ''' <summary>
        ''' Registers all services required by the application.
        ''' </summary>
        ''' <param name="services">
        ''' The service collection to add the services to.
        ''' </param>
        ''' <remarks>
        ''' This method calls individual methods to register different categories of services:
        ''' <list type="bullet">
        '''   <item>
        '''     <description>
        '''       <see cref="RegisterErrorHandlingServices"/> to register error handling services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="RegisterUserInputServices"/> to register user input services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="RegisterServiceManagementServices"/> to register service management services.
        '''     </description>
        '''   </item>
        ''' </list>
        ''' </remarks>
        Private Shared Sub RegisterServices(services As IServiceCollection)
            RegisterErrorHandlingServices(services)
            RegisterUserInputServices(services)
            RegisterServiceManagementServices(services)
        End Sub

        ''' <summary>
        ''' Registers error handling services.
        ''' </summary>
        ''' <param name="services">
        ''' The service collection to which the error handling services are added. This instance of <see cref="IServiceCollection"/> 
        ''' is used to register services and their implementations for dependency injection.
        ''' </param>
        ''' <remarks>
        ''' This method registers the following error handling services:
        ''' <list type="bullet">
        '''   <item>
        '''     <description>
        '''       <see cref="IWin32ErrorHelper"/> is implemented by <see cref="Win32ErrorHelper"/>. This service helps retrieve Win32 error codes.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IWin32ErrorUtility"/> is implemented by <see cref="Win32ErrorUtility"/>. This service provides descriptions for Win32 error codes.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IErrorHandlingService"/> is implemented by <see cref="ErrorHandlingService"/>. This service handles Win32 errors.
        '''     </description>
        '''   </item>
        ''' </list>
        ''' </remarks>
        ''' <seealso cref="AddServices"/>
        ''' <seealso cref="IWin32ErrorHelper"/>
        ''' <seealso cref="Win32ErrorHelper"/>
        ''' <seealso cref="IWin32ErrorUtility"/>
        ''' <seealso cref="Win32ErrorUtility"/>
        ''' <seealso cref="IErrorHandlingService"/>
        ''' <seealso cref="ErrorHandlingService"/>
        Private Shared Sub RegisterErrorHandlingServices(services As IServiceCollection)
            Dim errorHandlingServices As New Dictionary(Of Type, Type) From {
                    {GetType(IWin32ErrorHelper), GetType(Win32ErrorHelper)},
                    {GetType(IWin32ErrorUtility), GetType(Win32ErrorUtility)},
                    {GetType(IErrorHandlingService), GetType(ErrorHandlingService)}
                    }
            AddServices(services, errorHandlingServices)
        End Sub

        ''' <summary>
        ''' Registers user input services.
        ''' </summary>
        ''' <param name="services">
        ''' The service collection to which the user input services are added. This instance of <see cref="IServiceCollection"/> 
        ''' is used to register services and their implementations for dependency injection.
        ''' </param>
        ''' <remarks>
        ''' This method registers the following user input services:
        ''' <list type="bullet">
        '''   <item>
        '''     <description>
        '''       <see cref="IUserInputReader"/> is implemented by <see cref="UserInputReader"/>. This service handles reading user inputs 
        '''       during interaction processes.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IUserPrompter"/> is implemented by <see cref="UserPrompter"/>. This service prompts the user for inputs, 
        '''       typically used in setup tasks where user confirmation is needed.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IUserInputChecker"/> is implemented by <see cref="UserInputChecker"/>. This service handles user interactions 
        '''       to verify decisions, such as whether to proceed with setup tasks.
        '''     </description>
        '''   </item>
        ''' </list>
        ''' </remarks>
        ''' <seealso cref="AddServices"/>
        ''' <seealso cref="IUserInputReader"/>
        ''' <seealso cref="UserInputReader"/>
        ''' <seealso cref="IUserPrompter"/>
        ''' <seealso cref="UserPrompter"/>
        ''' <seealso cref="IUserInputChecker"/>
        ''' <seealso cref="UserInputChecker"/>
        Private Shared Sub RegisterUserInputServices(services As IServiceCollection)
            Dim userInputServices As New Dictionary(Of Type, Type) From {
                    {GetType(IUserInputReader), GetType(UserInputReader)},
                    {GetType(IUserPrompter), GetType(UserPrompter)},
                    {GetType(IUserInputChecker), GetType(UserInputChecker)}
                    }
            AddServices(services, userInputServices)
        End Sub


        ''' <summary>
        ''' Registers service management services.
        ''' </summary>
        ''' <param name="services">
        ''' The service collection to which the service management services are added. This instance of <see cref="IServiceCollection"/> 
        ''' is used to register services and their implementations for dependency injection.
        ''' </param>
        ''' <remarks>
        ''' This method registers the following service management services:
        ''' <list type="bullet">
        '''   <item>
        '''     <description>
        '''       <see cref="IServicePathProvider"/> is implemented by <see cref="ServicePathProvider"/>. This service provides paths 
        '''       for services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServiceControlManager"/> is implemented by <see cref="ServiceControlManager"/>. This service manages 
        '''       interactions with the service control manager.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServiceCreator"/> is implemented by <see cref="ServiceCreator"/>. This service is responsible for creating services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServiceInstaller"/> is implemented by <see cref="ServiceInstaller"/>. This service handles the installation 
        '''       of services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServiceStarter"/> is implemented by <see cref="ServiceStarter"/>. This service handles starting services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServiceStopper"/> is implemented by <see cref="ServiceStopper"/>. This service handles stopping services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServiceStatusChecker"/> is implemented by <see cref="ServiceStatusChecker"/>. This service provides functionality 
        '''       to check the status of services.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServiceDeleter"/> is implemented by <see cref="ServiceDeleter"/>. This service provides functionality to mark 
        '''       services for deletion from the service control manager database.
        '''     </description>
        '''   </item>
        '''   <item>
        '''     <description>
        '''       <see cref="IServiceUninstaller"/> is implemented by <see cref="ServiceUninstaller"/>. This service handles the uninstallation 
        '''       of services.
        '''     </description>
        '''   </item>
        ''' </list>
        ''' For additional information, refer to the <see href="https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicecollectionextensions.addservices">ServiceCollectionExtensions.AddServices</see> documentation.
        ''' </remarks>
        ''' <seealso cref="AddServices"/>
        ''' <seealso cref="IServicePathProvider"/>
        ''' <seealso cref="ServicePathProvider"/>
        ''' <seealso cref="IServiceControlManager"/>
        ''' <seealso cref="ServiceControlManager"/>
        ''' <seealso cref="IServiceCreator"/>
        ''' <seealso cref="ServiceCreator"/>
        ''' <seealso cref="IServiceInstaller"/>
        ''' <seealso cref="ServiceInstaller"/>
        ''' <seealso cref="IServiceStarter"/>
        ''' <seealso cref="ServiceStarter"/>
        ''' <seealso cref="IServiceStopper"/>
        ''' <seealso cref="ServiceStopper"/>
        ''' <seealso cref="IServiceStatusChecker"/>
        ''' <seealso cref="ServiceStatusChecker"/>
        ''' <seealso cref="IServiceDeleter"/>
        ''' <seealso cref="ServiceDeleter"/>
        ''' <seealso cref="IServiceUninstaller"/>
        ''' <seealso cref="ServiceUninstaller"/>
        Private Shared Sub RegisterServiceManagementServices(services As IServiceCollection)
            Dim serviceManagementServices As New Dictionary(Of Type, Type) From {
                {GetType(IServicePathProvider), GetType(ServicePathProvider)},
                {GetType(IServiceControlManager), GetType(ServiceControlManager)},
                {GetType(IServiceCreator), GetType(ServiceCreator)},
                {GetType(IServiceInstaller), GetType(ServiceInstaller)},
                {GetType(IServiceStarter), GetType(ServiceStarter)},
                {GetType(IServiceStopper), GetType(ServiceStopper)},
                {GetType(IServiceStatusChecker), GetType(ServiceStatusChecker)},
                {GetType(IServiceDeleter), GetType(ServiceDeleter)},
                {GetType(IServiceUninstaller), GetType(ServiceUninstaller)}
            }
            AddServices(services, serviceManagementServices)
        End Sub

        ''' <summary>
        ''' Adds the specified services to the service collection.
        ''' </summary>
        ''' <param name="services">
        ''' The service collection to which the services are added. This instance of <see cref="IServiceCollection"/> 
        ''' is used to register services and their implementations for dependency injection.
        ''' </param>
        ''' <param name="serviceRegistrations">
        ''' The dictionary containing service registrations, where each key represents a service type and each value 
        ''' represents its corresponding implementation type.
        ''' </param>
        ''' <remarks>
        ''' This method iterates over the provided dictionary of service registrations and adds each service
        ''' to the <paramref name="services"/> collection with a transient lifetime.
        ''' 
        ''' This method uses to add the services. 
        ''' Transient services are created each time they are requested, which is suitable for lightweight, stateless services.
        ''' </remarks>
        Private Shared Sub AddServices(services As IServiceCollection, serviceRegistrations As Dictionary(Of Type, Type))
            For Each kvp As KeyValuePair(Of Type, Type) In serviceRegistrations
                services.AddTransient(kvp.Key, kvp.Value)
            Next
        End Sub

        ''' <summary>
        ''' Configures the services for dependency injection.
        ''' </summary>
        ''' <returns>
        ''' An <see cref="IServiceProvider"/> that provides the configured services. This provider can be used to resolve services
        ''' at runtime.
        ''' </returns>
        ''' <remarks>
        ''' The <see cref="ConfigureServices"/> method creates a new instance of the <see cref="ServiceCollection"/>
        ''' and registers various services and their corresponding implementations by calling the <see cref="RegisterServices"/> method.
        ''' The method then builds and returns an <see cref="IServiceProvider"/> which can be used to resolve services at runtime.
        ''' 
        ''' The returned <see cref="IServiceProvider"/> is the main interface for accessing the configured services and is used 
        ''' throughout the application to resolve dependencies.
        ''' </remarks>
        Friend Shared Function ConfigureServices() As IServiceProvider
            Dim services As New ServiceCollection()
            RegisterServices(services)
            Return services.BuildServiceProvider()
        End Function
    End Class
End Namespace
