using UnityEngine;

namespace WestportTheGame.Player
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class ThirdPersonWalker : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float walkSpeed = 3.5f;
        [SerializeField] private float runSpeed = 6f;
        [SerializeField] private float turnSmoothTime = 0.1f;
        [SerializeField] private float gravity = -20f;

        private CharacterController controller;
        private float turnSmoothVelocity;
        private float verticalVelocity;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            if (cameraTransform == null && Camera.main != null) cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            if (cameraTransform == null && Camera.main != null) cameraTransform = Camera.main.transform;
            var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            var direction = new Vector3(input.x, 0f, input.y);
            if (direction.sqrMagnitude > 1f) direction.Normalize();

            if (direction.sqrMagnitude > 0.001f)
            {
                var cameraForward = cameraTransform == null ? Vector3.forward : cameraTransform.forward;
                var cameraRight = cameraTransform == null ? Vector3.right : cameraTransform.right;
                cameraForward.y = cameraRight.y = 0f;
                var move = (cameraForward.normalized * direction.z + cameraRight.normalized * direction.x).normalized;
                var targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
                var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                var speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
                controller.Move(move * speed * Time.deltaTime);
            }

            if (controller.isGrounded && verticalVelocity < 0f) verticalVelocity = -2f;
            verticalVelocity += gravity * Time.deltaTime;
            controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
        }
    }
}
