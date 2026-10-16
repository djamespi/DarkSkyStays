# Dark Sky Stays

A hospitality and tourism prototype for finding beautiful stays and memorable experiences under dark skies.

Built with .NET 8, Blazor Interactive Server, C#, and Tailwind CSS 4. No database, API keys, or external data service is required. Listings, prices, ratings, and sky conditions are fictional demonstration data. Original SVG illustrations are stored locally.

## Run locally

From `SprintApp`, install frontend dependencies once using `npm.cmd ci`.

Keep these commands running in separate terminals in `SprintApp`:

```powershell
dotnet watch
```

```powershell
npm.cmd run css:watch
```

For a clean build, generate CSS before compiling:

```powershell
npm.cmd run css:build
dotnet build
```

## Feature structure

```text
SprintApp/
  Features/
    Discovery/       Home page and destination models/data
    Stays/           Accommodation models, sample data, and browsing UI
    Experiences/     Tour models, sample data, and experience UI
    Sky/             Shared sample moon and light-pollution information
    SavedTrips/      Saved-item models and trip collection UI
  Components/
    Layout/          Application shell and navigation
    Shared/          Shared icons and UI
  Styles/            Tailwind source
  wwwroot/images/    Original local illustrations
```

Each feature owns its models, data, pages, and components as needed. Application layout and reusable visual elements stay in `Components`.

## Sprint commits

1. `feat: establish dark sky stays foundation` — feature structure, models, sample content, responsive shell, and interactive discovery home page.
2. `feat: add searchable stargazing stays` — separate Stays page, filters, accommodation details, and saving.
3. `feat: add night sky experiences` — separate Experiences page, filters, tour details, and simulated booking.
4. `feat: add saved trips and polish sprint demo` — optional Saved Trips page, shared saved state, responsive review, and final checks.

The completed sprint will have three required pages (Home, Stays, Experiences) and one optional page (Saved Trips). Work stops after each stage for review.

## Sky guide references

The educational guide uses general background from [NASA's sky quality guide](https://science.nasa.gov/solar-system/skywatching/night-sky-network/check-your-sky-quality-with-orion/) and [DarkSky International's sky quality survey guide](https://darksky.org/resources/guides-and-how-tos/how-to-conduct-a-night-sky-quality-survey/0/). These are background reading; the app does not fetch forecasts or claim that the sample sky conditions are current.
