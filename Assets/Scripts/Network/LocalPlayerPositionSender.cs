using Newtonsoft.Json;
using Services;
using UnityEngine;
using Zenject;

namespace Network
{
    public class LocalPlayerPositionSender : MonoBehaviour
    {
        private IClientService _clientService;
    
        [Inject]
        public void Constructor(IClientService clientService)
        {
            _clientService = clientService;
        }

        private void FixedUpdate()
        {       
            TransformProperties transformProperties =
                new TransformProperties(transform.position, transform.rotation);
            
            string transformJson = JsonUtility.ToJson(transformProperties);
            
            _clientService.SendPosition(transformJson);
        }
    }
}
