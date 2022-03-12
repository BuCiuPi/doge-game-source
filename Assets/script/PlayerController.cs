using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1;
    GameObject obj;

    public GameObject gameController;

    private bool isInGame = false;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    Vector2 moverment;
    // Update is called once per frame
    void Update()
    {
        if (isInGame)
        {
            if (Input.GetMouseButton(0))
            {
                gameController.GetComponent<gameController>().GOTOMousePos(obj, moveSpeed, 0);
                obj.transform.position = new Vector3(Mathf.Clamp(obj.transform.position.x, -5, 5), Mathf.Clamp(obj.transform.position.y, -3, 3), 0);
            }


            //arow moverment
            moverment.x = Input.GetAxisRaw("Horizontal");
            moverment.y = Input.GetAxisRaw("Vertical");
            obj.GetComponent<Rigidbody2D>().MovePosition(new Vector2(obj.transform.position.x, obj.transform.position.y) + moverment * moveSpeed * 0.1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Boom"))
        {
            Destroy(collision.gameObject);
            gameController.GetComponent<gameController>().endGame();
        }
    }

    public void StartPlayer()
    {
        isInGame = true;
    }

    public void StopPlayer()
    {
        isInGame = false;
    }
}
