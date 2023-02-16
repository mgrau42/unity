using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Holdcd : MonoBehaviour
{
  public p1Controller p1con;                //reference to p1Controller script
  public SpriteRenderer playerRenderer;    //reference to player's sprite renderer
  public Sprite holdBSprite;               //sprite to use when holding blue CD
  public Sprite holdRSprite;               //sprite to use when holding red CD
  public Sprite holdYSprite;               //sprite to use when holding yellow CD
  public Sprite holdGSprite;               //sprite to use when holding green CD

  void FixedUpdate()
  {
          obtener();                     //call obtener function every FixedUpdate
	}

  void obtener(){

      LayerMask mask1 = LayerMask.GetMask("CDs"); //layermask for CDs
      float distance = 200;                       //maximum distance of raycast
      if (Input.GetKeyDown(KeyCode.S) && (!(p1con.playerBall))){
          RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), distance); //raycast from player's position towards up
              if (hit.collider != null)           //check if raycast hit a collider
              {
                  cdDetection(hit);               //call cdDetection function with hit collider as argument
                  Destroy(hit.transform.gameObject); //destroy the CD that was hit
              }
      }
      else if (Input.GetKeyDown(KeyCode.S) && (p1con.playerBall)){
          //shake animation
      }
  }

  void cdDetection(RaycastHit2D hit){
      if(hit.collider.tag == "BlueCD"){           //if the hit CD is a blue CD
          p1con.playerBall = true;                //set playerBall to true (meaning the player is holding a CD)
          p1con.cdType = 1;                       //set cdType to 1 (meaning the player is holding a blue CD)
          playerRenderer.sprite = holdBSprite;    //set player sprite to holdBSprite
      }
      else if(hit.collider.tag == "GreenCD"){     //if the hit CD is a green CD
          p1con.playerBall = true;                //set playerBall to true
          p1con.cdType = 2;                       //set cdType to 2 (meaning the player is holding a green CD)
          playerRenderer.sprite = holdGSprite;    //set player sprite to holdGSprite
      }
      else if(hit.collider.tag == "YellowCD"){    //if the hit CD is a yellow CD
          p1con.playerBall = true;                //set playerBall to true
          p1con.cdType = 3;                       //set cdType to 3 (meaning the player is holding a yellow CD)
          playerRenderer.sprite = holdYSprite;    //set player sprite to holdYSprite
      }
      else if(hit.collider.tag == "RedCD"){       //if the hit CD is a red CD
          p1con.playerBall = true;                //set playerBall to true
          p1con.cdType = 4;                       //set cdType to 4 (meaning the player is holding a red CD)
          playerRenderer.sprite = holdRSprite;    //set player sprite to holdRSprite
      }
  }
}
