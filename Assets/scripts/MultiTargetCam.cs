using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class MultiTargetCam : MonoBehaviour
{

    public List<Transform> Targets;

    public Vector3 offset;

    public float smoothtime = 0f;

    private Vector3 velocity;

    public float minzoom = 1f;
    public float maxzoom = 2.7f;
    public float zoomlimiter = 8f;

    [SerializeField] private float _TimeTillNextScene = 500;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (GlobalVars.instance.Debug == false)
        {
            foreach (GameObject soos in GameObject.FindGameObjectsWithTag("Ceiling"))
            {
                soos.GetComponent<SpriteRenderer>().enabled = false;
                if (soos == null)
                {
                    break;
                }
            }

            foreach (GameObject soos in GameObject.FindGameObjectsWithTag("Ground"))
            {
                soos.GetComponent<SpriteRenderer>().enabled = false;
                if (soos == null)
                {
                    break;
                }
            }

            foreach (GameObject soos in GameObject.FindGameObjectsWithTag("Slope Bottom"))
            {
                soos.GetComponent<SpriteRenderer>().enabled = false;
                if (soos == null)
                {
                    break;
                }
            }

            foreach (GameObject soos in GameObject.FindGameObjectsWithTag("WeaponSpawn"))
            {
                soos.GetComponent<SpriteRenderer>().enabled = false;
                if (soos == null)
                {
                    break;
                }
            }

            foreach (GameObject soos in GameObject.FindGameObjectsWithTag("WeaponSpawn"))
            {
                soos.GetComponent<SpriteRenderer>().enabled = false;
                if (soos == null)
                {
                    break;
                }
            }

            foreach (GameObject soos in GameObject.FindGameObjectsWithTag("Spawn"))
            {
                soos.GetComponent<SpriteRenderer>().enabled = false;
                if (soos == null)
                {
                    break;
                }
            }

            foreach (GameObject soos in GameObject.FindGameObjectsWithTag("Space"))
            {
                soos.GetComponent<SpriteRenderer>().enabled = false;
                if (soos == null)
                {
                    break;
                }
            }
        }
    }
    private void LateUpdate()
    {
        Targets = GlobalVars.instance.StaticTargets;
        if (Targets.Count == 0 || Targets.Count == 1)
        {
            if (GlobalVars.instance.Debug == false)
            {
                _TimeTillNextScene -= 200 * Time.deltaTime;
            }
        }

        if (_TimeTillNextScene <= 0) //delete everything and return to the customization menu
        {
            movescene();
        }

        move();
        zoom();
        //Targets = GlobalVars.instance.StaticTargets;
    }

    void move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothtime);
    }

    void zoom()
    {
        float newzoom = Mathf.Lerp(minzoom, maxzoom, GetGreatestDistance() / zoomlimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newzoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(Targets[0].position, Vector3.zero);
        for (int i = 0; i < Targets.Count; i++)
        {
            bounds.Encapsulate(Targets[i].position);
        }
        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (Targets.Count == 1)
        {
            return Targets[0].position;
        }

        var bounds = new Bounds(Targets[0].position, Vector3.zero);
        for (int i = 0; i < Targets.Count; i++) 
        {
            bounds.Encapsulate(Targets[i].position);
        }

        return bounds.center;
    }

    void movescene()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            Destroy(o);
        }
        SceneManager.LoadScene("Menu");
    }
}
