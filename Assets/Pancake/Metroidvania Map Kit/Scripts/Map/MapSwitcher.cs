namespace PanCake.MetroidVania.Devtools.Utils
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class MapSwitcher : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_largeMap;
        [SerializeField]
        private GameObject m_miniMap;
        public void InputSwitchMap(InputAction.CallbackContext ctx)
        {
            //switch the map
            if (ctx.performed)
            {
                if (m_largeMap.activeSelf)
                {
                    m_largeMap.SetActive(false);
                    if (m_miniMap != null)
                    {
                        m_miniMap.SetActive(true);
                    }
                    Time.timeScale = 1;
                }
                else
                {
                    m_largeMap.SetActive(true);
                    if (m_miniMap != null)
                    {
                        m_miniMap.SetActive(false);
                    }
                    Time.timeScale = 0;
                }
            }
        }
    }
}
