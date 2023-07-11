using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector2 _StartPos;

    public float MaxPullDistance = 1f;
    public float FlyForce = 20;
    private bool isFly = false;
    public GameObject DotPrefab;
    public float DotTimeInterval = .05f;
    private GameObject[] _DotObjects = new GameObject[20];

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        _StartPos = transform.position;

        for (int i = 0; i < _DotObjects.Length; i++)
        {
            _DotObjects[i] = Instantiate(DotPrefab);
            _DotObjects[i].transform.localScale = _DotObjects[i].transform.localScale * (1 - .03f * i);
            _DotObjects[i].transform.parent = transform;
            _DotObjects[i].SetActive(false);
        }
    }

    private void OnMouseDrag()
    {
        if (isFly) return;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(_StartPos,pos) > MaxPullDistance)
        {
            pos = (pos - _StartPos).normalized * MaxPullDistance + _StartPos;
        }
        if(pos.x > _StartPos.x)
        {
            pos.x = _StartPos.x;
        }


        transform.position = pos;

        UpdateDotObjects();
    }

    private void OnMouseUp()
    {
        if (isFly) return;

        var force = (_StartPos - (Vector2)transform.position) * FlyForce;

        var rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        rb.AddForce(force, ForceMode2D.Impulse);

        Invoke(nameof(NextCharacter), 1);

        for (int i = 0; i < _DotObjects.Length; i++)
        {
            _DotObjects[i].SetActive(false);
        }


        isFly = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 5);
    }

    /// <summary>
    /// 次のキャラクターを生成
    /// </summary>
    private void NextCharacter()
    {
        LevelManager.i.NextCharacter();
    }

    private void UpdateDotObjects()
    {
        var force = (_StartPos - (Vector2)transform.position) * FlyForce;
        var currentTime = DotTimeInterval;
        for (int i = 0; i < _DotObjects.Length; i++)
        {
            _DotObjects[i].SetActive(true);
            var pos = new Vector2();
            pos.x = (transform.position.x + force.x * currentTime);
            pos.y = (transform.position.y + force.y * currentTime) - (Physics2D.gravity.magnitude * currentTime * currentTime) / 2;//y = Vy * t - 1/2gt^2(重量の計算)

            _DotObjects[i].transform.position = pos;
            currentTime += DotTimeInterval;
        }
    }




}
