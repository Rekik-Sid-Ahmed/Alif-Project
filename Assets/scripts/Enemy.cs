using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{

    Vector3 current;
    Vector2 Lvector, Uvector, Dvector, Rvector;
      GameObject player;
       public GameObject redcross;
        public GameObject fail;
        public float count=0f; 
        public float pace =0f;
        public float hor =3f;
        public float ver =0f;
        public float time =2f;
         Vector3 origin;
      bool k;
      bool captured2=false;
    // Start is called before the first frame update
    void Start()
    {
        current = transform.position;
         player=GameObject.Find("player");
         origin=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(current, current+new Vector3(hor,ver,0), Mathf.PingPong(Time.time, time));
        



    }

    void FixedUpdate()
    {
        Lvector = new Vector2(transform.position.x - count, transform.position.y);

        Rvector = new Vector2(transform.position.x + count, transform.position.y);

        Uvector = new Vector2(transform.position.x, transform.position.y + count);

        Dvector = new Vector2(transform.position.x, transform.position.y - count);

        // Cast a ray straight down.
        RaycastHit2D hitup = Physics2D.Raycast(Uvector, Vector2.up, pace);
        RaycastHit2D hitdown = Physics2D.Raycast(Dvector, Vector2.down, pace);
        RaycastHit2D hitright = Physics2D.Raycast(Rvector, Vector2.right, pace);
        RaycastHit2D hitleft = Physics2D.Raycast(Lvector, Vector2.left, pace);

        /* if ((hitup.collider != null)||(hitdown.collider != null)||(hitright.collider != null)||(hitleft.collider != null))
         { 

             if (hitright.collider.CompareTag("Player"))
             {
                     Debug.Log("Alif Found");
             }



          }   */
            if(captured2==true)
            {
                Instantiate(redcross, player.transform.position, Quaternion.identity);
                Debug.Log("press enter");
                Debug.Log("You lose");
                captured2=false;
               transform.position= origin;
                Instantiate(fail);
                
            }

            if(player.GetComponent<Move>().captured==true)
            {

                  if (Input.GetKeyDown(KeyCode.Return))
        {
                     Application.LoadLevel(Application.loadedLevel);

        }
            }
            
         if (player.GetComponent<Move>().safe == false)
         {
          //k = player.GetComponent<Move>().safe ;
          // Debug.Log(player.GetComponent<Move>().safe);
                       if (hitup.collider != null) 
            {

                if (hitup.collider.CompareTag("Player"))
                {
                    Debug.Log("Alif Found");
                            //Time.timeScale = 0;
                            //Lose();
                            player.GetComponent<Move>().captured=true;
                            captured2=true;
                             

                }
            }
            if (hitdown.collider != null)
            {

                if (hitdown.collider.CompareTag("Player"))
                {
                    Debug.Log("Alif Found");
                     player.GetComponent<Move>().captured=true;
                     captured2=true;
                    
                }
            }
            if (hitright.collider != null)
            {

                if (hitright.collider.CompareTag("Player"))
                {
                    Debug.Log("Alif Found");
                     //Time.timeScale = 0;
                      player.GetComponent<Move>().captured=true;
                      captured2=true;
                      
                }
            }
            if (hitleft.collider != null)
            {

                if (hitleft.collider.CompareTag("Player"))
                {
                    Debug.Log("Alif Found");
                     player.GetComponent<Move>().captured=true;
                     captured2=true;
                      
                }
            }
     }










    }


   IEnumerator Lose() 
{
   
        yield return new WaitForSeconds(.1f);

    
}
}
