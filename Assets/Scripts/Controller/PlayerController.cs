using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {
    [SerializeField]
    float _speed = 10.0f;

    //bool _moveToDest = false;
    Vector3 _destPos;

    void Start() {
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

        Managers.Resource.Instantiate("UI/UI_Button");
    }

    public enum PlayerState {
        Die,
        Moving,
        Idel,
    }

    PlayerState _state = PlayerState.Idel;

    void UpdateDie() {
        // 아무것도 못함
    }

    void UpdateMoving() {
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.0001f) {
            _state = PlayerState.Idel;
        } else {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }

        // 애니메이션
        Animator anim = GetComponent<Animator>();
        // 현재 게임 상태에 대한 정보를 넘겨준다
        anim.SetFloat("speed", _speed);
    }

    void UpdateIdel() {
        // 애니메이션
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0);
    }

    void Update() {
        switch (_state) {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idel:
                UpdateIdel();
                break;
        }
    }

    void OnMouseClicked(Define.MouseEvent evt) {
        if (_state == PlayerState.Die) {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

        LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
        //int mask = (1 << 8) | (1 << 9);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, mask)) {
            _destPos = hit.point;
            _state = PlayerState.Moving;
            //Debug.Log($"Raycast Camera @ {hit.collider.gameObject.tag}");
        }
    }
}