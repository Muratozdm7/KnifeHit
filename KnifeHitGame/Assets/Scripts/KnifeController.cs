using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeController : MonoBehaviour
{
    private KnifeManager knifeManager;

    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;

    private bool canShoot;



    private void Start()
    {
        GetComponentValue();
    }


    private void Update()
    {
        HandleShootInput();
    }


    private void FixedUpdate()
    {
        Shoot();
    }


    private void HandleShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            knifeManager.SetDisableKnifeIcon();
            canShoot = true;
        }
    }


    private void Shoot()
    {
        if (canShoot)
        {
            rb.AddForce(Vector2.up * moveSpeed * Time.fixedDeltaTime);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Circle"))
        {
            knifeManager.SetActiveKnife();
            canShoot = false;
            rb.isKinematic = true;
            transform.SetParent(other.gameObject.transform);
        }

        if (other.gameObject.CompareTag("Knife"))
        {
            SceneManager.LoadScene(0);
        }
    }


    private void GetComponentValue()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeManager = GameObject.FindObjectOfType<KnifeManager>();
    }
}
