using UnityEngine;

[RequireComponent(typeof(Alarm))]
[RequireComponent(typeof(BoxCollider2D))]
public class ControllerEntry : MonoBehaviour
{
    private Alarm _alarm;
    private bool _haveThief;
    private Coroutine _currentCoroutineSetVolume;


    // Start is called before the first frame update
    void Start()
    {
        _alarm = GetComponent<Alarm>();
    }

    private void ChangeVolume()
    {
        if (_currentCoroutineSetVolume != null)
            StopCoroutine(_currentCoroutineSetVolume);

        _currentCoroutineSetVolume = StartCoroutine(_alarm.SetVolume(_haveThief));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Controller>(out Controller controller))
        {
            _haveThief = true;
            ChangeVolume();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Controller>(out Controller controller))
        {
            _haveThief = false;
            ChangeVolume();
        }
    }
}
