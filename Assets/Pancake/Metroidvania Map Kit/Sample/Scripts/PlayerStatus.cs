namespace PanCake.MetroidVania.Devtools.Map.Sample
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerStatus : MonoBehaviour
    {
        private string scenePassword;
        //scenePassword的Set和Get方法
        public string ScenePassword
        {
            get
            {
                return scenePassword;
            }
            set
            {
                scenePassword = value;
            }
        }

    }
}