using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject door;
    public GameObject CollectablePrefeb;
    public List <GameObject> Collectables;
    public int collectableCount;
    public void hideDoor()
    {
        DeactiviteDoor();
        randomDoorPos();
        CollectableThings();
        
    }

    private void CollectableThings()
    {
        DeleteCollectable();
        GenerateCollectable();
    }
   
    private void GenerateCollectable()
    {
        for (int i = 0; i < collectableCount; i++)
        {
            var newCollectable = Instantiate(CollectablePrefeb);
            var pos = CollectablePrefeb.transform.position;
            pos.x = Random.Range(-5.53f, 7.2f);
            newCollectable.transform.position = new Vector3(pos.x,1f , 19);
            Collectables.Add(newCollectable);
        }
    }

    private void DeleteCollectable()
    {
       foreach (GameObject c in Collectables)
        {
            Destroy(c);
        }
       Collectables.Clear();
    }
    private void randomDoorPos()
    {
        var pos = door.transform.position;
        pos.x = Random.Range(-6.1f, 7.3f);
        door.transform.position = new Vector3(pos.x,0,-21.69f);
    }

    private void DeactiviteDoor()
    {
        door.SetActive(false);
    }

    public void showDoor()
    {    
        door.SetActive(true);
       
    }
}
