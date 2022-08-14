using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnObjects = new List<GameObject>();
    [Header("Positions")]
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float leftX;
    [SerializeField] private float rightX;
    [SerializeField] private float posZ;
    [SerializeField] private SpawnObject selectedObject;
    [Header("VariationByLevel")]
    public float RepeatTimer;

    void Start()
    {
        InvokeRepeating("SpawnSystem", 0.5f, RepeatTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSystem()
    {
        int rndIndex = Random.Range(0, spawnObjects.Count);
        float rndY = Random.Range(minY, maxY);
        float rndX = Random.Range(0, 2);
        if (rndX==0)
        {
            rndX = leftX;
        }
        else
        {
            rndX = rightX;
        }
        var newPos = new Vector3(rndX, rndY, posZ);
        var newSpanwObject=Instantiate(spawnObjects[rndIndex], newPos, Quaternion.identity);
        selectedObject = newSpanwObject.GetComponent<SpawnObject>();
        newSpanwObject.transform.DOJump(new Vector3(-newPos.x, newPos.y, newPos.z), 5f,selectedObject.JumpCount,selectedObject.JumpSpeed).OnComplete(() =>
        {
            Destroy(newSpanwObject);
        });
        //newSpanwObject.transform.DOJump
    }
}
