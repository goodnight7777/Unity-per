using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I : MonoBehaviour
{
    public float mousSens = 100f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float speed;
    [SerializeField] float forse;
    [SerializeField] GameObject planet;
    float pitch = 0, yaw = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizantal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 derection = (transform.right * horizantal + transform.forward * vertical);
        derection.Normalize();
        float dist = (transform.position - planet.transform.position).magnitude;
        Vector3 Vf = forse * derection / (dist * dist);
        GetComponent<Rigidbody>().AddForce(Vf);
        MouseLoock();
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = gameObject.transform.position;
            bullet.transform.rotation = gameObject.transform.rotation;
            bullet.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * speed;

        }
    }

    void MouseLoock()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousSens * Time.deltaTime;

        pitch -= mouseY;
        yaw += mouseX;

        Vector3 prevRot = transform.localRotation.eulerAngles;
        transform.localRotation = Quaternion.Euler(pitch,yaw, 0f);
    }
    void OnCollisionEnter(Collision collision)
    {

        // Вызывается в КАДР начала столкновения

        // Один раз при первом контакте

        Debug.Log("Началось столкновение с " + collision.gameObject.name);

    }
}
