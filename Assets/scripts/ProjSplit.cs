using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjSplit : MonoBehaviour
{
    public GameObject pickprefab;
    // Start is called before the first frame update
    private void OnDestroy()
    {
        var splitA = Instantiate(pickprefab, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.rotation);
        splitA.GetComponent<Rigidbody2D>().AddForce(new Vector2(75, 200));
        var splitB = Instantiate(pickprefab, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.rotation);
        splitB.GetComponent<Rigidbody2D>().AddForce(new Vector2(-75, 200));
        var splitC = Instantiate(pickprefab, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.rotation);
        splitC.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));
        var splitD = Instantiate(pickprefab, new Vector3(transform.position.x,transform.position.y + 0.1f, transform.position.z), transform.rotation);
        splitD.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
    }
}
