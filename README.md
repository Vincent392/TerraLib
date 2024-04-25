# TerraLib
FF9 modloader/script hook, and a limited one too.

### Alright, what can it do?

Terra Lib can do the following:
- Initialize DLL mods
- Initialize Dependencies, and spit out an error if they aren't there.
- Make FF9 easy to mod, even though Memoria exists to allow content modding.
- Memoria integration, IF, the PR to do so gets approved

### What can it not do?

TerraLib **cannot** do the following:

- Initialize ANYTHING to do with cloud save data, it's a hardcoded imposed limitation, any PR to remove it or fork will be *promptly* taken down\*, I don't want to get into trouble with Square Enix.
- Initialize mods ***with*** the same entry function.

\* Excluding **PRIVATE** forks, still, please don't.

### Mod Guidelines

Mods Can be Open or Closed Source, Open Source HIGHLY recommended.
Mods cannot modify or delete, /, C:\, C:\Windows or C:\Windows\System32, since that's just malware as a .DLL
Mods, cannot, currently, double as a separate modloader, since that doesn't make sense
Modders are highly adviced to stay inline with the PEGI 12/ESRB T rating for the game, if so, warn the user beforehand if it's upped the rating.
Do anything not listed here

### Build Instructions
TBA
