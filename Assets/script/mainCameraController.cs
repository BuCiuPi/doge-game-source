using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraController : MonoBehaviour
{
    GameObject obj;
    Vector3 mousePOS;
    public GameObject gameController;
    public GameObject sheep;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //gameController.GetComponent<gameController>().GOTOMousePos(obj, 1, -10);
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, -10);
        obj.transform.position = Vector3.Lerp(obj.transform.position, sheep.transform.position, 0.1f);
    }
}
