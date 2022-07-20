using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameflow : MonoBehaviour
{
    public Transform m_target;
    public Vector3 offset;
    public float damping = 1;
    public float distance = 10;
    public float height = 3;

    // Start is called before the first frame update
    void Start()
    {
        offset = m_target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        m_target = GameObject.Find("PlayerMove").GetComponent<Transform>();

        float horizontal = Input.GetAxis("Mouse X");
        m_target.Rotate(0, horizontal, 0);


        Vector3 desiredposition = m_target.position;
        desiredposition -= m_target.forward * distance;
        desiredposition += new Vector3(0, height, 0);
        transform.position = Vector3.Lerp(transform.position, desiredposition, Time.deltaTime * damping*2);
        transform.LookAt(m_target);
    }
}
