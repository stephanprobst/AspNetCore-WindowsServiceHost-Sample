# AspNetCore WindowsService Host

See: <https://docs.microsoft.com/de-de/aspnet/core/hosting/windows-service>

To build & publish service:

```bash
dotnet publish -c Release -o c:\svc\testservice
```

To install & start service:

```bash
sc create TestService binPath="C:\svc\testservice\WindowsServiceHost.exe"
sc start TestService
```

Open in browser:

```bash
http://localhost:7000/api/values
```

If you start it with debugger (Visual Studio) it listen to port 7001:

```bash
http://localhost:7001/api/values
```

To stop or delete the windows service run:

```bash
sc stop TestService
sc delete TestService
```