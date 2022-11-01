using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCroll : MonoBehaviour
{
// Start is called before the first frame update
    public Transform playerTransform; //creating a field in the Inspector that I can drag things into, in this case, the player
    public float parallaxModifier; //how fast/slow to scroll the bg
    float playerStartX;
    float currentPlayerPos;

    void Start()
    {
        playerStartX = playerTransform.position.x; //finding the x axis position of the player at the start of the game
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayerPos = playerTransform.position.x; //getting the CURRENT x position of the player
        gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2((currentPlayerPos-playerStartX)*parallaxModifier, gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset.y);

    }
}
