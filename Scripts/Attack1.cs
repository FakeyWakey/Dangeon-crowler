using UnityEngine;

public class Attack1 : MonoBehaviour
{
    private Animator anim;
     void Start()
    {
        anim = GetComponent<Animator>();
    }   

void Update()
{
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
        anim.SetTrigger("Attack");
    }
}
}
