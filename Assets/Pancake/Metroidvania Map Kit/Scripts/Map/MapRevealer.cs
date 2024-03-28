namespace PanCake.MetroidVania.Devtools.Map
{
    using System;
    using UnityEngine;
    using UnityEngine.Tilemaps;

    public class MapRevealer : MonoBehaviour
    {
        [Tooltip("The Grid which the tilemap is in ")]
        [SerializeField] private Grid m_Grid;
        [Tooltip("The object that will reveal the tiles.")]
        [SerializeField] private GameObject m_RevealerObject;
        [Tooltip("The tag of the object that will reveal the tiles.")]
        [SerializeField] private string m_ReavealerTag;
        [Tooltip("The distance from the revealer that tiles will be revealed.")]
        [SerializeField] private int m_RevealDistance = 18;
        [Tooltip("Does it transparent the tilemap")]
        [SerializeField] private bool m_Transparent = true;
        //if _transparent is true,_transparent_distance will be used
        [Tooltip("The distance from the revealer that tiles will be transparent.")]
        [SerializeField] private int m_TransparentDistance = 30;
        [Tooltip("The transparency of tilemap")]
        [Range(0f, 1f)]
        [SerializeField] private float m_Transparency = 0.5f;

        private Tile _transparent_tile = null;
        private void Start()
        {
            if (m_RevealerObject == null)
            {
                //find the revealer object from the tag
                m_RevealerObject = GameObject.FindGameObjectWithTag(m_ReavealerTag);
            }
        }
        // Update is called once per frame
        void Update()
        {
            //find where the reviealer is in the grid
            Vector3Int cell = m_Grid.WorldToCell(m_RevealerObject.transform.position);
            int loop_distance = m_RevealDistance;
            if (m_Transparent)
            {
                loop_distance = Mathf.Max(m_RevealDistance, m_TransparentDistance);
            }
            //loop through the cells around the revealer
            for (int x = -loop_distance; x <= loop_distance; x++)
            {
                for (int y = -loop_distance; y <= loop_distance; y++)
                {
                    //if the cell is within the reveal distance
                    if (Mathf.Pow(x, 2) + Mathf.Pow(y, 2) <= Mathf.Pow(m_RevealDistance, 2))
                    {
                        //create a new cell at the current position
                        Vector3Int new_cell = new Vector3Int(cell.x + x, cell.y + y, cell.z);
                        //reveal the tile at the new cell
                        RevealTile(new_cell);
                    }
                    else if (m_Transparent)
                    {
                        //if the cell is within the transparent distance
                        if (Mathf.Pow(x, 2) + Mathf.Pow(y, 2) <= Mathf.Pow(m_TransparentDistance, 2))
                        {
                            Vector3Int new_cell = new Vector3Int(cell.x + x, cell.y + y, cell.z);
                            TrasparentTile(new_cell);
                        }
                    }
                }
            }

        }

        private void TrasparentTile(Vector3Int cell)
        {
            //get the color of tile at the cell
            Tile tile = GetComponent<Tilemap>().GetTile<Tile>(cell);
            if(tile == null)
            {
                return;
            }
            if(_transparent_tile == null)
            {
                //copy the tile to _transparent_tile
                _transparent_tile = Instantiate(tile);
                //create a new color with the same RGB values as the tile, but with the alpha set to _tilemap_alpha
                Color color = new Color(tile.color.r, tile.color.g, tile.color.b, m_Transparency);
                _transparent_tile.color = color;
            }
            
            //set the color of the tile at the cell to the new color
            GetComponent<Tilemap>().SetTile(cell, _transparent_tile);
        }

        private void RevealTile(Vector3Int cell)
        {
            //delete the tile at the cell
            GetComponent<Tilemap>().SetTile(cell, null);
        }
    }
}