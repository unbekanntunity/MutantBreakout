using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GAME OVER");
        // The above log does print when we reach the game over screen but the cursor doesn't activate
        // Because of this, we can't click the buttons
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        // This does display the cursor but we still can't interact with anything
        if (Input.GetKeyDown("escape"))
        {
            Cursor.visible = true;
        }
    }
}
