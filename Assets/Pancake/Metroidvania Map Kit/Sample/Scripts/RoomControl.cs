namespace PanCake.MetroidVania.Devtools.Map.Sample
{
    using UnityEngine;

    public class RoomControl : MonoBehaviour
    {
        //进入2d触发器时，摄像机的活动空间
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                transform.gameObject.SetActive(true);
                CameraFollower.instance.activeRoom = transform;
            }
        }
        //停留在2d触发器时，摄像机的活动空间
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                CameraFollower.instance.activeRoom = transform;
            }
        }

    }
}