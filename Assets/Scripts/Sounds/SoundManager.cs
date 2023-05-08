using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
     public const string PlayerSoundEffectSavedValue = "PlayerSoundEffectSavedValue";
     
     public static SoundManager Instance { get; private set; }
     
     [SerializeField] private AudioClipSO _audioClipsSo;

     private float _volume = 1f;

     private void Awake()
     {
          Instance = this;
          _volume = PlayerPrefs.GetFloat(PlayerSoundEffectSavedValue, 1f);
     }

     private void Start()
     {
          ViewModel.ViewModel.DeliveryManagerContext.OnRecipeSuccess += (_,_) => 
               PlayRandomSound(_audioClipsSo.DeliverySuccess, DeliveryCounter.Instance.transform.position);
          
          ViewModel.ViewModel.DeliveryManagerContext.OnRecipeFail += (_,_) => 
               PlayRandomSound(_audioClipsSo.DeliveryFail, DeliveryCounter.Instance.transform.position);
          
          CuttingCounter.OnAnyCut += (sender,_) => 
               PlayRandomSound(_audioClipsSo.Chop, ((CuttingCounter)sender).transform.position);
          
          Player.Instance.OnPickedSmth += (sender,_) => 
               PlayRandomSound(_audioClipsSo.ObjectPickUp, Player.Instance.transform.position);
          
          Counter.OnAnyObjectPlaced += (sender,_) => 
               PlayRandomSound(_audioClipsSo.ObjectDrop, ((Counter)sender).transform.position);
          
          TrashCounter.OnAnyObjectTrashed += (sender,_) => 
               PlayRandomSound(_audioClipsSo.Trash, ((TrashCounter)sender).transform.position);
     }

     private void PlayRandomSound(AudioClip[] audioClips, Vector3 position, float volumeMultiplier = 1f)
     {
          AudioSource.PlayClipAtPoint(audioClips[Random.Range(0, audioClips.Length)], position, _volume * volumeMultiplier);
     }

     public void PlayFootstepsSound(Vector3 position, float volumeMultiplier)
     {
          PlayRandomSound(_audioClipsSo.FootStep, position, _volume * volumeMultiplier);
     }
     
     public void PlayCountdownSound()
     {
          PlayRandomSound(_audioClipsSo.Warning, Vector3.zero);
     }
     
     public void PlayWarningSound(Vector3 position)
     {
          PlayRandomSound(_audioClipsSo.Warning, position);
     }

     public void ChangeVolume(float value)
     {
          _volume = value;
          PlayerPrefs.SetFloat(PlayerSoundEffectSavedValue, _volume);
          PlayerPrefs.Save();
     }
}
