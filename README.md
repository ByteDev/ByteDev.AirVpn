[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.AirVpn?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-AirVpn/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.AirVpn.svg)](https://www.nuget.org/packages/ByteDev.AirVpn)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.AirVpn/blob/master/LICENSE)

# ByteDev.AirVpn

.NET Standard library SDK to help communicate with the AirVPN API.

AirVPN describes itself as:

> A VPN based on OpenVPN and operated by activists and hacktivists in defence of net neutrality, privacy and against censorship.

More information can be found in the **Links** section below.

## Installation

ByteDev.AirVpn is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.AirVpn`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.AirVpn/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.AirVpn/blob/master/docs/RELEASE-NOTES.md).

## Usage

The main class in the assembly is `AirVpnClient` and has four public methods which each act against the AirVPN API.

- `GetUserInfoAsync` *(requires API key)*
- `SendNotificationAsync` *(requires API key)*
- `DisconnectAsync` *(requires API key)*
- `GetStatusInfoAsync`

Example retrieving user info such as if the user is connected and the sessions they currently have:

```csharp
// AirVPN API keys are available to users at: https://airvpn.org/apisettings/
const string ApiKey = "someApiKey";

// Create an instance of AirVpnClient
IAirVpnClient client = new AirVpnClient(new HttpClient());

// Get user info
var request = new GetUserRequest(ApiKey);

var response = await client.GetUserAsync(request);

// response.IsSuccessful (if false ErrorMessage should be set)
// response.ErrorMessage
// response.User
// response.Sessions
```

All date times are UTC (that aren't Unix date time).

It should be noted that AirVPN has specified that they will ban an IP address that sends more than 600 requests every 10 minutes.

## Links

- [AirVPN home page](https://airvpn.org/)
- [AirVPN API info](https://airvpn.org/faq/api/)
- [AirVPN server status page](https://airvpn.org/status/)
- [Create an AirVPN API key](https://airvpn.org/apisettings/)
