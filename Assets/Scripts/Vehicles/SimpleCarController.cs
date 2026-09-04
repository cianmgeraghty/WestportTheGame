using UnityEngine;

namespace WestportTheGame.Vehicles
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class SimpleCarController : MonoBehaviour
    {
        [SerializeField] private float acceleration = 18f;
        [SerializeField] private float maxSpeed = 18f;
        [SerializeField] private float steeringDegreesPerSecond = 90f;
        [SerializeField] private float braking = 8f;

        public bool IsOccupied { get; set; }
        private Rigidbody body;

        private void Awake() => body = GetComponent<Rigidbody>();

        private void FixedUpdate()
        {
            if (!IsOccupied) return;
            var throttle = Input.GetAxis("Vertical");
            var steering = Input.GetAxis("Horizontal");
            if (Mathf.Abs(throttle) > 0.01f && body.velocity.magnitude < maxSpeed)
                body.AddForce(transform.forward * (throttle * acceleration), ForceMode.Acceleration);
            else if (Mathf.Abs(throttle) < 0.01f)
                body.velocity = Vector3.Lerp(body.velocity, Vector3.zero, braking * Time.fixedDeltaTime);

            var speedFactor = Mathf.Clamp01(body.velocity.magnitude / 3f);
            transform.Rotate(0f, steering * steeringDegreesPerSecond * speedFactor * Time.fixedDeltaTime, 0f);
        }
    }
}
