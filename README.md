# Ion Squad: Local Hero

## Description

This repository contains our implementation of the website of Ion Squad: Local Hero, an upcoming Belgian e-sports team and tournament host.
The goal we will try to achieve is to create a platform on which gamers from all across Belgium can connect and enjoy competitive gaming together.

## People Involved

**Group members:**
- [Jorn Lammens](https://github.com/jornlammens)
- [Liam Deman](https://github.com/liamdeman)
- [Robin De Brabanter](https://github.com/rdebrabanter)
- [Nicolas Van Damme](https://github.com/Mustachipleb)

**Class:** 2A

**Lecturers:**
- [Martine Van Audenrode](https://github.com/mvaudenrode)
- [Benjamin Vertonghen](https://github.com/vertonghenb)
- [Steven Van Impe](https://github.com/svanimpe)

## Running the Webserver

The master branch is deployed on [this link](https://proj2aalst-g320210323141654.azurewebsites.net/) using Azure. It is possible that certain features do not work as intended on this deployment, it's a learning process.

Steps to make everything working correctly:
- Run `npm install` in the src directory to install the needed npm packages.
- Make sure the app is running on port 44322, 5000 or 5001, this has been set up in the Discord App as redirect URI.
- Run the following commands in a terminal in the project folder, replacing each `[SECRET]` with the associated secret:
    - `dotnet user-secrets set "Discord:BotToken" "[SECRET]"`
    - `dotnet user-secrets set "Discord:ClientId" "[SECRET]"`
    - `dotnet user-secrets set "Discord:ClientSecret" "[SECRET]"`
    - `dotnet user-secrets set "Toornament:ApiKey" "[SECRET]"`
    - `dotnet user-secrets set "Toornament:ClientId" "[SECRET]"`
    - `dotnet user-secrets set "Toornament:ClientSecret" "[SECRET]"`
- [DSharpPlus](https://github.com/DSharpPlus/DSharpPlus) is not updated on the standard NuGet package source. This means the old version will be grabbed by default. To fix this:
    - Go to the NuGet package sources menu.
    - Add https://nuget.emzi0767.com/api/v3/index.json to the package sources.
    - Update all DSharpPlus packages which are installed on the project.
![gif tutorial](https://i.imgur.com/spfedkK.gif)
- If you want to run the Discord service, change the `--useDiscordBot false` launch argument to `true`.
