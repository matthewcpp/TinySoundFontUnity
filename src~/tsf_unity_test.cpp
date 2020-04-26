#include "tsf_unity.h"

#include <iostream>
#include <thread>
#include <random>
#include <array>

int main(int argc, char** argv) {

	if (argc < 2) {
		std::cout << "Usage: ./tsf_unity_test /path/to/soundfont.sf2" << std::endl;
		return 1;
	}

	std::random_device rd;
	std::mt19937 gen(rd());

	for (int i = 0; i < 5; i++)
	{
		TsfUnity* tsf_unity = tsf_unity_load_from_file(argv[1]);

		if (!tsf_unity) {
			std::cout << "Failed to load: " << argv[1] << std::endl;
			return 1;
		}

		const int preset_count = tsf_unity_get_preset_count(tsf_unity);
		std::uniform_int_distribution<> dis(1, preset_count - 1);
		const int random_preset_index = dis(gen);

		std::cout << "Sampling random preset: " << tsf_unity_get_preset_name(tsf_unity, random_preset_index) << std::endl;

		const uint32_t middle_c = 60;

		tsf_unity_note_on(tsf_unity, random_preset_index, middle_c, 1.0f);
		std::this_thread::sleep_for(std::chrono::milliseconds(500));
		tsf_unity_note_off(tsf_unity, random_preset_index, middle_c);

		tsf_unity_close(tsf_unity);
	}

	return 0;
}