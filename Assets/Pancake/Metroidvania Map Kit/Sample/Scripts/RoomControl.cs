namespace PanCake.MetroidVania.Devtools.Map.Sample
{
    using UnityEngine;

    public class RoomControl : MonoBehaviour
    {
        //����2d������ʱ��������Ļ�ռ�
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                transform.gameObject.SetActive(true);
                CameraFollower.instance.activeRoom = transform;
            }
        }
        //ͣ����2d������ʱ��������Ļ�ռ�
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                CameraFollower.instance.activeRoom = transform;
            }
        }

    }
}