using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Sword : MonoBehaviour
{
    [SerializeField] private int _rank;
    [SerializeField] private int _cost;
    [SerializeField] private bool _isMaxRank;

    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider2D;

    public int Rank => _rank;
    public int Cost => _cost;
    public bool IsMaxRank => _isMaxRank;
    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public CircleCollider2D Collider2D => _circleCollider2D;

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }
}
