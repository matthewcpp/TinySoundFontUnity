#include "tsf_unity.h"

#define TSF_IMPLEMENTATION
#include <tsf.h>

#define EZAUDIO_IMPLEMENTATION
#include "ez_audio.h"

#include <mutex>

struct TsfUnity {
	TsfUnity() {}
	~TsfUnity() {
		if (soundfont)
			tsf_close(soundfont);

		if (audio)
			ez_audio_destroy(audio);
	}

	tsf* soundfont = nullptr;
	ez_audio_session* audio = nullptr;
	std::mutex mutex;
};

static void tsf_unity_audio_callback(void* buffer, uint32_t buffer_size, uint32_t sample_count, void* user_data)
{
	TsfUnity* context = reinterpret_cast<TsfUnity*>(user_data);

	std::lock_guard<std::mutex>(context->mutex);
	tsf_render_float(context->soundfont, reinterpret_cast<float*>(buffer), sample_count, 0);
}

TsfUnity* tsf_unity_create(tsf* tsf)
{
	ez_audio_init();

	TsfUnity* tsf_unity = new TsfUnity();
	tsf_unity->soundfont = tsf;

	tiny_audio_params params;
	ez_audio_init_params(&params);

	params.frequency = 44100;
	params.render_callback = tsf_unity_audio_callback;
	params.user_data = tsf_unity;

	tsf_unity->audio = ez_audio_create(&params);

	tsf_set_output(tsf_unity->soundfont, TSF_STEREO_INTERLEAVED, params.frequency, 0.0f);

	if (ez_audio_start(tsf_unity->audio)) {
		delete tsf_unity;
		return nullptr;
	}

	return tsf_unity;
}

TsfUnity* tsf_unity_load_from_file(const char* filename)
{
	tsf* tsf = tsf_load_filename(filename);

	if (!tsf)
		return nullptr;

	return tsf_unity_create(tsf);
}

TsfUnity* tsf_unity_load_from_memory(uint8_t* data, int32_t size)
{
	tsf* tsf = tsf_load_memory(data, size);

	if (!tsf)
		return nullptr;

	return tsf_unity_create(tsf);
}

void tsf_unity_close(TsfUnity* context)
{
	delete context;
}

int tsf_unity_get_preset_count(const TsfUnity* context)
{
	return tsf_get_presetcount(context->soundfont);
}

const char* tsf_unity_get_preset_name(const TsfUnity* context, int32_t preset)
{
	return tsf_get_presetname(context->soundfont, preset);
}

void tsf_unity_note_on(TsfUnity* context, int32_t preset_index, int32_t key, float vel)
{
	std::lock_guard<std::mutex>(context->mutex);
	tsf_note_on(context->soundfont, preset_index, key, vel);
}

void tsf_unity_note_off(TsfUnity* context, int32_t preset_index, int32_t key)
{
	std::lock_guard<std::mutex>(context->mutex);
	tsf_note_off(context->soundfont, preset_index, key);
}

void tsf_unity_all_notes_off(TsfUnity* context)
{
	tsf_note_off_all(context->soundfont);
}
