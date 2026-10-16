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

## Current features (through Part 3)

- `/`: discovery home page with accommodation previews, a search that opens the Stays page, an educational sky guide, and experience previews that open tour details and demo booking.
- `/stays`: live text, destination, type, guest-capacity, budget, Bortle-class, low-moonlight, and saved-only filters. Five sort options, empty results, and reset controls are included.
- Stay cards and accessible details dialogs are reused by Home and Stays. Details show amenities, guest capacity, sample reviews, nightly price, and illustrative sky conditions.
- `/experiences`: text, destination, category, budget, duration, group-size, pristine-sky, and saved-only filters with four sort options. Details include the guide, inclusions, duration, capacity, price, and sample sky conditions.
- A three-step experience dialog shows details, a validated demo booking form, and a sample confirmation. The form checks required fields, name length, email format, dates from today through the next year, and the experience's group-size limit. Totals come from the sample catalog's price, and confirmations have generated demo references. The demo date uses Singapore time independently of the host timezone.
- Hearts add and remove stays and experiences from a shared, circuit-scoped collection. Favorites survive navigation within the app but reset on refresh or a new visit; there is no database or browser storage. The header's Saved menu links to each collection with separate counts. A separate Saved Trips page is planned for Part 4.
- Mobile filters collapse, and the native modal supports focus management, Escape, backdrop dismissal, and a close button.
- Demo confirmations are held in memory for the current visit. No reservation, payment, or email is made, and no external booking service is called.

Feature services live with their feature: `Stays/Services/StaySearchService.cs` and `Experiences/Services/ExperienceSearchService.cs` handle filtering and sorting; `Experiences/Services/DemoBookingService.cs` validates and creates sample confirmations; `SavedTrips/Services/SavedTripsService.cs` owns saved items. Pages hold presentation state and compose reusable components.

## Quick demo

1. On Home, search for a destination, then open a stay and save it with the heart.
2. Open **After dark**, try the category and budget filters, and explore an experience.
3. Select **Plan this night**, submit the empty form to see validation, then enter a sample name/email, a future date, and a group size. Confirm the demo to see its reference and total.
4. Save the experience and use the header's **Saved** menu to switch between the two collections. Refreshing starts a new visit and clears demo state.

## Sky guide references

The educational guide uses general background from [NASA's sky quality guide](https://science.nasa.gov/solar-system/skywatching/night-sky-network/check-your-sky-quality-with-orion/) and [DarkSky International's sky quality survey guide](https://darksky.org/resources/guides-and-how-tos/how-to-conduct-a-night-sky-quality-survey/0/). These are background reading; the app does not fetch forecasts or claim that the sample sky conditions are current.
