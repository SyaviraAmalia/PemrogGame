using UnityEngine;

public class NodeController : MonoBehaviour
{
    public bool canMoveLeft = false;
    public bool canMoveRight = false;
    public bool canMoveUp = false;
    public bool canMoveDown = false;

    public GameObject nodeLeft;
    public GameObject nodeRight;
    public GameObject nodeUp;
    public GameObject nodeDown;

    public bool isWarpRightNode = false;
    public bool isWarpLeftNode = false;

    //If the node contains a pellet when the game starts
    public bool isPelletNode = false;
    //If the node still has a pellet
    public bool hasPellet = false;

    public SpriteRenderer pelletSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (transform.childCount > 0)
        {
            hasPellet = true;
            isPelletNode = true;
            pelletSprite = GetComponentInChildren<SpriteRenderer>();
        }

        RaycastHit2D[] hitsDown;
        //Shoot raycast (line) going down
        hitsDown = Physics2D.RaycastAll(transform.position, -Vector2.up);

        //Loop through all of the gameobject that the raycast hits
        for (int i = 0; i < hitsDown.Length; i++)
        {
            float distance = Mathf.Abs(hitsDown[i].point.y - transform.position.y);
            if (distance < 0.4f && hitsDown[i].collider.tag == "Node")
            {
                canMoveDown = true;
                nodeDown = hitsDown[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitsUp;
        //Shoot raycast (line) going up
        hitsUp = Physics2D.RaycastAll(transform.position, Vector2.up);

        //Loop through all of the gameobject that the raycast hits
        for (int i = 0; i < hitsUp.Length; i++)
        {
            float distance = Mathf.Abs(hitsUp[i].point.y - transform.position.y);
            if (distance < 0.4f && hitsUp[i].collider.tag == "Node")
            {
                canMoveUp = true;
                nodeUp = hitsUp[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitsRight;
        //Shoot raycast (line) going right
        hitsRight = Physics2D.RaycastAll(transform.position, Vector2.right);

        //Loop through all of the gameobject that the raycast hits
        for (int i = 0; i < hitsRight.Length; i++)
        {
            float distance = Mathf.Abs(hitsRight[i].point.x - transform.position.x);
            if (distance < 0.4f && hitsRight[i].collider.tag == "Node")
            {
                canMoveRight = true;
                nodeRight = hitsRight[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitsLeft;
        //Shoot raycast (line) going rigth
        hitsLeft = Physics2D.RaycastAll(transform.position, -Vector2.right);

        //Loop through all of the gameobject that the raycast hits
        for (int i = 0; i < hitsLeft.Length; i++)
        {
            float distance = Mathf.Abs(hitsLeft[i].point.x - transform.position.x);
            if (distance < 0.4f && hitsLeft[i].collider.tag == "Node")
            {
                canMoveLeft = true;
                nodeLeft = hitsLeft[i].collider.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetNodeFromDirection(string direction)
    {
        if (direction == "left" && canMoveLeft)
        {
            return nodeLeft;
        }
        else if (direction == "right" && canMoveRight)
        {
            return nodeRight;
        }
        else if (direction == "up" && canMoveUp)
        {
            return nodeUp;
        }
        else if (direction == "down" && canMoveDown)
        {
            return nodeDown;
        }
        else
        {
            return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("Trigger entered with: " + collision.gameObject.name + ", Tag: " + collision.tag);
    Debug.Log("isPelletNode: " + isPelletNode + ", hasPellet: " + hasPellet);
    
    if (collision.tag == "Player" && isPelletNode)
    {
        Debug.Log("Pellet eaten!");
        hasPellet = false;
        pelletSprite.enabled = false;
    }  
}                                
}
