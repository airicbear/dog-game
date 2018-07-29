using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

  private Rigidbody2D rb2D;
  private SpriteRenderer srend;
  public float jumpHeight = 100.0f;
  public float movementSpeed = 10.0f;
  
  void Start () {
    rb2D = gameObject.GetComponent<Rigidbody2D>();
    srend = gameObject.GetComponent<SpriteRenderer>();
  }

  void FixedUpdate() {
    float horzPress = Input.GetAxis("Horizontal");
    if (Input.GetKeyDown("space")) {
      jump(jumpHeight);
    } else if (horzPress != 0) {
      walk(Input.GetAxis("Horizontal"), movementSpeed);
    }
  }

  void jump(float thrust) {
    if (rb2D.velocity.y == 0.0f) {
      rb2D.AddForce(transform.up * thrust);
    }
  }

  void walk(float dir, float speed) {
    // Flip the dog
    if (dir > 0) {
      srend.flipX = true;
    } else {
      srend.flipX = false;
    }

    // Move the dog
    transform.Translate(dir * speed * Time.deltaTime, 0, 0);
  }
}
