# Camera Viewport Rect
Automatically setup `Camera` viewports from `RectTransform`s.

This way one can easily show 3D models directly into responsive UI without the need of setting up `RenderTexture`s.

![Demonstration of the CameraViewportRect script](Extras~/demo.gif)


## Features
- Supports canvases in both `Screen Space - Overlay` and `Screen Space - Camera` modes
- Supports enabling/disabling the target Camera when the script itself gets enabled/disabled


## How to install
Either:

- Install via [Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui-giturl.html)
using the following URL:

```
https://github.com/gilzoide/unity-camera-viewport-rect.git
```
- Copy the script [CameraViewportRect.cs](Runtime/CameraViewportRect.cs) directly into your project


## Samples
This UPM package has the following sample scene:
- [RotatingCube](Samples~/RotatingCube/RotatingCubeSample.unity): Simple sample with a rotating cube that appears on a responsive UI