# DotNest Core SDK

## Overview

[DotNest Core SDK](https://github.com/Lombiq/DotNest-Core-SDK) is a local development environment for building [Media Themes](https://github.com/Lombiq/Hosting-Media-Theme) to be deployed to [Orchard Core CMS](http://orchardcore.net) sites running on [DotNest](http://dotnest.com), the Orchard SaaS. Media Themes are almost full-fledged Orchard themes that you can develop as any Orchard theme, but they'll still work on DotNest.

The base of the source code on the `dev` branch is the same Orchard Core version that is running on DotNest as well as all the hotfixes and mods we've applied to it. On top of that, all the open-source modules are added as NuGet packages, which gives you the ability to develop your theme and run your site locally in an environment quite close to the live DotNest site.

We at [Lombiq](https://lombiq.com/) also used this SDK for the following projects:

- The new [Xero4PowerBI website](https://xero4powerbi.com/) ([see case study](https://dotnest.com/blog/xero4powerbi-website-case-study-migration-to-orchard-core)).<!-- #spell-check-ignore-line -->
- The new [Ik wil een taart website](https://ikwileentaart.nl/) ([see case study](https://dotnest.com/blog/revamping-ik-wil-een-taart-migrating-an-old-version-of-orchard-core-website-with-custom-theme-and-commerce-logic-to-dotnest)).<!-- #spell-check-ignore-line -->
- The new [Show Orchard website](https://showorchard.com/) when migrating it from Orchard 1 DotNest to DotNest Core ([see case study](https://dotnest.com/blog/show-orchard-case-study-migrating-an-orchard-1-dotnest-site-to-orchard-core)).<!-- #spell-check-ignore-line -->

This project, along with DotNest, is developed by [Lombiq Technologies Ltd](https://lombiq.com). Commercial-grade support is available through Lombiq.

## Getting started

Are you unfamiliar with Orchard Core theme development and Liquid templates, or even Orchard Core in general? Then we recommend you check out the [Dojo Course 3 tutorial](https://orcharddojo.net/orchard-training/dojo-course-3-the-full-orchard-core-tutorial) and the official docs [on Liquid](https://docs.orchardcore.net/en/latest/docs/reference/modules/Liquid/) and [templates in Orchard Core](https://docs.orchardcore.net/en/latest/docs/reference/modules/Templates/) first. Otherwise, please continue below.

We have everything documented here, but if you prefer videos, check out our [DotNest Core tutorials here](https://www.youtube.com/playlist?list=PLuskKJW0FhJebHGSavU5OJugryMPCSKaU).

1. Go to GitHub and fork the [DotNest Core SDK](https://github.com/Lombiq/DotNest-Core-SDK) repository or create an empty repository and push the SDK's `dev` branch to it. For simplicity, we'll refer to your repository as `fork` from now on and assume a simple branching strategy with only one additional branch for development, but your use-case can be more complex.
2. For clarity, rename the solution file to what you prefer, e.g. _AwesomeProject.DotNestSites.sln_.
3. Create a project for your theme, as you'd usually do, with [the Orchard code generation template](https://docs.orchardcore.net/en/latest/docs/getting-started/templates/), manually, or by copying `Sample.Theme` from the SDK. The only thing important is that you'll need to add a NuGet package reference to `Lombiq.Hosting.MediaTheme` to it, and in its `Manifest` should declare `Lombiq.Hosting.MediaTheme.Bridge` as a dependency. See `Sample.Theme` for these.
4. Reference the theme project from the root web project, `DotNest.Core.SDK.Web`.
5. You're now good to continue with developing your theme and deploying it to your DotNest site. Continue with the below sections.

You can see an example of a fork of this project for the website [Letters from Fiume](https://lettersfromfiume.com/), with a Media Theme [here](https://github.com/Piedone/DotNest-Sites). This demonstrates how to have a Media Theme theme project with Liquid templates and CSS, and do local development with an export of the production site, also making use of [Auto Setup](https://docs.orchardcore.net/en/latest/docs/reference/modules/AutoSetup/).

### Automatic sync for your fork with Git-hg Mirror

Optionally, you can set up a mirror on [Git-hg Mirror](https://githgmirror.com) to automatically (and continuously) synchronize every commit from the original repository to your fork. This gives you an easy way to always work with same code base as what is running on DotNest.

- The "Git clone URL" should be `git+https://github.com/Lombiq/DotNest-Core-SDK.git`.
- The "Hg clone URL" (don't worry about "Hg") should be a similar URL pointing to your fork with some authentication details to allow Git-hg Mirror to push to your repository. You can create an access token under [your GitHub settings](https://github.com/settings/tokens) (select full `repo` access) and use it as follows: `git+https://0123456789abcdef0123456789abcdef:x-oauth-basic@github.com/AwesomeDeveloper/Awesome-Project.git`.
- The "Mirroring direction" should be `Git to Hg`.
- You'll just need the default branch, so configure "Git ref selection regex for pushes" as `refs/heads/dev`.
- Make sure that you never commit anything to the branches coming from the original repository, otherwise the synchronization will fail.

**Note** that this project uses [GitHub Actions](https://github.com/features/actions) for automated builds. If you don't need these, and especially if your fork will be auto-updated with Git-hg Mirror (which pushes to your repository multiple times a minute) then you shouldn't enable GitHub Actions for the repository (since then e.g. a build will run on each Git-hg Mirror push).

## Working with the repository 

- Whenever you create any branches, make sure that you prefix their names so they don't collide with the ones in the SDK.
For example, if the project you're working is called `Awesome Project`, then your development branch should be created on top of `dev` and name it e.g. `ap-dev`.
- You might also want to change the default branch of your fork to your development branch.
- In case new commits are pushed to your fork from the original repository, check the changes (e.g. new modules might be added that you also need to add to your custom solution) and merge `dev` to your development branch.

## Theme development

- General Orchard Core theme development rules apply but with [Media Theme practices](https://github.com/Lombiq/Hosting-Media-Theme#local-development) and [Media Theme limitations](https://github.com/Lombiq/Hosting-Media-Theme#limitations). Keep those in mind.
- You can synchronize content from your site running on DotNest by exporting it and then importing it locally. That way, you can maintain a setup recipe locally that you keep up-to-date with the production site's data, even using [Auto Setup](https://docs.orchardcore.net/en/latest/docs/reference/modules/AutoSetup/).
 to set up the site when you run the app. Be sure to not use the recipe locally without some modifications:
    - Remove feature `enable` references for all Azure-related features unless you want to use e.g. Azure Blob Storage locally too.
    - Enable your theme project and set it as the site theme (instead of Media Theme).
- Deploy your theme to your site by following [the corresponding docs of Media Theme](https://github.com/Lombiq/Hosting-Media-Theme/blob/dev/Readme.md#deployment-importexport).

The [`Piedone/DotNest-Sites` project](https://github.com/Piedone/DotNest-Sites) mentioned above also demonstrates all of these.<!-- #spell-check-ignore-line -->

## Help us make it better!

In case you come across an Orchard Core bug during development, don't keep it to yourself: Orchard Core bugs should be reported at [the official Orchard Core GitHub repository](https://github.com/OrchardCMS/OrchardCore).

There is a chance though that the problem you've discovered is already fixed since the latest release and we could add the necessary changes as a hotfix to DotNest (and the DotNest Core SDK) to improve it. You can tell us about it by opening an issue in [the DotNest Core SDK GitHub repository](https://github.com/Lombiq/DotNest-Core-SDK). Thanks!
