using NAudio.Wave;
using System;
using WebSocketSharp;

namespace PWST_v0._3_client.Utilities {
    internal class AudioTransmitter {
        private WaveInEvent waveIn;
        private WebSocket webSocket;

        public void StartTransmisson(WebSocket openWebSocket) {
            webSocket = openWebSocket;

            waveIn = new WaveInEvent();
            waveIn.WaveFormat = new WaveFormat(44100, 16, 2);
            waveIn.BufferMilliseconds = 50;

            waveIn.DataAvailable += OnWaveInDataAvailable;
            waveIn.StartRecording();


        }

        private void OnWaveInDataAvailable(object sender, WaveInEventArgs e) {
            string audioData = Convert.ToBase64String(e.Buffer);

            webSocket.Send(audioData);
        }
    }
}
