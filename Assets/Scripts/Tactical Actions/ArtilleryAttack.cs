using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryAttack : MonoBehaviour
{
    [SerializeField] private int _numberOfShots;
    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _shotRange;
    [SerializeField] private float _shotDamage;
    [SerializeField] private GameObject _artilleryFX;   

    private WaitForSeconds _shotWait;

    private void Awake()
    {
        _shotWait = new WaitForSeconds(_timeBetweenShots);
    }

    private void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        
        for (int i = 0; i < _numberOfShots; i++)
        {
            Vector2 circlePoint = Random.insideUnitCircle * _shotRange;

            Vector3 shootPoint = new Vector3(circlePoint.x, 25, circlePoint.y) + transform.position;
            Ray ray = new Ray(shootPoint, Vector3.down);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Instantiate(_artilleryFX, hit.point, Quaternion.LookRotation(hit.normal));
                RaycastHit[] hits = Physics.SphereCastAll(ray, _explosionRadius);
                foreach (var possibleHit in hits)
                {
                    var hitbox = possibleHit.collider.GetComponent<HitboxPiece>();
                    if(hitbox)
                    {
                        hitbox.Hit(_shotDamage);
                    }
                }
            }

            yield return _shotWait;
        }
    }
}
