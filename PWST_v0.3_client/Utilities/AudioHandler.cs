using NAudio.Wave;
using System;

namespace PWST_v0._3_client.Utilities {
    public class AudioHandler {
        private string audioFilePath;

        public AudioHandler(string audioFilePath) {
            this.audioFilePath = audioFilePath;            
        }


        


        public void RecordAudio() {

            // WARNING: HALT

            // Build it using example https://www.youtube.com/watch?v=6y9sAtPtTac&list=PLrqwM2iFaguiHMxomYvX01EJk82fuD8g_&index=4
            // https://github.com/naudio/NAudio/blob/master/NAudio.Core/Wave/WaveOutputs/WaveFileWriter.cs

            string fileToWrite = null;
            fileToWrite += ".wav";



            WaveFormat waveFormat = new WaveFormat(44100, 1);


            WaveFileWriter waveFileWriter = new WaveFileWriter(fileToWrite, waveFormat);
            WaveInEvent waveIn = new WaveInEvent();

            waveIn.WaveFormat = waveFormat;

            waveIn.DataAvailable += (s, e) => {

                waveFileWriter.Write(e.Buffer, 0, e.BytesRecorded);

            };


            waveIn.StartRecording();

            Console.WriteLine("Press any key to stop recording.");
            Console.ReadKey();
            waveIn.StopRecording();

            waveIn.Dispose();



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
