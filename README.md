# Translator

A mod for [Mycopunk](https://store.steampowered.com/app/3247750/Mycopunk/) that translates alien language in weapon upgrade names and description. This is a fork of [https://github.com/funlennysub/Translator](https://github.com/funlennysub/Translator) but refactored to support Linux builds and installations. This means using `mono` references intead of `Il2Cpp` but that might also be a consequence of recent game updates, I honestly wasn't paying too much attention.

## Pre-req's

- [dotnet 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- MycoPunk. Obviously.
- Possibly something else. But it's late now.

## Installation steps

1. Install MelonLoader 0.7.1 into Mycopunk
   - [https://melonwiki.xyz/#/?id=requirements](https://melonwiki.xyz/#/?id=requirements)
2. Run `configure.sh`
   - This looks for Mycopunk in your Steam Libraries by scanning `$HOME/.steam/root/steamapps/libraryfolders.vdf`
3. Run `dotnet restore` and `dotnet build`
   - This will automatically copy the `Translator.dll` file to your `../MycoPunk/Mods` directory.

## Troubleshooting

- "Could not load...": Did you run `configure.sh`? Check that the path generated in `Directory.Build.props` points to your MycoPunk installation path.
