using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Image aim;
    [SerializeField] private GameObject gun;
    [SerializeField] private Transform target;
    [SerializeField] private float _movementClampNegative;
    [SerializeField] private float _movementClampPositive;
    [SerializeField] private float horizontalSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AimPosition();
    }

    private void AimPosition()
    {
        if (Input.touchCount > 0)
        {
            aim.gameObject.SetActive(true);
            Touch _theTouch = Input.GetTouch(0);

            if (_theTouch.phase == TouchPhase.Moved)
            {
                Vector2 touchPos = _theTouch.deltaPosition;
                if (touchPos != Vector2.zero)
                {
                    target.transform.Translate(touchPos.x * (horizontalSpeed / 100) * Time.deltaTime, 0, 0);
                    target.transform.position = new Vector3(Mathf.Clamp(target.transform.position.x, _movementClampNegative, _movementClampPositive), target.transform.position.y, target.transform.position.z);
                    target.transform.Translate(0, touchPos.y * (horizontalSpeed / 100) * Time.deltaTime, 0);
                    target.transform.position = new Vector3(target.transform.position.x, Mathf.Clamp(target.transform.position.y, _movementClampNegative, _movementClampPositive), target.transform.position.z);
                    gun.transform.LookAt(aim.transform);
                   
                    //aim.rectTransform.Translate(touchPos.x * (horizontalSpeed) * Time.deltaTime, 0, 0);
                }
            }
            if (_theTouch.phase==TouchPhase.Ended)
            {
                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(gun.transform.position, gun.transform.TransformDirection(Vector3.forward), out hit, 100f))
                {
                    if (hit.collider.gameObject.tag=="Obstackle")
                    {
                        Destroy(hit.transform.gameObject);
                    }
                }
                aim.gameObject.SetActive(false);
            }
        }

        //aim.rectTransform.position = Input.mousePosition;
        //gun.transform.rotation = Quaternion.Euler(Mathf.Clamp(gun.transform.rotation.x - (Input.mousePosition.y*Time.deltaTime/sens),-20f,20f), gun.transform.rotation.y, gun.transform.rotation.z);
        //if (Input.touchCount>0)
        //{
        //    print("girdim");
        //    Touch finger = Input.GetTouch(0);
        //    RaycastHit touchPos;
        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(finger.position),out touchPos,18.7f))
        //    {
        //        print(touchPos.collider.gameObject.name);
        //        if (touchPos.collider.gameObject.name == "Plane")
        //        {
        //            //target.position = touchPos.point;
        //            gun.transform.LookAt(touchPos.point);
        //        }

        //        //if (touchPos.collider.tag == "Obstackle")
        //        //{
        //        //    Destroy(touchPos.collider.gameObject);
        //        //}
        //    }
        //    if (finger.phase == TouchPhase.Ended)
        //    {
        //        if (touchPos.collider.gameObject.tag == "Obstackle")
        //        {
        //            Destroy(touchPos.collider.gameObject);
        //        }
        //    }

        //}



    }
}
