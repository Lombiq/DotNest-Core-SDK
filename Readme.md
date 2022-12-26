# DotNest Core SDK

## Overview

[DotNest Core SDK](https://github.com/Lombiq/DotNest-Core-SDK) is a local developer environment for building Media Themes to be deployed on sites running on [DotNest](http://dotnest.com).
The base of the source code on the `dev` branch is the same Orchard Core version that is running on DotNest as well as all the hotfixes and mods we've applied to it.
On top of that, all the open-source modules are added as NuGet packages, which gives you the ability to develop your theme and run your site locally in an environment quite close to the live DotNest site.

This project (along with [DotNest](https://dotnest.com), the [Orchard Core CMS](http://orchardcore.net) SaaS) is developed by [Lombiq Technologies Ltd](https://lombiq.com). Commercial-grade support is available through Lombiq.

## Getting started

- Go to GitHub and fork the [DotNest Core SDK](https://github.com/Lombiq/DotNest-Core-SDK) repository or create an empty repository. 
For simplicity, we'll refer to your repository as `fork` from now on and assume a simple branching strategy with only one additional branch for development, but your use-case might be more complex.
- Set up a mirror on [Git-Hg Mirror](https://githgmirror.com) to automatically (and continuously) synchronize every commit from the original repository to your fork.
This gives you an easy way to always work with same code base as what is running on DotNest.
  - The `Git clone URL` should be `git+https://github.com/Lombiq/DotNest-Core-SDK.git`.
  - The `Hg clone URL` (don't worry about `Hg`) should be a similar URL pointing to your fork with some authentication details to allow Git-Hg Mirror to push to your repository.
  You can create an access token under [your GitHub settings](https://github.com/settings/tokens) (select full `repo` access) and use it as follows: `git+https://0123456789abcdef0123456789abcdef:x-oauth-basic@github.com/AwesomeDeveloper/Awesome-Project.git`.
  - The `Mirroring direction` should be `Git to Hg`.
  - Make sure that you never commit anything on the branches coming from the original repository, otherwise the synchronization will fail.

## Working with the repository 

- Whenever you create any branches, make sure that you prefix their names so they don't collide with the ones in the SDK.
For example, if the project you're working is called `Awesome Project`, then your development branch should be created on top of `dev` and name it e.g. `ap-dev`.
- You might also want to change the default branch of your fork to your development branch.
- In case new commits are pushed to your fork from the original repository, check the changes (e.g. new modules might be added that you also need to add to your custom solution) and merge `dev` to your development branch.

## Theme development

- Create a custom solution file on your prefixed development branch as a copy of `DotNest.Core.SDK.sln`, e.g. `AwesomeProject.sln`.
- From here on, general Orchard Core theme development rules apply with some DotNest-related extras. You can read about all these on the [`Theming a DotNest site` page of the DotNest Knowledge Base](https://dotnest.com/knowledge-base/topics/theming/).
- If your theme contains Liquid templates, enable the `Liquid` feature for these to be picked up by Orchard Core.
- The Media Theme on DotNest also has an automated mechanism to include some site-level resources. This might come in handy e.g. if your theme doesn't have a base theme and/or you're not overriding the `Document` or `Layout` shapes.
- You can synchronize content from your site running on DotNest by exporting it and then importing it locally.


## Help us make it better!

In case you come across an Orchard Core bug during development, don't keep it to yourself: Orchard Core bugs should be reported at [the official Orchard Core GitHub repository](https://github.com/OrchardCMS/OrchardCore).
There is a chance though that the problem you've discovered is already fixed since the latest release and we could add the necessary changes as a hotfix to DotNest (and the DotNest Core SDK) to improve it.
You can tell us about it by opening an issue at [the DotNest Core SDK GitHub repository](https://github.com/Lombiq/DotNest-Core-SDK). Thanks!
