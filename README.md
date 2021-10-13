# Blazor.I18N.Bug

## Dependencies
- Microsoft.Extensions.Localization
- System.Reactive

Blazor project from the .Net 5.0 template.  Added basic internationalization according to description on [MSDocs Globalization](https://docs.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?view=aspnetcore-5.0&pivots=server)

Added an IObservable to push random numbers.

## BUG
If IObservable is activated, changing language does not work as expected on the page subscribing to IObservable.
Language is correct until page is updated from delegate given to IObservable.
