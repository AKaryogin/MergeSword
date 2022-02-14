using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private ExperienceStar _experienceStar;
    [SerializeField] private Sound _sound;
    [SerializeField] private Coin _coin;

    private GameObject _gameObject;
    private Sword _sword;
    private Vector3 _lastPosition;

    public event UnityAction<Sword, Sword> Merged;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _gameObject = SelectObject(Input.mousePosition);

            if(_gameObject != null)
            {
                if(_gameObject.TryGetComponent(out Sword sword))
                {
                    if(sword.IsMaxRank)
                    {
                        Destroy(sword.gameObject, .5f);
                        _experienceStar.CreateStar(sword.transform.position);
                        _coin.CreateCoin(sword.transform.position, sword.Cost);
                        _board.IsFreeCells[(int)sword.transform.position.x, (int)sword.transform.position.y] = true;
                        _board.AddFreeCell();
                    }
                    else
                    {
                        _sword = sword;
                        _lastPosition = sword.transform.position;
                        _sword.Collider2D.enabled = false;
                    }
                }

                if(_gameObject.TryGetComponent(out Chest chest))
                {
                    if(_board.CountFreeCells > 0)
                        chest.CreateSword();
                    else
                        _sound.PlayNoFreeCells();
                }
            }
        }

        if(Input.GetMouseButton(0))
        {
            if(_sword != null)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _sword.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(_sword != null)
            {
                _gameObject = SelectObject(Input.mousePosition);

                if(_gameObject != null)
                {
                    if(_gameObject.TryGetComponent(out Sword sword))
                    {
                        if(sword.Rank == _sword.Rank)
                        {
                            _board.IsFreeCells[(int)_lastPosition.x, (int)_lastPosition.y] = true;
                            _board.AddFreeCell();
                            Merged?.Invoke(sword, _sword); 
                        }
                        else
                        {
                            _board.SetObjectTo(_sword.gameObject, _lastPosition);
                            _sword.Collider2D.enabled = true;
                        }
                    }

                    if(_gameObject.TryGetComponent(out Cell cell))
                    {
                        _sword.transform.position = cell.transform.position;
                        _sword.Collider2D.enabled = true;
                        _board.IsFreeCells[(int)_lastPosition.x, (int)_lastPosition.y] = true;
                        _board.IsFreeCells[(int)_sword.transform.position.x, (int)_sword.transform.position.y] = false;
                    }

                    if(_gameObject.TryGetComponent(out Chest chest))
                    {
                        _board.SetObjectTo(_sword.gameObject, _lastPosition);
                        _sword.Collider2D.enabled = true;
                    }

                }
                                
                _sword = null;
            }
        }
    }

    private GameObject SelectObject(Vector3 screenPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(ray.origin, Vector3.forward);

        return (raycastHit2D.collider != null) ? raycastHit2D.collider.gameObject : null;
    }
}
