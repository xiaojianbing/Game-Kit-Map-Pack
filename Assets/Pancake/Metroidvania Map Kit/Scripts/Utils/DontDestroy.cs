namespace PanCake.MetroidVania.Devtools.Utils
{
    using System.Collections.Generic;
    using UnityEngine;

    public class DontDestroy : MonoBehaviour
    {
        //singlton 
        public static DontDestroy instance;
        private static List<GameObject> objects = new List<GameObject>();
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                objects.Add(gameObject);
            }
            else
            {
                foreach (var obj in objects)
                {
                    if (obj.name == gameObject.name && obj != gameObject)
                    {
                        Destroy(gameObject);
                        return;
                    }
                }
                objects.Add(gameObject);
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
