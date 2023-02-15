using UnityEngine;
using CoreGameModule.Signals;
using PoolModule.Interfaces;
using PoolModule.Enums;
using PoolModule.Signals;
using System.Threading.Tasks;

public class PlayerPhysicController : MonoBehaviour, IGetPoolObject, IReleasePoolObject
{
    [SerializeField]
    private PlayerManager playerManager;

    public GameObject GetObject(PoolType poolType)
    {
        return PoolSignals.Instance.onGetObjectFromPool?.Invoke(poolType);
    }

    public void ReleaseObject(GameObject obj, PoolType poolType)
    {
        PoolSignals.Instance.onReleaseObjectFromPool?.Invoke(obj, poolType);
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CollectableManager>(out CollectableManager collectableManager))
        {

            if (collectableManager.GetCollectableType() == CollectableType.Sphere)
            {
                playerManager.transform.AddScaleValues(collectableManager.IncreaseScaleFactor());
            }
            else if (collectableManager.GetCollectableType() == CollectableType.Cube)
            {
                //Score arttýr
                SetScore(collectableManager);
            }
            else if (collectableManager.GetCollectableType() == CollectableType.Cylinder)
            {
                playerManager.transform.AddScaleValues(collectableManager.ReduceScaleFactor());
                //Score arttýr
                SetScore(collectableManager);
            }
            other.gameObject.SetActive(false);

            var obj = GetObject(PoolType.ExplodeParticle);
            obj.transform.position = other.transform.position;
            obj.transform.localScale = playerManager.transform.localScale;

            await Task.Delay(2000);

            ReleaseObject(obj, PoolType.ExplodeParticle);
        }
    }

    private void SetScore(CollectableManager collectableManager)
    {
        if (playerManager.GetPlayerType() == PlayerType.Player1)
        {
            CoreGameSignals.Instance.onUpdateGreenScore?.Invoke(collectableManager.ScoreValue());
        }
        else
        {
            CoreGameSignals.Instance.onUpdateBlueScore?.Invoke(collectableManager.ScoreValue());
        }
    }
}
