# Readme before adding workflows

When adding a new workflow or even a new job to an existing workflow, make sure that it'll only run in the original DotNest Core SDK repository. You can do this by adding the same check as in the existing workflows:

```yaml
# Don't run (by default) in fork repositories.
if: github.repository == 'Lombiq/DotNest-Core-SDK'
```
