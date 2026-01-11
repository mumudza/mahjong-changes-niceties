# Files

## Diffs

These show the code changes in existing code.

- standard_shader_diff
- unitystandardcore_shader_diff
- unitystandardcoreforward_shader_diff
- mahjong_diff (Changes in Mahjong.cs)

## Textures

These are new files not included in the prefab. They are necessary to properly show the numbered tiles without having the numbers seem as if they're "sinking" together with the tile carving.

- tiles_height 1numbered.png
- tiles_normal_numbered.png

## Source code

These are files that don't risk making me run into copyright issues. Adjust the button/text objects as needed. As you might not want to use TMP either way. The core logic should be clear.

- UnityStandardCore.cginc/UnityStandardCoreNoMirror.cginc: Standard Unity core shader + my own derivative 
- UnityStandardCoreForward.cginc/UnityStandardCoreForwardNoMirror.cginc: Standard Unity core forward shader + my own derivative
- UdonTileBackColor.cs: Switches tile's back material color.
- UdonToggleDoraHighlight.cs: Just enables and disables the empty object tracking the dora highlight toggle feature.
- UdonToggleTileMaterials.cs: Switches material of tile's front. Can be adjusted to handle several textures/materials.

Both UdonTileBackColor and UdonToggleTileMaterials expect to be provided with all of the TilesSet gameObjects in the scene
