# Blazor.I18N.Bug

## Dependencies
- Microsoft.Extensions.Localization

Blazor server project made with template from
Microsoft Visual Studio Professional 2019
Version 16.11.5
.Net 5.0

Added basic internationalization according to description on [MSDocs Globalization](https://docs.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?view=aspnetcore-5.0&pivots=server)

Using a FileSystemWatcher to get events triggered on creation and deletion of files on "C:\temp\WatchMe\"

## BUG
If the file watcher is instantiated in the constructor of my singleton FileWatcherService, it will remeber the CurrentUICulture from when it was instantiated.

Changing the language in the app will work as expected, until an event triggers a page update.  If the event used to trigger ```InvokeAsync(StateHasChanged)``` subscribes to ```FileWatcher```'s events, the razor component will render again with the old UICulture.

A second file watcher that is instantiated in the razor component is also demonstrated.  Here everything works as expected.

