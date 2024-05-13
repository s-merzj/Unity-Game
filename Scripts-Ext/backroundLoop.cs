using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backroundLoop : MonoBehaviour
{
    public GameObject [] levels;
    [SerializeField] private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;

    void Start(){
        mainCamera = gameObject.GetComponent<Camera>();

        // Calculate screen bounds
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width + 200, Screen.height, mainCamera.transform.position.z));
        Debug.Log(screenBounds);
        // Loads layers :)
        foreach(GameObject obj in levels){
            loadChildObjects(obj);
        }
    }

    //
    void loadChildObjects(GameObject obj){
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);

        GameObject clone = Instantiate(obj) as GameObject;
        for(int i = 0; i <= childsNeeded; i++){
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }

        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    void repositionChildObjects(GameObject obj){
        Transform [] children = obj.GetComponentsInChildren<Transform>();

        if(children.Length > 1){
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;

            // Check if camera is too far to the right of the object
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth) {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            // Else, check if camera is too far left
            else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth){
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }
    void LateUpdate(){
        foreach(GameObject obj in levels){
            repositionChildObjects(obj);

        }
    }

    



}
