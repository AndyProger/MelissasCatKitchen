using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
     public static SoundManager Instance { get; private set; }
     
     [SerializeField] private AudioClipSO _audioClipsSo;

     private void Awake()
     {
          Instance = this;
     }

     private void Start()
     {
          DeliveryManager.Instance.OnRecipeSuccess += (_,_) => 
               PlayRandomSound(_audioClipsSo.DeliverySuccess, DeliveryCounter.Instance.transform.position);
          
          DeliveryManager.Instance.OnRecipeFail += (_,_) => 
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

     private static void PlayRandomSound(AudioClip[] audioClips, Vector3 position, float volume = 1f)
     {
          AudioSource.PlayClipAtPoint(audioClips[Random.Range(0, audioClips.Length)], position, volume);
     }

     public void PlayFootstepsSound(Vector3 position, float volume)
     {
          PlayRandomSound(_audioClipsSo.FootStep, position);
     }
}
