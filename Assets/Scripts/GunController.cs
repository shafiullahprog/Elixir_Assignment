using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    float range = 20, shootRate = 0.4f;
    [SerializeField] float damageValue = 10f;
    float shootTimer;
    [SerializeField] TrailRenderer TrailObject;
    [SerializeField] ParticleSystem gunImpact;
    [SerializeField] Button shootButton;

   /* private void Start()
    {
        shootButton.onClick.AddListener(Shoot);
    }*/
    private void Update()
    {
        shootTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (shootTimer >= shootRate)
        {
            shootTimer = 0;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, range))
            {
                GunImpact(hit);
                GiveDamage(hit.transform.gameObject, damageValue);
            }
        }
    }

    public void GunImpact(RaycastHit hit)
    {
        gunImpact.Play();
        TrailRenderer t = Instantiate(TrailObject, transform.position, Quaternion.identity);
        StartCoroutine(TrailEffect(t, hit));
        StartCoroutine(DestroTailEffect(t));
        GameObject bullet = ObjectPooler.Instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = hit.point;
            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);
            bullet.SetActive(true);
        }
    }

    public void GiveDamage(GameObject gameObject, float damageValue)
    {
        Life life = gameObject.transform.GetComponent<Life>();
        if (life != null)
        {
            Debug.Log("LIFE" + gameObject.transform.GetComponent<Life>().Get());
            life.AddDamage(damageValue);  //decreasing enemy value
            gameObject.GetComponentInChildren<BarDisplay>().Set(life.Get()); //assigning enemy health bar
        }
    }

    IEnumerator TrailEffect(TrailRenderer trail, RaycastHit hit)
    {
        float Ttime = 0f;
        Vector3 startPos = trail.transform.position;

        while (Ttime < 0.5f)
        {
            trail.transform.position = Vector3.Lerp(startPos, hit.point, Ttime);
            Ttime += Time.deltaTime / trail.time;

            yield return null;
        }
    }

    IEnumerator DestroTailEffect(TrailRenderer t)
    {
        yield return new WaitForSeconds(0.5f);
        if(t!=null)
            Destroy(t.gameObject);
    } 
}
