using UnityEngine;

namespace Fu_x.i
{
    public abstract class Enemy : MonoBehaviour
    {
        private GameObject _player;
        [SerializeField] protected int health = 1;
        [SerializeField] protected int attack = 10;
        [SerializeField] protected int speed = 1;

        protected void Start()
        {
            _player = GameObject.Find("Health");
            transform.Rotate(Vector3.forward, Random.Range(0, 360));
        }

        protected void Update()
        {
            MoveTowardPlayer();
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
                var hit = Physics2D.Raycast(mousePosition, Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                {
                    HandleClickOrTouch();
                }
            }

            // 检测触摸输入
            if (Input.touchCount <= 0) return;
            {
                var touch = Input.GetTouch(0);
                if (touch.phase != TouchPhase.Began) return;
                Vector2 touchPosition = Camera.main!.ScreenToWorldPoint(touch.position);
                var hit = Physics2D.Raycast(touchPosition, Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                {
                    HandleClickOrTouch();
                }
            }
        }

        protected void HandleClickOrTouch()
        {
            Manager.Instance.killAmount++;
            health--;
            if (health <= 0) Destroy(gameObject);
        }

        protected virtual void MoveTowardPlayer()
        {
            if (_player == null) return;

            var direction = _player.transform.position - transform.position;
            var distance = speed * Time.deltaTime;
            if (direction.magnitude <= distance) Destroy(gameObject);
            else transform.position += direction.normalized * distance;
        }


        protected void OnTriggerEnter2D(Collider2D other)
        {
            var h = other.GetComponent<Health>();
            if (h == null) return;
            var change = -attack;
            h.ChangeHealth(change);
            Destroy(gameObject);
        }
    }
}