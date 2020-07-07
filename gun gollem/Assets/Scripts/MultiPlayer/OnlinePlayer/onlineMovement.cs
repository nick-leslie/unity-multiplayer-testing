using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onlineMovement : MonoBehaviour
{
    public Vector2 input;
    public float speed;
    public Rigidbody2D rb;
    [SerializeField]
    private UDPReceve reseve;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        reseve = GameObject.FindGameObjectWithTag("MultiplayerManiger").GetComponent<UDPReceve>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reseve.buffer != null && reseve.buffer.Count>=1)
        {
            input =JsonUtility.FromJson<Vector2>(reseve.buffer.Last.Value);
            reseve.buffer.RemoveLast();
        }
        

        rb.velocity = new Vector2(input.x * speed * Time.deltaTime, input.y * Time.deltaTime * speed);
    }
}
