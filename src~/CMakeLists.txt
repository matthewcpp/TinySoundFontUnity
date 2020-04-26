cmake_minimum_required(VERSION 3.0)

project(tsf_unity)

include(${CMAKE_BINARY_DIR}/conan_paths.cmake)
find_package(TinySoundFont REQUIRED)


add_library(tsf_unity SHARED tsf_unity.h tsf_unity.cpp ez_audio.h)

source_group(SDL FILES ${SDL_COMMON_SRC})

target_compile_definitions(tsf_unity PRIVATE -DBUILD_TSF_UNITY)
target_link_libraries(tsf_unity PRIVATE TinySoundFont::TinySoundFont)
target_include_directories(tsf_unity PRIVATE ${sdl_dir}/include ${sdl_dir}/src)

if (WIN32)
    target_link_libraries(tsf_unity PRIVATE setupapi.lib winmm.lib imm32.lib version.lib)
endif()

add_executable(tsf_unity_test tsf_unity_test.cpp)
target_link_libraries(tsf_unity_test tsf_unity)
