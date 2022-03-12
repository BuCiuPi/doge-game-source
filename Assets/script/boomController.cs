using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomController : MonoBehaviour
{
    public Vector3 target;
    public float moveSpeed = 1;
    public GameObject explor;

    private GameObject GameController;


    // Start is called before the first frame update
    void Start()
    {   
        // construct value
        GameController = GameObject.FindGameObjectWithTag("GameController");

        //destroy this obj after 2 second
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        // move obj to the target
        transform.Translate((transform.position - target) * moveSpeed * -0.1f);
    }

    private void OnDestroy()
    {
        // add score 
        GameController.GetComponent<gameController>().AddScore();

        // ganerate an explosion at boom postion after the Boom is destroy
        GameObject expl = Instantiate(explor,transform.position,Quaternion.identity) as GameObject;
        
        // destroy after 0.5 second
        Destroy(expl, 0.5f);
    }
}
