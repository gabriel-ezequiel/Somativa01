using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemMovimentacao : MonoBehaviour
{
    public float velocidade = 10f;
    public float rotacao = 90f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        
        Vector3 dir = new Vector3(x, 0, y) * velocidade;

        transform.Translate(dir * Time.deltaTime);

        transform.Rotate(new Vector3(0, mouseX * rotacao * Time.deltaTime, 0));
    }
}
