namespace PanCake.MetroidVania.Devtools.Map.Sample
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerController : MonoBehaviour
    {
        private Vector2 moveVector;
        private Rigidbody2D rb;
        public float speed = 7f;
        private float jumpForce = 16f;

        private void Start()
        {
            //initial the rigidbody
            rb = GetComponent<Rigidbody2D>();
        }
        // Start is called before the first frame update
        private void FixedUpdate()
        {
            if ((moveVector != null || moveVector != Vector2.zero))
            {
                rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
                FlipCharacter(moveVector.x);
            }
        }

        private void FlipCharacter(float x)
        {
            if (x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        // move method for InputAction
        public void Move(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                moveVector = context.ReadValue<Vector2>();
            }
            if (context.canceled)
            {
                moveVector = Vector2.zero;
            }
        }
        //jump method for InputAction
        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
}