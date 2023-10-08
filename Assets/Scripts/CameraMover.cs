using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    [SerializeField] private float _adjustingCameraPositionRelativeToPlayer;

    private void Update()
    {
        _camera.position = new Vector3(transform.position.x, transform.position.y + _adjustingCameraPositionRelativeToPlayer, _camera.position.z);
    }
}
