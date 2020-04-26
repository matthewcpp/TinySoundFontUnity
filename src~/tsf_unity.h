#pragma once

#include <cstdint>

#ifdef _WIN32
#ifdef BUILD_TSF_UNITY
	#define TSF_UNITY_API  __declspec (dllexport)
#else
	#define TSF_UNITY_API  __declspec (dllimport)
#endif
#else
#define TSF_UNITY_API 
#endif

typedef struct TsfUnity TsfUnity;

#ifdef __cplusplus
extern "C" {
#endif

	TSF_UNITY_API TsfUnity* tsf_unity_load_from_file(const char* filename);
	TSF_UNITY_API TsfUnity* tsf_unity_load_from_memory(uint8_t* data, int32_t size);
	TSF_UNITY_API void tsf_unity_close(TsfUnity* context);
	TSF_UNITY_API int tsf_unity_get_preset_count(const TsfUnity* context);
	TSF_UNITY_API const char* tsf_unity_get_preset_name(const TsfUnity* context, int32_t preset);
	TSF_UNITY_API void tsf_unity_note_on(TsfUnity* context, int32_t preset_index, int32_t key, float vel);
	TSF_UNITY_API void tsf_unity_note_off(TsfUnity* context, int32_t preset_index, int32_t key);
	TSF_UNITY_API void tsf_unity_all_notes_off(TsfUnity* context);

#ifdef __cplusplus
}
#endif
