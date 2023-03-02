using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : AbstractProjectile
{
    private AbstractUnit parrent;
    private float arcHeight = 2;
    private Vector3 _startPosition;
    private float _stepScale;
    private float _progress;
       
    private protected override void onStart()
    {
        base.onStart();
        parrent = transform.parent.GetComponent<AbstractUnit>();
        target = Physics.OverlapSphere(transform.position, 7f, _game.layerMaskEnemy)[0].transform;

        _startPosition = transform.position;
        float distance = Vector3.Distance(_startPosition, target.position);
        _stepScale = speed / distance;
    }

    private protected override void onUpdate()
    {
        base.onUpdate();
        if (target == null)
            Destroy(gameObject);

        _progress = Mathf.Min(_progress + Time.deltaTime, 1.0f);

        float parabola = 1.0f - 4.0f * (_progress - 0.5f) * (_progress - 0.5f);

        Vector3 nextPos = Vector3.Lerp(_startPosition, target.position, _progress);

        nextPos.y += parabola * arcHeight;

        transform.LookAt(nextPos, transform.forward);
        transform.position = nextPos;
        CheckHit();
    }

    private void CheckHit()
    {
        _contactCollider = Physics.OverlapSphere(transform.position, 0.1f, _game.layerMaskEnemy);

        if (_contactCollider.Length > 0)
        {            
            PlaySound();
            _contactCollider[0].GetComponent<AbstractUnit>().Hit(parrent.GetDamage());
            EventBus.GetHit(target.gameObject, parrent.GetDamage());
            Destroy(gameObject);
        }
    }
    
}
