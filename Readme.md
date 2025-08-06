# DotNest Core SDK

## Overview

The [DotNest Core SDK](https://github.com/Lombiq/DotNest-Core-SDK) is a local development environment for building [Media Themes](https://github.com/Lombiq/Hosting-Media-Theme) to be deployed to [Orchard Core CMS](https://orchardcore.net) sites running on [DotNest](https://dotnest.com), the Orchard Core SaaS. Media Themes are almost full-fledged Orchard themes that you can develop as any Orchard theme, but they'll still work on DotNest.

The base of the source code on the `dev` branch is the same Orchard Core version that is running on DotNest as well as all the hotfixes and mods we've applied to it. On top of that, all the open-source modules are added as NuGet packages, which gives you the ability to develop your theme and run your site locally in an environment quite close to the live DotNest site.

We at [Lombiq](https://lombiq.com/) also used this SDK for the following projects:

- The new [Xero4PowerBI website](https://xero4powerbi.com/) ([see case study](https://dotnest.com/blog/xero4powerbi-website-case-study-migration-to-orchard-core)).
- The new [Ik wil een taart website](https://ikwileentaart.nl/) ([see case study](https://dotnest.com/blog/revamping-ik-wil-een-taart-migrating-an-old-version-of-orchard-core-website-with-custom-theme-and-commerce-logic-to-dotnest)).
- The new [Show Orchard website](https://showorchard.com/) when migrating it from Orchard 1 DotNest to DotNest Core (see [case study](https://dotnest.com/blog/show-orchard-case-study-migrating-an-orchard-1-dotnest-site-to-orchard-core) and the [theme's source code](https://github.com/Lombiq/Show-Orchard-Theme)).
- The [GPU Day website](https://gpuday.com/) ([see case study](https://dotnest.com/blog/gpu-day-case-study-migrating-another-orchard-1-dotnest-site-to-orchard-core-with-smart-compromises-for-quicker-implementation) and the [theme's source code](https://github.com/Lombiq/GPU-Day-Theme)).

This project, along with DotNest, is developed by [Lombiq Technologies Ltd](https://lombiq.com). Commercial-grade support is available through Lombiq.

## Getting started

### Tutorials and examples

Are you unfamiliar with Orchard Core theme development and Liquid templates, or even Orchard Core in general? Then we recommend you check out the [Dojo Course 3 tutorial](https://orcharddojo.net/orchard-training/dojo-course-3-the-full-orchard-core-tutorial) and the official docs [on Liquid](https://docs.orchardcore.net/en/latest/docs/reference/modules/Liquid/) and [templates in Orchard Core](https://docs.orchardcore.net/en/latest/docs/reference/modules/Templates/) first. Otherwise, please continue below.

We have everything documented here, but if you prefer videos, check out our [DotNest Core tutorials here](https://www.youtube.com/playlist?list=PLuskKJW0FhJebHGSavU5OJugryMPCSKaU).

See [an example of a fork of this project](https://github.com/Piedone/DotNest-Sites) for the website [Letters from Fiume](https://lettersfromfiume.com/) including a Media Theme. This demonstrates Media Theme usage with Liquid templates and CSS, and local development with an export of the production site, also making use of [Auto Setup](https://docs.orchardcore.net/en/latest/docs/reference/modules/AutoSetup/).

**Note** that this project uses [GitHub Actions](https://github.com/features/actions) for automated builds. If you don't need these in your fork then you shouldn't enable GitHub Actions for the repository, but we do recommend you utilize them for automated QA.

### Setting up your repository

Fork the [DotNest Core SDK](https://github.com/Lombiq/DotNest-Core-SDK) repository or create an empty repository and push the SDK's `dev` branch to it. For simplicity, we'll refer to your repository as `fork` from now on and assume a simple branching strategy with only one additional branch for development, but your use-case can be more complex.

## Working with the repository

- Whenever you create any branches, make sure to choose names that don't collide with the ones in the SDK. If your project is called e.g. `Awesome Project`, then your development branch should be created on top of `dev` and name it e.g. `dev-ap`.
- We recommend you create such a development branch and set it as the default branch of your fork.
- For clarity, rename the solution file to what you prefer, e.g. _AwesomeProject.DotNestSites.sln_.

## Updating your fork with changes from the SDK

- If your repository is an actual fork, you can use the [`Sync fork` feature](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/working-with-forks/syncing-a-fork) on GitHub to manually update it.
- Regardless of whether your repository is a fork or not, you can also automate updating its `dev` branch from the SDK using our [Mirror branches workflow](https://github.com/Lombiq/GitHub-Actions/blob/dev/Docs/Workflows/Productivity/MirrorBranches.md). A minimal mirror workflow looks like this (you need to update the `destination-repository` parameter and set up a secret for `DESTINATION_TOKEN`):

    ```yaml
    name: Mirror from SDK

    on:
      workflow_dispatch:
      schedule:
        - cron: '0 0 * * *' # Once every day.

    jobs:
      mirror-from-sdk:
        name: Mirror from SDK
        uses: Lombiq/GitHub-Actions/.github/workflows/mirror-branches.yml@dev
        with:
          source-repository: Lombiq/DotNest-Core-SDK
          destination-repository: AwesomeDeveloper/Awesome-Project
          branch-names: dev
        secrets:
          DESTINATION_TOKEN: ${{ secrets.AWESOME_PROJECT_MIRROR_TOKEN }}
    ```

In case new commits are pushed to your fork from the SDK, check the changes (e.g. new modules might be added that you also need to add to your custom solution) and merge `dev` into your development branch.

## Theme development

### Creating the theme

1. Create a project for your theme with [the Orchard code generation template](https://docs.orchardcore.net/en/latest/docs/getting-started/templates/), manually, or by copying `Sample.Theme` from the SDK.
    - Note that you'll need to add a NuGet package reference to `Lombiq.Hosting.MediaTheme` to it, and in its `Manifest` should declare `Lombiq.Hosting.MediaTheme.Bridge` as a dependency. See `Sample.Theme` for these.
2. Reference the theme project from the root web project, `DotNest.Core.SDK.Web`.

### Development tips

- General Orchard Core theme development rules apply, but keep the [Media Theme practices](https://github.com/Lombiq/Hosting-Media-Theme#local-development) and [Media Theme limitations](https://github.com/Lombiq/Hosting-Media-Theme#limitations) in mind.
- You can synchronize content from your site running on DotNest by exporting it and then importing it locally. That way, you can maintain a setup recipe locally that you keep up-to-date with the production site's data, even using [Auto Setup](https://docs.orchardcore.net/en/latest/docs/reference/modules/AutoSetup/) to set up the site when you run the app. Be sure to modify the recipe before running it locally as follows:
  - Remove feature `enable` references for all Azure-related features unless you want to use e.g. Azure Blob Storage locally too.
  - Enable your theme project and set it as the site theme (instead of Media Theme).
- Deploy your theme to your site by following [the corresponding docs of Media Theme](https://github.com/Lombiq/Hosting-Media-Theme/blob/dev/Readme.md#deployment-importexport).

## Samples

- [Sample Theme](https://github.com/Lombiq/DotNest-Core-SDK/tree/dev/src/Themes/Sample.Theme)
- [Show Orchard Theme](https://github.com/Lombiq/Show-Orchard-Theme)
- [GPU Day Theme](https://github.com/Lombiq/GPU-Day-Theme)
- The [`Piedone/DotNest-Sites` project](https://github.com/Piedone/DotNest-Sites)

## Help us make it better

In case you come across an Orchard Core bug during development, don't keep it to yourself: Orchard Core bugs should be reported at [the official Orchard Core GitHub repository](https://github.com/OrchardCMS/OrchardCore).

There is a chance though that the problem you've discovered is already fixed since the latest release and we could add the necessary changes as a hotfix to DotNest (and the DotNest Core SDK) to improve it. You can tell us about it by opening an issue in [the DotNest Core SDK GitHub repository](https://github.com/Lombiq/DotNest-Core-SDK). Thanks!
