using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Services
{
    public class ClientService : IClientService
    {
        public event Action<string> OnRecievedMessage;

        [CanBeNull] private string _recievedMessage;
        private TcpClient _client;
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;
        private int _idOnServer;
        
        private readonly ITickService _tickService;
        private readonly IFinishGameService _finishGameService;

        public ClientService(ITickService tickService, IFinishGameService finishGameService)
        {
            _tickService = tickService;
            _tickService.OnTick += TryInvokeOnRecievedMessage;
            
            _finishGameService = finishGameService;
            _finishGameService.OnFinishGame += DisconnectFromServer;
        }

        public void ConnectToServer()
        {
            _client = new TcpClient("192.168.1.121", 5555);
            _streamWriter = new StreamWriter(_client.GetStream());
            _streamReader = new StreamReader(_client.GetStream());
            
            Debug.Log("Connected to server...");

            _idOnServer = int.Parse(_streamReader.ReadLine());

            Task.Run(StartListen);
        }

        private void DisconnectFromServer()
        {
            _client.Close();
        }

        public void SendPosition(Vector3 transformPosition)
        {
            string stringPosition = transformPosition.x + ", " +
                                    transformPosition.y + ", " + transformPosition.z; 
            _streamWriter.WriteLine(stringPosition);
            _streamWriter.Flush();
        }

        private async Task StartListen()
        {
            while (true)
            {
                _recievedMessage = await _streamReader.ReadLineAsync();
            }
        }

        private void TryInvokeOnRecievedMessage()
        {
            if (_recievedMessage == null) return;
            
            OnRecievedMessage?.Invoke(_recievedMessage);
            _recievedMessage = null;
        }
    }
}