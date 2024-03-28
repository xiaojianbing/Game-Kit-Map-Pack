namespace PanCake.MetroidVania.Devtools.Map.Sample
{
    using UnityEngine;

    public class CameraFollower : MonoBehaviour
    {
        public Camera mainCamera;
        public Transform activeRoom;
        public float moveSpeed = 0.1f;
        public static CameraFollower instance;
        [Range(-20, 20)]
        public float xMin = 9.5f, xMax = -8.5f, yMin = 6f, yMax = -0.9f;
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        private void Start()
        {
            //mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
        }
        void FixedUpdate()
        {
            if (activeRoom == null)
            {
                return;
            }
            var minPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.min.x;
            var maxPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.max.x;
            var minPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.min.y;
            var maxPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.max.y;
            //设置摄像机的x轴位置
            //Debug.Log("player.x:"+player.position.x+";minPosX:" + (minPosX+xMin) + ";maxPosX:" + (maxPosX+xMax) );
            float x = Mathf.Clamp(transform.position.x, minPosX + xMin, maxPosX + xMax);
            //设置摄像机的y轴位置
            //Debug.Log("player.y:" + player.position.y + ";minPosY:" + (minPosY + yMin) + ";maxPosY:" + (maxPosY + yMax));
            float y = Mathf.Clamp(transform.position.y, minPosY + yMin, maxPosY + yMax);
            //Debug.Log("camera.x:" + x + ";camera.y:" + y);

            Vector3 smoothPos = Vector3.Lerp(mainCamera.transform.position, new Vector3(x, y, mainCamera.transform.position.z), moveSpeed);
            //相机的位置設置為玩家的位置
            mainCamera.transform.position = smoothPos;
        }
    }
}