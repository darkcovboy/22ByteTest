using PlayerScripts.Movement.SwipeDetector;
using UnityEngine;
using Zenject;

namespace PlayerScripts.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveHandler : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private ISwipeDetector _swipeDetector;

        [Inject]
        public void Constructor(ISwipeDetector swipeDetector)
        {
            _swipeDetector = swipeDetector;
        }

        private void OnEnable()
        {
            _swipeDetector.OnSwipe += OnSwipeRotate;
        }

        private void OnDisable()
        {
            _swipeDetector.OnSwipe -= OnSwipeRotate;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        private void OnSwipeRotate(SwipeData swipeData)
        {
            switch (swipeData.Direction)
            {
                case SwipeDirection.Down:
                {
                    transform.Rotate(new Vector3(transform.rotation.x, -90f, transform.rotation.z));
                    break;
                }
                case SwipeDirection.Up:
                {
                    transform.Rotate(new Vector3(transform.rotation.x, 90f, transform.rotation.z));
                    break;
                }
                case SwipeDirection.Left:
                {
                    transform.Rotate(new Vector3(transform.rotation.x, 0f, transform.rotation.z));
                    break;
                }
                case SwipeDirection.Right:
                {
                    transform.Rotate(new Vector3(transform.rotation.x, 180f, transform.rotation.z));
                    break;
                }
            }
        }
    }
}