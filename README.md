![msal](https://github.com/nich2408/BlazorMsalWithApiSample/assets/98348348/e2578c9b-5aea-426e-9b46-178ab9a0874f)


## 🔐☁ Blazor MSAL with API sample
In this repository you can find a sample on how to use authentication inside a Blazor app.

The sample provided uses MSAL library https://learn.microsoft.com/en-us/entra/identity-platform/msal-overview and Azure (Microsoft Entra).


### 📁 Contents
- `BlazorMsalWithApiSample.API` contains a REST API with a sample controller that requires the client to be authenticated.
- `BlazorMsalWithApiSample.Blazor` contains the Blazor project with authentication.
- `BlazorMsalWithApiSample.Shared` contains simple models.

### 💻 Usage
API must be run in order to access the FetchData page from the Blazor app.

If you are using Visual Studio, it's better to enable multiple startup projects like so:

![image](https://github.com/nich2408/BlazorMsalWithApiSample/assets/98348348/3f9bd6c9-1975-4bdf-8906-56944419ec8f)

![image](https://github.com/nich2408/BlazorMsalWithApiSample/assets/98348348/2a18db8c-a09c-4b2a-b492-e6155d794b2a)

### ❔ Other info
- The projects were created using `dotnet-8` with Visual Studio 2022 Community Edition
- Blazor, Azure and Microsoft Entra logo are property of Microsoft https://www.microsoft.com/
