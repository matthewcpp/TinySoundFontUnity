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


message("Updating dependencies from Conan packages")
configure_file(${CONAN_TINYSOUNDFONT_ROOT}/include/tsf.h ${CMAKE_CURRENT_SOURCE_DIR}/tsf.h COPYONLY)
configure_file(${CONAN_EZAUDIO_ROOT}/include/ezaudio/ezaudio.h ${CMAKE_CURRENT_SOURCE_DIR}/ezaudio.h COPYONLY)

if (NOT IOS)
	add_library(tsf_unity SHARED tsf_unity.h tsf_unity.cpp tsf.h ezaudio.h)

	target_link_libraries(tsf_unity PRIVATE ${platform_libs})
	target_compile_definitions(tsf_unity PRIVATE -DBUILD_TSF_UNITY)
	set_target_properties(tsf_unity PROPERTIES  CXX_STANDARD 11 CXX_STANDARD_REQUIRED ON)

	add_executable(tsf_unity_test test~/tsf_unity_test.cpp)
	target_include_directories(tsf_unity_test PRIVATE ${CMAKE_CURRENT_SOURCE_DIR})
	target_link_libraries(tsf_unity_test tsf_unity)
	target_compile_definitions(tsf_unity_test PRIVATE SOUNDFONT_PATH=${CMAKE_CURRENT_SOURCE_DIR}/../../Sample/Resources/TinySoundFontUnity/florestan-subset.sf2.bytes)
endif()



