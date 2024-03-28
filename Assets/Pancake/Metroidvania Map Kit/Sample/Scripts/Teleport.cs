namespace PanCake.MetroidVania.Devtools.Map.Sample
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Teleport : MonoBehaviour
    {
        public string toScene;
        public string fromPassword;
        public string toPassword;
        public bool canTeleport = true;
        public bool remainX = false;
        public bool remainY = false;
        private PlayerStatus player;
        // Start is called before the first frame update
        void Start()
        {
            //获取角色脚本
            player = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
            if (player.ScenePassword == fromPassword)
            {
                Vector2 pos = new Vector2(transform.position.x, transform.position.y);
                if (remainX)
                {
                    pos.x = player.transform.position.x;
                }
                if (remainY)
                {
                    pos.y = player.transform.position.y;
                }
                player.transform.position = pos;
                canTeleport = false;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player" && canTeleport)
            {
                SceneManager.LoadScene(toScene);
                player.ScenePassword = toPassword;
                //player.transform.position = transform.position;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                canTeleport = true;
            }
        }
    }
}