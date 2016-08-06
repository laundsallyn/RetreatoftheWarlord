using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("Pause")!=1)
        {
            Vector2 offset = new Vector2(Time.time * scrollSpeed, 0);
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }


        // float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        // transform.position = startPosition + Vector3.right * newPosition;
    }
}