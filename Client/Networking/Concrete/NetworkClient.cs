using System.Windows.Forms;
using System;

using NAudio.Wave;
using WebSocketSharp;

namespace Client.Networking.Concrete {
    public class NetworkClient {

        // Properties

        private WaveInEvent _waveInEvent;
        private WaveOutEvent _waveOutEvent;
        private BufferedWaveProvider _bufferedWaveProvider;

        private bool _isUnmuted;
        private bool _flipFlop;

        private WebSocket _webSocket;
        private int _bytesRecorded = 0;

        public double dB { get; private set; }

        // Constructors

        public NetworkClient() {
            _flipFlop = false;
            _isUnmuted = false;
        }

        // Public Methods

        public bool FlipFlopUnmute() {
            _flipFlop = !_flipFlop;

            if (_flipFlop) {
                Unmute();
            }
            else {
                Mute();
            }

            return _flipFlop;
        }

        public void ClientConnect(string address) {


            _webSocket = new WebSocket("ws://" + address + "/audio");


            _webSocket.Connect();

            _webSocket.OnMessage += (s, e) => {
                byte[] recievedAudioData = e.RawData;
                _bufferedWaveProvider.AddSamples(recievedAudioData, 0, recievedAudioData.Length);
            };

        }


        // Private Methods

        private void Unmute() {
            if (!_isUnmuted) {
                try {
                    _isUnmuted = true;
                    InitializeWaveIn();
                    InitializeWaveOut();


                    _waveInEvent.StartRecording();
                    _waveOutEvent.Play();

                }
                catch (Exception ex) {
                    MessageBox.Show("Error starting recording: " + ex.Message);
                    _isUnmuted = false;
                }
            }
        }

        private void Mute() {
            if (_isUnmuted) {
                _waveInEvent.StopRecording();
                _waveOutEvent.Stop();
                _isUnmuted = false;
            }

        }

        private void InitializeWaveIn() {
            _waveInEvent = new WaveInEvent();
            _waveInEvent.WaveFormat = new WaveFormat(44100, 16, 1); // Adjust format as needed
            _waveInEvent.BufferMilliseconds = 20;
            _waveInEvent.DataAvailable += OnWaveDataAvailable;
        }

        private void InitializeWaveOut() {
            _bufferedWaveProvider = new BufferedWaveProvider(_waveInEvent.WaveFormat);
            _waveOutEvent = new WaveOutEvent();
            _waveOutEvent.Init(_bufferedWaveProvider);
            _waveOutEvent.Play();
        }

        private double Calculate_dB(byte[] buffer, int bytesRead) {
            float sum = 0, rms = 0;
            for (int i = 0; i < bytesRead; i += 2) {
                short sample = BitConverter.ToInt16(buffer, i);
                sum += sample * sample;
            }

            rms = (float)Math.Sqrt(sum / bytesRead);

            double outdB = 0;
            outdB = 20.0 * Math.Log10((double)rms);

            return outdB;
        }

        // Event Handlers

        private void OnWaveDataAvailable(object sender, WaveInEventArgs e) {
            byte[] buffer = e.Buffer;
            _bytesRecorded = e.BytesRecorded;


            _webSocket.Send(buffer);

            dB = Calculate_dB(buffer, _bytesRecorded);
        }

    }
}
