# TinySoundFontUnity

This Unity Plugin allows the use of Soundfonts in unity via the [TinySoundFont](https://github.com/schellingb/TinySoundFont) Library.
Audio Rendering is done natively to avoid latency introduced by using Audio Clip in streaming mode.
Audio writing is facilitated by the [ezaudio](https://github.com/matthewcpp/ezaudio) library.

## Updating the Native Plugin

Building the native code can be done easily with [conan](https://conan.io/) and [cmake](https://cmake.org/)

### Configure
Add the matthewcpp conan remote:
```
conan remote add matthewcpp https://api.bintray.com/conan/matthewcpp/conan
```

### Building
Note: 
* When building for IOS you should append `-DIOS` to your CMake invocation.
* If you are building for 32 bit systems omit the `-A x64` argument to the cmake invocation.

run the following commands in your terminal:
```
cd /path/to/Assets/TinySoundFontUnity/Plugins/src
mkdir build~ && cd build~
conan install ..
cmake .. -A x64
 cmake --build . --config Release --target tsf_unity_test
```

You can then run the `tsf_unity_test` application to ensure the library is working correctly on your platform.
Finally copy the plugin into the correct folder.  
Note that for macos you will need to drop the `.dylib` extension and place in the `Plugins/MacOS/tsf_unity.bundle/Contents/MacOs` folder.