using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace phys
{
    public class GameController : MonoBehaviour
    {
        float radius = 5.0F;
        float power = -500.0F;

        void Start()
        {
        }

        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point);
                // Debug.Log(hit.collider.name);
                if (Input.GetMouseButton(0))
                {
                    Vector3 explosionPos = hit.point;
                    Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

                    foreach (Collider hits in colliders)
                    {
                        Rigidbody rb = hits.GetComponent<Rigidbody>();

                        if (rb != null)
                            rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                    }
                }
            }
        }
    }
}