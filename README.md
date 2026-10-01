# Toru's Nook

A cozy, interactive portfolio built with Blazor WebAssembly for Andre's projects, skills, music rotation, and tiny digital companion, Toru.

This is less of a filing cabinet and more of a warm little room on the internet: browse around, talk to Toru, listen to a mood, inspect the work, and leave an album review.

## What is inside?

- **Home**: A personal welcome page with Toru's interactive mood demo.
- **Projects**: A curated collection of software projects and the tools behind them.
- **Skills**: A compact toolkit of languages, frameworks, and technologies.
- **Music Vault**: Album covers, local audio previews, reviews, ratings, and review submission.
- **Mood music**: Toru cycles through different moods, each with its own message, artwork, color treatment, and audio track.
- **Volume controls**: Ambient music starts gently and can be muted or adjusted from the header.
- **Responsive layout**: Designed to stay comfortable on both wide screens and small ones.

## Routes

| Route | Purpose |
| --- | --- |
| `/` | Introduction and interactive Toru demo |
| `/projects` | Featured projects |
| `/skills` | Skills and tools |
| `/music` | Album collection and reviews |

## Built with

- .NET 10
- Blazor WebAssembly
- C#
- Tailwind CSS 4
- JavaScript audio interop
- HTML and CSS

## Run locally

### Requirements

- .NET 10 SDK
- Node.js and npm

### Install dependencies

```bash
npm install
```

### Start the app

```bash
dotnet watch
```

The development server will print the local URL when it starts.

### Watch Tailwind CSS separately

```bash
npm run css:watch
```

For a one-time CSS build:

```bash
npm run css:build
```

### Build for release

```bash
dotnet build -c Release
```

The release build runs the Tailwind production build as part of the project build process.

## Audio setup

Mood tracks live in:

```text
wwwroot/audio/moods/
```

Album previews live in:

```text
wwwroot/audio/snippets/
```

Album snippet paths are defined in `Services/PortfolioDataService.cs`. Add a short audio file with the matching filename when adding or replacing a preview. Keep audio clips lightweight for a faster portfolio experience, and only use music you are allowed to publish.

## Project shape

```text
Components/   Reusable Blazor UI, including music, reviews, icons, and Toru
Layout/       Shared navigation and page layout
Models/       Portfolio, mood, music, and review records
Pages/        Route-level pages
Services/     Portfolio data and audio services
Styles/       Tailwind source stylesheet
wwwroot/      Static images, audio, JavaScript, and generated CSS
```

The portfolio data is currently held in `PortfolioDataService` and reviews are stored in memory while the app is running. Restarting the app resets reviews submitted during that session.

## A small note from the nook

The visual language is intentionally soft: parchment, sage, sky blue, blush, warm bark, and just enough motion to make the page feel inhabited. The goal is a portfolio that feels personal before it feels polished, while still showing the engineering underneath.

## License and media

Project code and personal artwork belong to the project author unless otherwise noted. Music, character references, album artwork, and other third-party media may have separate rights and should be used only with appropriate permission or under applicable terms.
