using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BuildSystem : MonoBehaviour
{
    //test
    public Transform shootingPoint;
    public GameObject blockObject;
    public GameObject cabinet;
 
    public Transform parent;
 
    public Color normalColor;
    public Color highlightedColor;
 
    GameObject lastHightlightedBlock;
 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BuildBlock(blockObject);
        }
        if (Input.GetMouseButtonDown(1))
        {
            DestroyBlock();
        }
        if(Input.GetButtonDown("RotateX")){
            Rotate();
        }

        if(Input.GetButtonDown("Cabinet")){
            
            SpawnCabinet(cabinet);
        }
        HighlightBlock();
    }
 
    void BuildBlock(GameObject block)
    {
        if(Physics.Raycast(shootingPoint.position, shootingPoint.forward, out RaycastHit hitInfo))
        {
 
            if(hitInfo.transform.tag == "Block")
            {
                Vector3 spawnPosition = new Vector3(Mathf.RoundToInt(hitInfo.point.x + hitInfo.normal.x/2), Mathf.RoundToInt(hitInfo.point.y + hitInfo.normal.y / 2), Mathf.RoundToInt(hitInfo.point.z + hitInfo.normal.z /2));
                Instantiate(block, spawnPosition, Quaternion.identity, parent);
            }
            else
            {
                Vector3 spawnPosition = new Vector3(Mathf.RoundToInt(hitInfo.point.x), Mathf.RoundToInt(hitInfo.point.y + 0.5f), Mathf.RoundToInt(hitInfo.point.z));
                Instantiate(block, spawnPosition, Quaternion.identity, parent);
            }
        }
    }
 
    void DestroyBlock()
    {
        if (Physics.Raycast(shootingPoint.position, shootingPoint.forward, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.tag == "Block")
            {
                Destroy(hitInfo.transform.gameObject);
            }
        }
    }

    void Rotate(){

         if (Physics.Raycast(shootingPoint.position, shootingPoint.forward, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.tag == "Block")
            {
        if(Input.GetButtonDown("RotateX")){
                        // new Quaternion(90,90,180, 90);
                        //hitInfo.transform.gameObject = Quaternion.Euler(new Vector3(90,0,0));
                        //GetComponent<Transform> ().eulerAngles = new Vector3 (90,132,0);
                      //transform.Rotate(Quaternion(90,0,0));
                        //Debug.Log("Rotere");
                         //Vector3 spawnPosition = new Vector3(Mathf.RoundToInt(hitInfo.point.x), Mathf.RoundToInt(hitInfo.point.y + 0.5f), Mathf.RoundToInt(hitInfo.point.z));
                       
//Vector3 newAngle = new Vector3(321,90,0);
//blockObject.transform.Rotate(newAngle);

hitInfo.transform.rotation = Quaternion.Euler(new Vector3(50,0,0));
//transform.localEulerAngles = new Vector3(33, 22, 15);
                       //blockObject.transform.Rotate(180,90,90);
                        //gameObject.transform.rotation = Quaternion.Euler(new Vector3(90,0,0));
                      //  lastHightlightedBlock.GetComponent<Renderer>().material.color = normalColor;
                    //hitInfo.transform.gameObject.GetComponent<Renderer>().material.color = highlightedColor;
                    //lastHightlightedBlock = hitInfo.transform.gameObject = new Quaternion(90,90,180, 90);

                         //gameObject.transform.rotation = new Quaternion(90,90,180, 90);

                }
            }
    }
    }


    void SpawnCabinet(GameObject cabinet){
              if(Physics.Raycast(shootingPoint.position, shootingPoint.forward, out RaycastHit hitInfo))
        {
 
            if(hitInfo.transform.tag == "Cabinet")
            {
                Vector3 spawnPosition = new Vector3(Mathf.RoundToInt(hitInfo.point.x + hitInfo.normal.x/2), Mathf.RoundToInt(hitInfo.point.y + hitInfo.normal.y / 2), Mathf.RoundToInt(hitInfo.point.z + hitInfo.normal.z /2));
                Instantiate(cabinet, spawnPosition, Quaternion.identity, parent);
            }
            else
            {
                Vector3 spawnPosition = new Vector3(Mathf.RoundToInt(hitInfo.point.x), Mathf.RoundToInt(hitInfo.point.y + 0.5f), Mathf.RoundToInt(hitInfo.point.z));
                Instantiate(cabinet, spawnPosition, Quaternion.identity, parent);
            }
        }
    }
 
    void HighlightBlock()
    {
        if (Physics.Raycast(shootingPoint.position, shootingPoint.forward, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.tag == "Block")
            {
                if(lastHightlightedBlock == null)
                {
                    lastHightlightedBlock = hitInfo.transform.gameObject;
                    hitInfo.transform.gameObject.GetComponent<Renderer>().material.color = highlightedColor;
                }
                else if (lastHightlightedBlock != hitInfo.transform.gameObject)
                {
                    lastHightlightedBlock.GetComponent<Renderer>().material.color = normalColor;
                    hitInfo.transform.gameObject.GetComponent<Renderer>().material.color = highlightedColor;
                    lastHightlightedBlock = hitInfo.transform.gameObject;
                }
        
            }
        }
    }
}