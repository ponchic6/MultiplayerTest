using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using Network;
using UnityEngine;

namespace Services
{
    public class ClientService : IClientService
    {
        public event Action<string> OnRecievedMessage;

        private Queue<string> _recievedMessage = new Queue<string>();
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
            
            Debug.Log($"Connected to {_client.Client.RemoteEndPoint}");

            _idOnServer = int.Parse(_streamReader.ReadLine());

            Task.Run(StartListen);
        }

        public void SendPosition(string transformJson)
        {
            _streamWriter.WriteLine(transformJson);
            _streamWriter.Flush();
        }

        private async Task StartListen()
        {
            while (true)
            { 
                _recievedMessage.Enqueue(await _streamReader.ReadLineAsync());
            }
        }

        private void TryInvokeOnRecievedMessage()
        {
            if (_recievedMessage.Count == 0) return;

            while (_recievedMessage.Count != 0)
            {
                string message = _recievedMessage.Dequeue();

                if (message != null)
                {   
                    Debug.Log(DateTime.Now);
                    OnRecievedMessage?.Invoke(message);
                }
            }
        }

        private void DisconnectFromServer()
        {
            _client.Close();
        }
    }
}