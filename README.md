# Dark Sky Stays

A hospitality and tourism prototype for finding beautiful stays and memorable experiences under dark skies.

Built with .NET 8, Blazor Interactive Server, C#, and Tailwind CSS 4. No database, API keys, or external data service is required. Listings, prices, ratings, and sky conditions are fictional demonstration data. Illustrations and the supplied Milky Way photograph are stored locally.

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
  wwwroot/images/    Local illustrations and supplied Milky Way photograph
```

Each feature owns its models, data, pages, and components as needed. Application layout and reusable visual elements stay in `Components`.

## Sprint commits

1. `feat: establish dark sky stays foundation` — feature structure, models, sample content, responsive shell, and interactive discovery home page.
2. `feat: add searchable stargazing stays` — separate Stays page, filters, accommodation details, and saving.
3. `feat: add night sky experiences` — separate Experiences page, filters, tour details, and simulated booking.
4. `feat: add saved trips and polish sprint demo` — Saved Trips page, demo confirmations, clear/undo, text export, and final responsive/interaction checks.

The completed sprint includes three required pages (Home, Stays, Experiences) and the optional fourth page (Saved Trips). All four development stages are complete.

The subsequent visual update uses `style: apply violet night sky component design`.

## Component design

The supplied `DESIGN.md` informed the component styling: near-black and violet colors, a drifting star field, translucent navigation and search, Fraunces headings, Space Grotesk UI text, rounded cards, glowing buttons, alternating tour rows, and nine-color Bortle indicators. The existing four pages, international sample catalog, USD prices, filtering, saving, simulated bookings, and collection export remain in place. The layouts remain responsive. Moon icons render each listing's sample illumination; the header explicitly labels its readout as a sample.

Shared theme tokens and font declarations live in `SprintApp/wwwroot/app.css`, with matching Tailwind tokens in `SprintApp/Styles/tailwind.css`. Feature components retain their own scoped styles. `Features/Sky/Components` owns the reusable moon icon and Bortle bar.

Home, Stays, and Experiences use the supplied `milky-way-landscape.png` as their banner photograph. Shared CSS layers add the guide's violet tint, ambient glow, and fade into the near-black page background while retaining the original image file. The global drifting stars and glass surfaces continue across the site; reduced-motion settings stop the animation.

Fonts ship locally in `SprintApp/wwwroot/fonts` under the SIL Open Font License; their licenses are included alongside the assets. Their sources are the Google Fonts repositories for [Fraunces](https://github.com/google/fonts/tree/main/ofl/fraunces) and [Space Grotesk](https://github.com/google/fonts/tree/main/ofl/spacegrotesk). No font service is contacted while using the app. To re-download these assets and licenses, run `node tools/download-design-fonts.mjs` from `SprintApp` with internet access. The star-field animation respects reduced-motion settings.

## Completed features

- `/`: discovery home page with accommodation previews, a search that opens the Stays page, an educational sky guide, and experience previews that open tour details and demo booking.
- `/stays`: live text, destination, type, guest-capacity, budget, Bortle-class, low-moonlight, and saved-only filters. Five sort options, empty results, and reset controls are included.
- Stay cards and accessible details dialogs are reused by Home and Stays. Details show amenities, guest capacity, sample reviews, nightly price, and illustrative sky conditions.
- `/experiences`: text, destination, category, budget, duration, group-size, pristine-sky, and saved-only filters with four sort options. Details include the guide, inclusions, duration, capacity, price, and sample sky conditions.
- A three-step experience dialog shows details, a validated demo booking form, and a sample confirmation. The form checks required fields, name length, email format, dates from today through the next year, and the experience's group-size limit. Totals come from the sample catalog's price, and confirmations have generated demo references. The demo date uses Singapore time independently of the host timezone.
- `/saved-trips`: combined collection with Everything, Stays, Experiences, and Demo Bookings views; destination counts; reusable detail dialogs; chronological confirmation receipts; and guest-detail disclosures. Visitors can remove favorites or demo plans, clear all favorites, undo a clear, and download a text snapshot.
- Hearts add and remove stays and experiences from a shared, circuit-scoped collection. Favorites survive navigation within the app but reset on refresh or a new visit; there is no database or browser storage. The header's Saved menu links to the combined page, each favorites list, and demo confirmations with live counts.
- Stay filters collapse on mobile, and the native modals support focus management, Escape, backdrop dismissal, and close buttons.
- Demo confirmations are held in memory for the current visit. No reservation, payment, or email is made, and no external booking service is called.
- Clearing saved favorites preserves demo confirmations. Removing a demo plan does not remove its saved experience. Downloading includes all favorites and current demo confirmations, independently of the selected collection view; the text labels rates and bookings as samples.

Feature services live with their feature: `Stays/Services/StaySearchService.cs` and `Experiences/Services/ExperienceSearchService.cs` handle filtering and sorting; `Experiences/Services/DemoBookingService.cs` validates and creates sample confirmations; `SavedTrips/Services/SavedTripsService.cs` owns saved items. Pages hold presentation state and compose reusable components.

## Quick demo

1. On Home, search for a destination, then open a stay and save it with the heart.
2. Open **After dark**, try the category and budget filters, and explore an experience.
3. Select **Plan this night**, submit the empty form to see validation, then enter a sample name/email, a future date, and a group size. Confirm the demo to see its reference and total.
4. Save the experience and open **Your collection**. Switch among saved stays, experiences, and demo bookings. Clear favorites, undo the clear, and download the collection as a text file.
5. Refresh to demonstrate that the app starts a new visit and clears its sample state. The downloaded snapshot remains available on your computer.

## Validation

- Debug and Release .NET builds complete with zero warnings/errors; Tailwind compilation succeeds.
- Browser checks cover lodging and experience filter combinations, sorting, empty states, reset controls, cross-page saves, native dialog focus/keyboard/backdrop behavior, and mobile navigation.
- Booking checks cover missing fields, invalid names/emails, past and out-of-range dates, group capacity, live totals, and desktop/mobile confirmations.
- Collection checks cover live receipt counts, chronological order, removal, clear/undo without removing bookings, text-file contents, and reset on refresh.
- All four pages are checked for horizontal overflow from 320px to 1440px, including intermediate tablet widths. All visual assets are local.

## Sky guide references

The educational guide uses general background from [NASA's sky quality guide](https://science.nasa.gov/solar-system/skywatching/night-sky-network/check-your-sky-quality-with-orion/) and [DarkSky International's sky quality survey guide](https://darksky.org/resources/guides-and-how-tos/how-to-conduct-a-night-sky-quality-survey/0/). These are background reading; the app does not fetch forecasts or claim that the sample sky conditions are current.
