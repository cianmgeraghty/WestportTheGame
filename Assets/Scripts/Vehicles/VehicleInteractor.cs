using UnityEngine;
using WestportTheGame.Player;

namespace WestportTheGame.Vehicles
{
    public sealed class VehicleInteractor : MonoBehaviour
    {
        [SerializeField] private float interactionRadius = 2.5f;
        [SerializeField] private Transform seat;
        [SerializeField] private KeyCode interactionKey = KeyCode.E;

        private SimpleCarController car;
        private ThirdPersonWalker walker;
        private CharacterController walkerController;

        private void Awake() => car = GetComponent<SimpleCarController>();

        private void Update()
        {
            if (!Input.GetKeyDown(interactionKey)) return;
            if (car.IsOccupied) ExitVehicle();
            else TryEnterVehicle();
        }

        private void TryEnterVehicle()
        {
            var player = FindObjectOfType<ThirdPersonWalker>();
            if (player == null || Vector3.Distance(player.transform.position, transform.position) > interactionRadius) return;
            walker = player;
            walkerController = player.GetComponent<CharacterController>();
            walkerController.enabled = false;
            player.gameObject.SetActive(false);
            car.IsOccupied = true;
        }

        private void ExitVehicle()
        {
            if (walker == null) return;
            var exitPosition = transform.position + transform.right * 2f;
            walker.transform.position = exitPosition;
            walker.gameObject.SetActive(true);
            walkerController.enabled = true;
            car.IsOccupied = false;
            walker = null;
        }
    }
}
