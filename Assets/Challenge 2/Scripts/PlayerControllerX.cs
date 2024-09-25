using UnityEngine;

namespace Challenge_2.Scripts
{
    public class PlayerControllerX : MonoBehaviour
    {
        [SerializeField] private GameObject dogPrefab;

        private bool _canSpawn;
        
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space) || !_canSpawn) return;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            _canSpawn = false;
        }

        public void SetSpawnStatus(bool newStatus) => _canSpawn = newStatus;
    }
}
