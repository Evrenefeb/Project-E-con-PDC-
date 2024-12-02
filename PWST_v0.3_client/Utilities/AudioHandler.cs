using NAudio.Wave;
using System;

namespace PWST_v0._3_client.Utilities {
    public class AudioHandler {
        private string audioFilePath;

        public AudioHandler(string audioFilePath) {
            this.audioFilePath = audioFilePath;            
        }

        public void RecordAudio() {

            // Build it using example https://www.youtube.com/watch?v=6y9sAtPtTac&list=PLrqwM2iFaguiHMxomYvX01EJk82fuD8g_&index=4
            // https://github.com/naudio/NAudio/blob/master/NAudio.Core/Wave/WaveOutputs/WaveFileWriter.cs

            string fileToWrite = null;

            WaveFileWriter waveFileWriter = new WaveFileWriter(fileToWrite, new WaveFormat(44100,1));
            WaveInEvent inEvent = new WaveInEvent();
            inEvent.StartRecording();

            Console.ReadKey();
            inEvent.StopRecording();

            inEvent.Dispose();



        }


        public void PlayAudio() {
            using (var audioFileReader = new AudioFileReader(audioFilePath)) {
                using (var outputDevice = new WaveOutEvent()) {
                    outputDevice.Init(audioFileReader);
                    outputDevice.Play();
                }
            }
        }

    }
}
