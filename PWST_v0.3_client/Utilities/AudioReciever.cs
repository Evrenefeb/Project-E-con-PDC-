using NAudio.Wave;
using System;
using System.IO;
using WebSocketSharp;

namespace PWST_v0._3_client.Utilities {
    internal class AudioReciever {
        private WaveOut waveOut;
        private WebSocket webSocket;

        public void StartListening(WebSocket openWebSocket) {
            webSocket = openWebSocket;  
            waveOut = new WaveOut();

            webSocket.OnMessage += OnAudioRecieved;
            webSocket.Connect();

        }

        private void OnAudioRecieved(object sender, MessageEventArgs e) {

            byte[] audioBuffer = Convert.FromBase64String(e.Data);

            using (var memoryStream = new MemoryStream(audioBuffer)) {
                using (var rawSourceWaveSream = new RawSourceWaveStream(memoryStream, new WaveFormat(44100, 16, 2) ) ) {
                    waveOut.Init(rawSourceWaveSream);
                    waveOut.Play();
                }
            }
        }
    }
}
