using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 myVector = new Vector3(1f, 0.0f, 0.0f);
    // Start is called before the first frame update
    public GameObject circle;

    public GameObject cross;
    public GameObject ci;
    public GameObject cr;
     public GameObject Amel;
     public GameObject Hamza;
     public GameObject Manager;
    bool dirRight = true, dirLeft = true, dirUp = true, dirDown = true;
    public bool locked = false;
    Vector2 Lvector, Uvector, Dvector, Rvector;

    public bool safe=false;
    public bool hamza=false;
    public SpriteRenderer spriteRenderer;
public Sprite newSprite;
public Sprite AlifSprite;
public SpriteRenderer AlifRenderer;
public Sprite HamzaSprite;
public SpriteRenderer HamzaRenderer;
public bool captured=false;


    void Start()
    {

            Amel=GameObject.Find("amal");
             spriteRenderer = Amel.GetComponent<SpriteRenderer>();
             Hamza=GameObject.Find("Target");
             HamzaRenderer = Hamza.GetComponent<SpriteRenderer>();
             Manager=GameObject.Find("Manager");
    }

    // Update is called once per frame
    void Update()
    {

        if(captured==false)
        {
        if (Input.GetKeyDown("right"))

        {
            if (dirRight)
                transform.Translate(Vector3.right);

        }
        if (Input.GetKeyDown("left"))

        {
            if (dirLeft)
                transform.Translate(Vector3.left);

        }
        if (Input.GetKeyDown("up"))

        {
            if (dirUp)
                transform.Translate(Vector3.up);

        }
        if (Input.GetKeyDown("down"))

        {
            if (dirDown)
                transform.Translate(Vector3.down);


        }
        }


    }

    void FixedUpdate()
    {


        Lvector = new Vector2(transform.position.x - 1f, transform.position.y);
        //Debug.Log(Lvector);
        Rvector = new Vector2(transform.position.x + 1f, transform.position.y);
        //Debug.Log(Rvector);
        Uvector = new Vector2(transform.position.x, transform.position.y + 1f);
        //Debug.Log(Uvector);
        Dvector = new Vector2(transform.position.x, transform.position.y - 1f);
       // Debug.Log(Dvector);
        // Cast a ray straight down.
        RaycastHit2D hitup = Physics2D.Raycast(Uvector, Vector2.up, 0);
        RaycastHit2D hitdown = Physics2D.Raycast(Dvector, Vector2.down, 0);
        RaycastHit2D hitright = Physics2D.Raycast(Rvector, Vector2.right, 0);
        RaycastHit2D hitleft = Physics2D.Raycast(Lvector, Vector2.left, 0);

        // If it hits something...
        if (hitup.collider != null)
        {   
            if (hitup.collider.CompareTag("wall"))
            {
                dirUp = false;
            }
            // If Locked
            if (locked == true)
            {
                if (hitup.collider.CompareTag("Hide") || (hitup.collider.CompareTag("Nothide")))
                {

                   // Debug.Log("there is a box on top of us");
                    dirUp = false;
                }
            }
        }else {dirUp = true;}
        /// Down
        if (hitdown.collider != null)
        {
            
            if (hitdown.collider.CompareTag("wall"))
            {
                dirDown = false;

            }
            //if locked
            if (locked == true)
            {
                if (hitdown.collider.CompareTag("Hide") || (hitdown.collider.CompareTag("Nothide")))
                {

                   // Debug.Log("there is a box on down of us");
                    dirDown = false;
                }
            }
        }else {dirDown = true;}

        //LEft 
        if (hitleft.collider != null)
        {
            if (hitleft.collider.CompareTag("wall"))
            {
                dirLeft = false;

            }

            //if locked
            if (locked == true)
            {
                if (hitleft.collider.CompareTag("Hide") || (hitleft.collider.CompareTag("Nothide")))
                {

                   // Debug.Log("there is a box on left of us");
                    dirLeft = false;
                }
            }
        }else {dirLeft = true;}
        //right
        if (hitright.collider != null)
        {   
            if (hitright.collider.CompareTag("wall"))
            {
                dirRight = false;

            }
            //if locked
            if (locked == true)
            {
                if (hitright.collider.CompareTag("Hide") || (hitright.collider.CompareTag("Nothide")))
                {

                   // Debug.Log("there is a box on right of us");
                    dirRight = false;
                }
            }
        }else {dirRight = true;}



    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Hide"))
        {
            //Debug.Log("Can Hide");
            ci = Instantiate(circle, transform.position, Quaternion.identity);
            locked = true;
            safe=true;



        }
        if (other.CompareTag("Nothide"))
        {
           // Debug.Log("Nothide");
            cr = Instantiate(cross, transform.position, Quaternion.identity);
            locked = true;

        }
        if (other.CompareTag("Hamza"))
        {
            Debug.Log("gothamza");
           hamza=true;
           HamzaRenderer.sprite=HamzaSprite;
           AlifRenderer.sprite=AlifSprite;
             

        }
           if (other.CompareTag("Amal"))
        {
            Debug.Log("Amal here we go");
            
             if(hamza==true)
             {

            spriteRenderer.sprite = newSprite; 
            Win();


             }
          
             

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {


        if (other.CompareTag("Hide"))
        {
            //Debug.Log("destroy circle");
            Destroy(ci);
            locked = false;
            dirRight = true;
            dirUp = true;
            dirLeft = true;
            dirDown = true;
            safe=false;
        }

        if (other.CompareTag("Nothide"))
        {


            locked = false;
            Destroy(cr);
            dirRight = true;
            dirLeft = true;
            dirUp = true;
            dirDown = true;



        }

    }

     void Win()
    {
      
        Debug.Log("You win");
        Manager.GetComponent<Manager>().win=true;

    }



}
