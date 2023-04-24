using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private const float FootstepTimerMax = 0.1f;
    private const float StepsVolume = 2f;
    
    private Player _player;
    private float _footstepTimer;

    public void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _footstepTimer -= Time.deltaTime;
        if (_footstepTimer < 0f)
        {
            _footstepTimer = FootstepTimerMax;
            
            if (_player.IsWalking)
                SoundManager.Instance.PlayFootstepsSound(_player.transform.position, StepsVolume);
        }
    }
}
