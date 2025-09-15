using UnityEngine;

public class Quiz1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    void Start()
    {
        
    }



    void Update()
    {
       float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
       float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down

       Vector3 movement = new Vector3(horizontal, 0f, vertical);
       transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        
    }
}
