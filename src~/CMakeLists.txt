cmake_minimum_required(VERSION 3.0)

project(tsf_unity)

include(${CMAKE_BINARY_DIR}/conan_paths.cmake)
find_package(TinySoundFont REQUIRED)
find_package(ezaudio REQUIRED)

if (${CMAKE_SYSTEM_NAME} MATCHES "Darwin")
    set(MACOS TRUE)
endif()

if (WIN32)
    set(platform_libs setupapi.lib winmm.lib imm32.lib version.lib)
elseif(MACOS)
    set(platform_libs "-framework AudioToolbox")
endif()

add_library(tsf_unity SHARED tsf_unity.h tsf_unity.cpp)

target_link_libraries(tsf_unity PRIVATE TinySoundFont::TinySoundFont ezaudio::ezaudio ${platform_libs})
target_include_directories(tsf_unity PRIVATE ${sdl_dir}/include )
target_compile_definitions(tsf_unity PRIVATE -DBUILD_TSF_UNITY)
set_target_properties(tsf_unity PROPERTIES  CXX_STANDARD 11 CXX_STANDARD_REQUIRED ON)

add_executable(tsf_unity_test tsf_unity_test.cpp)
target_link_libraries(tsf_unity_test tsf_unity)
