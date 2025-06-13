using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviour
{
    public LayerMask groundMask; // Warstwa ziemi lub pod³o¿a

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Trafiamy w pod³o¿e
        if (Physics.Raycast(ray, out hit, 1000f, groundMask))
        {
            Vector3 targetPos = hit.point;
            targetPos.y = transform.position.y; // Utrzymujemy poziom gracza

            transform.LookAt(targetPos);
    
        }

       
    }


}