﻿Namespace Application

    ''' <summary>
    ''' Represents an application that uses dependency injection to obtain services and perform operations.
    ''' </summary>
    ''' <remarks>
    ''' The <see cref="AppRunner"/> class relies on dependency injection to obtain an <see cref="IServiceProvider"/> 
    ''' which is used to retrieve services throughout the application. The main functionality of the class is to
    ''' run the application's core logic, including installing and uninstalling services.
    ''' </remarks>
    Friend Class AppRunner

        ''' <summary>
        ''' The service provider used for retrieving services.
        ''' </summary>
        Private ReadOnly _serviceProvider As IServiceProvider

        ''' <summary>
        ''' The user prompter used for displaying messages to the user.
        ''' </summary>
        Private ReadOnly _userPrompter As IUserPrompter

        ''' <summary>
        ''' The user input reader used for reading user input.
        ''' </summary>
        Private ReadOnly _userInputReader As IUserInputReader

        ''' <summary>
        ''' Initializes a new instance of the <see cref="AppRunner"/> class.
        ''' </summary>
        ''' <param name="serviceProvider">
        ''' An instance of <see cref="IServiceProvider"/> used to resolve dependencies and obtain services.
        ''' </param>
        ''' <param name="userPrompter">
        ''' An instance of <see cref="IUserPrompter"/> used to display messages to the user.
        ''' </param>
        ''' <param name="userInputReader">
        ''' An instance of <see cref="IUserInputReader"/> used to read user input.
        ''' </param>
        ''' <remarks>
        ''' The constructor takes an <see cref="IServiceProvider"/>, an <see cref="IUserPrompter"/>, and an <see cref="IUserInputReader"/> 
        ''' as parameters and assigns them to the corresponding fields.
        ''' </remarks>
        Friend Sub New(serviceProvider As IServiceProvider, userPrompter As IUserPrompter, userInputReader As IUserInputReader)
            _serviceProvider = serviceProvider
            _userPrompter = userPrompter
            _userInputReader = userInputReader
        End Sub

        ''' <summary>
        ''' Runs the application.
        ''' </summary>
        ''' <remarks>
        ''' The <see cref="RunAsync"/> method retrieves the <see cref="IUserInputChecker"/> from the service provider,
        ''' uses it to determine if the user wants to proceed with installing the service, and displays the result to the user.
        ''' </remarks>
        Friend Async Function RunAsync() As Task
            Dim userInputChecker = _serviceProvider.GetService(Of IUserInputChecker)()
            Dim shouldProceed = userInputChecker.ShouldProceed()

            If shouldProceed Then
                InstallService()
                Await DelayBeforeUninstall()
                UninstallService()
            End If

            _userInputReader.ReadInput()
        End Function

        ''' <summary>
        ''' Installs the service by using the <see cref="IServiceInstaller"/> retrieved from the service provider.
        ''' </summary>
        ''' <remarks>
        ''' This method attempts to install the service and handles any exceptions that occur during the installation process.
        ''' </remarks>
        Private Sub InstallService()
            Dim serviceInstaller = _serviceProvider.GetService(Of IServiceInstaller)()
            Try
                Dim installationSuccess = serviceInstaller.InstallService()
                _userPrompter.Prompt($"Service installation success: {installationSuccess}")
            Catch ex As Exception
                _userPrompter.Prompt($"Service installation failed: {ex.Message}")
            End Try
        End Sub

        ''' <summary>
        ''' Introduces a delay before proceeding to uninstall the service.
        ''' </summary>
        ''' <returns>
        ''' A task that represents the asynchronous operation.
        ''' </returns>
        ''' <remarks>
        ''' The <see cref="DelayBeforeUninstall"/> method prompts the user about the delay duration and then simulates a delay
        ''' before proceeding to uninstall the service.
        ''' </remarks>
        Private Async Function DelayBeforeUninstall() As Task
            Const delayMilliseconds = 10000
            PromptUserAboutDelay(delayMilliseconds)
            Await AsynchronousProcessor.SimulateDelayedResponse(delayMilliseconds)
        End Function

        ''' <summary>
        ''' Prompts the user about the delay duration.
        ''' </summary>
        ''' <param name="delayMilliseconds">The delay duration in milliseconds.</param>
        ''' <remarks>
        ''' The <see cref="PromptUserAboutDelay"/> method uses the <see cref="IUserPrompter"/> service to notify the user about
        ''' the delay before uninstalling the service.
        ''' </remarks>
        Private Sub PromptUserAboutDelay(delayMilliseconds As Integer)
            _userPrompter.Prompt($"The service will wait for {delayMilliseconds / 1000} seconds before proceeding to uninstall.")
        End Sub

        ''' <summary>
        ''' Uninstalls the service by using the <see cref="IServiceUninstaller"/> retrieved from the service provider.
        ''' </summary>
        ''' <remarks>
        ''' This method attempts to uninstall the service and handles any exceptions that occur during the uninstallation process.
        ''' </remarks>
        Private Async Sub UninstallService()
            Dim serviceUninstaller = _serviceProvider.GetService(Of IServiceUninstaller)()
            Try
                Dim uninstallationSuccess = Await serviceUninstaller.UninstallServiceAsync()
                _userPrompter.Prompt($"Service uninstallation success: {uninstallationSuccess}")
            Catch ex As Exception
                _userPrompter.Prompt($"Service uninstallation failed: {ex.Message}")
            End Try
        End Sub
    End Class
End Namespace
