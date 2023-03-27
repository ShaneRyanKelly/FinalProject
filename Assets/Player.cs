using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float xVector;
    public float yVector;
    private Rigidbody _rb;
    public float JumpVelocity = 5f;
    private bool _isJumping;
    private bool _shoot;
    public GameObject projectile;
    public float projectileVelocity;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        if (_isJumping){
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }
        if (_shoot){
            Vector3 mouse = Input.mousePosition;
            var newProjectile = Instantiate(projectile, transform.position, new Quaternion(0f,0f,0f,0f));
            var body = newProjectile.GetComponent<Rigidbody>();
            body.velocity += projectileVelocity * new Vector3(mouse.x, 0f, mouse.y);
        }

        _isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        xVector = Input.GetAxis("Horizontal") * rotateSpeed;
        yVector = Input.GetAxis("Vertical") * moveSpeed;

        this.transform.Translate(Vector3.forward * yVector * Time.deltaTime);
        this.transform.Rotate(Vector3.up * xVector * Time.deltaTime);

        _isJumping |= Input.GetKeyDown(KeyCode.Space);
        _shoot |= Input.GetMouseButtonDown(0);
    }
}
