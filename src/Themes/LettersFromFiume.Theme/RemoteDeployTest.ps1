$switches = @(
    '--path', '.'
    '--base-id', 'TheBlogTheme'
    '--remote-deployment-url', 'https://localhost:44335/demo/OrchardCore.Deployment.Remote/ImportRemoteInstance/Import'
    '--remote-deployment-client-name', 'demo'
    '--remote-deployment-client-api-key', 'Password1!'
)

media-theme-deploy @switches

Write-Output "Exit code: $LastExitCode"
