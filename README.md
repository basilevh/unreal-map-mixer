# unreal-map-mixer
Combines multiple Unreal Tournament levels into a fun mash-up using T3D files.
Only UT99 maps have been tested so far; I will look into other versions at a later time. Normally it _should_ work for Unreal, UT99, UT2003 and UT2004, see [this Unreal Wiki link](https://wiki.beyondunreal.com/Legacy:T3D_File) for more information.

## General usage
1. Open several maps you want to mix in Unreal Editor, and export them as T3D files.
2. Open Unreal Tournament Map Mixer and create your mix.
3. Import the generated T3D file **in the same Unreal Editor instance**, do a few modifications (such as checking for trapped PlayerStarts, adding level & zone information etc.) and save as a normal map file. It is important that you leave Unreal Editor running after exporting the source maps, because the textures might not load correctly otherwise.

## Example


## Known issues
* The mixing intelligence is rather minimal: most features are still WIP and thus disabled for now.
* Not all geometrical features are detected and processed yet, so the 'Remove trapped PlayerStarts' option might sometimes slip.
* ZoneInfos and Portals are not copied by default (to prevent bugs and zone leaking), so manual adjustments are definitely recommended.
* The mixed map might contain a lot of disjunct and unreachable rooms, especially if the brush copy probabilities are set too low. Setting all values to 100% is also worth trying (making it more of a superposition rather than a mix), although this is not recommended if you have many source maps.

## Future
My goal is to make the mixed maps as amusing and playable as possible. Some sort of geometrical intelligence is required, in a first instance to e.g. detect and remove trapped actors. More advanced features will include automatically resolving disjunct rooms by connecting them, or handling zones and portals to ensure they stay bug-free.

As an optional feature, mixing textures and actors also sounds like fun!



Enjoy!
