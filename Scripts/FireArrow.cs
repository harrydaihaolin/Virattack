using UnityEngine;

public class FireArrow : MonoBehaviour
{
    private float fileRate = 0.7f;
    private float nextFire = 0f;

    Animator anim;

    public Transform bowOrigin;
    public GameObject arrow;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public bool Firearrow()
    {
        anim.SetBool("isFiring", true);
        Instantiate(arrow, bowOrigin.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        //Invoke("StopFire", 0, 1f);
        return true;
    }

    void StopFire()
    {
        anim.SetBool("isFiring", false);
    }
}
