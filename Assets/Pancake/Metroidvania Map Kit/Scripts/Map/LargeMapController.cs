namespace PanCake.MetroidVania.Devtools.Map
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class LargeMapController : MonoBehaviour
    {
        [Tooltip("The player that the camera will follow.")]
        [SerializeField]
        private GameObject m_Player;
        [Tooltip("can find the revealer object from this tag")]
        [SerializeField]
        private string m_PlayerTag;
        [Tooltip("The camera that watch the map will be moved.")]
        [SerializeField]
        private Camera m_Camera;
        [SerializeField]
        [Tooltip("The speed of camera moving.")]
        private float m_CameraMoveSpeed = 1f;
        [SerializeField]
        [Tooltip("The speed of camera zooming.")]
        private float m_CameraZoomSpeed = 1f;
        [SerializeField]
        private float m_ZoomInMax = 30f;
        [SerializeField]
        private float m_ZoomOutMax = 150f;
        private Vector2 _moveVector;
        private Vector3 _zoomVector;

        private void Start()
        {
            if (m_Player == null)
            {
                //find player object from tag = Player
                m_Player = GameObject.FindGameObjectWithTag("Player");
            }
        }
        private void OnEnable()
        {
            resetPosition();
        }
        private void Update()
        {
            Zoom();
            Move();
        }

        private void Move()
        {
            //it controls the movement of camera
            if (_moveVector != null && _moveVector != Vector2.zero)
            {
                m_Camera.transform.position += new Vector3(_moveVector.x, _moveVector.y, 0) * m_CameraMoveSpeed;
            }
        }

        private void Zoom()
        {
            //it controls the movement of camera
            if (_zoomVector != null && _zoomVector != Vector3.zero)
            {
                if ((_zoomVector.z > 0 && m_Camera.transform.position.z < -m_ZoomInMax) || (_zoomVector.z < 0 && m_Camera.transform.position.z > -m_ZoomOutMax))
                {
                    m_Camera.transform.position += _zoomVector * m_CameraZoomSpeed;
                }
            }

        }
        public void InputMove(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _moveVector = ctx.ReadValue<Vector2>();
            }
            else
            {
                _moveVector = Vector2.zero;
            }
        }
        public void InputZoomIn(InputAction.CallbackContext ctx)
        {

            if (ctx.performed)
            {
                _zoomVector = new Vector3(0, 0, 1);
            }
            else
            {
                _zoomVector = Vector3.zero;
            }

        }
        public void InputZoomOut(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                //control the map to zoom out
                _zoomVector = new Vector3(0, 0, -1);
            }
            else
            {
                _zoomVector = Vector3.zero;
            }
        }
        public void InputResetPosition(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                resetPosition();
            }
        }
        private void resetPosition()
        {
            if (m_Player == null)
            {
                return;
            }
            //reset the position of camera
            Vector3 vector3 = new Vector3();
            vector3.x = m_Player.transform.position.x;
            vector3.y = m_Player.transform.position.y;
            vector3.z = m_Camera.transform.position.z;
            m_Camera.transform.position = vector3;
        }

    }
}
