Imports System.Configuration
Imports Microsoft.IdentityModel.Tokens
Imports Microsoft.Owin.Security.ActiveDirectory
Imports Owin

Partial Public Class Startup
    ' For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=868025
    Public Sub ConfigureAuth(app As IAppBuilder)
        app.UseWindowsAzureActiveDirectoryBearerAuthentication(
            New WindowsAzureActiveDirectoryBearerAuthenticationOptions() With {
                .Tenant = ConfigurationManager.AppSettings("ida:Tenant"),
                .TokenValidationParameters = New TokenValidationParameters() With {
                    .ValidAudience = ConfigurationManager.AppSettings("ida:Audience")
                },
                .MetadataAddress = ConfigurationManager.AppSettings("ida:MetadataAddress")
            })
    End Sub
End Class
